using System;
using System.IO;

namespace AttachmentEncryption
{
    /// <summary>
    /// ZIPファイルのコンテンツ格納用フォルダ.
    /// </summary>
    class ZipContentsFolder : IDisposable
    {

        /// <summary>
        /// ZIPコンテンツのルートフォルダパス.
        /// </summary>
        public string ContentsRootFolderPath { get; private set; }

        /// <summary>
        /// ZIPコンテンツフォルダを含む一時フォルダのパス.
        /// </summary>
        public string TemporaryFolderPath { get; private set; }

        /// <summary>
        /// ZIPファイルパス.
        /// </summary>
        public string ZipFilePath { get; private set; }

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="zipFileName">zipファイル名</param>
        public ZipContentsFolder(string zipFileName)
        {
            var zipRootName = Path.GetFileNameWithoutExtension(zipFileName);
            ContentsRootFolderPath = CreateZipContentsFolderPath(zipRootName);
            TemporaryFolderPath = Path.GetDirectoryName(ContentsRootFolderPath);
            ZipFilePath = ContentsRootFolderPath + ".zip";

            Directory.CreateDirectory(ContentsRootFolderPath);
        }

        /// <summary>
        /// ZIPコンテンツ用の一時フォルダを作成する.
        /// </summary>
        /// <param name="zipRootName"></param>
        /// <returns></returns>
        private string CreateZipContentsFolderPath(string zipRootName)
        {
            var guid = Guid.NewGuid().ToString("D");

            var folderPath = Path.Combine(Path.GetTempPath(),
                Properties.Settings.Default.TempFolder,
                guid,
                zipRootName);

            return folderPath;
        }

        /// <summary>
        /// フォルダを削除する.
        /// </summary>
        private void RemoveFolder()
        {
            if (string.IsNullOrEmpty(TemporaryFolderPath))
            {
                return;
            }
            try
            {
                if (Directory.Exists(TemporaryFolderPath))
                {
                    Directory.Delete(TemporaryFolderPath, true);
                }
            }
            catch
            {

            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                RemoveFolder();

                disposedValue = true;
            }
        }

        ~ZipContentsFolder()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(false);
        }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
