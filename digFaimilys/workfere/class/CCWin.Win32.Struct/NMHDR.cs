using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct NMHDR
	{
		public IntPtr hwndFrom;
		public int idFrom;
		public int code;
		public NMHDR(int flag)
		{
			this.hwndFrom = IntPtr.Zero;
			this.idFrom = 0;
			this.code = 0;
		}
	}
}
