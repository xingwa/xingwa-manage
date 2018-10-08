using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementBackend
{
    public class backend : iform.AppForm
    {
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel divMain;
        private System.Windows.Forms.StatusStrip statusStripDiv;
        private DevComponents.DotNetBar.PanelEx topDiv;
        private xingwaWinFormUI.SkinControl.SkinLabel skinLabelName;
        private DevComponents.DotNetBar.Controls.SymbolBox symbolBox1;
        private System.Windows.Forms.Panel div;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private DevComponents.DotNetBar.Controls.Line lineDiv;




        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("C2C买卖管理", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            this.statusStripDiv = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.divMain = new System.Windows.Forms.Panel();
            this.topDiv = new DevComponents.DotNetBar.PanelEx();
            this.lineDiv = new DevComponents.DotNetBar.Controls.Line();
            this.skinLabelName = new xingwaWinFormUI.SkinControl.SkinLabel();
            this.symbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.div = new System.Windows.Forms.Panel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStripDiv.SuspendLayout();
            this.divMain.SuspendLayout();
            this.topDiv.SuspendLayout();
            this.div.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripDiv
            // 
            this.statusStripDiv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripDiv.Location = new System.Drawing.Point(3, 743);
            this.statusStripDiv.Name = "statusStripDiv";
            this.statusStripDiv.Size = new System.Drawing.Size(1018, 22);
            this.statusStripDiv.TabIndex = 0;
            this.statusStripDiv.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(186, 17);
            this.toolStripStatusLabel1.Text = "现在时间：2018-05-04 13:22:10";
            // 
            // divMain
            // 
            this.divMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.divMain.Controls.Add(this.div);
            this.divMain.Location = new System.Drawing.Point(1, 66);
            this.divMain.Name = "divMain";
            this.divMain.Size = new System.Drawing.Size(1022, 677);
            this.divMain.TabIndex = 1;
            // 
            // topDiv
            // 
            this.topDiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topDiv.CanvasColor = System.Drawing.SystemColors.Control;
            this.topDiv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.topDiv.Controls.Add(this.lineDiv);
            this.topDiv.Controls.Add(this.skinLabelName);
            this.topDiv.Controls.Add(this.symbolBox1);
            this.topDiv.DisabledBackColor = System.Drawing.Color.Empty;
            this.topDiv.Location = new System.Drawing.Point(2, 23);
            this.topDiv.Name = "topDiv";
            this.topDiv.Size = new System.Drawing.Size(1019, 46);
            this.topDiv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.topDiv.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(150)))), ((int)(((byte)(178)))));
            this.topDiv.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            this.topDiv.Style.BorderColor.Color = System.Drawing.Color.Transparent;
            this.topDiv.Style.BorderWidth = 0;
            this.topDiv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.topDiv.Style.GradientAngle = 90;
            this.topDiv.TabIndex = 2;
            this.topDiv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topDiv_MouseDown);
            // 
            // lineDiv
            // 
            this.lineDiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineDiv.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineDiv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(170)))), ((int)(((byte)(192)))));
            this.lineDiv.Location = new System.Drawing.Point(-2, 41);
            this.lineDiv.Name = "lineDiv";
            this.lineDiv.Size = new System.Drawing.Size(1016, 3);
            this.lineDiv.TabIndex = 3;
            // 
            // skinLabelName
            // 
            this.skinLabelName.AutoSize = true;
            this.skinLabelName.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelName.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabelName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelName.ForeColor = System.Drawing.Color.White;
            this.skinLabelName.Location = new System.Drawing.Point(32, 7);
            this.skinLabelName.Name = "skinLabelName";
            this.skinLabelName.Size = new System.Drawing.Size(140, 17);
            this.skinLabelName.TabIndex = 1;
            this.skinLabelName.Text = "欢迎您：成都新交所张三";
            this.skinLabelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skinLabelName_MouseDown);
            // 
            // symbolBox1
            // 
            this.symbolBox1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.symbolBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.symbolBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.symbolBox1.Location = new System.Drawing.Point(2, 5);
            this.symbolBox1.Name = "symbolBox1";
            this.symbolBox1.Size = new System.Drawing.Size(34, 23);
            this.symbolBox1.Symbol = "";
            this.symbolBox1.SymbolColor = System.Drawing.Color.GhostWhite;
            this.symbolBox1.TabIndex = 2;
            this.symbolBox1.Text = "symbolBox1";
            // 
            // div
            // 
            this.div.Controls.Add(this.panelEx3);
            this.div.Controls.Add(this.expandableSplitter1);
            this.div.Controls.Add(this.panelEx1);
            this.div.Dock = System.Windows.Forms.DockStyle.Fill;
            this.div.Location = new System.Drawing.Point(0, 0);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(1022, 677);
            this.div.TabIndex = 1;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.webBrowser1);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(157, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(865, 677);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "Fill Panel";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.ExpandableControl = this.panelEx1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(181)))), ((int)(((byte)(226)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(232)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(181)))), ((int)(((byte)(226)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(152, 0);
            this.expandableSplitter1.MinExtra = 10;
            this.expandableSplitter1.MinSize = 5;
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 677);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter1.TabIndex = 400;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.panel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(152, 677);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Style.WordWrap = true;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "Click to collapse12";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(3, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 667);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode12.Name = "节点1";
            treeNode12.Text = "节点1";
            treeNode13.Name = "节点2";
            treeNode13.Text = "节点2";
            treeNode14.Name = "节点3";
            treeNode14.Text = "节点3";
            treeNode15.Name = "节点0";
            treeNode15.Text = "C2C买卖管理";
            treeNode16.Name = "节点5";
            treeNode16.Text = "节点5";
            treeNode17.Name = "节点6";
            treeNode17.Text = "节点6";
            treeNode18.Name = "节点7";
            treeNode18.Text = "节点7";
            treeNode19.Name = "节点8";
            treeNode19.Text = "节点8";
            treeNode20.Name = "节点9";
            treeNode20.Text = "节点9";
            treeNode21.Name = "节点10";
            treeNode21.Text = "节点10";
            treeNode22.Name = "节点4";
            treeNode22.Text = "节点4";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode22});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(146, 667);
            this.treeView1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(5, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(852, 665);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            // 
            // backend
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(150)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.topDiv);
            this.Controls.Add(this.divMain);
            this.Controls.Add(this.statusStripDiv);
            this.Name = "backend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试系统";
            this.statusStripDiv.ResumeLayout(false);
            this.statusStripDiv.PerformLayout();
            this.divMain.ResumeLayout(false);
            this.topDiv.ResumeLayout(false);
            this.topDiv.PerformLayout();
            this.div.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void winformShow()
        {
            InitializeComponent();

            this.CloseNormlBack = photoApp.Properties.Resources.btn_close_disable;
            this.CloseDownBack = photoApp.Properties.Resources.btn_close_down;
            this.CloseMouseBack = photoApp.Properties.Resources.btn_close_highlight;
        

            this.MiniNormlBack = photoApp.Properties.Resources.btn_mini_normal;
            this.MiniDownBack = photoApp.Properties.Resources.btn_mini_down;
            this.MiniMouseBack = photoApp.Properties.Resources.btn_mini_highlight;



            this.MaxNormlBack = photoApp.Properties.Resources.btn_max_normal;
            this.MaxDownBack = photoApp.Properties.Resources.btn_max_down;
            this.MaxMouseBack = photoApp.Properties.Resources.btn_max_highlight;



            this.BorderPalace = photoApp.Properties.Resources.BackPalace;


            this.SysBottomNorml = photoApp.Properties.Resources.btn_set_normal;
            this.SysBottomDown = photoApp.Properties.Resources.btn_set_press;
            this.SysBottomMouse = photoApp.Properties.Resources.btn_set_hover;


            this.RestoreDownBack = photoApp.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = photoApp.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = photoApp.Properties.Resources.btn_restore_normal;


            this.ControlBoxOffset = new System.Drawing.Point(0, -1);
            this.DoubleBuffered = true;
    
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "backend";
            this.ResumeLayout(false);
            this.Show();
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void topDiv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            user128.sendMessage(this.Handle);
        }

        private void skinLabelName_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            user128.sendMessage(this.Handle);
        }
    }
}
