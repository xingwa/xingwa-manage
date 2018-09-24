using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Const;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	internal abstract class MaskControlBase : NativeWindow, IDisposable
	{
		private CreateParams _createParams;
		private bool _disposed;
		protected bool IsHandleCreated
		{
			get
			{
				return base.Handle != IntPtr.Zero;
			}
		}
		protected virtual CreateParams CreateParams
		{
			get
			{
				return this._createParams;
			}
		}
		protected MaskControlBase(IntPtr hWnd)
		{
			this.CreateParamsInternal(hWnd);
		}
		protected MaskControlBase(IntPtr hWnd, Rectangle rect)
		{
			this.CreateParamsInternal(hWnd, rect);
		}
		~MaskControlBase()
		{
			this.Dispose(false);
		}
		protected internal void OnCreateHandle()
		{
			base.CreateHandle(this.CreateParams);
			this.SetZorder();
		}
		protected virtual void OnPaint(IntPtr hWnd)
		{
		}
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			try
			{
				int msg = m.Msg;
				if (msg == 15 || msg == 133)
				{
					this.OnPaint(m.HWnd);
				}
			}
			catch
			{
			}
		}
		internal void CreateParamsInternal(IntPtr hWnd)
		{
			IntPtr parent = NativeMethods.GetParent(hWnd);
			RECT rECT = default(RECT);
			NativeMethods.Point point = default(NativeMethods.Point);
			NativeMethods.GetWindowRect(hWnd, ref rECT);
			point.x = rECT.Left;
			point.y = rECT.Top;
			NativeMethods.ScreenToClient(parent, ref point);
			int style = 1409286157;
			int exStyle = 136;
			this._createParams = new CreateParams();
			this._createParams.Parent = parent;
			this._createParams.ClassName = "STATIC";
			this._createParams.Caption = null;
			this._createParams.Style = style;
			this._createParams.ExStyle = exStyle;
			this._createParams.X = point.x;
			this._createParams.Y = point.y;
			this._createParams.Width = rECT.Right - rECT.Left;
			this._createParams.Height = rECT.Bottom - rECT.Top;
		}
		internal void CreateParamsInternal(IntPtr hWnd, Rectangle rect)
		{
			IntPtr parent = NativeMethods.GetParent(hWnd);
			int style = 1409286157;
			int exStyle = 136;
			this._createParams = new CreateParams();
			this._createParams.Parent = parent;
			this._createParams.ClassName = "STATIC";
			this._createParams.Caption = null;
			this._createParams.Style = style;
			this._createParams.ExStyle = exStyle;
			this._createParams.X = rect.X;
			this._createParams.Y = rect.Y;
			this._createParams.Width = rect.Width;
			this._createParams.Height = rect.Height;
		}
		internal void DestroyHandleInternal()
		{
			if (this.IsHandleCreated)
			{
				base.DestroyHandle();
			}
		}
		internal void CheckBounds(IntPtr hWnd)
		{
			RECT rECT = default(RECT);
			RECT rECT2 = default(RECT);
			NativeMethods.GetWindowRect(base.Handle, ref rECT2);
			NativeMethods.GetWindowRect(hWnd, ref rECT);
			uint flags = 532u;
			if (!NativeMethods.EqualRect(ref rECT, ref rECT2))
			{
				NativeMethods.Point point = new NativeMethods.Point(rECT.Left, rECT.Top);
				IntPtr parent = NativeMethods.GetParent(base.Handle);
				NativeMethods.ScreenToClient(parent, ref point);
				NativeMethods.SetWindowPos(base.Handle, IntPtr.Zero, point.x, point.y, rECT.Right - rECT.Left, rECT.Bottom - rECT.Top, flags);
			}
		}
		internal void SetVisibale(IntPtr hWnd)
		{
			bool visibale = (NativeMethods.GetWindowLong(hWnd, -16) & 268435456) == 268435456;
			this.SetVisibale(visibale);
		}
		internal void SetVisibale(bool visibale)
		{
			if (visibale)
			{
				NativeMethods.ShowWindow(base.Handle, 1);
				return;
			}
			NativeMethods.ShowWindow(base.Handle, 0);
		}
		private void SetZorder()
		{
			uint flags = 531u;
			NativeMethods.SetWindowPos(base.Handle, HWND.HWND_TOP, 0, 0, 0, 0, flags);
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
					this._createParams = null;
				}
				this.DestroyHandleInternal();
			}
			this._disposed = true;
		}
	}
}
