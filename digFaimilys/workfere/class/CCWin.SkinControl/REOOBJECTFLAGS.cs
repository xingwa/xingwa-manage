using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[Flags, ComVisible(false)]
	public enum REOOBJECTFLAGS : uint
	{
		REO_NULL = 0u,
		REO_READWRITEMASK = 63u,
		REO_DONTNEEDPALETTE = 32u,
		REO_BLANK = 16u,
		REO_DYNAMICSIZE = 8u,
		REO_INVERTEDSELECT = 4u,
		REO_BELOWBASELINE = 2u,
		REO_RESIZABLE = 1u,
		REO_LINK = 2147483648u,
		REO_STATIC = 1073741824u,
		REO_SELECTED = 134217728u,
		REO_OPEN = 67108864u,
		REO_INPLACEACTIVE = 33554432u,
		REO_HILITED = 16777216u,
		REO_LINKAVAILABLE = 8388608u,
		REO_GETMETAFILE = 4194304u
	}
}
