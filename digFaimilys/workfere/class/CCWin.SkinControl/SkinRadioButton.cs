using xingwaWinFormUI.SkinClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(RadioButton))]
	public class SkinRadioButton : RadioButton
	{
		private ControlState _controlState;
		private static readonly ContentAlignment RightAlignment = (ContentAlignment)1092;
		private static readonly ContentAlignment LeftAligbment = (ContentAlignment)273;
		private Color _baseColor = Color.FromArgb(51, 161, 224);
		private int defaultradiobuttonwidth = 12;
		private Image mouseback;
		private Image downback;
		private Image normlback;
		private Image selectedmouseback;
		private Image selectedownback;
		private Image selectenormlback;
		private bool lighteffect = true;
		private Color lighteffectback = Color.White;
		private int lighteffectWidth = 4;
		[Category("Skin"), DefaultValue(typeof(Color), "51, 161, 224"), Description("非图片绘制时RadioButton色调")]
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
		public int DefaultRadioButtonWidth
		{
			get
			{
				return this.defaultradiobuttonwidth;
			}
			set
			{
				if (this.defaultradiobuttonwidth != value)
				{
					this.defaultradiobuttonwidth = value;
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
		public SkinRadioButton()
		{
			this.Init();
			this.BackColor = Color.Transparent;
			this.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		}
		public void Init()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.ControlState = ControlState.Hover;
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.ControlState = ControlState.Normal;
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				this.ControlState = ControlState.Pressed;
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				if (base.ClientRectangle.Contains(e.Location))
				{
					this.ControlState = ControlState.Hover;
					return;
				}
				this.ControlState = ControlState.Normal;
			}
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
			bool flag = false;
			Color color;
			Color color2;
			Color centerColor;
			Bitmap bitmap;
			if (base.Enabled)
			{
				switch (this.ControlState)
				{
				case ControlState.Hover:
					color = this._baseColor;
					color2 = this._baseColor;
					centerColor = this.GetColor(this._baseColor, 0, 35, 24, 9);
					bitmap = (base.Checked ? ((Bitmap)this.SelectedMouseBack) : ((Bitmap)this.MouseBack));
					flag = true;
					break;
				case ControlState.Pressed:
					color = this._baseColor;
					color2 = this.GetColor(this._baseColor, 0, -13, -8, -3);
					centerColor = this.GetColor(this._baseColor, 0, -35, -24, -9);
					bitmap = (base.Checked ? ((Bitmap)this.SelectedDownBack) : ((Bitmap)this.DownBack));
					flag = true;
					break;
				default:
					color = this._baseColor;
					color2 = Color.Empty;
					centerColor = this._baseColor;
					bitmap = (base.Checked ? ((Bitmap)this.SelectedNormlBack) : ((Bitmap)this.NormlBack));
					break;
				}
			}
			else
			{
				color = SystemColors.ControlDark;
				color2 = SystemColors.ControlDark;
				centerColor = SystemColors.ControlDark;
				bitmap = (base.Checked ? ((Bitmap)this.SelectedNormlBack) : ((Bitmap)this.NormlBack));
			}
			if (bitmap == null)
			{
				using (SolidBrush solidBrush = new SolidBrush(Color.White))
				{
					graphics.FillEllipse(solidBrush, rect);
				}
				if (flag)
				{
					using (Pen pen = new Pen(color2, 2f))
					{
						graphics.DrawEllipse(pen, rect);
					}
				}
				if (base.Checked)
				{
					rect.Inflate(-2, -2);
					using (GraphicsPath graphicsPath = new GraphicsPath())
					{
						graphicsPath.AddEllipse(rect);
						using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
						{
							pathGradientBrush.CenterColor = centerColor;
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
									0.4f,
									1f
								}
							};
							graphics.FillEllipse(pathGradientBrush, rect);
						}
					}
					rect.Inflate(2, 2);
				}
				using (Pen pen2 = new Pen(color))
				{
					graphics.DrawEllipse(pen2, rect);
					goto IL_2C2;
				}
			}
			graphics.DrawImage(bitmap, rect);
			IL_2C2:
			Color color3 = base.Enabled ? this.ForeColor : SystemColors.GrayText;
			if (this.LightEffect)
			{
				Image image = UpdateForm.ImageLightEffect(this.Text, this.Font, color3, this.LightEffectBack, this.LightEffectWidth);
				graphics.DrawImage(image, rectangle);
				return;
			}
			TextRenderer.DrawText(graphics, this.Text, this.Font, rectangle, color3, SkinRadioButton.GetTextFormatFlags(this.TextAlign, this.RightToLeft == RightToLeft.Yes));
		}
		private void CalculateRect(out Rectangle radioButtonRect, out Rectangle textRect)
		{
			radioButtonRect = new Rectangle(0, 0, this.DefaultRadioButtonWidth, this.DefaultRadioButtonWidth);
			textRect = Rectangle.Empty;
			bool flag = (SkinRadioButton.LeftAligbment & base.CheckAlign) != (ContentAlignment)0;
			bool flag2 = (SkinRadioButton.RightAlignment & base.CheckAlign) != (ContentAlignment)0;
			bool flag3 = this.RightToLeft == RightToLeft.Yes;
			if ((flag && !flag3) || (flag2 && flag3))
			{
				ContentAlignment checkAlign = base.CheckAlign;
				if (checkAlign <= ContentAlignment.MiddleLeft)
				{
					if (checkAlign == ContentAlignment.TopLeft || checkAlign == ContentAlignment.TopRight)
					{
						radioButtonRect.Y = 2;
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
						radioButtonRect.Y = base.Height - this.DefaultRadioButtonWidth - 2;
						goto IL_CD;
					}
				}
				radioButtonRect.Y = (base.Height - this.DefaultRadioButtonWidth) / 2;
				IL_CD:
				radioButtonRect.X = 1;
				textRect = new Rectangle(radioButtonRect.Right + 2, 0, base.Width - radioButtonRect.Right - 4, base.Height);
				return;
			}
			if ((flag2 && !flag3) || (flag && flag3))
			{
				ContentAlignment checkAlign2 = base.CheckAlign;
				if (checkAlign2 <= ContentAlignment.MiddleLeft)
				{
					if (checkAlign2 == ContentAlignment.TopLeft || checkAlign2 == ContentAlignment.TopRight)
					{
						radioButtonRect.Y = 2;
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
						radioButtonRect.Y = base.Height - this.DefaultRadioButtonWidth - 2;
						goto IL_17F;
					}
				}
				radioButtonRect.Y = (base.Height - this.DefaultRadioButtonWidth) / 2;
				IL_17F:
				radioButtonRect.X = base.Width - this.DefaultRadioButtonWidth - 1;
				textRect = new Rectangle(2, 0, base.Width - this.DefaultRadioButtonWidth - 6, base.Height);
				return;
			}
			ContentAlignment checkAlign3 = base.CheckAlign;
			if (checkAlign3 != ContentAlignment.TopCenter)
			{
				if (checkAlign3 != ContentAlignment.MiddleCenter)
				{
					if (checkAlign3 == ContentAlignment.BottomCenter)
					{
						radioButtonRect.Y = base.Height - this.DefaultRadioButtonWidth - 2;
						textRect.Y = 0;
						textRect.Height = base.Height - this.DefaultRadioButtonWidth - 6;
					}
				}
				else
				{
					radioButtonRect.Y = (base.Height - this.DefaultRadioButtonWidth) / 2;
					textRect.Y = 0;
					textRect.Height = base.Height;
				}
			}
			else
			{
				radioButtonRect.Y = 2;
				textRect.Y = radioButtonRect.Bottom + 2;
				textRect.Height = base.Height - this.DefaultRadioButtonWidth - 6;
			}
			radioButtonRect.X = (base.Width - this.DefaultRadioButtonWidth) / 2;
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
	}
}
