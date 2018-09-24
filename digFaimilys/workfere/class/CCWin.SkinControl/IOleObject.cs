using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("00000112-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IOleObject
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetClientSite([MarshalAs(UnmanagedType.Interface)] [In] IOleClientSite pClientSite);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetClientSite(out IOleClientSite site);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetHostNames([MarshalAs(UnmanagedType.LPWStr)] [In] string szContainerApp, [MarshalAs(UnmanagedType.LPWStr)] [In] string szContainerObj);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Close([MarshalAs(UnmanagedType.I4)] [In] int dwSaveOption);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetMoniker([MarshalAs(UnmanagedType.U4)] [In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] [In] object pmk);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetMoniker([MarshalAs(UnmanagedType.U4)] [In] int dwAssign, [MarshalAs(UnmanagedType.U4)] [In] int dwWhichMoniker, out object moniker);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int InitFromData([MarshalAs(UnmanagedType.Interface)] [In] IDataObject pDataObject, [MarshalAs(UnmanagedType.I4)] [In] int fCreation, [MarshalAs(UnmanagedType.U4)] [In] int dwReserved);
		int GetClipboardData([MarshalAs(UnmanagedType.U4)] [In] int dwReserved, out IDataObject data);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int DoVerb([MarshalAs(UnmanagedType.I4)] [In] int iVerb, [In] IntPtr lpmsg, [MarshalAs(UnmanagedType.Interface)] [In] IOleClientSite pActiveSite, [MarshalAs(UnmanagedType.I4)] [In] int lindex, [In] IntPtr hwndParent, [In] COMRECT lprcPosRect);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int EnumVerbs(out IEnumOLEVERB e);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Update();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int IsUpToDate();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetUserClassID([In] [Out] ref Guid pClsid);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetUserType([MarshalAs(UnmanagedType.U4)] [In] int dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string userType);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetExtent([MarshalAs(UnmanagedType.U4)] [In] int dwDrawAspect, [In] Size pSizel);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetExtent([MarshalAs(UnmanagedType.U4)] [In] int dwDrawAspect, [Out] Size pSizel);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Advise([MarshalAs(UnmanagedType.Interface)] [In] IAdviseSink pAdvSink, out int cookie);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int Unadvise([MarshalAs(UnmanagedType.U4)] [In] int dwConnection);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int EnumAdvise(out IEnumSTATDATA e);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetMiscStatus([MarshalAs(UnmanagedType.U4)] [In] int dwAspect, out int misc);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetColorScheme([In] tagLOGPALETTE pLogpal);
	}
}
