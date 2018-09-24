using System;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinFormBackgroundRenderEventArgs : PaintEventArgs
	{
		private MainWinForm _skinForm;
		public MainWinForm SkinForm
		{
			get
			{
				return this._skinForm;
			}
		}
		public SkinFormBackgroundRenderEventArgs(MainWinForm skinForm, Graphics g, Rectangle clipRect) : base(g, clipRect)
		{
			this._skinForm = skinForm;
		}
	}
}
