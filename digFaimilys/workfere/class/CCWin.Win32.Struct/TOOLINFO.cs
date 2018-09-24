using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct TOOLINFO
	{
		public int cbSize;
		public int uFlags;
		public IntPtr hwnd;
		public IntPtr uId;
		public RECT rect;
		public IntPtr hinst;
		public IntPtr lpszText;
		public IntPtr lParam;
		public TOOLINFO(int flags)
		{
			this.cbSize = Marshal.SizeOf(typeof(TOOLINFO));
			this.uFlags = flags;
			this.hwnd = IntPtr.Zero;
			this.uId = IntPtr.Zero;
			this.rect = new RECT(0, 0, 0, 0);
			this.hinst = IntPtr.Zero;
			this.lpszText = IntPtr.Zero;
			this.lParam = IntPtr.Zero;
		}
	}
}
