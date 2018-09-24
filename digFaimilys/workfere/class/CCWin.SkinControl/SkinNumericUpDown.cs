using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(NumericUpDown))]
	public class SkinNumericUpDown : NumericUpDown
	{
		private class UpDownButtonNativeWindow : NativeWindow, IDisposable
		{
			private const int WM_PAINT = 15;
			private const int VK_LBUTTON = 1;
			private const int VK_RBUTTON = 2;
			private SkinNumericUpDown _owner;
			private Control _upDownButton;
			private IntPtr _upDownButtonWnd;
			private bool _bPainting;
			private static readonly IntPtr TRUE = new IntPtr(1);
			public UpDownButtonNativeWindow(SkinNumericUpDown owner)
			{
				this._owner = owner;
				this._upDownButton = owner.UpDownButton;
				this._upDownButtonWnd = this._upDownButton.Handle;
				if (Environment.OSVersion.Version.Major > 5 && NativeMethods.IsAppThemed())
				{
					NativeMethods.SetWindowTheme(this._upDownButtonWnd, "", "");
				}
				base.AssignHandle(this._upDownButtonWnd);
			}
			private bool LeftKeyPressed()
			{
				if (SystemInformation.MouseButtonsSwapped)
				{
					return NativeMethods.GetKeyState(2) < 0;
				}
				return NativeMethods.GetKeyState(1) < 0;
			}
			private void DrawUpDownButton()
			{
				bool mousePress = this.LeftKeyPressed();
				Rectangle clientRectangle = this._upDownButton.ClientRectangle;
				RECT rECT = default(RECT);
				NativeMethods.Point pt = default(NativeMethods.Point);
				NativeMethods.GetCursorPos(ref pt);
				NativeMethods.GetWindowRect(this._upDownButtonWnd, ref rECT);
				bool mouseOver = NativeMethods.PtInRect(ref rECT, pt);
				pt.x -= rECT.Left;
				pt.y -= rECT.Top;
				bool mouseInUpButton = pt.y < clientRectangle.Height / 2;
				using (Graphics graphics = Graphics.FromHwnd(this._upDownButtonWnd))
				{
					UpDownButtonPaintEventArgs e = new UpDownButtonPaintEventArgs(graphics, clientRectangle, mouseOver, mousePress, mouseInUpButton);
					this._owner.OnPaintUpDownButton(e);
				}
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
					this.DrawUpDownButton();
					NativeMethods.EndPaint(m.HWnd, ref pAINTSTRUCT);
					this._bPainting = false;
					m.Result = SkinNumericUpDown.UpDownButtonNativeWindow.TRUE;
					return;
				}
				base.WndProc(ref m);
			}
			public void Dispose()
			{
				this._owner = null;
				this._upDownButton = null;
				base.ReleaseHandle();
			}
		}
		private SkinNumericUpDown.UpDownButtonNativeWindow _upDownButtonNativeWindow;
		private Color _baseColor = Color.FromArgb(166, 222, 255);
		private Color _borderColor = Color.FromArgb(23, 169, 254);
		private Color _arrowColor = Color.FromArgb(0, 95, 152);
		private static readonly object EventPaintUpDownButton = new object();
		public event UpDownButtonPaintEventHandler PaintUpDownButton
		{
			add
			{
				base.Events.AddHandler(SkinNumericUpDown.EventPaintUpDownButton, value);
			}
			remove
			{
				base.Events.RemoveHandler(SkinNumericUpDown.EventPaintUpDownButton, value);
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "166, 222, 255"), Description("色调")]
		public Color BaseColor
		{
			get
			{
				return this._baseColor;
			}
			set
			{
				this._baseColor = value;
				this.UpDownButton.Invalidate();
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "23, 169, 254"), Description("边框颜色")]
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
		[Category("Skin"), DefaultValue(typeof(Color), "0, 95, 152"), Description("箭头颜色")]
		public Color ArrowColor
		{
			get
			{
				return this._arrowColor;
			}
			set
			{
				this._arrowColor = value;
				this.UpDownButton.Invalidate();
			}
		}
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				base.Invalidate(true);
			}
		}
		public Control UpDownButton
		{
			get
			{
				return base.Controls[0];
			}
		}
		protected virtual void OnPaintUpDownButton(UpDownButtonPaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clipRectangle = e.ClipRectangle;
			Color baseColor = this._baseColor;
			Color borderColor = this._borderColor;
			Color arrowColor = this._arrowColor;
			Color baseColor2 = this._baseColor;
			Color borderColor2 = this._borderColor;
			Color arrowColor2 = this._arrowColor;
			Rectangle rect = clipRectangle;
			rect.Y++;
			rect.Width -= 2;
			rect.Height = clipRectangle.Height / 2 - 2;
			Rectangle rect2 = clipRectangle;
			rect2.Y = rect.Bottom + 2;
			rect2.Height = clipRectangle.Height - rect.Bottom - 4;
			rect2.Width -= 2;
			if (base.Enabled)
			{
				if (e.MouseOver)
				{
					if (e.MousePress)
					{
						if (e.MouseInUpButton)
						{
							baseColor = this.GetColor(this._baseColor, 0, -35, -24, -9);
						}
						else
						{
							baseColor2 = this.GetColor(this._baseColor, 0, -35, -24, -9);
						}
					}
					else
					{
						if (e.MouseInUpButton)
						{
							baseColor = this.GetColor(this._baseColor, 0, 35, 24, 9);
						}
						else
						{
							baseColor2 = this.GetColor(this._baseColor, 0, 35, 24, 9);
						}
					}
				}
			}
			else
			{
				baseColor = SystemColors.Control;
				borderColor = SystemColors.ControlDark;
				arrowColor = SystemColors.ControlDark;
				baseColor2 = SystemColors.Control;
				borderColor2 = SystemColors.ControlDark;
				arrowColor2 = SystemColors.ControlDark;
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Color color = base.Enabled ? base.BackColor : SystemColors.Control;
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				clipRectangle.Inflate(1, 1);
				graphics.FillRectangle(solidBrush, clipRectangle);
			}
			this.RenderButton(graphics, rect, baseColor, borderColor, arrowColor, ArrowDirection.Up);
			this.RenderButton(graphics, rect2, baseColor2, borderColor2, arrowColor2, ArrowDirection.Down);
			UpDownButtonPaintEventHandler upDownButtonPaintEventHandler = base.Events[SkinNumericUpDown.EventPaintUpDownButton] as UpDownButtonPaintEventHandler;
			if (upDownButtonPaintEventHandler != null)
			{
				upDownButtonPaintEventHandler(this, e);
			}
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (this._upDownButtonNativeWindow == null)
			{
				this._upDownButtonNativeWindow = new SkinNumericUpDown.UpDownButtonNativeWindow(this);
			}
		}
		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (this._upDownButtonNativeWindow != null)
			{
				this._upDownButtonNativeWindow.Dispose();
				this._upDownButtonNativeWindow = null;
			}
		}
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg != 15)
			{
				if (msg != 133)
				{
					base.WndProc(ref m);
					return;
				}
			}
			else
			{
				base.WndProc(ref m);
				if (base.BorderStyle == BorderStyle.None)
				{
					return;
				}
				Color color = base.Enabled ? this._borderColor : SystemColors.ControlDark;
				using (Graphics graphics = Graphics.FromHwnd(m.HWnd))
				{
					ControlPaint.DrawBorder(graphics, base.ClientRectangle, color, ButtonBorderStyle.Solid);
					return;
				}
			}
			if (base.BorderStyle != BorderStyle.None)
			{
				Color color2 = base.Enabled ? base.BackColor : SystemColors.Control;
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				IntPtr windowDC = NativeMethods.GetWindowDC(m.HWnd);
				if (windowDC == IntPtr.Zero)
				{
					throw new Win32Exception();
				}
				try
				{
					using (Graphics graphics2 = Graphics.FromHdc(windowDC))
					{
						using (Brush brush = new SolidBrush(color2))
						{
							graphics2.FillRectangle(brush, rect);
						}
					}
				}
				finally
				{
					NativeMethods.ReleaseDC(m.HWnd, windowDC);
				}
			}
			m.Result = IntPtr.Zero;
		}
		public void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
		{
			Point point = new Point(dropDownRect.Left + dropDownRect.Width / 2, dropDownRect.Top + dropDownRect.Height / 2);
			Point[] points;
			switch (direction)
			{
			case ArrowDirection.Left:
				points = new Point[]
				{
					new Point(point.X + 2, point.Y - 3),
					new Point(point.X + 2, point.Y + 3),
					new Point(point.X - 1, point.Y)
				};
				break;
			case ArrowDirection.Up:
				points = new Point[]
				{
					new Point(point.X - 3, point.Y + 1),
					new Point(point.X + 3, point.Y + 1),
					new Point(point.X, point.Y - 1)
				};
				break;
			default:
				if (direction != ArrowDirection.Right)
				{
					points = new Point[]
					{
						new Point(point.X - 3, point.Y - 1),
						new Point(point.X + 3, point.Y - 1),
						new Point(point.X, point.Y + 1)
					};
				}
				else
				{
					points = new Point[]
					{
						new Point(point.X - 2, point.Y - 3),
						new Point(point.X - 2, point.Y + 3),
						new Point(point.X + 1, point.Y)
					};
				}
				break;
			}
			g.FillPolygon(brush, points);
		}
		public void RenderButton(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color arrowColor, ArrowDirection direction)
		{
			this.RenderBackgroundInternal(g, rect, baseColor, borderColor, 0.45f, true, LinearGradientMode.Vertical);
			using (SolidBrush solidBrush = new SolidBrush(arrowColor))
			{
				this.RenderArrowInternal(g, rect, direction, solidBrush);
			}
		}
		public void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, float basePosition, bool drawBorder, LinearGradientMode mode)
		{
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
				g.FillRectangle(linearGradientBrush, rect);
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
				using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
				{
					g.FillRectangle(solidBrush, rect2);
				}
			}
			if (drawBorder)
			{
				using (Pen pen = new Pen(borderColor))
				{
					g.DrawRectangle(pen, rect);
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
	}
}
