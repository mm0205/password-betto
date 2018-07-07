namespace AttachmentEncryption
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelFileNamePrefix = new System.Windows.Forms.Label();
            this.toolTipFileNameFormat = new System.Windows.Forms.ToolTip(this.components);
            this.labelPasswordMailPrefix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPasswordMailTemplate = new System.Windows.Forms.Label();
            this.labelDefaultCompany = new System.Windows.Forms.Label();
            this.labelDefaultUserName = new System.Windows.Forms.Label();
            this.textBoxDefaultUserName = new System.Windows.Forms.TextBox();
            this.textBoxDefaultCompany = new System.Windows.Forms.TextBox();
            this.textBoxFileNameDateTime = new System.Windows.Forms.TextBox();
            this.textBoxPasswordMailTitlePrefix = new System.Windows.Forms.TextBox();
            this.textBoxFileNamePrefix = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSending = new System.Windows.Forms.CheckBox();
            this.textBoxPasswordMailTemplate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelFileNamePrefix
            // 
            this.labelFileNamePrefix.AutoSize = true;
            this.labelFileNamePrefix.Location = new System.Drawing.Point(51, 43);
            this.labelFileNamePrefix.Name = "labelFileNamePrefix";
            this.labelFileNamePrefix.Size = new System.Drawing.Size(132, 12);
            this.labelFileNamePrefix.TabIndex = 1;
            this.labelFileNamePrefix.Text = "圧縮ファイル名プレフィックス";
            this.toolTipFileNameFormat.SetToolTip(this.labelFileNamePrefix, "圧縮ファイル名のプレフィックスを指定してださい。\r\nファイル名は\r\n「 {{ 圧縮ファイル名プレフィックス }} +  {{ 圧縮ファイル名日時フォーマット }}" +
        " + \".zip\"」\r\nとなります。");
            // 
            // toolTipFileNameFormat
            // 
            this.toolTipFileNameFormat.AutomaticDelay = 200;
            this.toolTipFileNameFormat.AutoPopDelay = 99999999;
            this.toolTipFileNameFormat.InitialDelay = 10;
            this.toolTipFileNameFormat.IsBalloon = true;
            this.toolTipFileNameFormat.ReshowDelay = 10;
            this.toolTipFileNameFormat.ShowAlways = true;
            this.toolTipFileNameFormat.ToolTipTitle = "設定";
            // 
            // labelPasswordMailPrefix
            // 
            this.labelPasswordMailPrefix.AutoSize = true;
            this.labelPasswordMailPrefix.Location = new System.Drawing.Point(12, 93);
            this.labelPasswordMailPrefix.Name = "labelPasswordMailPrefix";
            this.labelPasswordMailPrefix.Size = new System.Drawing.Size(171, 12);
            this.labelPasswordMailPrefix.TabIndex = 5;
            this.labelPasswordMailPrefix.Text = "パスワード通知メールのプレフィックス";
            this.toolTipFileNameFormat.SetToolTip(this.labelPasswordMailPrefix, "パスワード通知メールの件名プレフィックスを指定してくさい。\r\n件名は「プレフィックス」 + 「元のメールの件名」となります。\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "圧縮ファイル名日時フォーマット";
            this.toolTipFileNameFormat.SetToolTip(this.label1, "圧縮ファイル名の日時フォーマットを指定してださい。\r\nDateTimeクラスの書式指定文字列が利用可能です。\r\nファイル名は\r\n「 {{ 圧縮ファイル名プレフィッ" +
        "クス }} +  {{ 圧縮ファイル名日時フォーマット }} + \".zip\"」\r\nとなります。\r\n");
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(438, 438);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(357, 438);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPasswordMailTemplate
            // 
            this.labelPasswordMailTemplate.AutoSize = true;
            this.labelPasswordMailTemplate.Location = new System.Drawing.Point(25, 168);
            this.labelPasswordMailTemplate.Name = "labelPasswordMailTemplate";
            this.labelPasswordMailTemplate.Size = new System.Drawing.Size(158, 12);
            this.labelPasswordMailTemplate.TabIndex = 13;
            this.labelPasswordMailTemplate.Text = "パスワード通知メールテンプレート";
            this.toolTipFileNameFormat.SetToolTip(this.labelPasswordMailTemplate, "パスワード通知メールのテンプレート入力して下さい。\r\n下記のパラメータが利用できます。\r\n* tos => 送信先文字列のリスト\r\n* company  => 会" +
        "社名\r\n* user => ユーザー名\r\n* subject => 元のメールの件名\r\n* password => ZIPファイルのパスワード\r\n");
            // 
            // labelDefaultCompany
            // 
            this.labelDefaultCompany.AutoSize = true;
            this.labelDefaultCompany.Location = new System.Drawing.Point(142, 118);
            this.labelDefaultCompany.Name = "labelDefaultCompany";
            this.labelDefaultCompany.Size = new System.Drawing.Size(41, 12);
            this.labelDefaultCompany.TabIndex = 7;
            this.labelDefaultCompany.Text = "会社名";
            this.toolTipFileNameFormat.SetToolTip(this.labelDefaultCompany, "パスワード通知メールに使用する会社名を入力して下さい。\r\nメールテンプレート内で\r\n{{ company }}\r\nとして参照できます。\r\n");
            // 
            // labelDefaultUserName
            // 
            this.labelDefaultUserName.AutoSize = true;
            this.labelDefaultUserName.Location = new System.Drawing.Point(126, 143);
            this.labelDefaultUserName.Name = "labelDefaultUserName";
            this.labelDefaultUserName.Size = new System.Drawing.Size(57, 12);
            this.labelDefaultUserName.TabIndex = 10;
            this.labelDefaultUserName.Text = "ユーザー名";
            this.toolTipFileNameFormat.SetToolTip(this.labelDefaultUserName, "パスワード通知メールに使用するユーザー名を入力して下さい。\r\nメールテンプレート内で\r\n{{ user }}\r\nとして参照できます。\r\n");
            // 
            // textBoxDefaultUserName
            // 
            this.textBoxDefaultUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "DefaultUserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDefaultUserName.Location = new System.Drawing.Point(210, 140);
            this.textBoxDefaultUserName.Name = "textBoxDefaultUserName";
            this.textBoxDefaultUserName.Size = new System.Drawing.Size(303, 19);
            this.textBoxDefaultUserName.TabIndex = 11;
            this.textBoxDefaultUserName.Text = global::AttachmentEncryption.Properties.Settings.Default.DefaultUserName;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxDefaultUserName, "パスワード通知メールに使用するユーザー名を入力して下さい。\r\nメールテンプレート内で\r\n{{ user }}\r\nとして参照できます。\r\n\r\n");
            // 
            // textBoxDefaultCompany
            // 
            this.textBoxDefaultCompany.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "DefaultCompany", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDefaultCompany.Location = new System.Drawing.Point(210, 115);
            this.textBoxDefaultCompany.Name = "textBoxDefaultCompany";
            this.textBoxDefaultCompany.Size = new System.Drawing.Size(303, 19);
            this.textBoxDefaultCompany.TabIndex = 8;
            this.textBoxDefaultCompany.Text = global::AttachmentEncryption.Properties.Settings.Default.DefaultCompany;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxDefaultCompany, "パスワード通知メールに使用する会社名を入力して下さい。\r\nメールテンプレート内で\r\n{{ company }}\r\nとして参照できます。\r\n\r\n");
            // 
            // textBoxFileNameDateTime
            // 
            this.textBoxFileNameDateTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "FileNameDateTimeFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFileNameDateTime.Location = new System.Drawing.Point(210, 65);
            this.textBoxFileNameDateTime.Name = "textBoxFileNameDateTime";
            this.textBoxFileNameDateTime.Size = new System.Drawing.Size(303, 19);
            this.textBoxFileNameDateTime.TabIndex = 4;
            this.textBoxFileNameDateTime.Text = global::AttachmentEncryption.Properties.Settings.Default.FileNameDateTimeFormat;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxFileNameDateTime, "圧縮ファイル名の日時フォーマットを指定してださい。\r\nDateTimeクラスの書式指定文字列が利用可能です。\r\nファイル名は\r\n「 {{ 圧縮ファイル名プレフィッ" +
        "クス }} +  {{ 圧縮ファイル名日時フォーマット }} + \".zip\"」\r\nとなります。\r\n\r\n");
            // 
            // textBoxPasswordMailTitlePrefix
            // 
            this.textBoxPasswordMailTitlePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "PasswordMailTitlePrefix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPasswordMailTitlePrefix.Location = new System.Drawing.Point(210, 90);
            this.textBoxPasswordMailTitlePrefix.Name = "textBoxPasswordMailTitlePrefix";
            this.textBoxPasswordMailTitlePrefix.Size = new System.Drawing.Size(303, 19);
            this.textBoxPasswordMailTitlePrefix.TabIndex = 6;
            this.textBoxPasswordMailTitlePrefix.Text = global::AttachmentEncryption.Properties.Settings.Default.PasswordMailTitlePrefix;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxPasswordMailTitlePrefix, "パスワード通知メールの件名プレフィックスを指定してくさい。\r\n件名は「プレフィックス」 + 「元のメールの件名」となります。");
            // 
            // textBoxFileNamePrefix
            // 
            this.textBoxFileNamePrefix.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "FileNamePrefix", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxFileNamePrefix.Location = new System.Drawing.Point(210, 40);
            this.textBoxFileNamePrefix.Name = "textBoxFileNamePrefix";
            this.textBoxFileNamePrefix.Size = new System.Drawing.Size(303, 19);
            this.textBoxFileNamePrefix.TabIndex = 2;
            this.textBoxFileNamePrefix.Text = global::AttachmentEncryption.Properties.Settings.Default.FileNamePrefix;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxFileNamePrefix, "圧縮ファイル名のプレフィックスを指定してださい。\r\nファイル名は\r\n「 {{ 圧縮ファイル名プレフィックス }} +  {{ 圧縮ファイル名日時フォーマット }}" +
        " + \".zip\"」\r\nとなります。\r\n");
            // 
            // checkBoxAutoSending
            // 
            this.checkBoxAutoSending.AutoSize = true;
            this.checkBoxAutoSending.Checked = global::AttachmentEncryption.Properties.Settings.Default.AutoSending;
            this.checkBoxAutoSending.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::AttachmentEncryption.Properties.Settings.Default, "AutoSending", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAutoSending.Location = new System.Drawing.Point(210, 12);
            this.checkBoxAutoSending.Name = "checkBoxAutoSending";
            this.checkBoxAutoSending.Size = new System.Drawing.Size(101, 16);
            this.checkBoxAutoSending.TabIndex = 0;
            this.checkBoxAutoSending.Text = "自動で送信する";
            this.checkBoxAutoSending.UseVisualStyleBackColor = true;
            // 
            // textBoxPasswordMailTemplate
            // 
            this.textBoxPasswordMailTemplate.AcceptsReturn = true;
            this.textBoxPasswordMailTemplate.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AttachmentEncryption.Properties.Settings.Default, "PasswordMailTemplate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPasswordMailTemplate.Location = new System.Drawing.Point(210, 165);
            this.textBoxPasswordMailTemplate.Multiline = true;
            this.textBoxPasswordMailTemplate.Name = "textBoxPasswordMailTemplate";
            this.textBoxPasswordMailTemplate.Size = new System.Drawing.Size(303, 267);
            this.textBoxPasswordMailTemplate.TabIndex = 14;
            this.textBoxPasswordMailTemplate.Text = global::AttachmentEncryption.Properties.Settings.Default.PasswordMailTemplate;
            this.toolTipFileNameFormat.SetToolTip(this.textBoxPasswordMailTemplate, "パスワード通知メールのテンプレート入力して下さい。\r\n下記のパラメータが利用できます。\r\n* tos => 送信先文字列のリスト\r\n* company  => 会" +
        "社名\r\n* user => ユーザー名\r\n* subject => 元のメールの件名\r\n* password => ZIPファイルのパスワード\r\n");
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(526, 471);
            this.Controls.Add(this.textBoxDefaultUserName);
            this.Controls.Add(this.labelDefaultUserName);
            this.Controls.Add(this.textBoxDefaultCompany);
            this.Controls.Add(this.labelDefaultCompany);
            this.Controls.Add(this.labelPasswordMailTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileNameDateTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxPasswordMailTitlePrefix);
            this.Controls.Add(this.labelPasswordMailPrefix);
            this.Controls.Add(this.labelFileNamePrefix);
            this.Controls.Add(this.textBoxFileNamePrefix);
            this.Controls.Add(this.checkBoxAutoSending);
            this.Controls.Add(this.textBoxPasswordMailTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "添付ファイル暗号化 (設定)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAutoSending;
        private System.Windows.Forms.TextBox textBoxFileNamePrefix;
        private System.Windows.Forms.Label labelFileNamePrefix;
        private System.Windows.Forms.ToolTip toolTipFileNameFormat;
        private System.Windows.Forms.Label labelPasswordMailPrefix;
        private System.Windows.Forms.TextBox textBoxPasswordMailTitlePrefix;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFileNameDateTime;
        private System.Windows.Forms.Label labelPasswordMailTemplate;
        private System.Windows.Forms.TextBox textBoxPasswordMailTemplate;
        private System.Windows.Forms.TextBox textBoxDefaultCompany;
        private System.Windows.Forms.Label labelDefaultCompany;
        private System.Windows.Forms.TextBox textBoxDefaultUserName;
        private System.Windows.Forms.Label labelDefaultUserName;
    }
}