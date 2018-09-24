using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(TextBox))]
	public class WaterTextBox : TextBox
	{
		private string _waterText = string.Empty;
		private Color _waterColor = Color.FromArgb(127, 127, 127);
		[Category("Skin"), Description("水印文字")]
		public string WaterText
		{
			get
			{
				return this._waterText;
			}
			set
			{
				this._waterText = value;
				base.Invalidate();
			}
		}
		[Category("Skin"), Description("水印的颜色")]
		public Color WaterColor
		{
			get
			{
				return this._waterColor;
			}
			set
			{
				this._waterColor = value;
				base.Invalidate();
			}
		}
		private void WmPaintWater(ref Message m)
		{
			using (Graphics graphics = Graphics.FromHwnd(base.Handle))
			{
				if (this.Text.Length == 0 && !string.IsNullOrEmpty(this._waterText) && !this.Focused)
				{
					TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
					if (this.RightToLeft == RightToLeft.Yes)
					{
						textFormatFlags |= (TextFormatFlags.Right | TextFormatFlags.RightToLeft);
					}
					TextRenderer.DrawText(graphics, this._waterText, new Font("微软雅黑", 8.5f), base.ClientRectangle, this._waterColor, textFormatFlags);
				}
			}
		}
		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == 15)
			{
				this.WmPaintWater(ref m);
			}
		}
	}
}
