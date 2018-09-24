using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("00000118-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleClientSite
	{
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int SaveObject();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetMoniker([MarshalAs(UnmanagedType.U4)] [In] int dwAssign, [MarshalAs(UnmanagedType.U4)] [In] int dwWhichMoniker, [MarshalAs(UnmanagedType.Interface)] out object ppmk);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int GetContainer([MarshalAs(UnmanagedType.Interface)] out IOleContainer container);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int ShowObject();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int OnShowWindow([MarshalAs(UnmanagedType.I4)] [In] int fShow);
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.I4)]
		int RequestNewObjectLayout();
	}
}
