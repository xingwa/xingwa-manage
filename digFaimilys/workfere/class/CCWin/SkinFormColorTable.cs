using System;
using System.Drawing;
namespace xingwaWinFormUI
{
	public class SkinFormColorTable
	{
		public static readonly Color _captionActive = Color.Transparent;
		public static readonly Color _captionDeactive = Color.Transparent;
		public static readonly Color _captionText = Color.Black;
		public static readonly Color _border = Color.FromArgb(100, 0, 0, 0);
		public static readonly Color _innerBorder = Color.FromArgb(100, 250, 250, 250);
		public static readonly Color _back = Color.FromArgb(128, 208, 255);
		public static readonly Color _controlBoxActive = Color.FromArgb(51, 153, 204);
		public static readonly Color _controlBoxDeactive = Color.FromArgb(88, 172, 218);
		public static readonly Color _controlBoxHover = Color.FromArgb(150, 39, 175, 231);
		public static readonly Color _controlBoxPressed = Color.FromArgb(150, 29, 142, 190);
		private static readonly Color _controlCloseBoxHover = Color.FromArgb(213, 66, 22);
		private static readonly Color _controlCloseBoxPressed = Color.FromArgb(171, 53, 17);
		public static readonly Color _controlBoxInnerBorder = Color.FromArgb(128, 250, 250, 250);
		public virtual Color CaptionActive
		{
			get
			{
				return SkinFormColorTable._captionActive;
			}
		}
		public virtual Color CaptionDeactive
		{
			get
			{
				return SkinFormColorTable._captionDeactive;
			}
		}
		public virtual Color CaptionText
		{
			get
			{
				return SkinFormColorTable._captionText;
			}
		}
		public virtual Color Border
		{
			get
			{
				return SkinFormColorTable._border;
			}
		}
		public virtual Color InnerBorder
		{
			get
			{
				return SkinFormColorTable._innerBorder;
			}
		}
		public virtual Color Back
		{
			get
			{
				return SkinFormColorTable._back;
			}
		}
		public virtual Color ControlBoxActive
		{
			get
			{
				return SkinFormColorTable._controlBoxActive;
			}
		}
		public virtual Color ControlBoxDeactive
		{
			get
			{
				return SkinFormColorTable._controlBoxDeactive;
			}
		}
		public virtual Color ControlBoxHover
		{
			get
			{
				return SkinFormColorTable._controlBoxHover;
			}
		}
		public virtual Color ControlBoxPressed
		{
			get
			{
				return SkinFormColorTable._controlBoxPressed;
			}
		}
		public virtual Color ControlCloseBoxHover
		{
			get
			{
				return SkinFormColorTable._controlCloseBoxHover;
			}
		}
		public virtual Color ControlCloseBoxPressed
		{
			get
			{
				return SkinFormColorTable._controlCloseBoxPressed;
			}
		}
		public virtual Color ControlBoxInnerBorder
		{
			get
			{
				return SkinFormColorTable._controlBoxInnerBorder;
			}
		}
	}
}
