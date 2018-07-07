using System;
using System.IO;
using ZipCore = ICSharpCode.SharpZipLib.Core;
using Zip = ICSharpCode.SharpZipLib.Zip;

namespace AttachmentEncryption
{
    /// <summary>
    /// Zipファイル操作のユーティリティ
    /// </summary>
    internal class ZipFileUtiliy
    {
        public ZipFileUtiliy()
        {
        }

        /// <summary>
        /// ZIPファイルを指定されたフォルダに展開する
        /// </summary>
        /// <param name="contentsRootFolderPath">展開先のフォルダのパス</param>
        /// <param name="zipFilePath">展開対象のZIPファイルのパス</param>
        internal void ExtractZipFile(string contentsRootFolderPath, string zipFilePath)
        {
            var buffer = new byte[4096];

            using (var zipFile = new Zip.ZipFile(zipFilePath))
            {
                foreach (Zip.ZipEntry entry in zipFile)
                {
                    var contentPath = Path.Combine(contentsRootFolderPath, entry.Name);
                    var contentFolderPath = Path.GetDirectoryName(contentPath);
                    if (!Directory.Exists(contentFolderPath))
                    {
                        Directory.CreateDirectory(contentFolderPath);
                    }
                    if (!entry.IsFile)
                    {
                        continue;
                    }

                    var zipStream = zipFile.GetInputStream(entry);
                    using (var outputStream = File.Create(contentPath))
                    {
                        ZipCore.StreamUtils.Copy(zipStream, outputStream, buffer);
                    }
                }
            }
        }

        /// <summary>
        /// 指定されたフォルダをZIPファイルにする
        /// </summary>
        /// <param name="zipFilePath">出力するZIPファイルのパス</param>
        /// <param name="password">パスワード</param>
        /// <param name="contentsRootFolderPath">ZIPファイルの要素のあるフォルダのパス</param>
        internal void ArchiveFolder(string zipFilePath, string password, string contentsRootFolderPath)
        {
            var buffer = new byte[4096];

            // エントリ名の作成用にコンテンツルートフォルダパスを取得
            var rootPath = contentsRootFolderPath.ToLower();
            if (!rootPath.EndsWith("\\"))
            {
                rootPath += "\\";
            }

            using (var fs = new System.IO.FileStream(zipFilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None))
            using (var zip = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(fs))
            {
                zip.Password = password;
                var files = Directory.GetFiles(contentsRootFolderPath, "*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    // エントリ名の作成, 絶対パスからルートフォルダまでのパスを取り除いたものにする
                    var entryName = file.Substring(rootPath.Length);
                    var entry = new Zip.ZipEntry(entryName);

                    var fi = new FileInfo(file);
                    entry.DateTime = fi.LastWriteTime;
                    entry.Size = fi.Length;

                    zip.PutNextEntry(entry);

                    using (var sr = File.OpenRead(file))
                    {
                        ZipCore.StreamUtils.Copy(sr, zip, buffer);
                    }
                    zip.CloseEntry();
                }
            }
        }
    }
}