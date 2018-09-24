using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.Win32.Com
{
	[Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), TypeLibType(TypeLibTypeFlags.FHidden | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface DWebBrowserEvents2
	{
		[DispId(102)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void StatusTextChange([MarshalAs(UnmanagedType.BStr)] [In] string Text);
		[DispId(108)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void ProgressChange([In] int Progress, [In] int ProgressMax);
		[DispId(105)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void CommandStateChange([In] int Command, [In] bool Enable);
		[DispId(106)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void DownloadBegin();
		[DispId(104)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void DownloadComplete();
		[DispId(113)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void TitleChange([MarshalAs(UnmanagedType.BStr)] [In] string Text);
		[DispId(112)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void PropertyChange([MarshalAs(UnmanagedType.BStr)] [In] string szProperty);
		[DispId(250)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void BeforeNavigate2([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [MarshalAs(UnmanagedType.Struct)] [In] ref object URL, [MarshalAs(UnmanagedType.Struct)] [In] ref object Flags, [MarshalAs(UnmanagedType.Struct)] [In] ref object TargetFrameName, [MarshalAs(UnmanagedType.Struct)] [In] ref object PostData, [MarshalAs(UnmanagedType.Struct)] [In] ref object Headers, [In] [Out] ref bool Cancel);
		[DispId(251)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void NewWindow2([MarshalAs(UnmanagedType.IDispatch)] [In] [Out] ref object ppDisp, [In] [Out] ref bool Cancel);
		[DispId(252)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void NavigateComplete2([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [MarshalAs(UnmanagedType.Struct)] [In] ref object URL);
		[DispId(259)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void DocumentComplete([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [MarshalAs(UnmanagedType.Struct)] [In] ref object URL);
		[DispId(253)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnQuit();
		[DispId(254)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnVisible([In] bool Visible);
		[DispId(255)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnToolBar([In] bool ToolBar);
		[DispId(256)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnMenuBar([In] bool MenuBar);
		[DispId(257)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnStatusBar([In] bool StatusBar);
		[DispId(258)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnFullScreen([In] bool FullScreen);
		[DispId(260)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void OnTheaterMode([In] bool TheaterMode);
		[DispId(262)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowSetResizable([In] bool Resizable);
		[DispId(264)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowSetLeft([In] int Left);
		[DispId(265)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowSetTop([In] int Top);
		[DispId(266)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowSetWidth([In] int Width);
		[DispId(267)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowSetHeight([In] int Height);
		[DispId(263)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void WindowClosing([In] bool IsChildWindow, [In] [Out] ref bool Cancel);
		[DispId(268)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void ClientToHostWindow([In] [Out] ref int CX, [In] [Out] ref int CY);
		[DispId(269)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void SetSecureLockIcon([In] int SecureLockIcon);
		[DispId(270)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void FileDownload([In] [Out] ref bool Cancel);
		[DispId(271)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void NavigateError([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [MarshalAs(UnmanagedType.Struct)] [In] ref object URL, [MarshalAs(UnmanagedType.Struct)] [In] ref object Frame, [MarshalAs(UnmanagedType.Struct)] [In] ref object StatusCode, [In] [Out] ref bool Cancel);
		[DispId(225)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void PrintTemplateInstantiation([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp);
		[DispId(226)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void PrintTemplateTeardown([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp);
		[DispId(227)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void UpdatePageStatus([MarshalAs(UnmanagedType.IDispatch)] [In] object pDisp, [MarshalAs(UnmanagedType.Struct)] [In] ref object nPage, [MarshalAs(UnmanagedType.Struct)] [In] ref object fDone);
		[DispId(272)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void PrivacyImpactedStateChange([In] bool bImpacted);
		[DispId(273)]
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		void NewWindow3([MarshalAs(UnmanagedType.IDispatch)] [In] [Out] ref object ppDisp, [In] [Out] ref bool Cancel, [In] uint dwFlags, [MarshalAs(UnmanagedType.BStr)] [In] string bstrUrlContext, [MarshalAs(UnmanagedType.BStr)] [In] string bstrUrl);
	}
}
