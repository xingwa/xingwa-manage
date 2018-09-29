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
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.Panel div;
        private System.Windows.Forms.StatusStrip statusStripDiv;


        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx topDiv;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem superTabItem5;
        private System.Windows.Forms.TreeView treeView1;
        private xingwaWinFormUI.SkinControl.SkinLabel skinLabel1;
        private DevComponents.DotNetBar.Controls.SymbolBox symbolBox1;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.PanelEx panelEx3;




        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode100 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode101 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode102 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode103 = new System.Windows.Forms.TreeNode("C2C买卖管理", new System.Windows.Forms.TreeNode[] {
            treeNode100,
            treeNode101,
            treeNode102});
            System.Windows.Forms.TreeNode treeNode104 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode105 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode106 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode107 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode108 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode109 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode110 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode104,
            treeNode105,
            treeNode106,
            treeNode107,
            treeNode108,
            treeNode109});
            this.statusStripDiv = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.divMain = new System.Windows.Forms.Panel();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.div = new System.Windows.Forms.Panel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem5 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.topDiv = new DevComponents.DotNetBar.PanelEx();
            this.skinLabel1 = new xingwaWinFormUI.SkinControl.SkinLabel();
            this.symbolBox1 = new DevComponents.DotNetBar.Controls.SymbolBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.statusStripDiv.SuspendLayout();
            this.divMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.div.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.topDiv.SuspendLayout();
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
            this.divMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.divMain.Controls.Add(this.superTabControl1);
            this.divMain.Location = new System.Drawing.Point(0, 66);
            this.divMain.Name = "divMain";
            this.divMain.Size = new System.Drawing.Size(1022, 668);
            this.divMain.TabIndex = 1;
            // 
            // superTabControl1
            // 
            this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            this.superTabControl1.CausesValidation = false;
            this.superTabControl1.CloseButtonOnTabsAlwaysDisplayed = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Controls.Add(this.superTabControlPanel5);
            this.superTabControl1.Controls.Add(this.superTabControlPanel4);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(2, 3);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(1015, 662);
            this.superTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControl1.TabFont = new System.Drawing.Font("微软雅黑", 9F);
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem3,
            this.superTabItem2,
            this.superTabItem4,
            this.superTabItem5});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014;
            this.superTabControl1.Text = "日志管理";
            this.superTabControl1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl1_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.div);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1015, 617);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // div
            // 
            this.div.Controls.Add(this.panelEx3);
            this.div.Controls.Add(this.expandableSplitter1);
            this.div.Controls.Add(this.panelEx1);
            this.div.Dock = System.Windows.Forms.DockStyle.Fill;
            this.div.Location = new System.Drawing.Point(0, 0);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(1015, 617);
            this.div.TabIndex = 0;
            // 
            // panelEx3
            // 
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(157, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(858, 617);
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
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(213)))), ((int)(((byte)(140)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.Empty;
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(152, 0);
            this.expandableSplitter1.MinExtra = 10;
            this.expandableSplitter1.MinSize = 5;
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 617);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla;
            this.expandableSplitter1.TabIndex = 400;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.treeView1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(152, 617);
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
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            treeNode100.Name = "节点1";
            treeNode100.Text = "节点1";
            treeNode101.Name = "节点2";
            treeNode101.Text = "节点2";
            treeNode102.Name = "节点3";
            treeNode102.Text = "节点3";
            treeNode103.Name = "节点0";
            treeNode103.Text = "C2C买卖管理";
            treeNode104.Name = "节点5";
            treeNode104.Text = "节点5";
            treeNode105.Name = "节点6";
            treeNode105.Text = "节点6";
            treeNode106.Name = "节点7";
            treeNode106.Text = "节点7";
            treeNode107.Name = "节点8";
            treeNode107.Text = "节点8";
            treeNode108.Name = "节点9";
            treeNode108.Text = "节点9";
            treeNode109.Name = "节点10";
            treeNode109.Text = "节点10";
            treeNode110.Name = "节点4";
            treeNode110.Text = "节点4";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode103,
            treeNode110});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(140, 355);
            this.treeView1.TabIndex = 0;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Symbol = "";
            this.superTabItem1.Text = "个人中心";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1015, 617);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem3;
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Symbol = "";
            this.superTabItem3.Text = "内容管理";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(902, 662);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.superTabItem5;
            // 
            // superTabItem5
            // 
            this.superTabItem5.AttachedControl = this.superTabControlPanel5;
            this.superTabItem5.GlobalItem = false;
            this.superTabItem5.Name = "superTabItem5";
            this.superTabItem5.Symbol = "";
            this.superTabItem5.Text = "日志管理";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1015, 425);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.superTabItem4;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel4;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Symbol = "";
            this.superTabItem4.Text = "统计系统";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1015, 425);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Symbol = "";
            this.superTabItem2.Text = "会员管理";
            // 
            // topDiv
            // 
            this.topDiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topDiv.CanvasColor = System.Drawing.SystemColors.Control;
            this.topDiv.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.topDiv.Controls.Add(this.line1);
            this.topDiv.Controls.Add(this.skinLabel1);
            this.topDiv.Controls.Add(this.symbolBox1);
            this.topDiv.DisabledBackColor = System.Drawing.Color.Empty;
            this.topDiv.Location = new System.Drawing.Point(1, 23);
            this.topDiv.Name = "topDiv";
            this.topDiv.Size = new System.Drawing.Size(1022, 46);
            this.topDiv.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.topDiv.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(150)))), ((int)(((byte)(178)))));
            this.topDiv.Style.BackColor2.Color = System.Drawing.Color.White;
            this.topDiv.Style.BorderColor.Color = System.Drawing.Color.Transparent;
            this.topDiv.Style.BorderWidth = 0;
            this.topDiv.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.topDiv.Style.GradientAngle = 90;
            this.topDiv.TabIndex = 2;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.White;
            this.skinLabel1.Location = new System.Drawing.Point(32, 7);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(140, 17);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "欢迎您：成都新交所张三";
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
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(7, 32);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(1010, 23);
            this.line1.TabIndex = 3;
            this.line1.Text = "line1";
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
            this.statusStripDiv.ResumeLayout(false);
            this.statusStripDiv.PerformLayout();
            this.divMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.div.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.topDiv.ResumeLayout(false);
            this.topDiv.PerformLayout();
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
    }
}
