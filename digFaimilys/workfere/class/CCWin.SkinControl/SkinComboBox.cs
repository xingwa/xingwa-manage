using xingwaWinFormUI.SkinClass;
using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(ComboBox))]
	public class SkinComboBox : ComboBox
	{
		private class EditNativeWindow : NativeWindow, IDisposable
		{
			private const int WM_PAINT = 15;
			private SkinComboBox _owner;
			public EditNativeWindow(SkinComboBox owner)
			{
				this._owner = owner;
				base.AssignHandle(this._owner.EditHandle);
			}
			[DllImport("user32.dll")]
			private static extern IntPtr GetDC(IntPtr ptr);
			[DllImport("user32.dll")]
			private static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);
			protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg == 15)
				{
					IntPtr hWnd = m.HWnd;
					IntPtr dC = SkinComboBox.EditNativeWindow.GetDC(hWnd);
					if (dC == IntPtr.Zero)
					{
						return;
					}
					try
					{
						using (Graphics graphics = Graphics.FromHdc(dC))
						{
							if (this._owner.Text.Length == 0 && !this._owner.Focused && !string.IsNullOrEmpty(this._owner.WaterText))
							{
								TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
								if (this._owner.RightToLeft == RightToLeft.Yes)
								{
									textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.RightToLeft);
								}
								TextRenderer.DrawText(graphics, this._owner.WaterText, new Font("微软雅黑", 8.5f), new Rectangle(0, 0, this._owner.EditRect.Width, this._owner.EditRect.Height), this._owner.WaterColor, textFormatFlags);
							}
						}
					}
					finally
					{
						SkinComboBox.EditNativeWindow.ReleaseDC(hWnd, dC);
					}
				}
			}
			public void Dispose()
			{
				this.ReleaseHandle();
				this._owner = null;
			}
		}
		private SkinComboBox.EditNativeWindow _editNativeWindow;
		private bool _bPainting;
		private Color mouseColor = Color.FromArgb(62, 151, 216);
		private Color mouseGradientColor = Color.FromArgb(51, 137, 201);
		private Color dropBackColor = Color.White;
		private Color itemBorderColor = Color.CornflowerBlue;
		private Color itemHoverForeColor = Color.White;
		private string _waterText = string.Empty;
		private Color _waterColor = Color.FromArgb(127, 127, 127);
		private Color _baseColor = Color.FromArgb(51, 161, 224);
		private Color _borderColor = Color.FromArgb(51, 161, 224);
		private Color _arrowColor = Color.FromArgb(19, 88, 128);
		private ControlState _buttonState;
		private IntPtr _editHandle;
		[Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "62, 151, 216"), Description("项被选中后的高亮度颜色")]
		public Color MouseColor
		{
			get
			{
				return this.mouseColor;
			}
			set
			{
				this.mouseColor = value;
				base.Invalidate();
			}
		}
		[Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "51, 137, 201"), Description("项被选中后的渐变颜色")]
		public Color MouseGradientColor
		{
			get
			{
				return this.mouseGradientColor;
			}
			set
			{
				this.mouseGradientColor = value;
				base.Invalidate();
			}
		}
		[Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "White"), Description("下拉框背景色")]
		public Color DropBackColor
		{
			get
			{
				return this.dropBackColor;
			}
			set
			{
				this.dropBackColor = value;
				base.Invalidate();
			}
		}
		[Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "CornflowerBlue"), Description("项被选中时的边框颜色")]
		public Color ItemBorderColor
		{
			get
			{
				return this.itemBorderColor;
			}
			set
			{
				this.itemBorderColor = value;
				base.Invalidate();
			}
		}
		[Browsable(true), Category("DropDown"), DefaultValue(typeof(Color), "White"), Description("项被选中时的字体颜色")]
		public Color ItemHoverForeColor
		{
			get
			{
				return this.itemHoverForeColor;
			}
			set
			{
				this.itemHoverForeColor = value;
				base.Invalidate();
			}
		}
		[Category("Skin"), Description("水印文字")]
		public string WaterText
		{
			get
			{
				return this._waterText;
			}
			set
			{
				this._waterText = value;
				base.Invalidate();
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "127, 127, 127"), Description("水印的颜色")]
		public Color WaterColor
		{
			get
			{
				return this._waterColor;
			}
			set
			{
				this._waterColor = value;
				base.Invalidate();
			}
		}
		[Category("Base"), DefaultValue(typeof(Color), "51, 161, 224"), Description("下拉按钮背景色")]
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
		[Category("Base"), DefaultValue(typeof(Color), "51, 161, 224"), Description("边框颜色")]
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
		[Category("Base"), DefaultValue(typeof(Color), "19, 88, 128"), Description("箭头颜色")]
		public Color ArrowColor
		{
			get
			{
				return this._arrowColor;
			}
			set
			{
				if (this._arrowColor != value)
				{
					this._arrowColor = value;
					base.Invalidate();
				}
			}
		}
		internal ControlState ButtonState
		{
			get
			{
				return this._buttonState;
			}
			set
			{
				if (this._buttonState != value)
				{
					this._buttonState = value;
					base.Invalidate(this.ButtonRect);
				}
			}
		}
		internal Rectangle ButtonRect
		{
			get
			{
				return this.GetDropDownButtonRect();
			}
		}
		internal bool ButtonPressed
		{
			get
			{
				return base.IsHandleCreated && this.GetComboBoxButtonPressed();
			}
		}
		internal IntPtr EditHandle
		{
			get
			{
				return this._editHandle;
			}
		}
		internal Rectangle EditRect
		{
			get
			{
				if (base.DropDownStyle == ComboBoxStyle.DropDownList)
				{
					Rectangle result = new Rectangle(3, 3, base.Width - this.ButtonRect.Width - 6, base.Height - 6);
					if (this.RightToLeft == RightToLeft.Yes)
					{
						result.X += this.ButtonRect.Right;
					}
					return result;
				}
				if (base.IsHandleCreated && this.EditHandle != IntPtr.Zero)
				{
					RECT rECT = default(RECT);
					NativeMethods.GetWindowRect(this.EditHandle, ref rECT);
					return base.RectangleToClient(rECT.Rect);
				}
				return Rectangle.Empty;
			}
		}
		public SkinComboBox()
		{
			base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.DrawMode = DrawMode.OwnerDrawFixed;
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			if (e.Index == -1)
			{
				return;
			}
			if ((e.State & DrawItemState.Selected) != DrawItemState.None)
			{
				LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, this.MouseColor, this.mouseGradientColor, LinearGradientMode.Vertical);
				Rectangle rect = new Rectangle(1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
				e.Graphics.FillRectangle(brush, rect);
				Pen pen = new Pen(this.ItemBorderColor);
				e.Graphics.DrawRectangle(pen, rect);
			}
			else
			{
				SolidBrush brush2 = new SolidBrush(this.DropBackColor);
				e.Graphics.FillRectangle(brush2, e.Bounds);
			}
			string s = base.Items[e.Index].ToString();
			Color color = ((e.State & DrawItemState.Selected) != DrawItemState.None) ? this.ItemHoverForeColor : this.ForeColor;
			StringFormat stringFormat = new StringFormat();
			stringFormat.LineAlignment = StringAlignment.Center;
			e.Graphics.DrawString(s, this.Font, new SolidBrush(color), e.Bounds, stringFormat);
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			NativeMethods.ComboBoxInfo comboBoxInfo = default(NativeMethods.ComboBoxInfo);
			comboBoxInfo.cbSize = Marshal.SizeOf(comboBoxInfo);
			NativeMethods.GetComboBoxInfo(base.Handle, ref comboBoxInfo);
			this._editHandle = comboBoxInfo.hwndEdit;
			if (base.DropDownStyle != ComboBoxStyle.DropDownList)
			{
				this._editNativeWindow = new SkinComboBox.EditNativeWindow(this);
			}
		}
		protected override void OnHandleDestroyed(EventArgs e)
		{
			base.OnHandleDestroyed(e);
			if (this._editNativeWindow != null)
			{
				this._editNativeWindow.Dispose();
				this._editNativeWindow = null;
			}
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			this._editHandle = this.GetComboBoxInfo().hwndEdit;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Point location = e.Location;
			if (this.ButtonRect.Contains(location))
			{
				this.ButtonState = ControlState.Hover;
				return;
			}
			this.ButtonState = ControlState.Normal;
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			Point pt = base.PointToClient(Cursor.Position);
			if (this.ButtonRect.Contains(pt))
			{
				this.ButtonState = ControlState.Hover;
			}
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.ButtonState = ControlState.Normal;
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.ButtonState = ControlState.Normal;
		}
		protected override void WndProc(ref Message m)
		{
			int msg = m.Msg;
			if (msg == 15)
			{
				this.WmPaint(ref m);
				return;
			}
			base.WndProc(ref m);
		}
		private void WmPaint(ref Message m)
		{
			if (base.DropDownStyle == ComboBoxStyle.Simple)
			{
				base.WndProc(ref m);
				return;
			}
			if (base.DropDownStyle != ComboBoxStyle.DropDown)
			{
				base.WndProc(ref m);
				this.RenderComboBox(ref m);
				return;
			}
			if (!this._bPainting)
			{
				PAINTSTRUCT pAINTSTRUCT = default(PAINTSTRUCT);
				this._bPainting = true;
				NativeMethods.BeginPaint(m.HWnd, ref pAINTSTRUCT);
				this.RenderComboBox(ref m);
				NativeMethods.EndPaint(m.HWnd, ref pAINTSTRUCT);
				this._bPainting = false;
				m.Result = Result.TRUE;
				return;
			}
			base.WndProc(ref m);
		}
		private void RenderComboBox(ref Message m)
		{
			Rectangle rect = new Rectangle(Point.Empty, base.Size);
			Rectangle buttonRect = this.ButtonRect;
			ControlState state = this.ButtonPressed ? ControlState.Pressed : this.ButtonState;
			using (Graphics graphics = Graphics.FromHwnd(m.HWnd))
			{
				this.RenderComboBoxBackground(graphics, rect, buttonRect);
				this.RenderConboBoxDropDownButton(graphics, this.ButtonRect, state);
				this.RenderConboBoxBorder(graphics, rect);
			}
		}
		private void RenderConboBoxBorder(Graphics g, Rectangle rect)
		{
			Color color = base.Enabled ? this._borderColor : SystemColors.ControlDarkDark;
			using (Pen pen = new Pen(color))
			{
				rect.Width--;
				rect.Height--;
				g.DrawRectangle(pen, rect);
			}
		}
		private void RenderComboBoxBackground(Graphics g, Rectangle rect, Rectangle buttonRect)
		{
			Color color = base.Enabled ? base.BackColor : SystemColors.Control;
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				buttonRect.Inflate(-1, -1);
				rect.Inflate(-1, -1);
				using (Region region = new Region(rect))
				{
					region.Exclude(buttonRect);
					region.Exclude(this.EditRect);
					g.FillRegion(solidBrush, region);
				}
			}
		}
		private void RenderConboBoxDropDownButton(Graphics g, Rectangle buttonRect, ControlState state)
		{
			Color innerBorderColor = Color.FromArgb(160, 250, 250, 250);
			Color borderColor = base.Enabled ? this._borderColor : SystemColors.ControlDarkDark;
			Color arrowColor = base.Enabled ? this._arrowColor : SystemColors.ControlDarkDark;
			Rectangle rect = buttonRect;
			Color baseColor;
			if (base.Enabled)
			{
				switch (state)
				{
				case ControlState.Hover:
					baseColor = RenderHelper.GetColor(this._baseColor, 0, -33, -22, -13);
					break;
				case ControlState.Pressed:
					baseColor = RenderHelper.GetColor(this._baseColor, 0, -65, -47, -25);
					break;
				default:
					baseColor = this._baseColor;
					break;
				}
			}
			else
			{
				baseColor = SystemColors.ControlDark;
			}
			rect.Inflate(-1, -1);
			this.RenderScrollBarArrowInternal(g, rect, baseColor, borderColor, innerBorderColor, arrowColor, RoundStyle.None, true, false, ArrowDirection.Down, LinearGradientMode.Vertical);
		}
		internal void RenderScrollBarArrowInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, Color arrowColor, RoundStyle roundStyle, bool drawBorder, bool drawGlass, ArrowDirection arrowDirection, LinearGradientMode mode)
		{
			RenderHelper.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, roundStyle, 0, 0.45f, drawBorder, drawGlass, mode);
			using (SolidBrush solidBrush = new SolidBrush(arrowColor))
			{
				this.RenderArrowInternal(g, rect, arrowDirection, solidBrush);
			}
		}
		internal void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
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
					new Point(point.X - 3, point.Y + 2),
					new Point(point.X + 3, point.Y + 2),
					new Point(point.X, point.Y - 2)
				};
				break;
			default:
				if (direction != ArrowDirection.Right)
				{
					points = new Point[]
					{
						new Point(point.X - 2, point.Y - 1),
						new Point(point.X + 3, point.Y - 1),
						new Point(point.X, point.Y + 2)
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
		private NativeMethods.ComboBoxInfo GetComboBoxInfo()
		{
			NativeMethods.ComboBoxInfo comboBoxInfo = default(NativeMethods.ComboBoxInfo);
			comboBoxInfo.cbSize = Marshal.SizeOf(comboBoxInfo);
			NativeMethods.GetComboBoxInfo(base.Handle, ref comboBoxInfo);
			return comboBoxInfo;
		}
		private bool GetComboBoxButtonPressed()
		{
			return this.GetComboBoxInfo().stateButton == NativeMethods.ComboBoxButtonState.STATE_SYSTEM_PRESSED;
		}
		private Rectangle GetDropDownButtonRect()
		{
			return this.GetComboBoxInfo().rcButton.Rect;
		}
	}
}
