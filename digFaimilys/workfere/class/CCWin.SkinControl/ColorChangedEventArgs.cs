using System;
using System.Drawing;
namespace xingwaWinFormUI.SkinControl
{
	public class ColorChangedEventArgs : EventArgs
	{
		private Color color;
		public Color Color
		{
			get
			{
				return this.color;
			}
		}
		public ColorChangedEventArgs(Color clr)
		{
			this.color = clr;
		}
	}
}
