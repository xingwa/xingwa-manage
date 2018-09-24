using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Const
{
	public static class TTM
	{
		public const int WM_USER = 1024;
		public const int TTM_ACTIVATE = 1025;
		public const int TTM_SETDELAYTIME = 1027;
		public const int TTM_RELAYEVENT = 1031;
		public const int TTM_GETTOOLCOUNT = 1037;
		public const int TTM_WINDOWFROMPOINT = 1040;
		public const int TTM_TRACKACTIVATE = 1041;
		public const int TTM_TRACKPOSITION = 1042;
		public const int TTM_SETTIPBKCOLOR = 1043;
		public const int TTM_SETTIPTEXTCOLOR = 1044;
		public const int TTM_GETDELAYTIME = 1045;
		public const int TTM_GETTIPBKCOLOR = 1046;
		public const int TTM_GETTIPTEXTCOLOR = 1047;
		public const int TTM_SETMAXTIPWIDTH = 1048;
		public const int TTM_GETMAXTIPWIDTH = 1049;
		public const int TTM_SETMARGIN = 1050;
		public const int TTM_GETMARGIN = 1051;
		public const int TTM_POP = 1052;
		public const int TTM_UPDATE = 1053;
		public const int TTM_POPUP = 1058;
		public const int TTM_ADJUSTRECT = 1055;
		public const int TTM_ADDTOOLA = 1028;
		public const int TTM_DELTOOLA = 1029;
		public const int TTM_NEWTOOLRECTA = 1030;
		public const int TTM_GETTOOLINFOA = 1032;
		public const int TTM_SETTOOLINFOA = 1033;
		public const int TTM_HITTESTA = 1034;
		public const int TTM_GETTEXTA = 1035;
		public const int TTM_UPDATETIPTEXTA = 1036;
		public const int TTM_GETCURRENTTOOLA = 1039;
		public const int TTM_ENUMTOOLSA = 1038;
		public const int TTM_SETTITLEA = 1056;
		public const int TTM_ADDTOOLW = 1074;
		public const int TTM_DELTOOLW = 1075;
		public const int TTM_NEWTOOLRECTW = 1076;
		public const int TTM_GETTOOLINFOW = 1077;
		public const int TTM_SETTOOLINFOW = 1078;
		public const int TTM_HITTESTW = 1079;
		public const int TTM_GETTEXTW = 1080;
		public const int TTM_UPDATETIPTEXTW = 1081;
		public const int TTM_ENUMTOOLSW = 1082;
		public const int TTM_GETCURRENTTOOLW = 1083;
		public const int TTM_SETTITLEW = 1057;
		public static readonly int TTM_ADDTOOL;
		public static readonly int TTM_DELTOOL;
		public static readonly int TTM_NEWTOOLRECT;
		public static readonly int TTM_GETTOOLINFO;
		public static readonly int TTM_SETTOOLINFO;
		public static readonly int TTM_HITTEST;
		public static readonly int TTM_GETTEXT;
		public static readonly int TTM_UPDATETIPTEXT;
		public static readonly int TTM_ENUMTOOLS;
		public static readonly int TTM_GETCURRENTTOOL;
		public static readonly int TTM_SETTITLE;
		static TTM()
		{
			bool flag = Marshal.SystemDefaultCharSize != 1;
			if (flag)
			{
				TTM.TTM_ADDTOOL = 1074;
				TTM.TTM_DELTOOL = 1075;
				TTM.TTM_NEWTOOLRECT = 1076;
				TTM.TTM_GETTOOLINFO = 1077;
				TTM.TTM_SETTOOLINFO = 1078;
				TTM.TTM_HITTEST = 1079;
				TTM.TTM_GETTEXT = 1080;
				TTM.TTM_UPDATETIPTEXT = 1081;
				TTM.TTM_GETCURRENTTOOL = 1083;
				TTM.TTM_ENUMTOOLS = 1082;
				TTM.TTM_GETCURRENTTOOL = 1083;
				TTM.TTM_SETTITLE = 1057;
				return;
			}
			TTM.TTM_ADDTOOL = 1028;
			TTM.TTM_DELTOOL = 1029;
			TTM.TTM_NEWTOOLRECT = 1030;
			TTM.TTM_GETTOOLINFO = 1032;
			TTM.TTM_SETTOOLINFO = 1033;
			TTM.TTM_HITTEST = 1034;
			TTM.TTM_GETTEXT = 1035;
			TTM.TTM_UPDATETIPTEXT = 1036;
			TTM.TTM_GETCURRENTTOOL = 1039;
			TTM.TTM_ENUMTOOLS = 1038;
			TTM.TTM_GETCURRENTTOOL = 1039;
			TTM.TTM_SETTITLE = 1056;
		}
	}
}
