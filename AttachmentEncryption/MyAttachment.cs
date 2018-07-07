using Microsoft.Office.Interop.Outlook;

namespace AttachmentEncryption
{
    /// <summary>
    /// 添付ファイル
    /// </summary>
    internal class MyAttachment : IMyAttachment
    {
        #region プライベートプロパティ

        /// <summary>
        /// OutlookのAttachmentオブジェクト
        /// </summary>
        private Attachment RawAttachment { get; set; }

        #endregion

        #region IMyAttachment

        /// <summary>
        /// 添付ファイル名を取得する.
        /// </summary>
        public string FileName => RawAttachment.FileName;

        /// <summary>
        /// 添付ファイルを指定されたパスに保存する
        /// </summary>
        /// <param name="filePath">保存するファイルのパス</param>
        public void SaveFile(string filePath)
        {
            RawAttachment.SaveAsFile(filePath);
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="attachment"></param>
        public MyAttachment(Attachment attachment)
        {
            this.RawAttachment = attachment;
        }
    }
}