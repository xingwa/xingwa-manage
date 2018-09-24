namespace digFaimilys
{
    partial class App
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDiv = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.autoLogin = new xingwaWinFormUI.SkinControl.SkinCheckBox();
            this.remember = new xingwaWinFormUI.SkinControl.SkinCheckBox();
            this.btn_login = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.password = new xingwaWinFormUI.SkinControl.SkinTextBox();
            this.account = new xingwaWinFormUI.SkinControl.SkinTextBox();
            this.headPhoto = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.multiLanguage = new xingwaWinFormUI.SkinControl.SkinContextMenuStrip();
            this.china = new System.Windows.Forms.ToolStripMenuItem();
            this.taiwan = new System.Windows.Forms.ToolStripMenuItem();
            this.english = new System.Windows.Forms.ToolStripMenuItem();
            this.ja = new System.Windows.Forms.ToolStripMenuItem();
            this.ko = new System.Windows.Forms.ToolStripMenuItem();
            this.proxySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotUseAProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.browserAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.serverAgent = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDiv.SuspendLayout();
            this.multiLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDiv
            // 
            this.btnDiv.BackColor = System.Drawing.Color.Transparent;
            this.btnDiv.Controls.Add(this.autoLogin);
            this.btnDiv.Controls.Add(this.remember);
            this.btnDiv.Controls.Add(this.btn_login);
            this.btnDiv.Controls.Add(this.password);
            this.btnDiv.Controls.Add(this.account);
            this.btnDiv.Controls.Add(this.headPhoto);
            this.btnDiv.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.btnDiv.DownBack = null;
            this.btnDiv.Location = new System.Drawing.Point(6, 179);
            this.btnDiv.MouseBack = null;
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.NormlBack = null;
            this.btnDiv.Size = new System.Drawing.Size(416, 143);
            this.btnDiv.TabIndex = 0;
            // 
            // autoLogin
            // 
            this.autoLogin.AutoSize = true;
            this.autoLogin.BackColor = System.Drawing.Color.Transparent;
            this.autoLogin.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.autoLogin.DownBack = null;
            this.autoLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.autoLogin.LightEffectBack = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.autoLogin.Location = new System.Drawing.Point(221, 76);
            this.autoLogin.MouseBack = null;
            this.autoLogin.Name = "autoLogin";
            this.autoLogin.NormlBack = null;
            this.autoLogin.SelectedDownBack = null;
            this.autoLogin.SelectedMouseBack = null;
            this.autoLogin.SelectedNormlBack = null;
            this.autoLogin.Size = new System.Drawing.Size(86, 21);
            this.autoLogin.TabIndex = 5;
            this.autoLogin.Text = "auto login";
            this.autoLogin.UseVisualStyleBackColor = false;
            // 
            // remember
            // 
            this.remember.AutoSize = true;
            this.remember.BackColor = System.Drawing.Color.Transparent;
            this.remember.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.remember.DownBack = null;
            this.remember.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.remember.Location = new System.Drawing.Point(128, 77);
            this.remember.MouseBack = null;
            this.remember.Name = "remember";
            this.remember.NormlBack = null;
            this.remember.SelectedDownBack = null;
            this.remember.SelectedMouseBack = null;
            this.remember.SelectedNormlBack = null;
            this.remember.Size = new System.Drawing.Size(88, 21);
            this.remember.TabIndex = 4;
            this.remember.Text = "remember";
            this.remember.UseVisualStyleBackColor = false;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_login.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.btn_login.DownBack = null;
            this.btn_login.Location = new System.Drawing.Point(128, 108);
            this.btn_login.MouseBack = null;
            this.btn_login.Name = "btn_login";
            this.btn_login.NormlBack = null;
            this.btn_login.Size = new System.Drawing.Size(185, 22);
            this.btn_login.TabIndex = 3;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            this.btn_login.Paint += new System.Windows.Forms.PaintEventHandler(this.btn_login_Paint);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Icon = null;
            this.password.IconIsButton = false;
            this.password.IsPasswordChat = '\0';
            this.password.IsSystemPasswordChar = false;
            this.password.Lines = new string[0];
            this.password.Location = new System.Drawing.Point(128, 45);
            this.password.Margin = new System.Windows.Forms.Padding(0);
            this.password.MaxLength = 32767;
            this.password.MinimumSize = new System.Drawing.Size(0, 28);
            this.password.MouseBack = null;
            this.password.Multiline = false;
            this.password.Name = "password";
            this.password.NormlBack = null;
            this.password.Padding = new System.Windows.Forms.Padding(5);
            this.password.ReadOnly = false;
            this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password.Size = new System.Drawing.Size(185, 28);
            this.password.TabIndex = 2;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.WaterColor = System.Drawing.Color.DarkGray;
            this.password.WaterText = "password";
            this.password.WordWrap = true;
            // 
            // account
            // 
            this.account.BackColor = System.Drawing.Color.Transparent;
            this.account.Icon = null;
            this.account.IconIsButton = false;
            this.account.IsPasswordChat = '\0';
            this.account.IsSystemPasswordChar = false;
            this.account.Lines = new string[0];
            this.account.Location = new System.Drawing.Point(128, 13);
            this.account.Margin = new System.Windows.Forms.Padding(0);
            this.account.MaxLength = 32767;
            this.account.MinimumSize = new System.Drawing.Size(0, 28);
            this.account.MouseBack = null;
            this.account.Multiline = false;
            this.account.Name = "account";
            this.account.NormlBack = null;
            this.account.Padding = new System.Windows.Forms.Padding(5);
            this.account.ReadOnly = false;
            this.account.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.account.Size = new System.Drawing.Size(185, 28);
            this.account.TabIndex = 1;
            this.account.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.account.WaterColor = System.Drawing.Color.DarkGray;
            this.account.WaterText = "111";
            this.account.WordWrap = true;
            // 
            // headPhoto
            // 
            this.headPhoto.BackColor = System.Drawing.Color.White;
            this.headPhoto.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.headPhoto.DownBack = null;
            this.headPhoto.Location = new System.Drawing.Point(19, 13);
            this.headPhoto.MouseBack = null;
            this.headPhoto.Name = "headPhoto";
            this.headPhoto.NormlBack = null;
            this.headPhoto.Radius = 10;
            this.headPhoto.Size = new System.Drawing.Size(95, 94);
            this.headPhoto.TabIndex = 0;
            // 
            // multiLanguage
            // 
            this.multiLanguage.Arrow = System.Drawing.Color.Black;
            this.multiLanguage.Back = System.Drawing.Color.White;
            this.multiLanguage.BackRadius = 4;
            this.multiLanguage.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.multiLanguage.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.multiLanguage.Fore = System.Drawing.Color.Black;
            this.multiLanguage.HoverFore = System.Drawing.Color.White;
            this.multiLanguage.ItemAnamorphosis = true;
            this.multiLanguage.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.multiLanguage.ItemBorderShow = true;
            this.multiLanguage.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.multiLanguage.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.multiLanguage.ItemRadius = 4;
            this.multiLanguage.ItemRadiusStyle = xingwaWinFormUI.SkinClass.RoundStyle.All;
            this.multiLanguage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.china,
            this.taiwan,
            this.english,
            this.ja,
            this.ko,
            this.proxySettings});
            this.multiLanguage.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.multiLanguage.Name = "multiLanguage";
            this.multiLanguage.RadiusStyle = xingwaWinFormUI.SkinClass.RoundStyle.All;
            this.multiLanguage.Size = new System.Drawing.Size(158, 136);
            this.multiLanguage.TitleAnamorphosis = true;
            this.multiLanguage.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.multiLanguage.TitleRadius = 4;
            this.multiLanguage.TitleRadiusStyle = xingwaWinFormUI.SkinClass.RoundStyle.All;
            // 
            // china
            // 
            this.china.Checked = true;
            this.china.CheckState = System.Windows.Forms.CheckState.Checked;
            this.china.Name = "china";
            this.china.Size = new System.Drawing.Size(157, 22);
            this.china.Text = "简体中文";
            this.china.Click += new System.EventHandler(this.china_Click);
            // 
            // taiwan
            // 
            this.taiwan.Name = "taiwan";
            this.taiwan.Size = new System.Drawing.Size(157, 22);
            this.taiwan.Text = "繁體中文";
            this.taiwan.Click += new System.EventHandler(this.taiwan_Click);
            // 
            // english
            // 
            this.english.Name = "english";
            this.english.Size = new System.Drawing.Size(157, 22);
            this.english.Text = "English";
            this.english.Click += new System.EventHandler(this.english_Click);
            // 
            // ja
            // 
            this.ja.Name = "ja";
            this.ja.Size = new System.Drawing.Size(157, 22);
            this.ja.Text = "日本語";
            this.ja.Click += new System.EventHandler(this.ja_Click);
            // 
            // ko
            // 
            this.ko.Name = "ko";
            this.ko.Size = new System.Drawing.Size(157, 22);
            this.ko.Text = "한국어";
            this.ko.Click += new System.EventHandler(this.ko_Click);
            // 
            // proxySettings
            // 
            this.proxySettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doNotUseAProxy,
            this.browserAgent,
            this.serverAgent});
            this.proxySettings.Name = "proxySettings";
            this.proxySettings.Size = new System.Drawing.Size(157, 22);
            this.proxySettings.Text = "Proxy settings";
            // 
            // doNotUseAProxy
            // 
            this.doNotUseAProxy.Checked = true;
            this.doNotUseAProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doNotUseAProxy.Name = "doNotUseAProxy";
            this.doNotUseAProxy.Size = new System.Drawing.Size(188, 22);
            this.doNotUseAProxy.Text = "Do not use a proxy";
            // 
            // browserAgent
            // 
            this.browserAgent.Name = "browserAgent";
            this.browserAgent.Size = new System.Drawing.Size(188, 22);
            this.browserAgent.Text = "Browser agent";
            // 
            // serverAgent
            // 
            this.serverAgent.Name = "serverAgent";
            this.serverAgent.Size = new System.Drawing.Size(188, 22);
            this.serverAgent.Text = "Server agent";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(428, 328);
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.btnDiv);
            this.MaximizeBox = false;
            this.Name = "App";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowSystemMenu = true;
            this.SysBottomVisibale = true;
            this.Text = "digFamily";
            this.SysBottomClick += new xingwaWinFormUI.MainWinForm.SysBottomEventHandler(this.App_SysBottomClick);
            this.Load += new System.EventHandler(this.App_Load);
            this.btnDiv.ResumeLayout(false);
            this.btnDiv.PerformLayout();
            this.multiLanguage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private xingwaWinFormUI.SkinControl.SkinPanel btnDiv;
        private xingwaWinFormUI.SkinControl.SkinPanel headPhoto;
        private xingwaWinFormUI.SkinControl.SkinTextBox account;
        private xingwaWinFormUI.SkinControl.SkinTextBox password;
        private xingwaWinFormUI.SkinControl.SkinPanel btn_login;
        private xingwaWinFormUI.SkinControl.SkinCheckBox remember;
        private xingwaWinFormUI.SkinControl.SkinCheckBox autoLogin;
        private xingwaWinFormUI.SkinControl.SkinContextMenuStrip multiLanguage;
        private System.Windows.Forms.ToolStripMenuItem china;
        private System.Windows.Forms.ToolStripMenuItem taiwan;
        private System.Windows.Forms.ToolStripMenuItem english;
        private System.Windows.Forms.ToolStripMenuItem ja;
        private System.Windows.Forms.ToolStripMenuItem ko;
        private System.Windows.Forms.ToolStripMenuItem proxySettings;
        private System.Windows.Forms.ToolStripMenuItem doNotUseAProxy;
        private System.Windows.Forms.ToolStripMenuItem browserAgent;
        private System.Windows.Forms.ToolStripMenuItem serverAgent;
    }
}

