using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true)]
	public struct tagMSG
	{
		public IntPtr hwnd;
		[MarshalAs(UnmanagedType.I4)]
		public int message;
		public IntPtr wParam;
		public IntPtr lParam;
		[MarshalAs(UnmanagedType.I4)]
		public int time;
		[MarshalAs(UnmanagedType.I4)]
		public int pt_x;
		[MarshalAs(UnmanagedType.I4)]
		public int pt_y;
	}
}
