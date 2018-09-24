using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace xingwaWinFormUI.SkinControl
{
	[Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IStream : ISequentialStream
	{
		int Seek(ulong dlibMove, uint dwOrigin, out ulong plibNewPosition);
		int SetSize(ulong libNewSize);
		int CopyTo([In] IStream pstm, ulong cb, out ulong pcbRead, out ulong pcbWritten);
		int Commit(uint grfCommitFlags);
		int Revert();
		int LockRegion(ulong libOffset, ulong cb, uint dwLockType);
		int UnlockRegion(ulong libOffset, ulong cb, uint dwLockType);
		int Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, uint grfStatFlag);
		int Clone(out IStream ppstm);
	}
}
