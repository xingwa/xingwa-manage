using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(false)]
	public struct FORMATETC
	{
		public CLIPFORMAT cfFormat;
		public IntPtr ptd;
		public DVASPECT dwAspect;
		public int lindex;
		public TYMED tymed;
	}
}
