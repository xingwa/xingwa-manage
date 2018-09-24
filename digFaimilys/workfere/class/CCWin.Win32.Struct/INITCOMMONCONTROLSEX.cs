using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct INITCOMMONCONTROLSEX
	{
		public int dwSize;
		public int dwICC;
		public INITCOMMONCONTROLSEX(int flags)
		{
			this.dwSize = Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX));
			this.dwICC = flags;
		}
	}
}
