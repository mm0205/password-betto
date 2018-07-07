using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scriban;

namespace AttachmentEncryption
{
    /// <summary>
    /// 設定画面
    /// </summary>
    public partial class ConfigForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定内容のチェック
        /// </summary>
        private void CheckConfiguration()
        {
            var template = Template.Parse(this.textBoxPasswordMailTemplate.Text);
            var ret = template.Render(new
            {
                Tos = new List<string>() { "TO1", "TO2" },
                Company = textBoxDefaultCompany.Text,
                User = textBoxDefaultUserName.Text,
                Subject = "サブジェクト",
                Password = "パスワード",
            });
            System.Diagnostics.Debug.WriteLine(ret);
        }

        #region イベントハンドラ

        /// <summary>
        /// キャンセルボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// OKボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                CheckConfiguration();
            }
            catch
            {
                MessageBox.Show("設定、テンプレートに謝りがあります");
                return;
            }
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
