using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace xingwaWinFormUI.SkinClass
{
	public class InterpolationModeGraphics : IDisposable
	{
		private InterpolationMode _oldMode;
		private Graphics _graphics;
		public InterpolationModeGraphics(Graphics graphics) : this(graphics, InterpolationMode.HighQualityBicubic)
		{
		}
		public InterpolationModeGraphics(Graphics graphics, InterpolationMode newMode)
		{
			this._graphics = graphics;
			this._oldMode = graphics.InterpolationMode;
			graphics.InterpolationMode = newMode;
		}
		public void Dispose()
		{
			this._graphics.InterpolationMode = this._oldMode;
		}
	}
}
