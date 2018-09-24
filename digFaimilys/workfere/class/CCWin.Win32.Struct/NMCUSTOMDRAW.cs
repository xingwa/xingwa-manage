using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct NMCUSTOMDRAW
	{
		public NMHDR hdr;
		public uint dwDrawStage;
		public IntPtr hdc;
		public RECT rc;
		public IntPtr dwItemSpec;
		public uint uItemState;
		public IntPtr lItemlParam;
	}
}
