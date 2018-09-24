using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class ControlBoxManager : IDisposable
	{
		private MainWinForm _owner;
		private bool _mouseDown;
		private ControlBoxState _closBoxState;
		private ControlBoxState _minimizeBoxState;
		private ControlBoxState _SysBottomState;
		private ControlBoxState _maximizeBoxState;
		public bool SysBottomVisibale
		{
			get
			{
				return this._owner.SysBottomVisibale;
			}
		}
		public bool CloseBoxVisibale
		{
			get
			{
				return this._owner.ControlBox;
			}
		}
		public bool MaximizeBoxVisibale
		{
			get
			{
				return this._owner.ControlBox && this._owner.MaximizeBox;
			}
		}
		public bool MinimizeBoxVisibale
		{
			get
			{
				return this._owner.ControlBox && this._owner.MinimizeBox;
			}
		}
		public Rectangle CloseBoxRect
		{
			get
			{
				if (this.CloseBoxVisibale)
				{
					Point controlBoxOffset = this.ControlBoxOffset;
					Size closeBoxSize = this._owner.CloseBoxSize;
					return new Rectangle(this._owner.Width - controlBoxOffset.X - closeBoxSize.Width, controlBoxOffset.Y, closeBoxSize.Width, closeBoxSize.Height);
				}
				return Rectangle.Empty;
			}
		}
		public Rectangle MaximizeBoxRect
		{
			get
			{
				if (this.MaximizeBoxVisibale)
				{
					Point controlBoxOffset = this.ControlBoxOffset;
					Size maxSize = this._owner.MaxSize;
					return new Rectangle(this.CloseBoxRect.X - this.ControlBoxSpace - maxSize.Width, controlBoxOffset.Y, maxSize.Width, maxSize.Height);
				}
				return Rectangle.Empty;
			}
		}
		public Rectangle MinimizeBoxRect
		{
			get
			{
				if (this.MinimizeBoxVisibale)
				{
					Point controlBoxOffset = this.ControlBoxOffset;
					Size miniSize = this._owner.MiniSize;
					int x = this.MaximizeBoxVisibale ? (this.MaximizeBoxRect.X - this.ControlBoxSpace - miniSize.Width) : (this.CloseBoxRect.X - this.ControlBoxSpace - miniSize.Width);
					return new Rectangle(x, controlBoxOffset.Y, miniSize.Width, miniSize.Height);
				}
				return Rectangle.Empty;
			}
		}
		public Rectangle SysBottomRect
		{
			get
			{
				if (this.SysBottomVisibale)
				{
					Point controlBoxOffset = this.ControlBoxOffset;
					Size sysBottomSize = this._owner.SysBottomSize;
					int x = this.MinimizeBoxVisibale ? (this.MinimizeBoxRect.X - this.ControlBoxSpace - sysBottomSize.Width) : (this.MaximizeBoxVisibale ? (this.MaximizeBoxRect.X - this.ControlBoxSpace - sysBottomSize.Width) : (this.CloseBoxRect.X - this.ControlBoxSpace - sysBottomSize.Width));
					return new Rectangle(x, controlBoxOffset.Y, sysBottomSize.Width, sysBottomSize.Height);
				}
				return Rectangle.Empty;
			}
		}
		public ControlBoxState CloseBoxState
		{
			get
			{
				return this._closBoxState;
			}
			protected set
			{
				if (this._closBoxState != value)
				{
					this._closBoxState = value;
					if (this._owner != null)
					{
						this.Invalidate(this.CloseBoxRect);
					}
				}
			}
		}
		public ControlBoxState MinimizeBoxState
		{
			get
			{
				return this._minimizeBoxState;
			}
			protected set
			{
				if (this._minimizeBoxState != value)
				{
					this._minimizeBoxState = value;
					if (this._owner != null)
					{
						this.Invalidate(this.MinimizeBoxRect);
					}
				}
			}
		}
		public ControlBoxState SysBottomState
		{
			get
			{
				return this._SysBottomState;
			}
			protected set
			{
				if (this._SysBottomState != value)
				{
					this._SysBottomState = value;
					if (this._owner != null)
					{
						this.Invalidate(this.SysBottomRect);
					}
				}
			}
		}
		public ControlBoxState MaximizeBoxState
		{
			get
			{
				return this._maximizeBoxState;
			}
			protected set
			{
				if (this._maximizeBoxState != value)
				{
					this._maximizeBoxState = value;
					if (this._owner != null)
					{
						this.Invalidate(this.MaximizeBoxRect);
					}
				}
			}
		}
		public Point ControlBoxOffset
		{
			get
			{
				return this._owner.ControlBoxOffset;
			}
		}
		public int ControlBoxSpace
		{
			get
			{
				return this._owner.ControlBoxSpace;
			}
		}
		public ControlBoxManager(MainWinForm owner)
		{
			this._owner = owner;
		}
		public void ProcessMouseOperate(Point mousePoint, MouseOperate operate)
		{
			if (!this._owner.ControlBox)
			{
				return;
			}
			Rectangle closeBoxRect = this.CloseBoxRect;
			Rectangle minimizeBoxRect = this.MinimizeBoxRect;
			Rectangle maximizeBoxRect = this.MaximizeBoxRect;
			Rectangle sysBottomRect = this.SysBottomRect;
			bool closeBoxVisibale = this.CloseBoxVisibale;
			bool minimizeBoxVisibale = this.MinimizeBoxVisibale;
			bool maximizeBoxVisibale = this.MaximizeBoxVisibale;
			bool sysBottomVisibale = this.SysBottomVisibale;
			switch (operate)
			{
			case MouseOperate.Move:
				this.ProcessMouseMove(mousePoint, closeBoxRect, minimizeBoxRect, maximizeBoxRect, sysBottomRect, closeBoxVisibale, minimizeBoxVisibale, maximizeBoxVisibale, sysBottomVisibale);
				return;
			case MouseOperate.Down:
				this.ProcessMouseDown(mousePoint, closeBoxRect, minimizeBoxRect, maximizeBoxRect, sysBottomRect, closeBoxVisibale, minimizeBoxVisibale, maximizeBoxVisibale, sysBottomVisibale);
				return;
			case MouseOperate.Up:
				this.ProcessMouseUP(mousePoint, closeBoxRect, minimizeBoxRect, maximizeBoxRect, sysBottomRect, closeBoxVisibale, minimizeBoxVisibale, maximizeBoxVisibale, sysBottomVisibale);
				return;
			case MouseOperate.Leave:
				this.ProcessMouseLeave(closeBoxVisibale, minimizeBoxVisibale, maximizeBoxVisibale, sysBottomVisibale);
				break;
			case MouseOperate.Hover:
				break;
			default:
				return;
			}
		}
		private void ProcessMouseMove(Point mousePoint, Rectangle closeBoxRect, Rectangle minimizeBoxRect, Rectangle maximizeBoxRect, Rectangle sysbottomRect, bool closeBoxVisibale, bool minimizeBoxVisibale, bool maximizeBoxVisibale, bool sysbottomVisibale)
		{
			string text = string.Empty;
			bool flag = true;
			if (closeBoxVisibale)
			{
				if (closeBoxRect.Contains(mousePoint))
				{
					flag = false;
					if (!this._mouseDown)
					{
						if (this.CloseBoxState != ControlBoxState.Hover)
						{
							text = "关闭";
						}
						this.CloseBoxState = ControlBoxState.Hover;
					}
					else
					{
						if (this.CloseBoxState == ControlBoxState.PressedLeave)
						{
							this.CloseBoxState = ControlBoxState.Pressed;
						}
					}
				}
				else
				{
					if (!this._mouseDown)
					{
						this.CloseBoxState = ControlBoxState.Normal;
					}
					else
					{
						if (this.CloseBoxState == ControlBoxState.Pressed)
						{
							this.CloseBoxState = ControlBoxState.PressedLeave;
						}
					}
				}
			}
			if (minimizeBoxVisibale)
			{
				if (minimizeBoxRect.Contains(mousePoint))
				{
					flag = false;
					if (!this._mouseDown)
					{
						if (this.MinimizeBoxState != ControlBoxState.Hover)
						{
							text = "最小化";
						}
						this.MinimizeBoxState = ControlBoxState.Hover;
					}
					else
					{
						if (this.MinimizeBoxState == ControlBoxState.PressedLeave)
						{
							this.MinimizeBoxState = ControlBoxState.Pressed;
						}
					}
				}
				else
				{
					if (!this._mouseDown)
					{
						this.MinimizeBoxState = ControlBoxState.Normal;
					}
					else
					{
						if (this.MinimizeBoxState == ControlBoxState.Pressed)
						{
							this.MinimizeBoxState = ControlBoxState.PressedLeave;
						}
					}
				}
			}
			if (maximizeBoxVisibale)
			{
				if (maximizeBoxRect.Contains(mousePoint))
				{
					flag = false;
					if (!this._mouseDown)
					{
						if (this.MaximizeBoxState != ControlBoxState.Hover)
						{
							text = ((this._owner.WindowState == FormWindowState.Maximized) ? "还原" : "最大化");
						}
						this.MaximizeBoxState = ControlBoxState.Hover;
					}
					else
					{
						if (this.MaximizeBoxState == ControlBoxState.PressedLeave)
						{
							this.MaximizeBoxState = ControlBoxState.Pressed;
						}
					}
				}
				else
				{
					if (!this._mouseDown)
					{
						this.MaximizeBoxState = ControlBoxState.Normal;
					}
					else
					{
						if (this.MaximizeBoxState == ControlBoxState.Pressed)
						{
							this.MaximizeBoxState = ControlBoxState.PressedLeave;
						}
					}
				}
			}
			if (sysbottomVisibale)
			{
				if (sysbottomRect.Contains(mousePoint))
				{
					flag = false;
					if (!this._mouseDown)
					{
						if (this.SysBottomState != ControlBoxState.Hover)
						{
							text = this._owner.SysBottomToolTip;
						}
						this.SysBottomState = ControlBoxState.Hover;
					}
					else
					{
						if (this.SysBottomState == ControlBoxState.PressedLeave)
						{
							this.SysBottomState = ControlBoxState.Pressed;
						}
					}
				}
				else
				{
					if (!this._mouseDown)
					{
						this.SysBottomState = ControlBoxState.Normal;
					}
					else
					{
						if (this.SysBottomState == ControlBoxState.Pressed)
						{
							this.SysBottomState = ControlBoxState.PressedLeave;
						}
					}
				}
			}
			if (text != string.Empty)
			{
				this.HideToolTip();
				this.ShowTooTip(text);
			}
			if (flag)
			{
				this.HideToolTip();
			}
		}
		private void ProcessMouseDown(Point mousePoint, Rectangle closeBoxRect, Rectangle minimizeBoxRect, Rectangle maximizeBoxRect, Rectangle sysbottomRect, bool closeBoxVisibale, bool minimizeBoxVisibale, bool maximizeBoxVisibale, bool sysbottomVisibale)
		{
			this._mouseDown = true;
			if (closeBoxVisibale && closeBoxRect.Contains(mousePoint))
			{
				this.CloseBoxState = ControlBoxState.Pressed;
				return;
			}
			if (minimizeBoxVisibale && minimizeBoxRect.Contains(mousePoint))
			{
				this.MinimizeBoxState = ControlBoxState.Pressed;
				return;
			}
			if (this.SysBottomVisibale && sysbottomRect.Contains(mousePoint))
			{
				this.SysBottomState = ControlBoxState.Pressed;
				return;
			}
			if (maximizeBoxVisibale && maximizeBoxRect.Contains(mousePoint))
			{
				this.MaximizeBoxState = ControlBoxState.Pressed;
			}
		}
		private void ProcessMouseUP(Point mousePoint, Rectangle closeBoxRect, Rectangle minimizeBoxRect, Rectangle maximizeBoxRect, Rectangle sysbottomRect, bool closeBoxVisibale, bool minimizeBoxVisibale, bool maximizeBoxVisibale, bool sysbottomVisible)
		{
			this._mouseDown = false;
			if (closeBoxVisibale)
			{
				if (closeBoxRect.Contains(mousePoint) && this.CloseBoxState == ControlBoxState.Pressed)
				{
					this._owner.Close();
					this.CloseBoxState = ControlBoxState.Normal;
					return;
				}
				this.CloseBoxState = ControlBoxState.Normal;
			}
			if (minimizeBoxVisibale)
			{
				if (minimizeBoxRect.Contains(mousePoint) && this.MinimizeBoxState == ControlBoxState.Pressed)
				{
					if (this._owner.ShowInTaskbar)
					{
						this._owner.WindowState = FormWindowState.Minimized;
					}
					else
					{
						this._owner.Hide();
					}
					this.MinimizeBoxState = ControlBoxState.Normal;
					return;
				}
				this.MinimizeBoxState = ControlBoxState.Normal;
			}
			if (sysbottomVisible)
			{
				if (sysbottomRect.Contains(mousePoint) && this.SysBottomState == ControlBoxState.Pressed)
				{
					this._owner.SysbottomAv(this._owner);
					this.SysBottomState = ControlBoxState.Normal;
					return;
				}
				this.MinimizeBoxState = ControlBoxState.Normal;
			}
			if (maximizeBoxVisibale)
			{
				if (maximizeBoxRect.Contains(mousePoint) && this.MaximizeBoxState == ControlBoxState.Pressed)
				{
					bool flag = this._owner.WindowState == FormWindowState.Maximized;
					if (flag)
					{
						this._owner.WindowState = FormWindowState.Normal;
					}
					else
					{
						this._owner.WindowState = FormWindowState.Maximized;
					}
					this.MaximizeBoxState = ControlBoxState.Normal;
					return;
				}
				this.MaximizeBoxState = ControlBoxState.Normal;
			}
		}
		private void ProcessMouseLeave(bool closeBoxVisibale, bool minimizeBoxVisibale, bool maximizeBoxVisibale, bool sysbottomVisibale)
		{
			if (closeBoxVisibale)
			{
				if (this.CloseBoxState == ControlBoxState.Pressed)
				{
					this.CloseBoxState = ControlBoxState.PressedLeave;
				}
				else
				{
					this.CloseBoxState = ControlBoxState.Normal;
				}
			}
			if (minimizeBoxVisibale)
			{
				if (this.MinimizeBoxState == ControlBoxState.Pressed)
				{
					this.MinimizeBoxState = ControlBoxState.PressedLeave;
				}
				else
				{
					this.MinimizeBoxState = ControlBoxState.Normal;
				}
			}
			if (sysbottomVisibale)
			{
				if (this.SysBottomState == ControlBoxState.Pressed)
				{
					this.SysBottomState = ControlBoxState.PressedLeave;
				}
				else
				{
					this.SysBottomState = ControlBoxState.Normal;
				}
			}
			if (maximizeBoxVisibale)
			{
				if (this.MaximizeBoxState == ControlBoxState.Pressed)
				{
					this.MaximizeBoxState = ControlBoxState.PressedLeave;
				}
				else
				{
					this.MaximizeBoxState = ControlBoxState.Normal;
				}
			}
			this.HideToolTip();
		}
		private void Invalidate(Rectangle rect)
		{
			this._owner.Invalidate(rect);
		}
		private void ShowTooTip(string toolTipText)
		{
			if (this._owner != null)
			{
				this._owner.ToolTip.Active = true;
				this._owner.ToolTip.SetToolTip(this._owner, toolTipText);
			}
		}
		private void HideToolTip()
		{
			if (this._owner != null)
			{
				this._owner.ToolTip.Active = false;
			}
		}
		public void Dispose()
		{
			this._owner = null;
		}
	}
}
