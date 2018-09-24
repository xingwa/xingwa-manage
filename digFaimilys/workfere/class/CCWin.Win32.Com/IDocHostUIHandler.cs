using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
namespace xingwaWinFormUI.Win32.Com
{
	[ComVisible(true), Guid("bd3f23c0-d43e-11cf-893b-00aa00bdce1a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IDocHostUIHandler
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ShowContextMenu([MarshalAs(UnmanagedType.U4)] [In] uint dwID, [MarshalAs(UnmanagedType.Struct)] [In] ref tagPOINT pt, [MarshalAs(UnmanagedType.IUnknown)] [In] object pcmdtReserved, [MarshalAs(UnmanagedType.IDispatch)] [In] object pdispReserved);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetHostInfo([MarshalAs(UnmanagedType.Struct)] [In] [Out] ref DOCHOSTUIINFO info);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ShowUI([MarshalAs(UnmanagedType.I4)] [In] int dwID, [MarshalAs(UnmanagedType.Interface)] [In] IOleInPlaceActiveObject activeObject, [MarshalAs(UnmanagedType.Interface)] [In] IOleCommandTarget commandTarget, [MarshalAs(UnmanagedType.Interface)] [In] IOleInPlaceFrame frame, [MarshalAs(UnmanagedType.Interface)] [In] IOleInPlaceUIWindow doc);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int HideUI();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int UpdateUI();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int EnableModeless([MarshalAs(UnmanagedType.Bool)] [In] bool fEnable);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int OnDocWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int OnFrameWindowActivate([MarshalAs(UnmanagedType.Bool)] [In] bool fActivate);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ResizeBorder([MarshalAs(UnmanagedType.Struct)] [In] ref tagRECT rect, [MarshalAs(UnmanagedType.Interface)] [In] IOleInPlaceUIWindow doc, [MarshalAs(UnmanagedType.Bool)] [In] bool fFrameWindow);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int TranslateAccelerator([MarshalAs(UnmanagedType.Struct)] [In] ref tagMSG msg, [In] ref Guid group, [MarshalAs(UnmanagedType.U4)] [In] uint nCmdID);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetOptionKeyPath([MarshalAs(UnmanagedType.LPWStr)] out string pbstrKey, [MarshalAs(UnmanagedType.U4)] [In] uint dw);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetDropTarget([MarshalAs(UnmanagedType.Interface)] [In] IDropTarget pDropTarget, [MarshalAs(UnmanagedType.Interface)] out IDropTarget ppDropTarget);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetExternal([MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int TranslateUrl([MarshalAs(UnmanagedType.U4)] [In] uint dwTranslate, [MarshalAs(UnmanagedType.LPWStr)] [In] string strURLIn, [MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int FilterDataObject([MarshalAs(UnmanagedType.Interface)] [In] IDataObject pDO, [MarshalAs(UnmanagedType.Interface)] out IDataObject ppDORet);
	}
}
