using System;
using System.Drawing;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
		public Rectangle Rect
		{
			get
			{
				return new Rectangle(this.Left, this.Top, this.Right - this.Left, this.Bottom - this.Top);
			}
		}
		public Size Size
		{
			get
			{
				return new Size(this.Right - this.Left, this.Bottom - this.Top);
			}
		}
		public RECT(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}
		public RECT(Rectangle rect)
		{
			this.Left = rect.Left;
			this.Top = rect.Top;
			this.Right = rect.Right;
			this.Bottom = rect.Bottom;
		}
		public static RECT FromXYWH(int x, int y, int width, int height)
		{
			return new RECT(x, y, x + width, y + height);
		}
		public static RECT FromRectangle(Rectangle rect)
		{
			return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
		}
	}
}
