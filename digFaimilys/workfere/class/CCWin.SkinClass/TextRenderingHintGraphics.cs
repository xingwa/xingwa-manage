using System;
using System.Drawing;
using System.Drawing.Text;
namespace xingwaWinFormUI.SkinClass
{
	public class TextRenderingHintGraphics : IDisposable
	{
		private Graphics _graphics;
		private TextRenderingHint _oldTextRenderingHint;
		public TextRenderingHintGraphics(Graphics graphics) : this(graphics, TextRenderingHint.AntiAlias)
		{
		}
		public TextRenderingHintGraphics(Graphics graphics, TextRenderingHint newTextRenderingHint)
		{
			this._graphics = graphics;
			this._oldTextRenderingHint = graphics.TextRenderingHint;
			this._graphics.TextRenderingHint = newTextRenderingHint;
		}
		public void Dispose()
		{
			this._graphics.TextRenderingHint = this._oldTextRenderingHint;
		}
	}
}
