using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace AttachmentEncryption
{
    /// <summary>
    /// VSTOをラップするメールアイテム
    /// </summary>
    class MyMailItem : IMyMailItem
    {

        #region IMyMailItem

        /// <summary>
        /// 宛先数を取得する
        /// </summary>
        public int RecipientsCount => RawItem.Recipients.Count;


        /// <summary>
        /// 件名を取得する
        /// </summary>
        public string Subject => RawItem.Subject;

        /// <summary>
        /// メールアイテムの添付ファイルがZIPファイル一つだけか判定する.
        /// </summary>
        /// <returns>メールアイテムの添付ファイルがZIPファイル一つだけの場合はtrue, それ以外の場合はfalse</returns>
        public bool HasOneZipFileOnly()
        {
            if (RawItem.Attachments == null)
            {
                return false;
            }
            if (RawItem.Attachments.Count != 1)
            {
                return false;
            }
            return Path.GetExtension(RawItem.Attachments[1].FileName).ToLower() == ".zip";
        }

        /// <summary>
        /// 添付ファイルの一覧を取得する
        /// </summary>
        /// <returns>添付ファイルの一覧</returns>
        public IEnumerable<IMyAttachment> GetAttachments()
        {
            foreach (Outlook.Attachment attachment in RawItem.Attachments)
            {
                yield return new MyAttachment(attachment);
            }
        }

        /// <summary>
        /// 添付ファイルを全て削除する.
        /// </summary>
        public void RemoveAttachments()
        {
            // ※ バグっぽい書き方だけど、これで良いらしい。

            while(RawItem.Attachments.Count > 0)
            {
                RawItem.Attachments.Remove(1);
            }
        }

        /// <summary>
        /// 添付ファイルを追加する.
        /// </summary>
        /// <param name="filePath">追加する添付ファイルのパス</param>
        public void AddAttachment(string filePath)
        {
            RawItem.Attachments.Add(filePath);
        }

        /// <summary>
        /// 同じ送信先、送信元のメールアイテムを作成する.
        /// </summary>
        /// <returns></returns>
        public IMyMailItem NewItemWithSameRecipientsAndSender()
        {
            var result = (Outlook.MailItem)Globals.ThisAddIn.Application.CreateItem(Outlook.OlItemType.olMailItem);
            result.SendUsingAccount = RawItem.SendUsingAccount;
            foreach (Outlook.Recipient recipient in RawItem.Recipients)
            {
                var newRecipient= result.Recipients.Add(recipient.Name);
                newRecipient.AddressEntry = recipient.AddressEntry;
                newRecipient.Type = recipient.Type;
            }
            return new MyMailItem(result);
        }

        /// <summary>
        /// メールアイテムを保存する.
        /// </summary>
        public void Save()
        {
            RawItem.Save();
        }

        /// <summary>
        /// メールアイテムを送信する
        /// </summary>
        public void Send()
        {
            RawItem.Send();
        }

        /// <summary>
        /// 送信先(TO)の一覧を取得する.
        /// </summary>
        /// <returns>送信先(TO)の一覧</returns>
        public IEnumerable<string> Tos()
        {
            foreach (Outlook.Recipient recipient in RawItem.Recipients)
            {
                if (recipient.Type == (int)Outlook.OlMailRecipientType.olTo)
                {
                    yield return recipient.Name;
                }
            }
        }

        /// <summary>
        /// 件名と本文をセットする
        /// </summary>
        /// <param name="subject">件名</param>
        /// <param name="body">本文</param>
        public void SetContents(string subject, string body)
        {
            RawItem.Subject = subject;
            RawItem.Body = body;
        }

        /// <summary>
        /// メールアイテムを表示する
        /// </summary>
        public void Display()
        {
            RawItem.Display();
        }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="mailItem">MailItemオブジェクト</param>
        private MyMailItem(Outlook.MailItem mailItem)
        {
            this.RawItem = mailItem;
        }


        #endregion

        #region プライベートメソッド

        /// <summary>
        /// VSTOのMailItemオブジェクト.
        /// </summary>
        private Outlook.MailItem RawItem { get; set; }

        #endregion

        /// <summary>
        /// 現在編集中のメールアイテムを取得する.
        /// </summary>
        /// <remarks>
        /// 本メソッドを呼ぶことができるのは、メール編集画面がアクティブな場合のみ.
        /// ※ アドインのリボンイベントハンドラ経由で呼ばれることを想定している.
        /// </remarks>
        /// <returns>メールアイテム</returns>
        public static MyMailItem CreateFromCurrentItem()
        {
            // メールアイテムの操作前に現在のメールアイテムを保存する.
            // このタイミングで Recipients (送信先) の Resolve も行われる。
            var item = (Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem;
            item.Save();

            return new MyMailItem((Outlook.MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem);
        }

    }
}
