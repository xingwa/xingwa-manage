using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("0000011B-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleContainer
	{
		void ParseDisplayName([MarshalAs(UnmanagedType.Interface)] [In] object pbc, [MarshalAs(UnmanagedType.BStr)] [In] string pszDisplayName, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] pchEaten, [MarshalAs(UnmanagedType.LPArray)] [Out] object[] ppmkOut);
		void EnumObjects([MarshalAs(UnmanagedType.U4)] [In] int grfFlags, [MarshalAs(UnmanagedType.LPArray)] [Out] object[] ppenum);
		void LockContainer([MarshalAs(UnmanagedType.I4)] [In] int fLock);
	}
}
