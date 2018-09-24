using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace xingwaWinFormUI.SkinControl
{
	[Guid("0000000a-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface ILockBytes
	{
		int ReadAt(ulong ulOffset, IntPtr pv, uint cb, out IntPtr pcbRead);
		int WriteAt(ulong ulOffset, IntPtr pv, uint cb, out IntPtr pcbWritten);
		int Flush();
		int SetSize(ulong cb);
		int LockRegion(ulong libOffset, ulong cb, uint dwLockType);
		int UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);
		int Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, uint grfStatFlag);
	}
}
