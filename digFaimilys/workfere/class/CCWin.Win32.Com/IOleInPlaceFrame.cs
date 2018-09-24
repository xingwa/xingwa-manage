using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("00000116-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IOleInPlaceFrame
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetWindow([In] [Out] ref IntPtr phwnd);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] [In] bool fEnterMode);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetBorder([MarshalAs(UnmanagedType.LPStruct)] [Out] tagRECT lprectBorder);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int RequestBorderSpace([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT pborderwidths);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetBorderSpace([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT pborderwidths);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetActiveObject([MarshalAs(UnmanagedType.Interface)] [In] ref IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszObjName);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int InsertMenus([In] IntPtr hmenuShared, [MarshalAs(UnmanagedType.Struct)] [In] [Out] ref object lpMenuWidths);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetMenu([In] IntPtr hmenuShared, [In] IntPtr holemenu, [In] IntPtr hwndActiveObject);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int RemoveMenus([In] IntPtr hmenuShared);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetStatusText([MarshalAs(UnmanagedType.LPWStr)] [In] string pszStatusText);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int EnableModeless([MarshalAs(UnmanagedType.Bool)] [In] bool fEnable);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int TranslateAccelerator([MarshalAs(UnmanagedType.Struct)] [In] ref tagMSG lpmsg, [MarshalAs(UnmanagedType.U2)] [In] short wID);
	}
}
