using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(RichTextBox))]
	public class SkinRichTextBox : RichTextBox
	{
		private RichEditOle _richEditOle;
		private Dictionary<int, REOBJECT> _oleObjectList;
		public Dictionary<int, REOBJECT> OleObjectList
		{
			get
			{
				if (this._oleObjectList == null)
				{
					this._oleObjectList = new Dictionary<int, REOBJECT>(10);
				}
				return this._oleObjectList;
			}
		}
		public RichEditOle RichEditOle
		{
			get
			{
				if (this._richEditOle == null && base.IsHandleCreated)
				{
					this._richEditOle = new RichEditOle(this);
				}
				return this._richEditOle;
			}
		}
		public bool InsertImageUseGifBox(string path)
		{
			bool result;
			try
			{
				SkinGifBox skinGifBox = new SkinGifBox();
				skinGifBox.BackColor = base.BackColor;
				skinGifBox.Image = Image.FromFile(path);
				this.RichEditOle.InsertControl(skinGifBox);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
