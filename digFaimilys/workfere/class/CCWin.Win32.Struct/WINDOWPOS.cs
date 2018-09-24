using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct WINDOWPOS
	{
		public IntPtr hWnd;
		public IntPtr hWndInsertAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public int flags;
	}
}
