using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[Guid("00020D00-0000-0000-c000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IRichEditOle
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetClientSite(out IOleClientSite site);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetObjectCount();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetLinkCount();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetObject(int iob, [In] [Out] REOBJECT lpreobject, [MarshalAs(UnmanagedType.U4)] GETOBJECTOPTIONS flags);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int InsertObject(REOBJECT lpreobject);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ConvertObject(int iob, Guid rclsidNew, string lpstrUserTypeNew);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ActivateAs(Guid rclsid, Guid rclsidAs);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetHostNames(string lpstrContainerApp, string lpstrContainerObj);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetLinkAvailable(int iob, bool fAvailable);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SetDvaspect(int iob, uint dvaspect);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int HandsOffStorage(int iob);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SaveCompleted(int iob, IStorage lpstg);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int InPlaceDeactivate();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ContextSensitiveHelp(bool fEnterMode);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetClipboardData([In] [Out] ref CHARRANGE lpchrg, [MarshalAs(UnmanagedType.U4)] GETCLIPBOARDDATAFLAGS reco, out IDataObject lplpdataobj);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ImportDataObject(IDataObject lpdataobj, int cf, IntPtr hMetaPict);
	}
}
