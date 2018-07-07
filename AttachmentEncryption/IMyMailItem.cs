using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentEncryption
{
    /// <summary>
    /// メールアイテム用のインタフェース
    /// </summary>
    interface IMyMailItem
    {
        /// <summary>
        /// 宛先数を取得する
        /// </summary>
        int RecipientsCount { get; }

        /// <summary>
        /// 件名を取得する
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// メールアイテムの添付ファイルがZIPファイル一つだけか判定する.
        /// </summary>
        /// <returns>メールアイテムの添付ファイルがZIPファイル一つだけの場合はtrue, それ以外の場合はfalse</returns>
        bool HasOneZipFileOnly();

        /// <summary>
        /// 添付ファイルの一覧を取得する
        /// </summary>
        /// <returns>添付ファイルの一覧</returns>
        IEnumerable<IMyAttachment> GetAttachments();

        /// <summary>
        /// 添付ファイルを全て削除する.
        /// </summary>
        void RemoveAttachments();

        /// <summary>
        /// 添付ファイルを追加する.
        /// </summary>
        /// <param name="filePath">追加する添付ファイルのパス</param>
        void AddAttachment(string filePath);

        /// <summary>
        /// 同じ送信先、送信元のメールアイテムを作成する.
        /// </summary>
        /// <returns></returns>
        IMyMailItem NewItemWithSameRecipientsAndSender();

        /// <summary>
        /// メールアイテムを保存する.
        /// </summary>
        void Save();

        /// <summary>
        /// メールアイテムを送信する
        /// </summary>
        void Send();

        /// <summary>
        /// 送信先(TO)の一覧を取得する.
        /// </summary>
        /// <returns>送信先(TO)の一覧</returns>
        IEnumerable<string> Tos();

        /// <summary>
        /// 件名と本文をセットする
        /// </summary>
        /// <param name="subject">件名</param>
        /// <param name="body">本文</param>
        void SetContents(string subject, string body);

        /// <summary>
        /// メールアイテムを表示する
        /// </summary>
        void Display();
    }
}
