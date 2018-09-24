using System;
using System.Drawing;
namespace xingwaWinFormUI.Imaging
{
	public class RGB
	{
		public const short RIndex = 2;
		public const short GIndex = 1;
		public const short BIndex = 0;
		private byte _r;
		private byte _g;
		private byte _b;
		public byte R
		{
			get
			{
				return this._r;
			}
			set
			{
				this._r = value;
			}
		}
		public byte G
		{
			get
			{
				return this._g;
			}
			set
			{
				this._g = value;
			}
		}
		public byte B
		{
			get
			{
				return this._b;
			}
			set
			{
				this._b = value;
			}
		}
		public Color Color
		{
			get
			{
				return Color.FromArgb((int)this._r, (int)this._g, (int)this._b);
			}
			set
			{
				this._r = value.R;
				this._g = value.G;
				this._b = value.B;
			}
		}
		public RGB()
		{
		}
		public RGB(byte r, byte g, byte b)
		{
			this._r = r;
			this._g = g;
			this._b = b;
		}
		public RGB(Color color)
		{
			this._r = color.R;
			this._g = color.G;
			this._b = color.B;
		}
		public override string ToString()
		{
			return string.Format("RGB [R={0}, G={1}, B={2}]", this._r, this._g, this._b);
		}
	}
}
