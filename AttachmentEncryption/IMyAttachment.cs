namespace AttachmentEncryption
{
    /// <summary>
    /// 添付ファイル操作用のインタフェース
    /// </summary>
    interface IMyAttachment
    {
        /// <summary>
        /// 添付ファイル名を取得する.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// 添付ファイルを指定されたパスに保存する
        /// </summary>
        /// <param name="filePath">保存するファイルのパス</param>
        void SaveFile(string filePath);
    }
}
