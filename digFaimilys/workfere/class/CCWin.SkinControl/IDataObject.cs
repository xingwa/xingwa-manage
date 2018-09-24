using System;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[ComVisible(true), Guid("0000010E-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IDataObject
	{
		[PreserveSig]
		uint GetData(ref FORMATETC a, ref STGMEDIUM b);
		[PreserveSig]
		uint GetDataHere(ref FORMATETC pFormatetc, out STGMEDIUM pMedium);
		[PreserveSig]
		uint QueryGetData(ref FORMATETC pFormatetc);
		[PreserveSig]
		uint GetCanonicalFormatEtc(ref FORMATETC pformatectIn, out FORMATETC pformatetcOut);
		[PreserveSig]
		uint SetData(ref FORMATETC pFormatectIn, ref STGMEDIUM pmedium, [MarshalAs(UnmanagedType.Bool)] [In] bool fRelease);
		[PreserveSig]
		uint EnumFormatEtc(uint dwDirection, IEnumFORMATETC penum);
		[PreserveSig]
		uint DAdvise(ref FORMATETC pFormatetc, int advf, [MarshalAs(UnmanagedType.Interface)] [In] IAdviseSink pAdvSink, out uint pdwConnection);
		[PreserveSig]
		uint DUnadvise(uint dwConnection);
		[PreserveSig]
		uint EnumDAdvise([MarshalAs(UnmanagedType.Interface)] out IEnumSTATDATA ppenumAdvise);
	}
}
