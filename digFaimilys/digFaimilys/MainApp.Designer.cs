namespace digFaimilys
{
    partial class MainApp
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
            this.skinPanel1 = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.tagIco = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.skinPanel3 = new xingwaWinFormUI.SkinControl.SkinPanel();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(6, 27);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(264, 94);
            this.skinPanel1.TabIndex = 0;
            // 
            // tagIco
            // 
            this.tagIco.BackColor = System.Drawing.Color.White;
            this.tagIco.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.tagIco.DownBack = null;
            this.tagIco.Location = new System.Drawing.Point(1, 125);
            this.tagIco.MouseBack = null;
            this.tagIco.Name = "tagIco";
            this.tagIco.NormlBack = null;
            this.tagIco.Size = new System.Drawing.Size(273, 411);
            this.tagIco.TabIndex = 1;
            // 
            // skinPanel3
            // 
            this.skinPanel3.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel3.ControlState = xingwaWinFormUI.SkinClass.ControlState.Normal;
            this.skinPanel3.DownBack = null;
            this.skinPanel3.Location = new System.Drawing.Point(6, 542);
            this.skinPanel3.MouseBack = null;
            this.skinPanel3.Name = "skinPanel3";
            this.skinPanel3.NormlBack = null;
            this.skinPanel3.Size = new System.Drawing.Size(264, 84);
            this.skinPanel3.TabIndex = 1;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(275, 632);
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.Controls.Add(this.skinPanel3);
            this.Controls.Add(this.tagIco);
            this.Controls.Add(this.skinPanel1);
            this.MaximizeBox = false;
            this.Name = "MainApp";
            this.Text = "MainApp";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private xingwaWinFormUI.SkinControl.SkinPanel skinPanel1;
        private xingwaWinFormUI.SkinControl.SkinPanel tagIco;
        private xingwaWinFormUI.SkinControl.SkinPanel skinPanel3;
    }
}