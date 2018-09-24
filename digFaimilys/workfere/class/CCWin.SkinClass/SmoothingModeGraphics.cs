using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace xingwaWinFormUI.SkinClass
{
	public class SmoothingModeGraphics : IDisposable
	{
		private SmoothingMode _oldMode;
		private Graphics _graphics;
		public SmoothingModeGraphics(Graphics graphics) : this(graphics, SmoothingMode.AntiAlias)
		{
		}
		public SmoothingModeGraphics(Graphics graphics, SmoothingMode newMode)
		{
			this._graphics = graphics;
			this._oldMode = graphics.SmoothingMode;
			graphics.SmoothingMode = newMode;
		}
		public void Dispose()
		{
			this._graphics.SmoothingMode = this._oldMode;
		}
	}
}
