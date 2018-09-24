using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true)]
	public struct tagRECT
	{
		[MarshalAs(UnmanagedType.I4)]
		public int Left;
		[MarshalAs(UnmanagedType.I4)]
		public int Top;
		[MarshalAs(UnmanagedType.I4)]
		public int Right;
		[MarshalAs(UnmanagedType.I4)]
		public int Bottom;
		public tagRECT(int left_, int top_, int right_, int bottom_)
		{
			this.Left = left_;
			this.Top = top_;
			this.Right = right_;
			this.Bottom = bottom_;
		}
	}
}
