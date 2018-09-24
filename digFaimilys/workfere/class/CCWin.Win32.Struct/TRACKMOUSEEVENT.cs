using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct TRACKMOUSEEVENT
	{
		public uint cbSize;
		public uint dwFlags;
		public IntPtr hwndTrack;
		public uint dwHoverTime;
	}
}
