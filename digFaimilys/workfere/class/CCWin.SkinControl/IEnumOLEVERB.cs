using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("00000104-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IEnumOLEVERB
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Next([MarshalAs(UnmanagedType.U4)] int celt, [Out] tagOLEVERB rgelt, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] pceltFetched);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Skip([MarshalAs(UnmanagedType.U4)] [In] int celt);
		void Reset();
		void Clone(out IEnumOLEVERB ppenum);
	}
}
