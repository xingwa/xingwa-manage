using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[Flags, ComVisible(false)]
	public enum DVASPECT
	{
		DVASPECT_CONTENT = 1,
		DVASPECT_THUMBNAIL = 2,
		DVASPECT_ICON = 4,
		DVASPECT_DOCPRINT = 8,
		DVASPECT_OPAQUE = 16,
		DVASPECT_TRANSPARENT = 32
	}
}
