using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Scriban;

namespace AttachmentEncryption
{
    /// <summary>
    /// メールアイテムの操作クラス
    /// </summary>
    class MailItemOperation
    {
        #region メソッド

        /// <summary>
        /// 対象のメールアイテムが添付ファイル暗号化を行える状態か検証する
        /// </summary>
        /// <param name="item">メールアイテム</param>
        public void ValidateMailItemForEncryption(IMyMailItem item)
        {
            if (item.RecipientsCount <= 0)
            {
                throw new MailItemValidationException("送信先が設定されていません。TO, CC, BCCのいずれかに一つ以上のメールアドレスを入力してください");
            }
            if (String.IsNullOrEmpty(item.Subject))
            {
                throw new MailItemValidationException("件名が設定されていません。件名を入力して下さい");
            }

            var attachments = item.GetAttachments().ToList();
            if (attachments.Count <= 0)
            {
                throw new MailItemValidationException("添付ファイルが一つも存在しません。一つ以上の添付ファイルを設定して下さい。");
            }

            var fileNameSet = new HashSet<string>();
            foreach (var attachment in attachments)
            {
                if (fileNameSet.Contains(attachment.FileName))
                {
                    throw new MailItemValidationException("添付ファイルに同名のファイルが複数存在します。添付ファイル名は全て別名にして下さい:" + attachment.FileName);
                }
                fileNameSet.Add(attachment.FileName);
            }
        }

        /// <summary>
        /// 添付ファイルをパスワード付きZIPファイルに変換する.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ZIPファイルのパスワード</returns>
        public string ConvertAttachmentsToPasswordProtectedZipFile(IMyMailItem item)
        {
            // 最終的な添付ファイルとなるパスワード付きZIPファイル名を作成する
            var zipFileName = CreateZipFileName(item);

            // ZIPファイル作成用のフォルダを準備する
            using (var zipFolder = new ZipContentsFolder(zipFileName))
            {
                // パスワード付きZIP用のエントリをフォルダにまとめて作成する.
                CreateZipEntriesInFolder(item, zipFolder);

                // パスワードを生成する.
                var password = GeneratePassword();

                // 添付ファイル用のパスワード付きZIPファイルを生成する.
                ArchiveFolderWithPassword(zipFolder, password);

                // 現在の添付ファイルを作成したパスワード付きZIPファイルに置き換える
                ReplaceAttachmentsToZipFile(item, zipFolder);

                return password;
            }
        }

        /// <summary>
        /// パスワード通知メールを作成する.
        /// </summary>
        /// <param name="sourceMail">元になるメールアイテム</param>
        /// <param name="password">パスワード</param>
        /// <returns></returns>
        public IMyMailItem CreatePasswordNotificationMail(IMyMailItem sourceMail, string password)
        {
            // 同じ送信先、送信元のメールアイテムを作成する.
            var result = sourceMail.NewItemWithSameRecipientsAndSender();

            // 本文を作成する
            var bodyTemplate = Template.Parse(Properties.Settings.Default.PasswordMailTemplate);
            var subject = Properties.Settings.Default.PasswordMailTitlePrefix + sourceMail.Subject;
            var body = bodyTemplate.Render(new
            {
                Tos = result.Tos(),
                Company = Properties.Settings.Default.DefaultCompany,
                User = Properties.Settings.Default.DefaultUserName,
                Subject = Properties.Settings.Default.PasswordMailTitlePrefix + sourceMail.Subject,
                Password = password,
            });

            result.SetContents(subject, body);

            return result;
        }

        #endregion

        #region プライベートメソッド

        /// <summary>
        /// ZIPファイル名を作成する
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string CreateZipFileName(IMyMailItem item)
        {
            if (item.HasOneZipFileOnly())
            {
                // 添付ファイルがZIPファイル一つのみの場合は、ZIPファイル名を流用する
                return item.GetAttachments().First().FileName;
            }
            return CreateDefaultZipFileName();
        }

        /// <summary>
        /// デフォルトのZIPファイル名を作成する
        /// </summary>
        /// <returns></returns>
        private string CreateDefaultZipFileName()
        {
            var settings = Properties.Settings.Default;
            return settings.FileNamePrefix + DateTime.Now.ToString(settings.FileNameDateTimeFormat) + ".zip";
        }

        /// <summary>
        /// パスワード付きZIPのエントリを作成する.
        /// </summary>
        /// <param name="mailItem">メールアイテム</param>
        /// <param name="zipFolder">パスワード付きZIPの元にするフォルダ</param>
        private void CreateZipEntriesInFolder(IMyMailItem mailItem, ZipContentsFolder zipFolder)
        {
            if (mailItem.HasOneZipFileOnly())
            {
                ExtractZipFile(zipFolder, mailItem.GetAttachments().First());
            }
            else
            {
                SaveAttachmentsToZipFolder(zipFolder.ContentsRootFolderPath, mailItem.GetAttachments());
            }
        }

        /// <summary>
        /// ZIPファイルを展開する.
        /// </summary>
        /// <param name="destinationFolder">展開先のフォルダ</param>
        /// <param name="attachment">添付ファイル</param>
        private void ExtractZipFile(ZipContentsFolder destinationFolder, IMyAttachment attachment)
        {
            try
            {
                // 添付ファイルを一時的に保存する.
                attachment.SaveFile(destinationFolder.ZipFilePath);

                // ZIPファイルを展開する (展開先は、パスワード付きの元にするフォルダ.)
                var utility = new ZipFileUtiliy();
                utility.ExtractZipFile(destinationFolder.ContentsRootFolderPath, destinationFolder.ZipFilePath);
            }
            finally
            {
                // 一時的に保存した元の添付ファイルを削除する
                File.Delete(destinationFolder.ZipFilePath);
            }
        }

        /// <summary>
        /// 添付ファイルを全て保存する
        /// </summary>
        /// <param name="contentsRootFolderPath">保存先のフォルダ</param>
        /// <param name="attachments">添付ファイルの一覧</param>
        private void SaveAttachmentsToZipFolder(string contentsRootFolderPath, IEnumerable<IMyAttachment> attachments)
        {
            foreach (var attachment in attachments)
            {
                var filePath = Path.Combine(contentsRootFolderPath, attachment.FileName);
                attachment.SaveFile(filePath);
            }
        }

        /// <summary>
        /// パスワードを生成する
        /// </summary>
        /// <returns>パスワード</returns>
        private string GeneratePassword()
        {
            var password = System.Web.Security.Membership.GeneratePassword(10, 0);
            var rand = new System.Random();
            return System.Text.RegularExpressions.Regex.Replace(password, @"[^a-zA-Z0-9]", m => rand.Next(0, 9).ToString());
        }

        /// <summary>
        /// フォルダをパスワード付きZIPにする.
        /// </summary>
        /// <param name="zipFolder">ZIPフォルダ</param>
        /// <param name="password">パスワード</param>
        private void ArchiveFolderWithPassword(ZipContentsFolder zipFolder, string password)
        {
            var utility = new ZipFileUtiliy();
            utility.ArchiveFolder(zipFolder.ZipFilePath, password, zipFolder.ContentsRootFolderPath);
        }

        /// <summary>
        /// 現在の添付ファイルをパスワード付きZIPファイルで置き換える
        /// </summary>
        /// <param name="item"></param>
        /// <param name="zipFolder"></param>
        private void ReplaceAttachmentsToZipFile(IMyMailItem item, ZipContentsFolder zipFolder)
        {
            item.RemoveAttachments();
            item.AddAttachment(zipFolder.ZipFilePath);
        }

        #endregion
    }
}
