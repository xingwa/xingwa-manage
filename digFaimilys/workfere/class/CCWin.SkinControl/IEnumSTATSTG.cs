using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace xingwaWinFormUI.SkinControl
{
	[Guid("0000000d-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IEnumSTATSTG
	{
		[PreserveSig]
		uint Next(uint celt, [MarshalAs(UnmanagedType.LPArray)] [Out] System.Runtime.InteropServices.ComTypes.STATSTG[] rgelt, out uint pceltFetched);
		void Skip(uint celt);
		void Reset();
		[return: MarshalAs(UnmanagedType.Interface)]
		IEnumSTATSTG Clone();
	}
}
