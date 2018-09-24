using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true)]
	public struct tagPOINT
	{
		[MarshalAs(UnmanagedType.I4)]
		public int X;
		[MarshalAs(UnmanagedType.I4)]
		public int Y;
	}
}
