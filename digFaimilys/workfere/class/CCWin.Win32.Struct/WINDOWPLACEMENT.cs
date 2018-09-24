using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct WINDOWPLACEMENT
	{
		public int length;
		public int flags;
		public int showCmd;
		public Point ptMinPosition;
		public Point ptMaxPosition;
		public RECT rcNormalPosition;
		public static WINDOWPLACEMENT Default
		{
			get
			{
				WINDOWPLACEMENT wINDOWPLACEMENT = default(WINDOWPLACEMENT);
				wINDOWPLACEMENT.length = Marshal.SizeOf(wINDOWPLACEMENT);
				return wINDOWPLACEMENT;
			}
		}
	}
}
