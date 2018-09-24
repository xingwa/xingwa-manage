using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class PaintScrollBarArrowEventArgs : IDisposable
	{
		private Graphics _graphics;
		private Rectangle _arrowRect;
		private ControlState _controlState;
		private ArrowDirection _arrowDirection;
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
		public Rectangle ArrowRectangle
		{
			get
			{
				return this._arrowRect;
			}
			set
			{
				this._arrowRect = value;
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
		public ArrowDirection ArrowDirection
		{
			get
			{
				return this._arrowDirection;
			}
			set
			{
				this._arrowDirection = value;
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
		public PaintScrollBarArrowEventArgs(Graphics graphics, Rectangle arrowRect, ControlState controlState, ArrowDirection arrowDirection, Orientation orientation) : this(graphics, arrowRect, controlState, arrowDirection, orientation, true)
		{
		}
		public PaintScrollBarArrowEventArgs(Graphics graphics, Rectangle arrowRect, ControlState controlState, ArrowDirection arrowDirection, Orientation orientation, bool enabled)
		{
			this._graphics = graphics;
			this._arrowRect = arrowRect;
			this._controlState = controlState;
			this._arrowDirection = arrowDirection;
			this._orientation = orientation;
			this._enabled = enabled;
		}
		public void Dispose()
		{
			this._graphics = null;
		}
	}
}
