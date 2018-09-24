using xingwaWinFormUI.SkinClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(Button))]
	public class SkinButtom : Button
	{
		private DrawStyle drawType = DrawStyle.Draw;
		private Color _baseColor = Color.FromArgb(51, 161, 224);
		private int _imageWidth = 18;
		private RoundStyle _roundStyle;
		private ControlState _controlState;
		private bool palace;
		private bool create;
		private Rectangle backrectangle = new Rectangle(10, 10, 10, 10);
		private Image mouseback;
		private Image downback;
		private Image normlback;
		private int radius = 8;
		private ControlState states;
		private IContainer components;
		[Category("Skin"), DefaultValue(typeof(DrawStyle), "2"), Description("按钮的绘画模式")]
		public DrawStyle DrawType
		{
			get
			{
				return this.drawType;
			}
			set
			{
				if (this.drawType != value)
				{
					this.drawType = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "51, 161, 224"), Description("非图片绘制时Bottom色调")]
		public Color BaseColor
		{
			get
			{
				return this._baseColor;
			}
			set
			{
				this._baseColor = value;
				base.Invalidate();
			}
		}
		[Category("Skin"), DefaultValue(18), Description("设置或获取图像的大小")]
		public int ImageWidth
		{
			get
			{
				return this._imageWidth;
			}
			set
			{
				if (value != this._imageWidth)
				{
					this._imageWidth = ((value < 12) ? 12 : value);
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(RoundStyle), "0"), Description("设置或获取按钮圆角的样式")]
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
					base.Invalidate();
				}
			}
		}
		[Description("控件状态")]
		public ControlState ControlState
		{
			get
			{
				return this._controlState;
			}
			set
			{
				if (this._controlState != value)
				{
					this._controlState = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "false"), Description("是否开启九宫绘图")]
		public bool Palace
		{
			get
			{
				return this.palace;
			}
			set
			{
				if (this.palace != value)
				{
					this.palace = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "false"), Description("是否开启:根据所绘图限制控件范围")]
		public bool Create
		{
			get
			{
				return this.create;
			}
			set
			{
				if (this.create != value)
				{
					this.create = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Rectangle), "10,10,10,10"), Description("九宫绘画区域")]
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
				}
				base.Invalidate();
			}
		}
		[Category("MouseEnter"), Description("悬浮时背景")]
		public Image MouseBack
		{
			get
			{
				return this.mouseback;
			}
			set
			{
				if (this.mouseback != value)
				{
					this.mouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MouseDown"), Description("点击时背景")]
		public Image DownBack
		{
			get
			{
				return this.downback;
			}
			set
			{
				if (this.downback != value)
				{
					this.downback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MouseNorml"), Description("初始时背景")]
		public Image NormlBack
		{
			get
			{
				return this.normlback;
			}
			set
			{
				if (this.normlback != value)
				{
					this.normlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(int), "8"), Description("圆角大小")]
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
					this.radius = ((value < 4) ? 4 : value);
					base.Invalidate();
				}
			}
		}
		public SkinButtom()
		{
			this.Init();
			base.ResizeRedraw = true;
			this.BackColor = Color.Transparent;
		}
		public void Init()
		{
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.SetStyle(ControlStyles.StandardDoubleClick, false);
			base.SetStyle(ControlStyles.Selectable, true);
			base.UpdateStyles();
		}
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.Invalidate();
			base.OnEnabledChanged(e);
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			this._controlState = ControlState.Hover;
			base.Invalidate();
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			this._controlState = ControlState.Normal;
			base.Invalidate();
			base.OnMouseLeave(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
			{
				return;
			}
			this._controlState = ControlState.Pressed;
			base.Invalidate();
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				this._controlState = ControlState.Hover;
				base.Invalidate();
			}
			base.OnMouseUp(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.OnPaintBackground(e);
			Graphics graphics = e.Graphics;
			Rectangle clientRectangle = base.ClientRectangle;
			Rectangle destRect;
			Rectangle bounds;
			this.CalculateRect(out destRect, out bounds);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Color innerBorderColor = Color.FromArgb(200, 255, 255, 255);
			int num = 0;
			Bitmap bitmap;
			Color baseColor;
			Color borderColor;
			switch (this._controlState)
			{
			case ControlState.Hover:
				bitmap = (Bitmap)this.MouseBack;
				baseColor = this.GetColor(this._baseColor, 0, -13, -8, -3);
				borderColor = this._baseColor;
				break;
			case ControlState.Pressed:
				bitmap = (Bitmap)this.DownBack;
				baseColor = this.GetColor(this._baseColor, 0, -35, -24, -9);
				borderColor = this._baseColor;
				num = 1;
				break;
			default:
				bitmap = (Bitmap)this.NormlBack;
				baseColor = this._baseColor;
				borderColor = this._baseColor;
				break;
			}
			if (!base.Enabled)
			{
				baseColor = SystemColors.ControlDark;
				borderColor = SystemColors.ControlDark;
			}
			if (bitmap != null && this.DrawType == DrawStyle.Img)
			{
				UpdateForm.CreateRegion(this, clientRectangle, this.Radius, this.RoundStyle);
				if (this.Create && this._controlState != this.states)
				{
					UpdateForm.CreateControlRegion(this, bitmap, 1);
				}
				if (this.Palace)
				{
					xingwaWinFormUI.ImageDrawRect.DrawRect(graphics, bitmap, new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, clientRectangle.Height), Rectangle.FromLTRB(this.BackRectangle.X, this.BackRectangle.Y, this.BackRectangle.Width, this.BackRectangle.Height), 1, 1);
				}
				else
				{
					graphics.DrawImage(bitmap, 0, 0, base.Width, base.Height);
				}
			}
			else
			{
				if (this.DrawType == DrawStyle.Draw)
				{
					this.RenderBackgroundInternal(graphics, clientRectangle, baseColor, borderColor, innerBorderColor, this.RoundStyle, this.Radius, 0.35f, true, true, LinearGradientMode.Vertical);
				}
			}
			Size empty = Size.Empty;
			if (base.Image != null)
			{
				if (string.IsNullOrEmpty(this.Text))
				{
					Image image = base.Image;
					empty = new Size(image.Width, image.Height);
					clientRectangle.Inflate(-4, -4);
					if (empty.Width * empty.Height != 0)
					{
						Rectangle withinThis = clientRectangle;
						withinThis = xingwaWinFormUI.ImageDrawRect.HAlignWithin(empty, withinThis, base.ImageAlign);
						withinThis = xingwaWinFormUI.ImageDrawRect.VAlignWithin(empty, withinThis, base.ImageAlign);
						if (!base.Enabled)
						{
							ControlPaint.DrawImageDisabled(graphics, image, withinThis.Left, withinThis.Top, this.BackColor);
						}
						else
						{
							graphics.DrawImage(image, withinThis.Left + num, withinThis.Top + num, image.Width, image.Height);
						}
					}
				}
				else
				{
					graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
					graphics.DrawImage(base.Image, destRect, -num, -num, base.Image.Width, base.Image.Height, GraphicsUnit.Pixel);
				}
			}
			else
			{
				if (base.ImageList != null && base.ImageIndex != -1)
				{
					Image image = base.ImageList.Images[base.ImageIndex];
				}
			}
			Color foreColor = base.Enabled ? this.ForeColor : SystemColors.ControlDark;
			TextRenderer.DrawText(graphics, this.Text, this.Font, bounds, foreColor, SkinButtom.GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));
			this.states = this._controlState;
		}
		private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
		{
			imageRect = Rectangle.Empty;
			textRect = Rectangle.Empty;
			if (base.Image == null)
			{
				textRect = new Rectangle(2, 0, base.Width - 4, base.Height);
				return;
			}
			switch (base.TextImageRelation)
			{
			case TextImageRelation.Overlay:
				imageRect = new Rectangle(2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
				textRect = new Rectangle(2, 0, base.Width - 4, base.Height);
				break;
			case TextImageRelation.ImageAboveText:
				imageRect = new Rectangle((base.Width - this.ImageWidth) / 2, 2, this.ImageWidth, this.ImageWidth);
				textRect = new Rectangle(2, imageRect.Bottom, base.Width, base.Height - imageRect.Bottom - 2);
				break;
			case TextImageRelation.TextAboveImage:
				imageRect = new Rectangle((base.Width - this.ImageWidth) / 2, base.Height - this.ImageWidth - 2, this.ImageWidth, this.ImageWidth);
				textRect = new Rectangle(0, 2, base.Width, base.Height - imageRect.Y - 2);
				break;
			case TextImageRelation.ImageBeforeText:
				imageRect = new Rectangle(2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
				textRect = new Rectangle(imageRect.Right + 2, 0, base.Width - imageRect.Right - 4, base.Height);
				break;
			case TextImageRelation.TextBeforeImage:
				imageRect = new Rectangle(base.Width - this.ImageWidth - 2, (base.Height - this.ImageWidth) / 2, this.ImageWidth, this.ImageWidth);
				textRect = new Rectangle(2, 0, imageRect.X - 2, base.Height);
				break;
			}
			if (this.RightToLeft == RightToLeft.Yes)
			{
				imageRect.X = base.Width - imageRect.Right;
				textRect.X = base.Width - textRect.Right;
			}
		}
		public void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			if (drawBorder)
			{
				rect.Width--;
				rect.Height--;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
			{
				Color[] colors = new Color[]
				{
					this.GetColor(baseColor, 0, 35, 24, 9),
					this.GetColor(baseColor, 0, 13, 8, 3),
					baseColor,
					this.GetColor(baseColor, 0, 68, 69, 54)
				};
				linearGradientBrush.InterpolationColors = new ColorBlend
				{
					Positions = new float[]
					{
						0f,
						basePosition,
						basePosition + 0.05f,
						1f
					},
					Colors = colors
				};
				if (style != RoundStyle.None)
				{
					using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						g.FillPath(linearGradientBrush, graphicsPath);
					}
					if (baseColor.A > 80)
					{
						Rectangle rect2 = rect;
						if (mode == LinearGradientMode.Vertical)
						{
							rect2.Height = (int)((float)rect2.Height * basePosition);
						}
						else
						{
							rect2.Width = (int)((float)rect.Width * basePosition);
						}
						using (GraphicsPath graphicsPath2 = GraphicsPathHelper.CreatePath(rect2, roundWidth, RoundStyle.Top, false))
						{
							using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
							{
								g.FillPath(solidBrush, graphicsPath2);
							}
						}
					}
					if (drawGlass)
					{
						RectangleF glassRect = rect;
						if (mode == LinearGradientMode.Vertical)
						{
							glassRect.Y = (float)rect.Y + (float)rect.Height * basePosition;
							glassRect.Height = ((float)rect.Height - (float)rect.Height * basePosition) * 2f;
						}
						else
						{
							glassRect.X = (float)rect.X + (float)rect.Width * basePosition;
							glassRect.Width = ((float)rect.Width - (float)rect.Width * basePosition) * 2f;
						}
						this.DrawGlass(g, glassRect, 170, 0);
					}
					if (!drawBorder)
					{
						goto IL_413;
					}
					using (GraphicsPath graphicsPath3 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						using (Pen pen = new Pen(borderColor))
						{
							g.DrawPath(pen, graphicsPath3);
						}
					}
					rect.Inflate(-1, -1);
					using (GraphicsPath graphicsPath4 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						using (Pen pen2 = new Pen(innerBorderColor))
						{
							g.DrawPath(pen2, graphicsPath4);
						}
						goto IL_413;
					}
				}
				g.FillRectangle(linearGradientBrush, rect);
				if (baseColor.A > 80)
				{
					Rectangle rect3 = rect;
					if (mode == LinearGradientMode.Vertical)
					{
						rect3.Height = (int)((float)rect3.Height * basePosition);
					}
					else
					{
						rect3.Width = (int)((float)rect.Width * basePosition);
					}
					using (SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
					{
						g.FillRectangle(solidBrush2, rect3);
					}
				}
				if (drawGlass)
				{
					RectangleF glassRect2 = rect;
					if (mode == LinearGradientMode.Vertical)
					{
						glassRect2.Y = (float)rect.Y + (float)rect.Height * basePosition;
						glassRect2.Height = ((float)rect.Height - (float)rect.Height * basePosition) * 2f;
					}
					else
					{
						glassRect2.X = (float)rect.X + (float)rect.Width * basePosition;
						glassRect2.Width = ((float)rect.Width - (float)rect.Width * basePosition) * 2f;
					}
					this.DrawGlass(g, glassRect2, 200, 0);
				}
				if (drawBorder)
				{
					using (Pen pen3 = new Pen(borderColor))
					{
						g.DrawRectangle(pen3, rect);
					}
					rect.Inflate(-1, -1);
					using (Pen pen4 = new Pen(innerBorderColor))
					{
						g.DrawRectangle(pen4, rect);
					}
				}
				IL_413:;
			}
		}
		private void DrawGlass(Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
		{
			this.DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
		}
		private void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(glassRect);
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
					pathGradientBrush.SurroundColors = new Color[]
					{
						Color.FromArgb(alphaSurround, glassColor)
					};
					pathGradientBrush.CenterPoint = new PointF(glassRect.X + glassRect.Width / 2f, glassRect.Y + glassRect.Height / 2f);
					g.FillPath(pathGradientBrush, graphicsPath);
				}
			}
		}
		private Color GetColor(Color colorBase, int a, int r, int g, int b)
		{
			int a2 = (int)colorBase.A;
			int r2 = (int)colorBase.R;
			int g2 = (int)colorBase.G;
			int b2 = (int)colorBase.B;
			if (a + a2 > 255)
			{
				a = 255;
			}
			else
			{
				a = Math.Max(a + a2, 0);
			}
			if (r + r2 > 255)
			{
				r = 255;
			}
			else
			{
				r = Math.Max(r + r2, 0);
			}
			if (g + g2 > 255)
			{
				g = 255;
			}
			else
			{
				g = Math.Max(g + g2, 0);
			}
			if (b + b2 > 255)
			{
				b = 255;
			}
			else
			{
				b = Math.Max(b + b2, 0);
			}
			return Color.FromArgb(a, r, g, b);
		}
		public static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
		{
			TextFormatFlags textFormatFlags = TextFormatFlags.SingleLine | TextFormatFlags.WordBreak;
			if (rightToleft)
			{
				textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.RightToLeft);
			}
			if (alignment <= ContentAlignment.MiddleCenter)
			{
				switch (alignment)
				{
				case ContentAlignment.TopLeft:
					textFormatFlags = textFormatFlags;
					break;
				case ContentAlignment.TopCenter:
					textFormatFlags |= TextFormatFlags.HorizontalCenter;
					break;
				case (ContentAlignment)3:
					break;
				case ContentAlignment.TopRight:
					textFormatFlags |= TextFormatFlags.Right;
					break;
				default:
					if (alignment != ContentAlignment.MiddleLeft)
					{
						if (alignment == ContentAlignment.MiddleCenter)
						{
							textFormatFlags |= (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
						}
					}
					else
					{
						textFormatFlags |= TextFormatFlags.VerticalCenter;
					}
					break;
				}
			}
			else
			{
				if (alignment <= ContentAlignment.BottomLeft)
				{
					if (alignment != ContentAlignment.MiddleRight)
					{
						if (alignment == ContentAlignment.BottomLeft)
						{
							textFormatFlags |= TextFormatFlags.Bottom;
						}
					}
					else
					{
						textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
					}
				}
				else
				{
					if (alignment != ContentAlignment.BottomCenter)
					{
						if (alignment == ContentAlignment.BottomRight)
						{
							textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.Right);
						}
					}
					else
					{
						textFormatFlags |= (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);
					}
				}
			}
			return textFormatFlags;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
	}
}
