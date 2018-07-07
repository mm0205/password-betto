using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using Scriban;

namespace AttachmentEncryption
{
    /// <summary>
    /// 添付ファイル暗号化ツール リボン
    /// </summary>
    public partial class AttachmentEncryptionRibbon
    {

        #region Private メソッド

        private bool IsEmptyAttachments(Attachments attachments)
        {
            if (attachments == null)
            {
                return true;
            }
            return attachments.Count <= 0;
        }

        /// <summary>
        /// 現在のメールアイテムを取得する.
        /// </summary>
        /// <returns></returns>
        private MailItem GetCurrentMailItem()
        {
            var item = (MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem();

            // 変更前に現在のメールアイテムを保存する
            // このタイミングで Recipients (送信先) の Resolve も行われる。
            item.Save();

            return  (MailItem)Globals.ThisAddIn.Application.ActiveInspector().CurrentItem();
        }

        /// <summary>
        /// 添付ファイルを暗号化して送信する.
        /// </summary>
        /// <param name="item">メールアイテム</param>
        private void EncryptAndSend(IMyMailItem item)
        {
            var operation = new MailItemOperation();

            // メールアイテムの検証
            operation.ValidateMailItemForEncryption(item);

            // 添付ファイルをパスワード付きZIPファイルに変換する.
            var password = operation.ConvertAttachmentsToPasswordProtectedZipFile(item);

            // パスワード通知メールを作成する.
            var passwordNotificationMail = operation.CreatePasswordNotificationMail(item, password);

            // 作成したメールアイテムを保存する.
            item.Save();
            passwordNotificationMail.Save();
            passwordNotificationMail.Display();

            // 送信まで自動で行う場合は、送信
            if (Properties.Settings.Default.AutoSending)
            {
                item.Send();
                passwordNotificationMail.Send();
            }

        }

        #endregion

        #region イベントハンドラ

        private void AttachmentEncryptionRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        
        /// <summary>
        /// 暗号化して送信ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonEncryptAndSend_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                EncryptAndSend(MyMailItem.CreateFromCurrentItem());
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("エラーが発生しました\r\n" + ex.ToString(), "添付ファイル暗号化ツール", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 設定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfig_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var f = new ConfigForm();
                f.ShowDialog();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("設定処理に失敗しました\r\n" + ex.ToString(), "添付ファイル暗号化ツール", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
