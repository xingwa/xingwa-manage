using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Struct
{
	[StructLayout(LayoutKind.Sequential)]
	public sealed class CWPSTRUCT
	{
		public IntPtr lParam;
		public IntPtr wParam;
		public int message;
		public IntPtr hwnd;
	}
}
