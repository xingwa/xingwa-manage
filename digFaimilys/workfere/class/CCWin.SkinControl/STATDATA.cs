using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(false)]
	[StructLayout(LayoutKind.Sequential)]
	public sealed class STATDATA
	{
		[MarshalAs(UnmanagedType.U4)]
		public int advf;
		[MarshalAs(UnmanagedType.U4)]
		public int dwConnection;
	}
}
