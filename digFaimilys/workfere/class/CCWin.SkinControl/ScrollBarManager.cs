using xingwaWinFormUI.SkinClass;
using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	internal class ScrollBarManager : NativeWindow, IDisposable
	{
		private class ScrollBarMaskControl : MaskControlBase
		{
			private ScrollBarManager _owner;
			public ScrollBarMaskControl(ScrollBarManager owner) : base(owner.OwnerHWnd)
			{
				this._owner = owner;
			}
			protected override void OnPaint(IntPtr hWnd)
			{
				this._owner.DrawScrollBar(this._owner.OwnerHWnd, hWnd);
			}
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					this._owner = null;
				}
				base.Dispose(disposing);
			}
		}
		private bool _bPainting;
		private ScrollBar _owner;
		private ScrollBarManager.ScrollBarMaskControl _maskControl;
		private ScrollBarHistTest _lastMouseDownHistTest;
		private bool _disposed;
		private IntPtr OwnerHWnd
		{
			get
			{
				return this._owner.Handle;
			}
		}
		private Orientation Direction
		{
			get
			{
				if (this._owner is HScrollBar)
				{
					return Orientation.Horizontal;
				}
				return Orientation.Vertical;
			}
		}
		private int ArrowCx
		{
			get
			{
				return SystemInformation.HorizontalScrollBarArrowWidth;
			}
		}
		private int ArrowCy
		{
			get
			{
				return SystemInformation.VerticalScrollBarArrowHeight;
			}
		}
		internal ScrollBarManager(ScrollBar owner)
		{
			this._owner = owner;
			this.CreateHandle();
		}
		~ScrollBarManager()
		{
			this.Dispose(false);
		}
		protected override void WndProc(ref Message m)
		{
			try
			{
				int msg = m.Msg;
				if (msg <= 125)
				{
					if (msg != 15)
					{
						if (msg == 71)
						{
							WINDOWPOS wINDOWPOS = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
							bool flag = ((long)wINDOWPOS.flags & 128L) != 0L;
							bool flag2 = ((long)wINDOWPOS.flags & 64L) != 0L;
							if (flag)
							{
								this._maskControl.SetVisibale(false);
							}
							else
							{
								if (flag2)
								{
									this._maskControl.SetVisibale(true);
								}
							}
							this._maskControl.CheckBounds(m.HWnd);
							base.WndProc(ref m);
							goto IL_22D;
						}
						if (msg == 125)
						{
							this.DrawScrollBar(m.HWnd, this._maskControl.Handle, false, true);
							base.WndProc(ref m);
							goto IL_22D;
						}
					}
					else
					{
						if (!this._bPainting)
						{
							PAINTSTRUCT pAINTSTRUCT = default(PAINTSTRUCT);
							this._bPainting = true;
							NativeMethods.BeginPaint(m.HWnd, ref pAINTSTRUCT);
							this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
							NativeMethods.ValidateRect(m.HWnd, ref pAINTSTRUCT.rcPaint);
							NativeMethods.EndPaint(m.HWnd, ref pAINTSTRUCT);
							this._bPainting = false;
							m.Result = Result.TRUE;
							goto IL_22D;
						}
						base.WndProc(ref m);
						goto IL_22D;
					}
				}
				else
				{
					if (msg == 233)
					{
						this.DrawScrollBar(m.HWnd, this._maskControl.Handle, true, false);
						base.WndProc(ref m);
						goto IL_22D;
					}
					switch (msg)
					{
					case 512:
					case 514:
						this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
						base.WndProc(ref m);
						goto IL_22D;
					case 513:
						this._lastMouseDownHistTest = this.ScrollBarHitTest(m.HWnd);
						this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
						base.WndProc(ref m);
						goto IL_22D;
					default:
						if (msg == 675)
						{
							this.DrawScrollBar(m.HWnd, this._maskControl.Handle);
							base.WndProc(ref m);
							goto IL_22D;
						}
						break;
					}
				}
				base.WndProc(ref m);
				IL_22D:;
			}
			catch
			{
			}
		}
		private void DrawScrollBar(IntPtr scrollBarHWnd, IntPtr maskHWnd)
		{
			this.DrawScrollBar(scrollBarHWnd, maskHWnd, false, false);
		}
		private void DrawScrollBar(IntPtr scrollBarHWnd, IntPtr maskHWnd, bool sbm, bool styleChanged)
		{
			Orientation direction = this.Direction;
			bool bHorizontal = direction == Orientation.Horizontal;
			Rectangle bounds;
			Rectangle trackRect;
			Rectangle topLeftArrowRect;
			Rectangle bottomRightArrowRect;
			Rectangle thumbRect;
			this.CalculateRect(scrollBarHWnd, bHorizontal, out bounds, out trackRect, out topLeftArrowRect, out bottomRightArrowRect, out thumbRect);
			ScrollBarHistTest scrollBarHistTest;
			ControlState topLeftArrowState;
			ControlState bottomRightArrowState;
			ControlState thumbState;
			this.GetState(scrollBarHWnd, bHorizontal, out scrollBarHistTest, out topLeftArrowState, out bottomRightArrowState, out thumbState);
			if (sbm)
			{
				if (scrollBarHistTest == ScrollBarHistTest.None)
				{
					thumbState = ControlState.Pressed;
				}
				else
				{
					if (this._lastMouseDownHistTest == ScrollBarHistTest.Track)
					{
						thumbState = ControlState.Normal;
					}
				}
			}
			if (styleChanged)
			{
				thumbState = ControlState.Normal;
			}
			this.DrawScrollBar(maskHWnd, bounds, trackRect, topLeftArrowRect, bottomRightArrowRect, thumbRect, topLeftArrowState, bottomRightArrowState, thumbState, direction);
		}
		private void DrawScrollBar(ControlState topLeftArrowState, ControlState bottomRightArrowState, ControlState thumbState)
		{
			Orientation direction = this.Direction;
			bool bHorizontal = direction == Orientation.Horizontal;
			Rectangle bounds;
			Rectangle trackRect;
			Rectangle topLeftArrowRect;
			Rectangle bottomRightArrowRect;
			Rectangle thumbRect;
			this.CalculateRect(this.OwnerHWnd, bHorizontal, out bounds, out trackRect, out topLeftArrowRect, out bottomRightArrowRect, out thumbRect);
			this.DrawScrollBar(this._maskControl.Handle, bounds, trackRect, topLeftArrowRect, bottomRightArrowRect, thumbRect, topLeftArrowState, bottomRightArrowState, thumbState, direction);
		}
		private void DrawScrollBar(IntPtr maskHWnd, Rectangle bounds, Rectangle trackRect, Rectangle topLeftArrowRect, Rectangle bottomRightArrowRect, Rectangle thumbRect, ControlState topLeftArrowState, ControlState bottomRightArrowState, ControlState thumbState, Orientation direction)
		{
			bool flag = direction == Orientation.Horizontal;
			bool enabled = this._owner.Enabled;
			IScrollBarPaint scrollBarPaint = this._owner as IScrollBarPaint;
			if (scrollBarPaint == null)
			{
				return;
			}
			ImageDc imageDc = new ImageDc(bounds.Width, bounds.Height);
			IntPtr dC = NativeMethods.GetDC(maskHWnd);
			try
			{
				using (Graphics graphics = Graphics.FromHdc(imageDc.Hdc))
				{
					using (PaintScrollBarTrackEventArgs paintScrollBarTrackEventArgs = new PaintScrollBarTrackEventArgs(graphics, trackRect, direction, enabled))
					{
						scrollBarPaint.OnPaintScrollBarTrack(paintScrollBarTrackEventArgs);
					}
					ArrowDirection arrowDirection = flag ? ArrowDirection.Left : ArrowDirection.Up;
					using (PaintScrollBarArrowEventArgs paintScrollBarArrowEventArgs = new PaintScrollBarArrowEventArgs(graphics, topLeftArrowRect, topLeftArrowState, arrowDirection, direction, enabled))
					{
						scrollBarPaint.OnPaintScrollBarArrow(paintScrollBarArrowEventArgs);
					}
					arrowDirection = (flag ? ArrowDirection.Right : ArrowDirection.Down);
					using (PaintScrollBarArrowEventArgs paintScrollBarArrowEventArgs2 = new PaintScrollBarArrowEventArgs(graphics, bottomRightArrowRect, bottomRightArrowState, arrowDirection, direction, enabled))
					{
						scrollBarPaint.OnPaintScrollBarArrow(paintScrollBarArrowEventArgs2);
					}
					using (PaintScrollBarThumbEventArgs paintScrollBarThumbEventArgs = new PaintScrollBarThumbEventArgs(graphics, thumbRect, thumbState, direction, enabled))
					{
						scrollBarPaint.OnPaintScrollBarThumb(paintScrollBarThumbEventArgs);
					}
				}
				NativeMethods.BitBlt(dC, 0, 0, bounds.Width, bounds.Height, imageDc.Hdc, 0, 0, 13369376);
			}
			finally
			{
				NativeMethods.ReleaseDC(maskHWnd, dC);
				imageDc.Dispose();
			}
		}
		private void CalculateRect(IntPtr scrollBarHWnd, bool bHorizontal, out Rectangle bounds, out Rectangle trackRect, out Rectangle topLeftArrowRect, out Rectangle bottomRightArrowRect, out Rectangle thumbRect)
		{
			RECT rECT = default(RECT);
			NativeMethods.GetWindowRect(scrollBarHWnd, ref rECT);
			NativeMethods.OffsetRect(ref rECT, -rECT.Left, -rECT.Top);
			int num = bHorizontal ? this.ArrowCx : this.ArrowCy;
			bounds = rECT.Rect;
			Point scrollBarThumb = this.GetScrollBarThumb(bounds, bHorizontal, num);
			trackRect = bounds;
			if (!bHorizontal)
			{
				topLeftArrowRect = new Rectangle(0, 0, bounds.Width, num);
				bottomRightArrowRect = new Rectangle(0, bounds.Height - num, bounds.Width, num);
				thumbRect = new Rectangle(0, scrollBarThumb.X, bounds.Width, scrollBarThumb.Y - scrollBarThumb.X);
				return;
			}
			topLeftArrowRect = new Rectangle(0, 0, num, bounds.Height);
			bottomRightArrowRect = new Rectangle(bounds.Width - num, 0, num, bounds.Height);
			if (this._owner.RightToLeft == RightToLeft.Yes)
			{
				thumbRect = new Rectangle(scrollBarThumb.Y, 0, scrollBarThumb.X - scrollBarThumb.Y, bounds.Height);
				return;
			}
			thumbRect = new Rectangle(scrollBarThumb.X, 0, scrollBarThumb.Y - scrollBarThumb.X, bounds.Height);
		}
		private void GetState(IntPtr scrollBarHWnd, bool bHorizontal, out ScrollBarHistTest histTest, out ControlState topLeftArrowState, out ControlState bottomRightArrowState, out ControlState thumbState)
		{
			histTest = this.ScrollBarHitTest(scrollBarHWnd);
			bool flag = Helper.LeftKeyPressed();
			bool enabled = this._owner.Enabled;
			topLeftArrowState = ControlState.Normal;
			bottomRightArrowState = ControlState.Normal;
			thumbState = ControlState.Normal;
		    int histTests = Convert.ToInt32(histTest);
		    ;
			switch (histTests)
			{
			case 1:
			case 3:
				if (enabled)
				{
					topLeftArrowState = (flag ? ControlState.Pressed : ControlState.Hover);
					return;
				}
				break;
			case 2:
			case 4:
				if (enabled)
				{
					bottomRightArrowState = (flag ? ControlState.Pressed : ControlState.Hover);
					return;
				}
				break;
			case 5:
				if (enabled)
				{
					thumbState = (flag ? ControlState.Pressed : ControlState.Hover);
				}
				break;
			default:
				return;
			}
		}
		protected void CreateHandle()
		{
			base.AssignHandle(this.OwnerHWnd);
			this._maskControl = new ScrollBarManager.ScrollBarMaskControl(this);
			this._maskControl.OnCreateHandle();
		}
		internal void ReleaseHandleInternal()
		{
			if (base.Handle != IntPtr.Zero)
			{
				base.ReleaseHandle();
			}
		}
		private SCROLLBARINFO GetScrollBarInfo(IntPtr hWnd)
		{
			SCROLLBARINFO sCROLLBARINFO = default(SCROLLBARINFO);
			sCROLLBARINFO.cbSize = Marshal.SizeOf(sCROLLBARINFO);
			NativeMethods.SendMessage(hWnd, 235, 0, ref sCROLLBARINFO);
			return sCROLLBARINFO;
		}
		private SCROLLBARINFO GetScrollBarInfo(IntPtr hWnd, uint objid)
		{
			SCROLLBARINFO sCROLLBARINFO = default(SCROLLBARINFO);
			sCROLLBARINFO.cbSize = Marshal.SizeOf(sCROLLBARINFO);
			NativeMethods.GetScrollBarInfo(hWnd, objid, ref sCROLLBARINFO);
			return sCROLLBARINFO;
		}
		private Point GetScrollBarThumb()
		{
			bool flag = this.Direction == Orientation.Horizontal;
			int arrowWidth = flag ? this.ArrowCx : this.ArrowCy;
			return this.GetScrollBarThumb(this._owner.ClientRectangle, flag, arrowWidth);
		}
		private Point GetScrollBarThumb(Rectangle rect, bool bHorizontal, int arrowWidth)
		{
			ScrollBar owner = this._owner;
			Point result = default(Point);
			int num;
			if (bHorizontal)
			{
				num = rect.Width - arrowWidth * 2;
			}
			else
			{
				num = rect.Height - arrowWidth * 2;
			}
			int num2 = owner.Maximum - owner.Minimum - owner.LargeChange + 1;
			float num3 = (float)num / ((float)num2 / (float)owner.LargeChange + 1f);
			if (num3 < 8f)
			{
				num3 = 8f;
			}
			if (num2 != 0)
			{
				int num4 = owner.Value - owner.Minimum;
				if (num4 > num2)
				{
					num4 = num2;
				}
				result.X = (int)((float)num4 * (((float)num - num3) / (float)num2));
			}
			result.X += arrowWidth;
			result.Y = result.X + (int)Math.Ceiling((double)num3);
			if (bHorizontal && owner.RightToLeft == RightToLeft.Yes)
			{
				result.X = owner.Width - result.X;
				result.Y = owner.Width - result.Y;
			}
			return result;
		}
		private ScrollBarHistTest ScrollBarHitTest(IntPtr hWnd)
		{
			NativeMethods.Point pt = default(NativeMethods.Point);
			RECT rECT = default(RECT);
			Point scrollBarThumb = this.GetScrollBarThumb();
			int arrowCx = this.ArrowCx;
			int arrowCy = this.ArrowCy;
			NativeMethods.GetWindowRect(hWnd, ref rECT);
			NativeMethods.OffsetRect(ref rECT, -rECT.Left, -rECT.Top);
			RECT rECT2 = rECT;
			NativeMethods.GetCursorPos(ref pt);
			NativeMethods.ScreenToClient(hWnd, ref pt);
			if (this.Direction == Orientation.Horizontal)
			{
				if (NativeMethods.PtInRect(ref rECT, pt))
				{
					rECT2.Right = arrowCx;
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.LeftArrow;
					}
					rECT2.Left = rECT.Right - arrowCx;
					rECT2.Right = rECT.Right;
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.RightArrow;
					}
					if (this._owner.RightToLeft == RightToLeft.Yes)
					{
						rECT2.Left = pt.y;
						rECT2.Right = pt.x;
					}
					else
					{
						rECT2.Left = scrollBarThumb.X;
						rECT2.Right = scrollBarThumb.Y;
					}
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.Thumb;
					}
					return ScrollBarHistTest.Track;
				}
			}
			else
			{
				if (NativeMethods.PtInRect(ref rECT, pt))
				{
					rECT2.Bottom = arrowCy;
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.TopArrow;
					}
					rECT2.Top = rECT.Bottom - arrowCy;
					rECT2.Bottom = rECT.Bottom;
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.BottomArrow;
					}
					rECT2.Top = scrollBarThumb.X;
					rECT2.Bottom = scrollBarThumb.Y;
					if (NativeMethods.PtInRect(ref rECT2, pt))
					{
						return ScrollBarHistTest.Thumb;
					}
					return ScrollBarHistTest.Track;
				}
			}
			return ScrollBarHistTest.None;
		}
		private void InvalidateWindow(bool messaged)
		{
			this.InvalidateWindow(this.OwnerHWnd, messaged);
		}
		private void InvalidateWindow(IntPtr hWnd, bool messaged)
		{
			if (messaged)
			{
				NativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 2);
				return;
			}
			NativeMethods.RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, 257);
		}
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					if (this._maskControl != null)
					{
						this._maskControl.Dispose();
						this._maskControl = null;
					}
					this._owner = null;
				}
				this.ReleaseHandleInternal();
			}
			this._disposed = true;
		}
	}
}
