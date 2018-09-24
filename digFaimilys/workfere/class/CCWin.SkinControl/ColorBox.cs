using workfere.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	internal class ColorBox : Control
	{
		public delegate void ColorChangedHandler(object sender, ColorChangedEventArgs e);
		private IContainer components;
		private Color selectedColor;
		private Point m_ptCurrent;
		private Rectangle m_rectSelected;
		private Bitmap m_clrImage = Resources.color;
		private Color m_lastColor;
		public event ColorBox.ColorChangedHandler ColorChanged;
		public Color SelectedColor
		{
			get
			{
				return this.selectedColor;
			}
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
			base.SuspendLayout();
			base.Name = "ColorBox";
			base.Size = new Size(203, 50);
			base.ResumeLayout(false);
		}
		public ColorBox()
		{
			this.InitializeComponent();
			this.selectedColor = Color.Red;
			this.m_rectSelected = new Rectangle(-100, -100, 14, 14);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}
		protected virtual void OnColorChanged(ColorChangedEventArgs e)
		{
			if (this.ColorChanged != null)
			{
				this.ColorChanged(this, e);
			}
		}
		protected override void OnClick(EventArgs e)
		{
			Color pixel = this.m_clrImage.GetPixel(this.m_ptCurrent.X, this.m_ptCurrent.Y);
			if (pixel.ToArgb() != Color.FromArgb(255, 254, 254, 254).ToArgb() && pixel.ToArgb() != Color.FromArgb(255, 133, 141, 151).ToArgb() && pixel.ToArgb() != Color.FromArgb(255, 110, 126, 149).ToArgb())
			{
				if (this.selectedColor != pixel)
				{
					this.selectedColor = pixel;
				}
				base.Invalidate();
				this.OnColorChanged(new ColorChangedEventArgs(pixel));
			}
			base.OnClick(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			this.m_ptCurrent = e.Location;
			try
			{
				Color pixel = this.m_clrImage.GetPixel(this.m_ptCurrent.X, this.m_ptCurrent.Y);
				if (pixel != this.m_lastColor)
				{
					if (pixel.ToArgb() != Color.FromArgb(255, 254, 254, 254).ToArgb() && pixel.ToArgb() != Color.FromArgb(255, 133, 141, 151).ToArgb() && pixel.ToArgb() != Color.FromArgb(255, 110, 126, 149).ToArgb() && e.X > 39)
					{
						this.m_rectSelected.Y = ((e.Y > 17) ? 17 : 2);
						this.m_rectSelected.X = (e.X - 39) / 15 * 15 + 38;
						base.Invalidate();
					}
					else
					{
						this.m_rectSelected.X = (this.m_rectSelected.Y = -100);
						base.Invalidate();
					}
				}
				this.m_lastColor = pixel;
			}
			finally
			{
				base.OnMouseMove(e);
			}
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			this.m_rectSelected.X = (this.m_rectSelected.Y = -100);
			base.Invalidate();
			base.OnMouseLeave(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			graphics.DrawImage(Resources.color, new Rectangle(0, 0, 165, 35));
			graphics.DrawRectangle(Pens.SteelBlue, 0, 0, 164, 34);
			SolidBrush brush = new SolidBrush(this.selectedColor);
			graphics.FillRectangle(brush, 9, 5, 24, 24);
			graphics.DrawRectangle(Pens.DarkCyan, this.m_rectSelected);
			base.OnPaint(e);
		}
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			base.SetBoundsCore(x, y, 165, 35, specified);
		}
	}
}
