using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true)]
	public struct tagOLECMD
	{
		[MarshalAs(UnmanagedType.U4)]
		public uint cmdID;
		[MarshalAs(UnmanagedType.U4)]
		public uint cmdf;
	}
}
