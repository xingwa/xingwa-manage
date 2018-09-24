using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinFormControlBoxRenderEventArgs : PaintEventArgs
	{
		private MainWinForm _form;
		private bool _active;
		private ControlBoxState _controlBoxState;
		private ControlBoxStyle _controlBoxStyle;
		public MainWinForm Form
		{
			get
			{
				return this._form;
			}
		}
		public bool Active
		{
			get
			{
				return this._active;
			}
		}
		public ControlBoxStyle ControlBoxStyle
		{
			get
			{
				return this._controlBoxStyle;
			}
		}
		public ControlBoxState ControlBoxtate
		{
			get
			{
				return this._controlBoxState;
			}
		}
		public SkinFormControlBoxRenderEventArgs(MainWinForm form, Graphics graphics, Rectangle clipRect, bool active, ControlBoxStyle controlBoxStyle, ControlBoxState controlBoxState) : base(graphics, clipRect)
		{
			this._form = form;
			this._active = active;
			this._controlBoxState = controlBoxState;
			this._controlBoxStyle = controlBoxStyle;
		}
	}
}
