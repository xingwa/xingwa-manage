using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct SCROLLINFO
	{
		public uint cbSize;
		public uint fMask;
		public int nMin;
		public int nMax;
		public uint nPage;
		public int nPos;
		public int nTrackPos;
	}
}
