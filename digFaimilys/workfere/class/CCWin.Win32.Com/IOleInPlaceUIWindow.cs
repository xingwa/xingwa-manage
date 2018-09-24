using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("00000115-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IOleInPlaceUIWindow
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetWindow([In] [Out] ref IntPtr phwnd);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] [In] bool fEnterMode);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetBorder([MarshalAs(UnmanagedType.Struct)] [In] [Out] ref tagRECT lprectBorder);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int RequestBorderSpace([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT pborderwidths);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetBorderSpace([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT pborderwidths);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetActiveObject([MarshalAs(UnmanagedType.Interface)] [In] ref IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszObjName);
	}
}
