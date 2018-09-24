using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct WINDOWINFO
	{
		public uint cbSize;
		public RECT rcWindow;
		public RECT rcClient;
		public uint dwStyle;
		public uint dwExStyle;
		public uint dwWindowStatus;
		public uint cxWindowBorders;
		public uint cyWindowBorders;
		public IntPtr atomWindowType;
		public ushort wCreatorVersion;
	}
}
