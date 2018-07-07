namespace AttachmentEncryption
{
    partial class AttachmentEncryptionRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AttachmentEncryptionRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// このメソッドの内容をコード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.buttonEncryptAndSend = this.Factory.CreateRibbonButton();
            this.buttonConfig = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "添付ファイル暗号化";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.buttonEncryptAndSend);
            this.group1.Items.Add(this.buttonConfig);
            this.group1.Label = "添付ファイル暗号化";
            this.group1.Name = "group1";
            // 
            // buttonEncryptAndSend
            // 
            this.buttonEncryptAndSend.Label = "暗号化して送信";
            this.buttonEncryptAndSend.Name = "buttonEncryptAndSend";
            this.buttonEncryptAndSend.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonEncryptAndSend_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Label = "設定";
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonConfig_Click);
            // 
            // AttachmentEncryptionRibbon
            // 
            this.Name = "AttachmentEncryptionRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AttachmentEncryptionRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonEncryptAndSend;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonConfig;
    }

    partial class ThisRibbonCollection
    {
        internal AttachmentEncryptionRibbon AttachmentEncryptionRibbon
        {
            get { return this.GetRibbon<AttachmentEncryptionRibbon>(); }
        }
    }
}
