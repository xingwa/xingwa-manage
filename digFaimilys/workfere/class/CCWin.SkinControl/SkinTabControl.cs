using workfere.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(TabControl))]
	public class SkinTabControl : TabControl
	{
		private Image _titleBackground = Resources.main_tab_highlighttwo;
		private Color _baseColor = Color.White;
		private Color _backColor = Color.Transparent;
		private Color _borderColor = Color.White;
		private Color _pageColor = Color.White;
		private bool _isFocus;
		private Rectangle _btnArrowRect = Rectangle.Empty;
		private Image Icon;
		[Category("Skin"), DefaultValue(typeof(Color), "102, 180, 228")]
		public Color BaseColor
		{
			get
			{
				return this._baseColor;
			}
			set
			{
				this._baseColor = value;
				base.Invalidate(true);
			}
		}
		[Browsable(true), Category("Skin"), DefaultValue(typeof(Color), "Transparent")]
		public override Color BackColor
		{
			get
			{
				return this._backColor;
			}
			set
			{
				this._backColor = value;
				base.Invalidate(true);
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "102, 180, 228")]
		public Color BorderColor
		{
			get
			{
				return this._borderColor;
			}
			set
			{
				this._borderColor = value;
				base.Invalidate(true);
			}
		}
		[Category("Skin"), Description("所有TabPage的背景颜色")]
		public Color PageColor
		{
			get
			{
				return this._pageColor;
			}
			set
			{
				this._pageColor = value;
				if (base.TabPages.Count > 0)
				{
					for (int i = 0; i < base.TabPages.Count; i++)
					{
						base.TabPages[i].BackColor = this._pageColor;
					}
				}
				base.Invalidate(true);
			}
		}
		public SkinTabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(70, 36);
			base.UpdateStyles();
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
			graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			this.DrawBackground(graphics);
			this.DrawTabPages(graphics);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!base.DesignMode && e.Button == MouseButtons.Left && this._btnArrowRect.Contains(e.Location))
			{
				this._isFocus = true;
				base.Invalidate(this._btnArrowRect);
			}
		}
		protected override void WndProc(ref Message m)
		{
			if (m.Msg != 123)
			{
				base.WndProc(ref m);
			}
		}
		private void DrawBackground(Graphics g)
		{
			int arg_0E_0 = base.ClientRectangle.Width;
			int arg_1D_0 = base.ClientRectangle.Height;
			int arg_2D_0 = this.DisplayRectangle.Height;
			Color color = base.Enabled ? this._backColor : SystemColors.Control;
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				g.FillRectangle(solidBrush, base.ClientRectangle);
			}
		}
		private void DrawImage(Graphics g, Image image, Rectangle rect)
		{
			g.DrawImage(image, new Rectangle(rect.X, rect.Y, 5, rect.Height), 0, 0, 5, image.Height, GraphicsUnit.Pixel);
			g.DrawImage(image, new Rectangle(rect.X + 5, rect.Y, rect.Width - 10, rect.Height), 5, 0, image.Width - 10, image.Height, GraphicsUnit.Pixel);
			g.DrawImage(image, new Rectangle(rect.X + rect.Width - 5, rect.Y, 5, rect.Height), image.Width - 5, 0, 5, image.Height, GraphicsUnit.Pixel);
		}
		private void DrawTabPages(Graphics g)
		{
			using (SolidBrush solidBrush = new SolidBrush(this._pageColor))
			{
				int x = 2;
				int height = base.ItemSize.Height;
				int num = base.Width - 2;
				int num2 = base.Height - base.ItemSize.Height;
				g.FillRectangle(solidBrush, x, height, num, num2);
				g.DrawRectangle(new Pen(this._borderColor), x, height, num - 1, num2 - 1);
			}
			Rectangle rectangle = Rectangle.Empty;
			Point pt = base.PointToClient(Control.MousePosition);
			for (int i = 0; i < base.TabCount; i++)
			{
				TabPage tabPage = base.TabPages[i];
				rectangle = base.GetTabRect(i);
				Color arg_AB_0 = Color.Yellow;
				this.Icon = ((base.TabPages[i].ImageIndex != -1 && base.ImageList != null) ? base.ImageList.Images[base.TabPages[i].ImageIndex] : null);
				Image image = null;
				Image image2 = null;
				if (base.SelectedIndex == i)
				{
					image = Resources.tab_dots_down;
					Point screenLocation = base.PointToScreen(new Point(this._btnArrowRect.Left, this._btnArrowRect.Top + this._btnArrowRect.Height + 5));
					ContextMenuStrip contextMenuStrip = base.TabPages[i].ContextMenuStrip;
					if (contextMenuStrip != null)
					{
						contextMenuStrip.Closed -= new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
						contextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
						if (screenLocation.X + contextMenuStrip.Width > Screen.PrimaryScreen.WorkingArea.Width - 20)
						{
							screenLocation.X = Screen.PrimaryScreen.WorkingArea.Width - contextMenuStrip.Width - 50;
						}
						if (rectangle.Contains(pt))
						{
							if (this._isFocus)
							{
								image2 = Resources.tab_dots_down;
								contextMenuStrip.Show(screenLocation);
							}
							else
							{
								image2 = Resources.tab_dots_normal;
							}
							this._btnArrowRect = new Rectangle(rectangle.X + rectangle.Width - image2.Width, rectangle.Y, image2.Width, image2.Height);
						}
						else
						{
							if (this._isFocus)
							{
								image2 = Resources.tab_dots_down;
								contextMenuStrip.Show(screenLocation);
							}
						}
					}
				}
				else
				{
					if (rectangle.Contains(pt))
					{
						image = Resources.tab_dots_mouseover;
					}
				}
				if (image != null)
				{
					if (base.SelectedIndex == i)
					{
						if (base.SelectedIndex == base.TabCount - 1)
						{
							rectangle.Inflate(2, 0);
						}
						else
						{
							rectangle.Inflate(1, 0);
						}
					}
					this.DrawImage(g, image, rectangle);
					if (image2 != null)
					{
						g.DrawImage(image2, this._btnArrowRect);
					}
				}
				if (this.Icon != null)
				{
					g.DrawImage(this.Icon, rectangle.X + (rectangle.Width - this.Icon.Width) / 2, rectangle.Y + (rectangle.Height - this.Icon.Height) / 2);
				}
				TextRenderer.DrawText(g, tabPage.Text, tabPage.Font, rectangle, tabPage.ForeColor);
			}
		}
		private void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this._isFocus = false;
			base.Invalidate(this._btnArrowRect);
		}
	}
}
