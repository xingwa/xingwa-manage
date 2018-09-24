using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct SCROLLBARINFO
	{
		public int cbSize;
		public RECT rcScrollBar;
		public int dxyLineButton;
		public int xyThumbTop;
		public int xyThumbBottom;
		public int reserved;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public int[] rgstate;
	}
}
