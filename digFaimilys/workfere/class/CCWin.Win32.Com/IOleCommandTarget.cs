using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IOleCommandTarget
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int QueryStatus([In] IntPtr pguidCmdGroup, [MarshalAs(UnmanagedType.U4)] [In] uint cCmds, [MarshalAs(UnmanagedType.Struct)] [In] [Out] ref tagOLECMD prgCmds, [In] [Out] IntPtr pCmdText);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Exec([In] IntPtr pguidCmdGroup, [MarshalAs(UnmanagedType.U4)] [In] uint nCmdID, [MarshalAs(UnmanagedType.U4)] [In] uint nCmdexecopt, [In] IntPtr pvaIn, [In] [Out] IntPtr pvaOut);
	}
}
