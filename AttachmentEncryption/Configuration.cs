using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttachmentEncryption.Properties;
using Newtonsoft.Json;

namespace AttachmentEncryption
{
    /// <summary>
    /// 設定
    /// </summary>
    class Configuration
    {
        private static readonly string ConfigFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Soultech",
            "AttachmentEncryption",
            "config.json");

        public bool AutoSending { get; set; }

        public string DefaultCompany { get; set; }
        public string DefaultUserName { get; set; }
        public string FileNameDateTimeFormat { get; set; }
        public string FileNamePrefix { get; set; }
        public string PasswordMailTemplate { get; set; }

        public static void Load()
        {
            if (!File.Exists(ConfigFilePath))
            {
                return;
            }
            var json = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<Configuration>(json);
            Settings.Default.AutoSending = config.AutoSending;
            Settings.Default.DefaultCompany = config.DefaultCompany;
            Settings.Default.DefaultUserName = config.DefaultUserName;
            Settings.Default.FileNameDateTimeFormat = config.FileNameDateTimeFormat;
            Settings.Default.FileNamePrefix = config.FileNamePrefix;
            Settings.Default.PasswordMailTemplate = config.PasswordMailTemplate;
        }

        public static void Save()
        {
            var config = new Configuration
            {
                AutoSending = Settings.Default.AutoSending,
                DefaultCompany = Settings.Default.DefaultCompany,
                DefaultUserName = Settings.Default.DefaultUserName,
                FileNameDateTimeFormat = Settings.Default.FileNameDateTimeFormat,
                FileNamePrefix = Settings.Default.FileNamePrefix,
                PasswordMailTemplate = Settings.Default.PasswordMailTemplate
            };

            var configJson = JsonConvert.SerializeObject(config);

            var dirPath = Path.GetDirectoryName(ConfigFilePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            
            File.WriteAllText(ConfigFilePath, configJson);
        }
    }
}
