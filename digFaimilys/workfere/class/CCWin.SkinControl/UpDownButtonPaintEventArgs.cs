using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class UpDownButtonPaintEventArgs : PaintEventArgs
	{
		private bool _mouseOver;
		private bool _mousePress;
		private bool _mouseInUpButton;
		public bool MouseOver
		{
			get
			{
				return this._mouseOver;
			}
		}
		public bool MousePress
		{
			get
			{
				return this._mousePress;
			}
		}
		public bool MouseInUpButton
		{
			get
			{
				return this._mouseInUpButton;
			}
		}
		public UpDownButtonPaintEventArgs(Graphics graphics, Rectangle clipRect, bool mouseOver, bool mousePress, bool mouseInUpButton) : base(graphics, clipRect)
		{
			this._mouseOver = mouseOver;
			this._mousePress = mousePress;
			this._mouseInUpButton = mouseInUpButton;
		}
	}
}
