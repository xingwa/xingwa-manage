using xingwaWinFormUI.SkinClass;
using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class MainWinForm : Form
	{
		public delegate void BackEventHandler(object sender, BackEventArgs e);
		public delegate void SysBottomEventHandler(object sender);
		private const int CS_DROPSHADOW = 131072;
		private const int GCL_STYLE = -26;
		public CCSkinForm skin;
		private SkinFormRenderer _renderer;
		private RoundStyle _roundStyle = RoundStyle.All;
		private Rectangle _deltaRect;
		private int _radius = 6;
		private int _captionHeight = 24;
		private Font _captionFont = SystemFonts.CaptionFont;
		private int _borderWidth = 3;
		private Size _miniSize = new Size(32, 18);
		private Size sysBottomSize = new Size(28, 20);
		private Size _maxBoxSize = new Size(32, 18);
		private Size _closeBoxSize = new Size(32, 18);
		private Point _controlBoxOffset = new Point(6, 0);
		private int _controlBoxSpace;
		private bool _active;
		private bool _showSystemMenu;
		private ControlBoxManager _controlBoxManager;
		private Padding _padding;
		private bool _canResize = true;
		private bool _inPosChanged;
		private ToolTip _toolTip;
		private MobileStyle _mobile = MobileStyle.Mobile;
		private static readonly object EventRendererChanged = new object();
		private double skinOpacity = 1.0;
		private Image back;
		private bool backLayout = true;
		private Image backpalace;
		private Image borderpalace;
		private bool showborder = true;
		private bool showdrawicon = true;
		private bool special = true;
		private bool shadow = true;
		private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
		private Rectangle borderrectangle = new Rectangle(10, 10, 10, 10);
		private bool backtocolor = true;
		private bool effectcaption = true;
		private Color effectback = Color.White;
		private int effectWidth = 6;
		private bool dropback = true;
		private string sysBottomToolTip;
		private bool sysBottomVisibale;
		private Image sysBottomMouse;
		private Image sysBottomDown;
		private Image sysBottomNorml;
		private Image minimouseback;
		private Image minidownback;
		private Image mininormlback;
		private Image maxmouseback;
		private Image maxdownback;
		private Image maxnormlback;
		private Image restoremouseback;
		private Image restoredownback;
		private Image restorenormlback;
		private Image closemouseback;
		private Image closedownback;
		private Image closenormlback;
		public bool isMouseDown;
		public AnchorStyles Aanhor;
		[Category("Skin"), Description("自定义按钮被点击时引发的事件")]
		public event MainWinForm.SysBottomEventHandler SysBottomClick;
		[Category("Skin"), Description("Back属性值更改时引发的事件")]
		public event MainWinForm.BackEventHandler BackChanged;
		public event EventHandler RendererChangled
		{
			add
			{
				base.Events.AddHandler(MainWinForm.EventRendererChanged, value);
			}
			remove
			{
				base.Events.RemoveHandler(MainWinForm.EventRendererChanged, value);
			}
		}
		[Category("Skin"), Description("窗体渐变后透明度")]
		public double SkinOpacity
		{
			get
			{
				return this.skinOpacity;
			}
			set
			{
				if (this.skinOpacity != value)
				{
					this.skinOpacity = value;
				}
			}
		}
		[Category("Skin"), Description("背景")]
		public Image Back
		{
			get
			{
				return this.back;
			}
			set
			{
				if (this.back != value)
				{
					this.OnBackChanged(new BackEventArgs(this.back, value));
					this.back = value;
					if (this.BackToColor && this.back != null)
					{
						this.BackColor = BitmapHelper.GetImageAverageColor((Bitmap)this.back);
					}
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), Description("是否从左绘制背景")]
		public bool BackLayout
		{
			get
			{
				return this.backLayout;
			}
			set
			{
				if (this.backLayout != value)
				{
					this.backLayout = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), Description("质感层背景")]
		public Image BackPalace
		{
			get
			{
				return this.backpalace;
			}
			set
			{
				if (this.backpalace != value)
				{
					this.backpalace = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), Description("边框层背景")]
		public Image BorderPalace
		{
			get
			{
				return this.borderpalace;
			}
			set
			{
				if (this.borderpalace != value)
				{
					this.borderpalace = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(true), Description("是否在窗体上绘画边框")]
		public bool ShowBorder
		{
			get
			{
				return this.showborder;
			}
			set
			{
				if (this.showborder != value)
				{
					this.showborder = value;
					base.Invalidate();
				}
			}
		}
		[Category("窗口样式"), DefaultValue(true), Description("是否在窗体上绘画ICO图标")]
		public bool ShowDrawIcon
		{
			get
			{
				return this.showdrawicon;
			}
			set
			{
				if (this.showdrawicon != value)
				{
					this.showdrawicon = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(true), Description("是否启用窗口淡入淡出")]
		public bool Special
		{
			get
			{
				return this.special;
			}
			set
			{
				if (this.special != value)
				{
					this.special = value;
				}
			}
		}
		[Category("Skin"), DefaultValue(true), Description("是否启用窗体阴影")]
		public bool Shadow
		{
			get
			{
				return this.shadow;
			}
			set
			{
				if (this.shadow != value)
				{
					this.shadow = value;
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Rectangle), "10,10,10,10"), Description("质感层九宫绘画区域")]
		public Rectangle BackRectangle
		{
			get
			{
				return this.backrectangle;
			}
			set
			{
				if (this.backrectangle != value)
				{
					this.backrectangle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Rectangle), "10,10,10,10"), Description("边框质感层九宫绘画区域")]
		public Rectangle BorderRectangle
		{
			get
			{
				return this.borderrectangle;
			}
			set
			{
				if (this.borderrectangle != value)
				{
					this.borderrectangle = value;
					base.Invalidate();
				}
			}
		}
		[Browsable(false), Description("设置或获取窗体的绘制方法"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SkinFormRenderer Renderer
		{
			get
			{
				if (this._renderer == null)
				{
					this._renderer = new SkinFormProfessionalRenderer();
				}
				return this._renderer;
			}
			set
			{
				this._renderer = value;
				this.OnRendererChanged(EventArgs.Empty);
			}
		}
		[Category("Caption")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate(new Rectangle(0, 0, base.Width, this.CaptionHeight + 1));
			}
		}
		[Category("Skin"), DefaultValue(true), Description("是否根据背景图决定背景色，并加入背景渐变效果")]
		public bool BackToColor
		{
			get
			{
				return this.backtocolor;
			}
			set
			{
				if (this.backtocolor != value)
				{
					this.backtocolor = value;
					base.Invalidate();
				}
			}
		}
		[Category("Caption"), DefaultValue(true), Description("是否绘制发光标题")]
		public bool EffectCaption
		{
			get
			{
				return this.effectcaption;
			}
			set
			{
				if (this.effectcaption != value)
				{
					this.effectcaption = value;
					base.Invalidate();
				}
			}
		}
		[Category("Caption"), DefaultValue(typeof(Font), "CaptionFont"), Description("设置或获取窗体标题的字体")]
		public Font CaptionFont
		{
			get
			{
				return this._captionFont;
			}
			set
			{
				if (value == null)
				{
					this._captionFont = SystemFonts.CaptionFont;
				}
				else
				{
					this._captionFont = value;
				}
				base.Invalidate(this.CaptionRect);
			}
		}
		[Category("Caption"), DefaultValue(typeof(Color), "White"), Description("发光字体背景色")]
		public Color EffectBack
		{
			get
			{
				return this.effectback;
			}
			set
			{
				if (this.effectback != value)
				{
					this.effectback = value;
					base.Invalidate();
				}
			}
		}
		[Category("Caption"), DefaultValue(typeof(int), "6"), Description("光圈大小")]
		public int EffectWidth
		{
			get
			{
				return this.effectWidth;
			}
			set
			{
				if (this.effectWidth != value)
				{
					this.effectWidth = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(true), Description("指示控件是否可以将用户拖动到背景上的图片作为背景(注意:开启前请设置AllowDrop为true,否则无效)")]
		public bool DropBack
		{
			get
			{
				return this.dropback;
			}
			set
			{
				if (this.dropback != value)
				{
					this.dropback = value;
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(RoundStyle), "1"), Description("设置或获取窗体的圆角样式")]
		public RoundStyle RoundStyle
		{
			get
			{
				return this._roundStyle;
			}
			set
			{
				if (this._roundStyle != value)
				{
					this._roundStyle = value;
					this.SetReion();
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(MobileStyle), "2"), Description("移动窗体的条件")]
		public MobileStyle Mobile
		{
			get
			{
				return this._mobile;
			}
			set
			{
				if (this._mobile != value)
				{
					this._mobile = value;
				}
			}
		}
		[Category("Skin"), DefaultValue(6), Description("设置或获取窗体的圆角的大小")]
		public int Radius
		{
			get
			{
				return this._radius;
			}
			set
			{
				if (this._radius != value)
				{
					this._radius = value;
					this.SetReion();
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(24), Description("设置或获取窗体标题栏的高度")]
		public int CaptionHeight
		{
			get
			{
				return this._captionHeight;
			}
			set
			{
				if (this._captionHeight != value)
				{
					this._captionHeight = ((value < this._borderWidth) ? this._borderWidth : value);
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(3), Description("设置或获取窗体的边框的宽度")]
		public int BorderWidth
		{
			get
			{
				return this._borderWidth;
			}
			set
			{
				if (this._borderWidth != value)
				{
					this._borderWidth = ((value < 1) ? 1 : value);
				}
			}
		}
		[Category("MinimizeBox"), DefaultValue(typeof(Size), "32, 18"), Description("设置或获取最小化按钮的大小")]
		public Size MiniSize
		{
			get
			{
				return this._miniSize;
			}
			set
			{
				if (this._miniSize != value)
				{
					this._miniSize = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), DefaultValue(typeof(Size), "28, 20"), Description("设置或获取自定义系统按钮的大小")]
		public Size SysBottomSize
		{
			get
			{
				return this.sysBottomSize;
			}
			set
			{
				if (this.sysBottomSize != value)
				{
					this.sysBottomSize = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), Description("自定义系统按钮悬浮提示")]
		public string SysBottomToolTip
		{
			get
			{
				return this.sysBottomToolTip;
			}
			set
			{
				if (this.sysBottomToolTip != value)
				{
					this.sysBottomToolTip = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), Description("自定义系统按钮是否显示")]
		public bool SysBottomVisibale
		{
			get
			{
				return this.sysBottomVisibale;
			}
			set
			{
				if (this.sysBottomVisibale != value)
				{
					this.sysBottomVisibale = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), Description("自定义系统按钮悬浮时")]
		public Image SysBottomMouse
		{
			get
			{
				return this.sysBottomMouse;
			}
			set
			{
				if (this.sysBottomMouse != value)
				{
					this.sysBottomMouse = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), Description("自定义系统按钮点击时")]
		public Image SysBottomDown
		{
			get
			{
				return this.sysBottomDown;
			}
			set
			{
				if (this.sysBottomDown != value)
				{
					this.sysBottomDown = value;
					base.Invalidate();
				}
			}
		}
		[Category("SysBottom"), Description("自定义系统按钮初始时")]
		public Image SysBottomNorml
		{
			get
			{
				return this.sysBottomNorml;
			}
			set
			{
				if (this.sysBottomNorml != value)
				{
					this.sysBottomNorml = value;
					base.Invalidate();
				}
			}
		}
		[Category("MinimizeBox"), Description("最小化按钮悬浮时背景")]
		public Image MiniMouseBack
		{
			get
			{
				return this.minimouseback;
			}
			set
			{
				if (this.minimouseback != value)
				{
					this.minimouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MinimizeBox"), Description("最小化按钮点击时背景")]
		public Image MiniDownBack
		{
			get
			{
				return this.minidownback;
			}
			set
			{
				if (this.minidownback != value)
				{
					this.minidownback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MinimizeBox"), Description("最小化按钮初始时背景")]
		public Image MiniNormlBack
		{
			get
			{
				return this.mininormlback;
			}
			set
			{
				if (this.mininormlback != value)
				{
					this.mininormlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), DefaultValue(typeof(Size), "32, 18"), Description("设置或获取最大化（还原）按钮的大小")]
		public Size MaxSize
		{
			get
			{
				return this._maxBoxSize;
			}
			set
			{
				if (this._maxBoxSize != value)
				{
					this._maxBoxSize = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("最大化按钮悬浮时背景")]
		public Image MaxMouseBack
		{
			get
			{
				return this.maxmouseback;
			}
			set
			{
				if (this.maxmouseback != value)
				{
					this.maxmouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("最大化按钮点击时背景")]
		public Image MaxDownBack
		{
			get
			{
				return this.maxdownback;
			}
			set
			{
				if (this.maxdownback != value)
				{
					this.maxdownback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("最大化按钮初始时背景")]
		public Image MaxNormlBack
		{
			get
			{
				return this.maxnormlback;
			}
			set
			{
				if (this.maxnormlback != value)
				{
					this.maxnormlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("还原按钮悬浮时背景")]
		public Image RestoreMouseBack
		{
			get
			{
				return this.restoremouseback;
			}
			set
			{
				if (this.restoremouseback != value)
				{
					this.restoremouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("还原按钮点击时背景")]
		public Image RestoreDownBack
		{
			get
			{
				return this.restoredownback;
			}
			set
			{
				if (this.restoredownback != value)
				{
					this.restoredownback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MaximizeBox"), Description("还原按钮初始时背景")]
		public Image RestoreNormlBack
		{
			get
			{
				return this.restorenormlback;
			}
			set
			{
				if (this.restorenormlback != value)
				{
					this.restorenormlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("CloseBox"), DefaultValue(typeof(Size), "32, 18"), Description("设置或获取关闭按钮的大小")]
		public Size CloseBoxSize
		{
			get
			{
				return this._closeBoxSize;
			}
			set
			{
				if (this._closeBoxSize != value)
				{
					this._closeBoxSize = value;
					base.Invalidate();
				}
			}
		}
		[Category("CloseBox"), Description("关闭按钮悬浮时背景")]
		public Image CloseMouseBack
		{
			get
			{
				return this.closemouseback;
			}
			set
			{
				if (this.closemouseback != value)
				{
					this.closemouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("CloseBox"), Description("关闭按钮点击时背景")]
		public Image CloseDownBack
		{
			get
			{
				return this.closedownback;
			}
			set
			{
				if (this.closedownback != value)
				{
					this.closedownback = value;
					base.Invalidate();
				}
			}
		}
		[Category("CloseBox"), Description("关闭按钮初始时背景")]
		public Image CloseNormlBack
		{
			get
			{
				return this.closenormlback;
			}
			set
			{
				if (this.closenormlback != value)
				{
					this.closenormlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(false), Description("获取或设置窗体是否显示系统菜单")]
		public bool ShowSystemMenu
		{
			get
			{
				return this._showSystemMenu;
			}
			set
			{
				this._showSystemMenu = value;
			}
		}
		[Category("Skin"), DefaultValue(typeof(Point), "6, 0"), Description("设置或获取控制按钮的偏移")]
		public Point ControlBoxOffset
		{
			get
			{
				return this._controlBoxOffset;
			}
			set
			{
				if (this._controlBoxOffset != value)
				{
					this._controlBoxOffset = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(0), Description("设置或获取控制按钮的间距")]
		public int ControlBoxSpace
		{
			get
			{
				return this._controlBoxSpace;
			}
			set
			{
				if (this._controlBoxSpace != value)
				{
					this._controlBoxSpace = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(true), Description("设置或获取窗体是否可以改变大小")]
		public bool CanResize
		{
			get
			{
				return this._canResize;
			}
			set
			{
				this._canResize = value;
			}
		}
		[DefaultValue(typeof(Padding), "0")]
		public new Padding Padding
		{
			get
			{
				return this._padding;
			}
			set
			{
				this._padding = value;
				base.Padding = new Padding(this.BorderWidth + this._padding.Left, this.CaptionHeight + this._padding.Top, this.BorderWidth + this._padding.Right, this.BorderWidth + this._padding.Bottom);
			}
		}
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
		public new FormBorderStyle FormBorderStyle
		{
			get
			{
				return base.FormBorderStyle;
			}
			set
			{
				base.FormBorderStyle = FormBorderStyle.Sizable;
			}
		}
		protected override Padding DefaultPadding
		{
			get
			{
				return new Padding(this.BorderWidth, this.CaptionHeight, this.BorderWidth, this.BorderWidth);
			}
		}
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (!base.DesignMode)
				{
					createParams.Style |= 262144;
					if (base.ControlBox)
					{
						createParams.Style |= 524288;
					}
					if (base.MinimizeBox)
					{
						createParams.Style |= 131072;
					}
					if (!base.MaximizeBox)
					{
						createParams.Style &= -65537;
					}
					if (this._inPosChanged)
					{
						createParams.Style &= -786433;
						createParams.ExStyle &= -258;
					}
				}
				return createParams;
			}
		}
		public Rectangle CaptionRect
		{
			get
			{
				return new Rectangle(0, 0, base.Width, this.CaptionHeight);
			}
		}
		public ControlBoxManager ControlBoxManager
		{
			get
			{
				if (this._controlBoxManager == null)
				{
					this._controlBoxManager = new ControlBoxManager(this);
				}
				return this._controlBoxManager;
			}
		}
		public Rectangle IconRect
		{
			get
			{
				if (this.ShowDrawIcon && base.Icon != null)
				{
					int num = SystemInformation.SmallIconSize.Width;
					if (this.CaptionHeight - this.BorderWidth - 4 < num)
					{
						num = this.CaptionHeight - this.BorderWidth - 4;
					}
					return new Rectangle(this.BorderWidth, this.BorderWidth + (this.CaptionHeight - this.BorderWidth - num) / 2, num, num);
				}
				return Rectangle.Empty;
			}
		}
		public ToolTip ToolTip
		{
			get
			{
				return this._toolTip;
			}
		}
		protected Rectangle RealClientRect
		{
			get
			{
				if (base.WindowState == FormWindowState.Maximized)
				{
					return new Rectangle(this._deltaRect.X, this._deltaRect.Y, base.Width - this._deltaRect.Width, base.Height - this._deltaRect.Height);
				}
				return new Rectangle(Point.Empty, base.Size);
			}
		}
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleMode = AutoScaleMode.None;
			base.ClientSize = new Size(284, 262);
			this.FormBorderStyle = FormBorderStyle.None;
			base.Name = "SkinForm";
			this.Text = "SkinForm";
			base.ResumeLayout(false);
		}
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClassLong(IntPtr hwnd, int nIndex);
		public MainWinForm()
		{
			this.SetStyles();
			this.Init();
		}
		protected virtual void OnSysBottomClick(object e)
		{
			if (this.SysBottomClick != null)
			{
				this.SysBottomClick(this);
			}
		}
		public void SysbottomAv(object e)
		{
			this.OnSysBottomClick(e);
		}
		protected virtual void OnBackChanged(BackEventArgs e)
		{
			if (this.BackChanged != null)
			{
				this.BackChanged(this, e);
			}
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing(e);
			if (this.skin != null)
			{
				this.skin.Close();
			}
			if (this.Special)
			{
				base.Opacity = 1.0;
				NativeMethods.AnimateWindow(base.Handle, 150, 589824);
			}
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (base.Visible)
			{
				if (this.Special && !base.DesignMode)
				{
					NativeMethods.AnimateWindow(base.Handle, 150, 655360);
					base.Opacity = this.SkinOpacity;
				}
				if (!base.DesignMode && this.skin == null && this.Shadow)
				{
					this.skin = new CCSkinForm(this);
					this.skin.Show(this);
				}
				base.OnVisibleChanged(e);
				return;
			}
			base.OnVisibleChanged(e);
			if (this.Special)
			{
				base.Opacity = 1.0;
				NativeMethods.AnimateWindow(base.Handle, 150, 589824);
			}
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}
		protected virtual void OnRendererChanged(EventArgs e)
		{
			this.Renderer.InitSkinForm(this);
			EventHandler eventHandler = base.Events[MainWinForm.EventRendererChanged] as EventHandler;
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
			base.Invalidate();
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.SetReion();
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.SetReion();
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.ControlBoxManager.ProcessMouseOperate(e.Location, MouseOperate.Move);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			Point location = e.Location;
			if (e.Button == MouseButtons.Left)
			{
				if (!this.ControlBoxManager.CloseBoxRect.Contains(location) && !this.ControlBoxManager.MaximizeBoxRect.Contains(location) && !this.ControlBoxManager.MinimizeBoxRect.Contains(location) && !this.ControlBoxManager.SysBottomRect.Contains(location) && this.Mobile != MobileStyle.None)
				{
					this.isMouseDown = true;
					if (this.Mobile == MobileStyle.Mobile)
					{
						NativeMethods.ReleaseCapture();
						NativeMethods.SendMessage(base.Handle, 274, 61457, 0);
					}
					else
					{
						if (this.Mobile == MobileStyle.TitleMobile && location.Y < this.CaptionHeight)
						{
							NativeMethods.ReleaseCapture();
							NativeMethods.SendMessage(base.Handle, 274, 61457, 0);
						}
					}
					this.OnMouseUp(e);
				}
				else
				{
					this.ControlBoxManager.ProcessMouseOperate(e.Location, MouseOperate.Down);
				}
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.isMouseDown = false;
			base.OnMouseUp(e);
			this.ControlBoxManager.ProcessMouseOperate(e.Location, MouseOperate.Up);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.ControlBoxManager.ProcessMouseOperate(Point.Empty, MouseOperate.Leave);
		}
		protected override void OnMouseHover(EventArgs e)
		{
			base.OnMouseHover(e);
			this.ControlBoxManager.ProcessMouseOperate(base.PointToClient(Control.MousePosition), MouseOperate.Hover);
		}
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			this.mStopAnthor();
		}
		private void mStopAnthor()
		{
			if (base.Left <= 0)
			{
				this.Aanhor = AnchorStyles.Left;
				return;
			}
			if (base.Left >= Screen.PrimaryScreen.Bounds.Width - base.Width)
			{
				this.Aanhor = AnchorStyles.Right;
				return;
			}
			if (base.Top <= 0)
			{
				this.Aanhor = AnchorStyles.Top;
				return;
			}
			this.Aanhor = AnchorStyles.None;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			if (this.Back != null)
			{
				if (this.BackLayout)
				{
					graphics.DrawImage(this.Back, 0, 0, this.Back.Width, this.Back.Height);
				}
				else
				{
					graphics.DrawImage(this.Back, -(this.Back.Width - base.Width), 0, this.Back.Width, this.Back.Height);
				}
			}
			if (this.Back != null && this.BackToColor)
			{
				if (this.BackLayout)
				{
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Rectangle(this.Back.Width - 50, 0, 50, this.Back.Height), this.BackColor, Color.Transparent, 180f);
					LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Rectangle(0, this.Back.Height - 50, this.Back.Width, 50), this.BackColor, Color.Transparent, 270f);
					graphics.FillRectangle(linearGradientBrush, (float)this.Back.Width - linearGradientBrush.Rectangle.Width + 1f, 0f, linearGradientBrush.Rectangle.Width, linearGradientBrush.Rectangle.Height);
					graphics.FillRectangle(linearGradientBrush2, 0f, (float)this.Back.Height - linearGradientBrush2.Rectangle.Height + 1f, linearGradientBrush2.Rectangle.Width, linearGradientBrush2.Rectangle.Height);
				}
				else
				{
					LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(new Rectangle(-(this.Back.Width - base.Width), 0, 50, this.Back.Height), this.BackColor, Color.Transparent, 360f);
					LinearGradientBrush linearGradientBrush4 = new LinearGradientBrush(new Rectangle(-(this.Back.Width - base.Width), this.Back.Height - 50, this.Back.Width, 50), this.BackColor, Color.Transparent, 270f);
					graphics.FillRectangle(linearGradientBrush3, (float)(-(float)(this.Back.Width - base.Width)), 0f, linearGradientBrush3.Rectangle.Width, linearGradientBrush3.Rectangle.Height);
					graphics.FillRectangle(linearGradientBrush4, (float)(-(float)(this.Back.Width - base.Width)), (float)(this.Back.Height - 50), linearGradientBrush4.Rectangle.Width, linearGradientBrush4.Rectangle.Height);
				}
			}
			base.OnPaint(e);
			Rectangle clientRectangle = base.ClientRectangle;
			SkinFormRenderer renderer = this.Renderer;
			if (this.ControlBoxManager.CloseBoxVisibale)
			{
				renderer.DrawSkinFormControlBox(new SkinFormControlBoxRenderEventArgs(this, graphics, this.ControlBoxManager.CloseBoxRect, this._active, ControlBoxStyle.Close, this.ControlBoxManager.CloseBoxState));
			}
			if (this.ControlBoxManager.MaximizeBoxVisibale)
			{
				renderer.DrawSkinFormControlBox(new SkinFormControlBoxRenderEventArgs(this, graphics, this.ControlBoxManager.MaximizeBoxRect, this._active, ControlBoxStyle.Maximize, this.ControlBoxManager.MaximizeBoxState));
			}
			if (this.ControlBoxManager.MinimizeBoxVisibale)
			{
				renderer.DrawSkinFormControlBox(new SkinFormControlBoxRenderEventArgs(this, graphics, this.ControlBoxManager.MinimizeBoxRect, this._active, ControlBoxStyle.Minimize, this.ControlBoxManager.MinimizeBoxState));
			}
			if (this.ControlBoxManager.SysBottomVisibale)
			{
				renderer.DrawSkinFormControlBox(new SkinFormControlBoxRenderEventArgs(this, graphics, this.ControlBoxManager.SysBottomRect, this._active, ControlBoxStyle.SysBottom, this.ControlBoxManager.SysBottomState));
			}
			if (this.ShowBorder)
			{
				renderer.DrawSkinFormBorder(new SkinFormBorderRenderEventArgs(this, graphics, clientRectangle, this._active));
			}
			if (this.BackPalace != null)
			{
				ImageDrawRect.DrawRect(graphics, (Bitmap)this.BackPalace, new Rectangle(base.ClientRectangle.X - 5, base.ClientRectangle.Y - 5, base.ClientRectangle.Width + 10, base.ClientRectangle.Height + 10), Rectangle.FromLTRB(this.BackRectangle.X, this.BackRectangle.Y, this.BackRectangle.Width, this.BackRectangle.Height), 1, 1);
			}
			if (this.BorderPalace != null)
			{
				ImageDrawRect.DrawRect(graphics, (Bitmap)this.BorderPalace, new Rectangle(base.ClientRectangle.X - 5, base.ClientRectangle.Y - 5, base.ClientRectangle.Width + 10, base.ClientRectangle.Height + 10), Rectangle.FromLTRB(this.BorderRectangle.X, this.BorderRectangle.Y, this.BorderRectangle.Width, this.BorderRectangle.Height), 1, 1);
			}
			renderer.DrawSkinFormCaption(new SkinFormCaptionRenderEventArgs(this, graphics, this.CaptionRect, this._active));
		}
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg <= 71)
			{
				if (msg == 36)
				{
					this.WmGetMinMaxInfo(ref m);
					return;
				}
				if (msg == 71)
				{
					this._inPosChanged = true;
					base.WndProc(ref m);
					this._inPosChanged = false;
					return;
				}
			}
			else
			{
				switch (msg)
				{
				case 131:
				case 133:
					return;
				case 132:
					this.WmNcHitTest(ref m);
					return;
				case 134:
					this.WmNcActive(ref m);
					return;
				default:
					switch (msg)
					{
					case 174:
					case 175:
						m.Result = Result.TRUE;
						return;
					}
					break;
				}
			}
			base.WndProc(ref m);
		}
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (this._controlBoxManager != null)
				{
					this._controlBoxManager.Dispose();
					this._controlBoxManager = null;
				}
				this._renderer = null;
				this._toolTip.Dispose();
			}
		}
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if (this.DropBack)
			{
				string[] array = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
				FileInfo fileInfo = new FileInfo(array[0]);
				if (array != null)
				{
					string text = fileInfo.Extension.Substring(1);
					string[] array2 = new string[]
					{
						"png",
						"bmp",
						"jpg",
						"jpeg",
						"gif"
					};
					if (((IList)array2).Contains(text.ToLower()))
					{
						this.Back = Image.FromFile(array[0]);
					}
				}
			}
			base.OnDragDrop(drgevent);
		}
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (this.DropBack)
			{
				drgevent.Effect = DragDropEffects.Link;
			}
			base.OnDragEnter(drgevent);
		}
		private void WmNcHitTest(ref Message m)
		{
			Point point = new Point(m.LParam.ToInt32());
			point = base.PointToClient(point);
			if (this.IconRect.Contains(point) && this.ShowSystemMenu)
			{
				m.Result = new IntPtr(3);
				return;
			}
			if (!this._canResize)
			{
				base.WndProc(ref m);
				return;
			}
			if (point.X < 5 && point.Y < 5)
			{
				m.Result = new IntPtr(13);
				return;
			}
			if (point.X > base.Width - 5 && point.Y < 5)
			{
				m.Result = new IntPtr(14);
				return;
			}
			if (point.X < 5 && point.Y > base.Height - 5)
			{
				m.Result = new IntPtr(16);
				return;
			}
			if (point.X > base.Width - 5 && point.Y > base.Height - 5)
			{
				m.Result = new IntPtr(17);
				return;
			}
			if (point.Y < 3)
			{
				m.Result = new IntPtr(12);
				return;
			}
			if (point.Y > base.Height - 3)
			{
				m.Result = new IntPtr(15);
				return;
			}
			if (point.X < 3)
			{
				m.Result = new IntPtr(10);
				return;
			}
			if (point.X > base.Width - 3)
			{
				m.Result = new IntPtr(11);
				return;
			}
			base.WndProc(ref m);
		}
		private void WmGetMinMaxInfo(ref Message m)
		{
			MINMAXINFO mINMAXINFO = (MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(MINMAXINFO));
			if (this.MaximumSize != Size.Empty)
			{
				mINMAXINFO.maxTrackSize = this.MaximumSize;
			}
			else
			{
				Rectangle workingArea = Screen.GetWorkingArea(this);
				mINMAXINFO.maxPosition = new Point(workingArea.X - this.BorderWidth, workingArea.Y);
				mINMAXINFO.maxTrackSize = new Size(workingArea.Width + this.BorderWidth * 2, workingArea.Height + this.BorderWidth);
			}
			if (this.MinimumSize != Size.Empty)
			{
				mINMAXINFO.minTrackSize = this.MinimumSize;
			}
			else
			{
				mINMAXINFO.minTrackSize = new Size(this.CloseBoxSize.Width + this.MiniSize.Width + this.MaxSize.Width + this.ControlBoxOffset.X + this.ControlBoxSpace * 2 + SystemInformation.SmallIconSize.Width + this.BorderWidth * 2 + 3, this.CaptionHeight);
			}
			Marshal.StructureToPtr(mINMAXINFO, m.LParam, false);
		}
		private void WmNcActive(ref Message m)
		{
			if (m.WParam.ToInt32() == 1)
			{
				this._active = true;
			}
			else
			{
				this._active = false;
			}
			m.Result = Result.TRUE;
			base.Invalidate();
		}
		private void SetStyles()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
			base.AutoScaleMode = AutoScaleMode.None;
		}
		private void SetReion()
		{
			if (base.Region != null)
			{
				base.Region.Dispose();
			}
			UpdateForm.CreateRegion(this, this.RealClientRect, this.Radius, this.RoundStyle);
		}
		private void Init()
		{
			this._toolTip = new ToolTip();
			base.FormBorderStyle = FormBorderStyle.None;
			base.BackgroundImageLayout = ImageLayout.None;
			this.Renderer.InitSkinForm(this);
			base.Padding = this.DefaultPadding;
		}
	}
}
