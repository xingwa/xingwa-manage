using xingwaWinFormUI.SkinClass;
using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(ProgressBar))]
	public class SkinProgressBar : ProgressBar
	{
		private const int Internal = 10;
		private const int MarqueeWidth = 100;
		private BufferedGraphicsContext _context;
		private BufferedGraphics _bufferedGraphics;
		private bool _bPainting;
		private int _trackX = -100;
		private Timer _timer;
		private string _formatString = "{0:0.0%}";
		private bool barGlass = true;
		private bool glass = true;
		private BackStyle barBackStyle;
		private Size barMinusSize = new Size(1, 1);
		private bool txtShow = true;
		private int radius = 2;
		private RoundStyle radiusStyle = RoundStyle.All;
		private int barradius = 2;
		private RoundStyle barradiusStyle = RoundStyle.All;
		private Image back;
		private Image barBack;
		private Color _trackBack = Color.FromArgb(185, 185, 185);
		private Color _trackFore = Color.FromArgb(15, 181, 43);
		private Color _border = Color.FromArgb(158, 158, 158);
		private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
		[Category("Bar"), DefaultValue(typeof(bool), "true"), Description("滚动条是否启用颜色渐变")]
		public bool BarGlass
		{
			get
			{
				return this.barGlass;
			}
			set
			{
				if (this.barGlass != value)
				{
					this.barGlass = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "true"), Description("控件是否启用颜色渐变")]
		public bool Glass
		{
			get
			{
				return this.glass;
			}
			set
			{
				if (this.glass != value)
				{
					this.glass = value;
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), DefaultValue(typeof(BackStyle), "0"), Description("进度条的图像绘制模式")]
		public BackStyle BarBackStyle
		{
			get
			{
				return this.barBackStyle;
			}
			set
			{
				if (this.barBackStyle != value)
				{
					this.barBackStyle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), DefaultValue(typeof(Size), "1,1"), Description("自减宽高。")]
		public Size BarMinusSize
		{
			get
			{
				return this.barMinusSize;
			}
			set
			{
				if (this.barMinusSize != value)
				{
					this.barMinusSize = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "true"), Description("是否显示进度百分比")]
		public bool TxtShow
		{
			get
			{
				return this.txtShow;
			}
			set
			{
				if (this.txtShow != value)
				{
					this.txtShow = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(int), "2"), Description("控件圆角大小")]
		public int Radius
		{
			get
			{
				return this.radius;
			}
			set
			{
				if (this.radius != value)
				{
					this.radius = ((value < 1) ? 1 : value);
					this.SetRegion();
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(RoundStyle), "1"), Description("控件圆角样式")]
		public RoundStyle RadiusStyle
		{
			get
			{
				return this.radiusStyle;
			}
			set
			{
				if (this.radiusStyle != value)
				{
					this.radiusStyle = value;
					this.SetRegion();
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), DefaultValue(typeof(int), "2"), Description("进度条圆角大小")]
		public int BarRadius
		{
			get
			{
				return this.barradius;
			}
			set
			{
				if (this.barradius != value)
				{
					this.barradius = ((value < 1) ? 1 : value);
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), DefaultValue(typeof(RoundStyle), "1"), Description("进度条圆角样式")]
		public RoundStyle BarRadiusStyle
		{
			get
			{
				return this.barradiusStyle;
			}
			set
			{
				if (this.barradiusStyle != value)
				{
					this.barradiusStyle = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), Description("控件背景图片")]
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
					this.back = value;
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), Description("进度条图片")]
		public Image BarBack
		{
			get
			{
				return this.barBack;
			}
			set
			{
				if (this.barBack != value)
				{
					this.barBack = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue("{0:0.0%}")]
		public string FormatString
		{
			get
			{
				return this._formatString;
			}
			set
			{
				if (this._formatString != value)
				{
					this._formatString = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "185, 185, 185")]
		public Color TrackBack
		{
			get
			{
				return this._trackBack;
			}
			set
			{
				if (this._trackBack != value)
				{
					this._trackBack = value;
					base.Invalidate();
				}
			}
		}
		[Category("Bar"), DefaultValue(typeof(Color), "15, 181, 43")]
		public Color TrackFore
		{
			get
			{
				return this._trackFore;
			}
			set
			{
				if (this._trackFore != value)
				{
					this._trackFore = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "158, 158, 158")]
		public Color Border
		{
			get
			{
				return this._border;
			}
			set
			{
				if (this._border != value)
				{
					this._border = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "200, 250, 250, 250")]
		public Color InnerBorder
		{
			get
			{
				return this._innerBorder;
			}
			set
			{
				if (this._innerBorder != value)
				{
					this._innerBorder = value;
					base.Invalidate();
				}
			}
		}
		public new ProgressBarStyle Style
		{
			get
			{
				return base.Style;
			}
			set
			{
				if (base.Style != value)
				{
					base.Style = value;
					if (value == ProgressBarStyle.Marquee)
					{
						if (this._timer != null)
						{
							this._timer.Dispose();
						}
						this._timer = new Timer();
						this._timer.Interval = 10;
						this._timer.Tick += delegate(object sender, EventArgs e)
						{
							this._trackX += (int)Math.Ceiling((double)((float)base.Width / (float)base.MarqueeAnimationSpeed));
							if (this._trackX > base.Width)
							{
								this._trackX = -100;
							}
							base.Invalidate();
						};
						if (!base.DesignMode)
						{
							this._timer.Start();
							return;
						}
					}
					else
					{
						if (this._timer != null)
						{
							this._timer.Dispose();
							this._timer = null;
						}
					}
				}
			}
		}
		[Browsable(true)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}
		public SkinProgressBar()
		{
			this._context = BufferedGraphicsManager.Current;
			this._context.MaximumBuffer = new Size(base.Width + 1, base.Height + 1);
			this._bufferedGraphics = this._context.Allocate(base.CreateGraphics(), new Rectangle(Point.Empty, base.Size));
			this.ForeColor = Color.Red;
			base.ResizeRedraw = true;
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this.SetRegion();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.SetRegion();
			this._context.MaximumBuffer = new Size(base.Width + 1, base.Height + 1);
			if (this._bufferedGraphics != null)
			{
				this._bufferedGraphics.Dispose();
				this._bufferedGraphics = null;
			}
			this._bufferedGraphics = this._context.Allocate(base.CreateGraphics(), new Rectangle(Point.Empty, base.Size));
		}
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg != 15)
			{
				base.WndProc(ref m);
				return;
			}
			if (!this._bPainting)
			{
				this._bPainting = true;
				PAINTSTRUCT pAINTSTRUCT = default(PAINTSTRUCT);
				NativeMethods.BeginPaint(m.HWnd, ref pAINTSTRUCT);
				try
				{
					this.DrawProgressBar(m.HWnd);
				}
				catch
				{
				}
				NativeMethods.ValidateRect(m.HWnd, ref pAINTSTRUCT.rcPaint);
				NativeMethods.EndPaint(m.HWnd, ref pAINTSTRUCT);
				this._bPainting = false;
				m.Result = Result.TRUE;
				return;
			}
			base.WndProc(ref m);
		}
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				if (this._timer != null)
				{
					this._timer.Dispose();
					this._timer = null;
				}
				if (this._bufferedGraphics != null)
				{
					this._bufferedGraphics.Dispose();
					this._bufferedGraphics = null;
				}
				if (this._context != null)
				{
					this._context = null;
				}
			}
		}
		private void DrawProgressBar(IntPtr hWnd)
		{
			Graphics graphics = this._bufferedGraphics.Graphics;
			graphics.Clear(Color.Transparent);
			Rectangle rectangle = new Rectangle(Point.Empty, base.Size);
			bool flag = this.Style != ProgressBarStyle.Marquee || base.DesignMode;
			float basePosition = flag ? 0.3f : 0.45f;
			SmoothingModeGraphics smoothingModeGraphics = new SmoothingModeGraphics(graphics);
			if (this.Back != null)
			{
				Bitmap bitmap = new Bitmap(this.Back, base.Size);
				UpdateForm.CreateControlRegion(this, bitmap, 200);
				graphics.DrawImage(this.Back, rectangle);
			}
			else
			{
				RenderHelper.RenderBackgroundInternal(graphics, rectangle, this.TrackBack, this.Border, this.InnerBorder, this.RadiusStyle, this.Radius, basePosition, true, this.Glass, LinearGradientMode.Vertical);
			}
			Rectangle rectangle2 = rectangle;
			rectangle2.Inflate(-this.BarMinusSize.Width, -this.BarMinusSize.Height);
			if (flag)
			{
				rectangle2.Width = (int)((double)base.Value / (double)(base.Maximum - base.Minimum) * (double)rectangle2.Width);
				if (this.BarBack != null)
				{
					if (this.BarBackStyle == BackStyle.Tile)
					{
						using (TextureBrush textureBrush = new TextureBrush(this.BarBack))
						{
							textureBrush.WrapMode = WrapMode.Tile;
							graphics.FillRectangle(textureBrush, rectangle2);
							goto IL_19B;
						}
					}
					Bitmap image = new Bitmap(this.BarBack, base.Size);
					graphics.DrawImageUnscaledAndClipped(image, rectangle2);
				}
				else
				{
					RenderHelper.RenderBackgroundInternal(graphics, rectangle2, this.TrackFore, this.Border, this.InnerBorder, this.BarRadiusStyle, this.BarRadius, basePosition, false, this.BarGlass, LinearGradientMode.Vertical);
				}
				IL_19B:
				if (!string.IsNullOrEmpty(this._formatString) && this.TxtShow)
				{
					TextRenderer.DrawText(graphics, string.Format(this._formatString, (double)base.Value / (double)(base.Maximum - base.Minimum)), base.Font, rectangle, base.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
				}
			}
			else
			{
				GraphicsState gstate = graphics.Save();
				graphics.SetClip(rectangle2);
				rectangle2.X = this._trackX;
				rectangle2.Width = 100;
				using (GraphicsPath graphicsPath = new GraphicsPath())
				{
					graphicsPath.AddEllipse(rectangle2);
					graphics.SetClip(graphicsPath, CombineMode.Intersect);
				}
				RenderHelper.RenderBackgroundInternal(graphics, rectangle2, this.TrackFore, this.Border, this.InnerBorder, RoundStyle.None, 8, basePosition, false, this.BarGlass, LinearGradientMode.Vertical);
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle2, this.InnerBorder, Color.Transparent, 0f))
				{
					Blend blend = new Blend();
					Blend arg_2A0_0 = blend;
					float[] array = new float[3];
					array[1] = 1f;
					arg_2A0_0.Factors = array;
					blend.Positions = new float[]
					{
						0f,
						0.5f,
						1f
					};
					linearGradientBrush.Blend = blend;
					graphics.FillRectangle(linearGradientBrush, rectangle2);
				}
				graphics.Restore(gstate);
			}
			smoothingModeGraphics.Dispose();
			IntPtr dC = NativeMethods.GetDC(hWnd);
			this._bufferedGraphics.Render(dC);
			NativeMethods.ReleaseDC(hWnd, dC);
		}
		private void SetRegion()
		{
			RegionHelper.CreateRegion(this, new Rectangle(Point.Empty, base.Size), this.Radius, this.RadiusStyle);
		}
	}
}
