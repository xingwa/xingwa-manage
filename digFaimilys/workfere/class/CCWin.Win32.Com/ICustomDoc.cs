using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[Guid("3050F3F0-98B5-11CF-BB82-00AA00BDCE0B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface ICustomDoc
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetUIHandler([MarshalAs(UnmanagedType.Interface)] [In] IDocHostUIHandler pUIHandler);
	}
}
