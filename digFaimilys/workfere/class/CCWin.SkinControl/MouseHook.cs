using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	public class MouseHook
	{
		public struct POINT
		{
			public int X;
			public int Y;
		}
		public struct MSLLHOOTSTRUCT
		{
			public MouseHook.POINT pt;
			public int mouseData;
			public int flags;
			public int time;
			public int dwExtraInfo;
		}
		public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
		public delegate void MHookEventHandler(object sender, MHookEventArgs e);
		private const int WH_MOUSE_LL = 14;
		private const uint WM_LBUTTONDOWN = 513u;
		private const uint WM_LBUTTONUP = 514u;
		private const uint WM_RBUTTONDOWN = 516u;
		private const uint WM_RBUTTONUP = 517u;
		private IntPtr hHook = IntPtr.Zero;
		private GCHandle gc;
		public event MouseHook.MHookEventHandler MHookEvent;
		public IntPtr HHook
		{
			get
			{
				return this.hHook;
			}
		}
		[DllImport("user32.dll")]
		public static extern IntPtr SetWindowsHookEx(int idHook, MouseHook.HookProc lpfn, IntPtr hmod, int dwThreadid);
		[DllImport("user32.dll")]
		public static extern int CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll")]
		public static extern bool UnhookWindowsHookEx(IntPtr hHook);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetModuleHandle(string lpModuleName);
		private int MouseHookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && this.MHookEvent != null)
			{
				MouseHook.MSLLHOOTSTRUCT mSLLHOOTSTRUCT = (MouseHook.MSLLHOOTSTRUCT)Marshal.PtrToStructure(lParam, typeof(MouseHook.MSLLHOOTSTRUCT));
				ButtonStatus btn = ButtonStatus.None;
				if (wParam == (IntPtr)513L)
				{
					btn = ButtonStatus.LeftDown;
				}
				else
				{
					if (wParam == (IntPtr)514L)
					{
						btn = ButtonStatus.LeftUp;
					}
					else
					{
						if (wParam == (IntPtr)516L)
						{
							btn = ButtonStatus.RightDown;
						}
						else
						{
							if (wParam == (IntPtr)517L)
							{
								btn = ButtonStatus.RightUp;
							}
						}
					}
				}
				this.MHookEvent(this, new MHookEventArgs(btn, mSLLHOOTSTRUCT.pt.X, mSLLHOOTSTRUCT.pt.Y));
			}
			return MouseHook.CallNextHookEx(this.hHook, nCode, wParam, lParam);
		}
		public bool SetHook()
		{
			if (this.hHook != IntPtr.Zero)
			{
				return false;
			}
			MouseHook.HookProc hookProc = new MouseHook.HookProc(this.MouseHookProcedure);
			this.hHook = MouseHook.SetWindowsHookEx(14, hookProc, MouseHook.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
			if (this.hHook != IntPtr.Zero)
			{
				this.gc = GCHandle.Alloc(hookProc);
				return true;
			}
			return false;
		}
		public bool UnLoadHook()
		{
			if (this.hHook == IntPtr.Zero)
			{
				return false;
			}
			if (MouseHook.UnhookWindowsHookEx(this.hHook))
			{
				this.hHook = IntPtr.Zero;
				this.gc.Free();
				return true;
			}
			return false;
		}
	}
}
