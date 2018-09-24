using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("0000010F-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAdviseSink
	{
		void OnDataChange([In] FORMATETC pFormatetc, [In] STGMEDIUM pStgmed);
		void OnViewChange([MarshalAs(UnmanagedType.U4)] [In] int dwAspect, [MarshalAs(UnmanagedType.I4)] [In] int lindex);
		void OnRename([MarshalAs(UnmanagedType.Interface)] [In] object pmk);
		void OnSave();
		void OnClose();
	}
}
