using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct MOUSEHOOKSTRUCT
	{
		public POINT Pt;
		public IntPtr hwnd;
		public uint wHitTestCode;
		public IntPtr dwExtraInfo;
	}
}
