using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class PaintScrollBarTrackEventArgs : IDisposable
	{
		private Graphics _graphics;
		private Rectangle _trackRect;
		private Orientation _orientation;
		private bool _enabled;
		public Graphics Graphics
		{
			get
			{
				return this._graphics;
			}
			set
			{
				this._graphics = value;
			}
		}
		public Rectangle TrackRectangle
		{
			get
			{
				return this._trackRect;
			}
			set
			{
				this._trackRect = value;
			}
		}
		public Orientation Orientation
		{
			get
			{
				return this._orientation;
			}
			set
			{
				this._orientation = value;
			}
		}
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
			}
		}
		public PaintScrollBarTrackEventArgs(Graphics graphics, Rectangle trackRect, Orientation orientation) : this(graphics, trackRect, orientation, true)
		{
		}
		public PaintScrollBarTrackEventArgs(Graphics graphics, Rectangle trackRect, Orientation orientation, bool enabled)
		{
			this._graphics = graphics;
			this._trackRect = trackRect;
			this._orientation = orientation;
			this._enabled = enabled;
		}
		public void Dispose()
		{
			this._graphics = null;
		}
	}
}
