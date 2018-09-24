using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("00000105-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumSTATDATA
	{
		void Next([MarshalAs(UnmanagedType.U4)] [In] int celt, [Out] STATDATA rgelt, [MarshalAs(UnmanagedType.LPArray)] [Out] int[] pceltFetched);
		void Skip([MarshalAs(UnmanagedType.U4)] [In] int celt);
		void Reset();
		void Clone([MarshalAs(UnmanagedType.LPArray)] [Out] IEnumSTATDATA[] ppenum);
	}
}
