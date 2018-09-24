using System;
namespace xingwaWinFormUI.SkinControl
{
	public interface IScrollBarPaint
	{
		void OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e);
		void OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e);
		void OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e);
	}
}
