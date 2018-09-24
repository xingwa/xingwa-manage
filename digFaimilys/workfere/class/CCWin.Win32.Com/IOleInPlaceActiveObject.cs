using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("00000117-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IOleInPlaceActiveObject
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetWindow([In] [Out] ref IntPtr phwnd);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] [In] bool fEnterMode);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int TranslateAccelerator([MarshalAs(UnmanagedType.Struct)] [In] ref tagMSG lpmsg);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int OnFrameWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int OnDocWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ResizeBorder([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT prcBorder, [MarshalAs(UnmanagedType.Interface)] [In] ref IOleInPlaceUIWindow pUIWindow, [MarshalAs(UnmanagedType.Bool)] [In] bool fFrameWindow);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int EnableModeless([MarshalAs(UnmanagedType.Bool)] [In] bool fEnable);
	}
}
