using System;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct BLENDFUNCTION
	{
		public byte BlendOp;
		public byte BlendFlags;
		public byte SourceConstantAlpha;
		public byte AlphaFormat;
		public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
		{
			this.BlendOp = op;
			this.BlendFlags = flags;
			this.SourceConstantAlpha = alpha;
			this.AlphaFormat = format;
		}
	}
}
