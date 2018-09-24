using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class PaintScrollBarThumbEventArgs : IDisposable
	{
		private Graphics _graphics;
		private Rectangle _thumbRect;
		private ControlState _controlState;
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
		public Rectangle ThumbRectangle
		{
			get
			{
				return this._thumbRect;
			}
			set
			{
				this._thumbRect = value;
			}
		}
		public ControlState ControlState
		{
			get
			{
				return this._controlState;
			}
			set
			{
				this._controlState = value;
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
		public PaintScrollBarThumbEventArgs(Graphics graphics, Rectangle thumbRect, ControlState controlState, Orientation orientation) : this(graphics, thumbRect, controlState, orientation, true)
		{
		}
		public PaintScrollBarThumbEventArgs(Graphics graphics, Rectangle thumbRect, ControlState controlState, Orientation orientation, bool enabled)
		{
			this._graphics = graphics;
			this._thumbRect = thumbRect;
			this._controlState = controlState;
			this._orientation = orientation;
			this._enabled = enabled;
		}
		public void Dispose()
		{
			this._graphics = null;
		}
	}
}
