using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(false)]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class tagLOGPALETTE
	{
		[MarshalAs(UnmanagedType.U2)]
		public short palVersion;
		[MarshalAs(UnmanagedType.U2)]
		public short palNumEntries;
	}
}
