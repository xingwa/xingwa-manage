using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(false)]
	public struct STGMEDIUM
	{
		public int tymed;
		public IntPtr unionmember;
		public IntPtr pUnkForRelease;
	}
}
