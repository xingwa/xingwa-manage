using xingwaWinFormUI.Win32;
using System;
using System.Security.Permissions;
namespace xingwaWinFormUI.SkinClass
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class ImageDc : IDisposable
	{
		private int _height;
		private int _width;
		private IntPtr _pHdc = IntPtr.Zero;
		private IntPtr _pBmp = IntPtr.Zero;
		private IntPtr _pBmpOld = IntPtr.Zero;
		public IntPtr Hdc
		{
			get
			{
				return this._pHdc;
			}
		}
		public IntPtr HBmp
		{
			get
			{
				return this._pBmp;
			}
		}
		public ImageDc(int width, int height, IntPtr hBmp)
		{
			this.CreateImageDc(width, height, hBmp);
		}
		public ImageDc(int width, int height)
		{
			this.CreateImageDc(width, height, IntPtr.Zero);
		}
		private void CreateImageDc(int width, int height, IntPtr hBmp)
		{
			IntPtr hdc = IntPtr.Zero;
			hdc = NativeMethods.CreateDCA("DISPLAY", "", "", 0);
			this._pHdc = NativeMethods.CreateCompatibleDC(hdc);
			if (hBmp != IntPtr.Zero)
			{
				this._pBmp = hBmp;
			}
			else
			{
				this._pBmp = NativeMethods.CreateCompatibleBitmap(hdc, width, height);
			}
			this._pBmpOld = NativeMethods.SelectObject(this._pHdc, this._pBmp);
			if (this._pBmpOld == IntPtr.Zero)
			{
				this.ImageDestroy();
			}
			else
			{
				this._width = width;
				this._height = height;
			}
			NativeMethods.DeleteDC(hdc);
			hdc = IntPtr.Zero;
		}
		private void ImageDestroy()
		{
			if (this._pBmpOld != IntPtr.Zero)
			{
				NativeMethods.SelectObject(this._pHdc, this._pBmpOld);
				this._pBmpOld = IntPtr.Zero;
			}
			if (this._pBmp != IntPtr.Zero)
			{
				NativeMethods.DeleteObject(this._pBmp);
				this._pBmp = IntPtr.Zero;
			}
			if (this._pHdc != IntPtr.Zero)
			{
				NativeMethods.DeleteDC(this._pHdc);
				this._pHdc = IntPtr.Zero;
			}
		}
		public void Dispose()
		{
			this.ImageDestroy();
		}
	}
}
