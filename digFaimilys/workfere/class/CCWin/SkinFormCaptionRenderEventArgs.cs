using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinFormCaptionRenderEventArgs : PaintEventArgs
	{
		private MainWinForm _skinForm;
		private bool _active;
		public MainWinForm SkinForm
		{
			get
			{
				return this._skinForm;
			}
		}
		public bool Active
		{
			get
			{
				return this._active;
			}
		}
		public SkinFormCaptionRenderEventArgs(MainWinForm skinForm, Graphics g, Rectangle clipRect, bool active) : base(g, clipRect)
		{
			this._skinForm = skinForm;
			this._active = active;
		}
	}
}
