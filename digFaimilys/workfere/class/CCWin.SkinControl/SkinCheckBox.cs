using xingwaWinFormUI.SkinClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(CheckBox))]
	public class SkinCheckBox : CheckBox
	{
		private ControlState _controlState;
		private static readonly ContentAlignment RightAlignment = (ContentAlignment)1092;
		private static readonly ContentAlignment LeftAligbment = (ContentAlignment)273;
		private Color _baseColor = Color.FromArgb(51, 161, 224);
		private int defaultcheckbuttonwidth = 12;
		private Image mouseback;
		private Image downback;
		private Image normlback;
		private Image selectedmouseback;
		private Image selectedownback;
		private Image selectenormlback;
		private bool lighteffect = true;
		private Color lighteffectback = Color.White;
		private int lighteffectWidth = 4;
		private IContainer components;
		[Category("Skin"), DefaultValue(typeof(Color), "51, 161, 224"), Description("非图片绘制时CheckBox色调")]
		public Color BaseColor
		{
			get
			{
				return this._baseColor;
			}
			set
			{
				if (this._baseColor != value)
				{
					this._baseColor = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(12), Description("选择框大小")]
		public int DefaultCheckButtonWidth
		{
			get
			{
				return this.defaultcheckbuttonwidth;
			}
			set
			{
				if (this.defaultcheckbuttonwidth != value)
				{
					this.defaultcheckbuttonwidth = value;
					base.Invalidate();
				}
			}
		}
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
		[Category("MouseEnter"), Description("悬浮时图像")]
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
		[Category("MouseDown"), Description("点击时图像")]
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
		[Category("MouseNorml"), Description("初始时图像")]
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
		[Category("MouseEnter"), Description("选中悬浮时图像")]
		public Image SelectedMouseBack
		{
			get
			{
				return this.selectedmouseback;
			}
			set
			{
				if (this.selectedmouseback != value)
				{
					this.selectedmouseback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MouseDown"), Description("选中点击时图像")]
		public Image SelectedDownBack
		{
			get
			{
				return this.selectedownback;
			}
			set
			{
				if (this.selectedownback != value)
				{
					this.selectedownback = value;
					base.Invalidate();
				}
			}
		}
		[Category("MouseNorml"), Description("选中初始时图像")]
		public Image SelectedNormlBack
		{
			get
			{
				return this.selectenormlback;
			}
			set
			{
				if (this.selectenormlback != value)
				{
					this.selectenormlback = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "true"), Description("是否绘制发光字体")]
		public bool LightEffect
		{
			get
			{
				return this.lighteffect;
			}
			set
			{
				if (this.lighteffect != value)
				{
					this.lighteffect = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "White"), Description("发光字体背景色")]
		public Color LightEffectBack
		{
			get
			{
				return this.lighteffectback;
			}
			set
			{
				if (this.lighteffectback != value)
				{
					this.lighteffectback = value;
					base.Invalidate();
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(int), "4"), Description("光圈大小")]
		public int LightEffectWidth
		{
			get
			{
				return this.lighteffectWidth;
			}
			set
			{
				if (this.lighteffectWidth != value)
				{
					this.lighteffectWidth = value;
					base.Invalidate();
				}
			}
		}
		public SkinCheckBox()
		{
			this.Init();
			base.ResizeRedraw = true;
			this.BackColor = Color.Transparent;
			this.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		}
		public void Init()
		{
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.UpdateStyles();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			this.ControlState = ControlState.Hover;
			base.Invalidate();
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			this.ControlState = ControlState.Normal;
			base.Invalidate();
			base.OnMouseLeave(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
			{
				return;
			}
			this.ControlState = ControlState.Pressed;
			base.Invalidate();
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				if (base.ClientRectangle.Contains(e.Location))
				{
					this.ControlState = ControlState.Hover;
				}
				else
				{
					this.ControlState = ControlState.Normal;
				}
			}
			base.Invalidate();
			base.OnMouseUp(e);
		}
		protected override void OnEnter(EventArgs e)
		{
			this.ControlState = ControlState.Focused;
			base.OnEnter(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.OnPaintBackground(e);
			Graphics graphics = e.Graphics;
			Rectangle rect;
			Rectangle rectangle;
			this.CalculateRect(out rect, out rectangle);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			ControlPaint.Light(this._baseColor);
			bool flag = false;
			Color color;
			Color color2;
			Color color3;
			Bitmap bitmap;
			if (base.Enabled)
			{
				switch (this.ControlState)
				{
				case ControlState.Hover:
					color = this._baseColor;
					color2 = this._baseColor;
					color3 = this.GetColor(this._baseColor, 0, 35, 24, 9);
					bitmap = (base.Checked ? ((Bitmap)this.SelectedMouseBack) : ((Bitmap)this.MouseBack));
					flag = true;
					break;
				case ControlState.Pressed:
					color = this._baseColor;
					color2 = this.GetColor(this._baseColor, 0, -13, -8, -3);
					color3 = this.GetColor(this._baseColor, 0, -35, -24, -9);
					bitmap = (base.Checked ? ((Bitmap)this.SelectedDownBack) : ((Bitmap)this.DownBack));
					flag = true;
					break;
				default:
					color = this._baseColor;
					color2 = Color.Empty;
					color3 = this._baseColor;
					bitmap = (base.Checked ? ((Bitmap)this.SelectedNormlBack) : ((Bitmap)this.NormlBack));
					break;
				}
			}
			else
			{
				color = SystemColors.ControlDark;
				color2 = SystemColors.ControlDark;
				color3 = SystemColors.ControlDark;
				bitmap = (base.Checked ? ((Bitmap)this.SelectedNormlBack) : ((Bitmap)this.NormlBack));
			}
			if (bitmap == null)
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.White))
				{
					graphics.FillRectangle(solidBrush, rect);
				}
				if (flag)
				{
					using (Pen pen = new Pen(color2, 2f))
					{
						graphics.DrawRectangle(pen, rect);
					}
				}
				switch (base.CheckState)
				{
				case CheckState.Checked:
					this.DrawCheckedFlag(graphics, rect, color3);
					break;
				case CheckState.Indeterminate:
					rect.Inflate(-1, -1);
					using (GraphicsPath graphicsPath = new GraphicsPath())
					{
						graphicsPath.AddEllipse(rect);
						using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
						{
							pathGradientBrush.CenterColor = color3;
							pathGradientBrush.SurroundColors = new Color[]
							{
								Color.White
							};
							pathGradientBrush.Blend = new Blend
							{
								Positions = new float[]
								{
									0f,
									0.4f,
									1f
								},
								Factors = new float[]
								{
									0f,
									0.3f,
									1f
								}
							};
							graphics.FillEllipse(pathGradientBrush, rect);
						}
					}
					rect.Inflate(1, 1);
					break;
				}
				using (Pen pen2 = new Pen(color))
				{
					graphics.DrawRectangle(pen2, rect);
					goto IL_2EE;
				}
			}
			graphics.DrawImage(bitmap, rect);
			IL_2EE:
			Color color4 = base.Enabled ? this.ForeColor : SystemColors.GrayText;
			if (this.LightEffect)
			{
				Image image = UpdateForm.ImageLightEffect(this.Text, this.Font, color4, this.LightEffectBack, this.LightEffectWidth);
				graphics.DrawImage(image, rectangle);
				return;
			}
			TextRenderer.DrawText(graphics, this.Text, this.Font, rectangle, color4, SkinCheckBox.GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));
		}
		private void DrawCheckedFlag(Graphics graphics, Rectangle rect, Color color)
		{
			PointF[] points = new PointF[]
			{
				new PointF((float)rect.X + (float)rect.Width / 4.5f, (float)rect.Y + (float)rect.Height / 2.5f),
				new PointF((float)rect.X + (float)rect.Width / 2.5f, (float)rect.Bottom - (float)rect.Height / 3f),
				new PointF((float)rect.Right - (float)rect.Width / 4f, (float)rect.Y + (float)rect.Height / 4.5f)
			};
			using (Pen pen = new Pen(color, 2f))
			{
				graphics.DrawLines(pen, points);
			}
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
		private void CalculateRect(out Rectangle checkButtonRect, out Rectangle textRect)
		{
			checkButtonRect = new Rectangle(0, 0, this.DefaultCheckButtonWidth, this.DefaultCheckButtonWidth);
			textRect = Rectangle.Empty;
			bool flag = (SkinCheckBox.LeftAligbment & base.CheckAlign) != (ContentAlignment)0;
			bool flag2 = (SkinCheckBox.RightAlignment & base.CheckAlign) != (ContentAlignment)0;
			bool flag3 = this.RightToLeft == RightToLeft.Yes;
			if ((flag && !flag3) || (flag2 && flag3))
			{
				ContentAlignment checkAlign = base.CheckAlign;
				if (checkAlign <= ContentAlignment.MiddleLeft)
				{
					if (checkAlign == ContentAlignment.TopLeft || checkAlign == ContentAlignment.TopRight)
					{
						checkButtonRect.Y = 2;
						goto IL_CD;
					}
					if (checkAlign != ContentAlignment.MiddleLeft)
					{
						goto IL_CD;
					}
				}
				else
				{
					if (checkAlign != ContentAlignment.MiddleRight)
					{
						if (checkAlign != ContentAlignment.BottomLeft && checkAlign != ContentAlignment.BottomRight)
						{
							goto IL_CD;
						}
						checkButtonRect.Y = base.Height - this.DefaultCheckButtonWidth - 2;
						goto IL_CD;
					}
				}
				checkButtonRect.Y = (base.Height - this.DefaultCheckButtonWidth) / 2;
				IL_CD:
				checkButtonRect.X = 1;
				textRect = new Rectangle(checkButtonRect.Right + 2, 0, base.Width - checkButtonRect.Right - 4, base.Height);
				return;
			}
			if ((flag2 && !flag3) || (flag && flag3))
			{
				ContentAlignment checkAlign2 = base.CheckAlign;
				if (checkAlign2 <= ContentAlignment.MiddleLeft)
				{
					if (checkAlign2 == ContentAlignment.TopLeft || checkAlign2 == ContentAlignment.TopRight)
					{
						checkButtonRect.Y = 2;
						goto IL_17F;
					}
					if (checkAlign2 != ContentAlignment.MiddleLeft)
					{
						goto IL_17F;
					}
				}
				else
				{
					if (checkAlign2 != ContentAlignment.MiddleRight)
					{
						if (checkAlign2 != ContentAlignment.BottomLeft && checkAlign2 != ContentAlignment.BottomRight)
						{
							goto IL_17F;
						}
						checkButtonRect.Y = base.Height - this.DefaultCheckButtonWidth - 2;
						goto IL_17F;
					}
				}
				checkButtonRect.Y = (base.Height - this.DefaultCheckButtonWidth) / 2;
				IL_17F:
				checkButtonRect.X = base.Width - this.DefaultCheckButtonWidth - 1;
				textRect = new Rectangle(2, 0, base.Width - this.DefaultCheckButtonWidth - 6, base.Height);
				return;
			}
			ContentAlignment checkAlign3 = base.CheckAlign;
			if (checkAlign3 != ContentAlignment.TopCenter)
			{
				if (checkAlign3 != ContentAlignment.MiddleCenter)
				{
					if (checkAlign3 == ContentAlignment.BottomCenter)
					{
						checkButtonRect.Y = base.Height - this.DefaultCheckButtonWidth - 2;
						textRect.Y = 0;
						textRect.Height = base.Height - this.DefaultCheckButtonWidth - 6;
					}
				}
				else
				{
					checkButtonRect.Y = (base.Height - this.DefaultCheckButtonWidth) / 2;
					textRect.Y = 0;
					textRect.Height = base.Height;
				}
			}
			else
			{
				checkButtonRect.Y = 2;
				textRect.Y = checkButtonRect.Bottom + 2;
				textRect.Height = base.Height - this.DefaultCheckButtonWidth - 6;
			}
			checkButtonRect.X = (base.Width - this.DefaultCheckButtonWidth) / 2;
			textRect.X = 2;
			textRect.Width = base.Width - 4;
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
