using xingwaWinFormUI.Imaging;
using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class SkinVScrollBar : VScrollBar, IScrollBarPaint
	{
		private ScrollBarManager _manager;
		private Color _base = Color.FromArgb(171, 230, 247);
		private Color _backNormal = Color.FromArgb(235, 249, 253);
		private Color _backHover = Color.FromArgb(121, 216, 243);
		private Color _backPressed = Color.FromArgb(70, 202, 239);
		private Color _border = Color.FromArgb(89, 210, 249);
		private Color _innerBorder = Color.FromArgb(200, 250, 250, 250);
		private Color _fore = Color.FromArgb(48, 135, 192);
		public Color Base
		{
			get
			{
				return this._base;
			}
			set
			{
				if (this._base != value)
				{
					this._base = value;
					base.Invalidate();
				}
			}
		}
		public Color BackNormal
		{
			get
			{
				return this._backNormal;
			}
			set
			{
				if (this._backNormal != value)
				{
					this._backNormal = value;
					base.Invalidate();
				}
			}
		}
		public Color BackHover
		{
			get
			{
				return this._backHover;
			}
			set
			{
				if (this._backHover != value)
				{
					this._backHover = value;
					base.Invalidate();
				}
			}
		}
		public Color BackPressed
		{
			get
			{
				return this._backPressed;
			}
			set
			{
				if (this._backPressed != value)
				{
					this._backPressed = value;
					base.Invalidate();
				}
			}
		}
		public Color Border
		{
			get
			{
				return this._border;
			}
			set
			{
				if (this._border != value)
				{
					this._border = value;
					base.Invalidate();
				}
			}
		}
		public Color InnerBorder
		{
			get
			{
				return this._innerBorder;
			}
			set
			{
				if (this._innerBorder != value)
				{
					this._innerBorder = value;
					base.Invalidate();
				}
			}
		}
		public Color Fore
		{
			get
			{
				return this._fore;
			}
			set
			{
				if (this._fore != value)
				{
					this._fore = value;
					base.Invalidate();
				}
			}
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (this._manager != null)
			{
				this._manager.Dispose();
			}
			this._manager = new ScrollBarManager(this);
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this._manager != null)
			{
				this._manager.Dispose();
				this._manager = null;
			}
			base.Dispose(disposing);
		}
		protected internal virtual void OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle trackRectangle = e.TrackRectangle;
			Color gray = this.GetGray(this.Base);
			ControlPaintEx.DrawScrollBarTrack(graphics, trackRectangle, gray, Color.White, e.Orientation);
		}
		protected internal virtual void OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle arrowRectangle = e.ArrowRectangle;
			ControlState controlState = e.ControlState;
			ArrowDirection arrowDirection = e.ArrowDirection;
			Orientation arg_22_0 = e.Orientation;
			bool enabled = e.Enabled;
			Color color = this.BackNormal;
			Color begin = this.Base;
			Color color2 = this.Border;
			Color innerBorder = this.InnerBorder;
			Color color3 = this.Fore;
			bool changeColor = false;
			if (enabled)
			{
				switch (controlState)
				{
				case ControlState.Hover:
					begin = this.BackHover;
					break;
				case ControlState.Pressed:
					begin = this.BackPressed;
					changeColor = true;
					break;
				default:
					begin = this.Base;
					break;
				}
			}
			else
			{
				color = this.GetGray(color);
				begin = this.GetGray(this.Base);
				color2 = this.GetGray(color2);
				color3 = this.GetGray(color3);
			}
			using (new SmoothingModeGraphics(graphics))
			{
				ControlPaintEx.DrawScrollBarArraw(graphics, arrowRectangle, begin, color, color2, innerBorder, color3, e.Orientation, arrowDirection, changeColor);
			}
		}
		protected internal virtual void OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e)
		{
			if (!e.Enabled)
			{
				return;
			}
			Graphics graphics = e.Graphics;
			Rectangle thumbRectangle = e.ThumbRectangle;
			ControlState controlState = e.ControlState;
			Color backNormal = this.BackNormal;
			Color begin = this.Base;
			Color border = this.Border;
			Color innerBorder = this.InnerBorder;
			bool changeColor = false;
			switch (controlState)
			{
			case ControlState.Hover:
				begin = this.BackHover;
				break;
			case ControlState.Pressed:
				begin = this.BackPressed;
				changeColor = true;
				break;
			default:
				begin = this.Base;
				break;
			}
			using (new SmoothingModeGraphics(graphics))
			{
				ControlPaintEx.DrawScrollBarThumb(graphics, thumbRectangle, begin, backNormal, border, innerBorder, e.Orientation, changeColor);
			}
		}
		private Color GetGray(Color color)
		{
			return ColorConverterEx.RgbToGray(new RGB(color)).Color;
		}
		void IScrollBarPaint.OnPaintScrollBarArrow(PaintScrollBarArrowEventArgs e)
		{
			this.OnPaintScrollBarArrow(e);
		}
		void IScrollBarPaint.OnPaintScrollBarThumb(PaintScrollBarThumbEventArgs e)
		{
			this.OnPaintScrollBarThumb(e);
		}
		void IScrollBarPaint.OnPaintScrollBarTrack(PaintScrollBarTrackEventArgs e)
		{
			this.OnPaintScrollBarTrack(e);
		}
	}
}
