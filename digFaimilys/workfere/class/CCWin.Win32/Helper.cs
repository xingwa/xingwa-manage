using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.Win32
{
	public static class Helper
	{
		public static bool LeftKeyPressed()
		{
			if (SystemInformation.MouseButtonsSwapped)
			{
				return NativeMethods.GetKeyState(2) < 0;
			}
			return NativeMethods.GetKeyState(1) < 0;
		}
		public static int HIWORD(int n)
		{
			return n >> 16 & 65535;
		}
		public static int HIWORD(IntPtr n)
		{
			return Helper.HIWORD((int)((long)n));
		}
		public static int LOWORD(int n)
		{
			return n & 65535;
		}
		public static int LOWORD(IntPtr n)
		{
			return Helper.LOWORD((int)((long)n));
		}
		public static int MAKELONG(int low, int high)
		{
			return high << 16 | (low & 65535);
		}
		public static IntPtr MAKELPARAM(int low, int high)
		{
			return (IntPtr)(high << 16 | (low & 65535));
		}
		public static int SignedHIWORD(int n)
		{
			return (int)((short)(n >> 16 & 65535));
		}
		public static int SignedHIWORD(IntPtr n)
		{
			return Helper.SignedHIWORD((int)((long)n));
		}
		public static int SignedLOWORD(int n)
		{
			return (int)((short)(n & 65535));
		}
		public static int SignedLOWORD(IntPtr n)
		{
			return Helper.SignedLOWORD((int)((long)n));
		}
		public static void Swap(ref int x, ref int y)
		{
			int num = x;
			x = y;
			y = num;
		}
		public static IntPtr ToIntPtr(object structure)
		{
			IntPtr intPtr = IntPtr.Zero;
			intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(structure));
			Marshal.StructureToPtr(structure, intPtr, false);
			return intPtr;
		}
		public static void SetRedraw(IntPtr hWnd, bool redraw)
		{
			IntPtr wParam = redraw ? Result.TRUE : Result.FALSE;
			NativeMethods.SendMessage(hWnd, 11, wParam, 0);
		}
	}
}
