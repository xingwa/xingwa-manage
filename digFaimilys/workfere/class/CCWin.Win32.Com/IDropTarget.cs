using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("00000122-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IDropTarget
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int DragEnter([MarshalAs(UnmanagedType.Interface)] [In] IDataObject pDataObj, [MarshalAs(UnmanagedType.U4)] [In] uint grfKeyState, [MarshalAs(UnmanagedType.Struct)] [In] tagPOINT pt, [MarshalAs(UnmanagedType.U4)] [In] [Out] ref uint pdwEffect);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int DragOver([MarshalAs(UnmanagedType.U4)] [In] uint grfKeyState, [MarshalAs(UnmanagedType.Struct)] [In] tagPOINT pt, [MarshalAs(UnmanagedType.U4)] [In] [Out] ref uint pdwEffect);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int DragLeave();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Drop([MarshalAs(UnmanagedType.Interface)] [In] IDataObject pDataObj, [MarshalAs(UnmanagedType.U4)] [In] uint grfKeyState, [MarshalAs(UnmanagedType.Struct)] [In] tagPOINT pt, [MarshalAs(UnmanagedType.U4)] [In] [Out] ref uint pdwEffect);
	}
}
