using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("00000103-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IEnumFORMATETC
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Next([MarshalAs(UnmanagedType.U4)] [In] int celt, [Out] FORMATETC rgelt, [MarshalAs(UnmanagedType.LPArray)] [In] [Out] int[] pceltFetched);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Skip([MarshalAs(UnmanagedType.U4)] [In] int celt);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Reset();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Clone([MarshalAs(UnmanagedType.LPArray)] [Out] IEnumFORMATETC[] ppenum);
	}
}
