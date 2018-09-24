using System;
using System.Drawing;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct TCHITTESTINFO
	{
		public Point Point;
		public int Flags;
		public TCHITTESTINFO(Point location)
		{
			this.Point = location;
			this.Flags = 6;
		}
	}
}
