using xingwaWinFormUI.SkinClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(Label))]
	public class SkinLabel : Label
	{
		private ArtTextStyle _artTextStyle = ArtTextStyle.Border;
		private int _borderSize = 1;
		private Color _borderColor = Color.White;
		[Browsable(true), Category("Skin"), DefaultValue(typeof(ArtTextStyle), "1"), Description("字体样式（None:正常样式,Border:边框样式,Relievo:浮雕样式,Forme:印版样式,Anamorphosis:渐变样式）")]
		public ArtTextStyle ArtTextStyle
		{
			get
			{
				return this._artTextStyle;
			}
			set
			{
				if (this._artTextStyle != value)
				{
					this._artTextStyle = value;
					base.Invalidate();
				}
			}
		}
		[Browsable(true), Category("Skin"), DefaultValue(1), Description("样式效果宽度")]
		public int BorderSize
		{
			get
			{
				return this._borderSize;
			}
			set
			{
				if (this._borderSize != value)
				{
					this._borderSize = value;
					base.Invalidate();
				}
			}
		}
		[Browsable(true), Category("Skin"), DefaultValue(typeof(Color), "80, 0, 0, 0"), Description("样式效果颜色")]
		public Color BorderColor
		{
			get
			{
				return this._borderColor;
			}
			set
			{
				if (this._borderColor != value)
				{
					this._borderColor = value;
					base.Invalidate();
				}
			}
		}
		public SkinLabel()
		{
			this.SetStyles();
			this.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.ArtTextStyle == ArtTextStyle.None)
			{
				base.OnPaint(e);
				return;
			}
			if (base.Text.Length == 0)
			{
				return;
			}
			this.RenderText(e.Graphics);
		}
		public string SetStrLeng(string txt, Font font, int width)
		{
			Size size = TextRenderer.MeasureText(txt, font);
			while (size.Width > width && txt.Length != 0)
			{
				txt = txt.Substring(0, txt.Length - 1);
				size = TextRenderer.MeasureText(txt, font);
			}
			return txt;
		}
		private void RenderText(Graphics g)
		{
			using (new TextRenderingHintGraphics(g))
			{
				PointF point = this.CalculateRenderTextStartPoint(g);
				switch (this._artTextStyle)
				{
				case ArtTextStyle.Border:
					this.RenderBordText(g, point);
					break;
				case ArtTextStyle.Relievo:
					this.RenderRelievoText(g, point);
					break;
				case ArtTextStyle.Forme:
					this.RenderFormeText(g, point);
					break;
				case ArtTextStyle.Anamorphosis:
					this.RenderAnamorphosisText(g, point);
					break;
				}
			}
		}
		private void RenderAnamorphosisText(Graphics g, PointF point)
		{
			using (new SolidBrush(base.ForeColor))
			{
				Rectangle rc = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), base.ClientRectangle.Size);
				Image image = UpdateForm.ImageLightEffect(this.Text, base.Font, this.ForeColor, this.BorderColor, this.BorderSize, rc, !this.AutoSize);
				g.DrawImage(image, point.X - (float)(this.BorderSize / 2), point.Y - (float)(this.BorderSize / 2));
			}
		}
		private void RenderFormeText(Graphics g, PointF point)
		{
			StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
			stringFormat.Trimming = (this.AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord);
			Rectangle r = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), base.ClientRectangle.Size);
			using (Brush brush = new SolidBrush(this._borderColor))
			{
				for (int i = 1; i <= this._borderSize; i++)
				{
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X - (float)i), Convert.ToInt32(point.Y + (float)i)), base.ClientRectangle.Size), stringFormat);
				}
			}
			using (Brush brush2 = new SolidBrush(base.ForeColor))
			{
				g.DrawString(this.Text, this.Font, brush2, r, stringFormat);
			}
		}
		private void RenderRelievoText(Graphics g, PointF point)
		{
			StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
			stringFormat.Trimming = (this.AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord);
			Rectangle r = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), base.ClientRectangle.Size);
			using (Brush brush = new SolidBrush(this._borderColor))
			{
				for (int i = 1; i <= this._borderSize; i++)
				{
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X + (float)i), Convert.ToInt32(point.Y)), base.ClientRectangle.Size), stringFormat);
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y + (float)i)), base.ClientRectangle.Size), stringFormat);
				}
			}
			using (Brush brush2 = new SolidBrush(base.ForeColor))
			{
				g.DrawString(this.Text, base.Font, brush2, r, stringFormat);
			}
		}
		private void RenderBordText(Graphics g, PointF point)
		{
			StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
			stringFormat.Trimming = (this.AutoSize ? StringTrimming.None : StringTrimming.EllipsisWord);
			Rectangle r = new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)), base.ClientRectangle.Size);
			using (Brush brush = new SolidBrush(this._borderColor))
			{
				for (int i = 1; i <= this._borderSize; i++)
				{
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X - (float)i), Convert.ToInt32(point.Y)), base.ClientRectangle.Size), stringFormat);
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y - (float)i)), base.ClientRectangle.Size), stringFormat);
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X + (float)i), Convert.ToInt32(point.Y)), base.ClientRectangle.Size), stringFormat);
					g.DrawString(this.Text, base.Font, brush, new Rectangle(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y + (float)i)), base.ClientRectangle.Size), stringFormat);
				}
			}
			using (Brush brush2 = new SolidBrush(base.ForeColor))
			{
				g.DrawString(this.Text, base.Font, brush2, r, stringFormat);
			}
		}
		private PointF CalculateRenderTextStartPoint(Graphics g)
		{
			PointF empty = PointF.Empty;
			SizeF sizeF = g.MeasureString(base.Text, base.Font, PointF.Empty, StringFormat.GenericTypographic);
			if (this.AutoSize)
			{
				empty.X = (float)base.Padding.Left;
				empty.Y = (float)base.Padding.Top;
			}
			else
			{
				ContentAlignment textAlign = base.TextAlign;
				if (textAlign == ContentAlignment.TopLeft || textAlign == ContentAlignment.MiddleLeft || textAlign == ContentAlignment.BottomLeft)
				{
					empty.X = (float)base.Padding.Left;
				}
				else
				{
					if (textAlign == ContentAlignment.TopCenter || textAlign == ContentAlignment.MiddleCenter || textAlign == ContentAlignment.BottomCenter)
					{
						empty.X = ((float)base.Width - sizeF.Width) / 2f;
					}
					else
					{
						empty.X = (float)base.Width - ((float)base.Padding.Right + sizeF.Width);
					}
				}
				if (textAlign == ContentAlignment.TopLeft || textAlign == ContentAlignment.TopCenter || textAlign == ContentAlignment.TopRight)
				{
					empty.Y = (float)base.Padding.Top;
				}
				else
				{
					if (textAlign == ContentAlignment.MiddleLeft || textAlign == ContentAlignment.MiddleCenter || textAlign == ContentAlignment.MiddleRight)
					{
						empty.Y = ((float)base.Height - sizeF.Height) / 2f;
					}
					else
					{
						empty.Y = (float)base.Height - ((float)base.Padding.Bottom + sizeF.Height);
					}
				}
			}
			return empty;
		}
		private void SetStyles()
		{
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			base.ResizeRedraw = true;
			this.BackColor = Color.Transparent;
			base.UpdateStyles();
		}
	}
}
