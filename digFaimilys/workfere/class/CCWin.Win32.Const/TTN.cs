using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Const
{
	public static class TTN
	{
		public const int TTN_FIRST = -520;
		public const int TTN_GETDISPINFOA = -520;
		public const int TTN_GETDISPINFOW = -530;
		public const int TTN_SHOW = -521;
		public const int TTN_POP = -522;
		public const int TTN_LINKCLICK = -523;
		public const int TTN_NEEDTEXTA = -520;
		public const int TTN_NEEDTEXTW = -530;
		public const int TTN_LAST = -549;
		public static readonly int TTN_GETDISPINFO;
		public static readonly int TTN_NEEDTEXT;
		static TTN()
		{
			bool flag = Marshal.SystemDefaultCharSize != 1;
			if (flag)
			{
				TTN.TTN_GETDISPINFO = -530;
				TTN.TTN_NEEDTEXT = -530;
				return;
			}
			TTN.TTN_GETDISPINFO = -520;
			TTN.TTN_NEEDTEXT = -520;
		}
	}
}
