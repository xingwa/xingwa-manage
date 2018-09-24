using workfere.Properties;
using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
namespace xingwaWinFormUI.SkinControl
{
	public class ToolStripColorTable
	{
		private Color _base = Color.FromArgb(105, 200, 254);
		private Color _itemborder = Color.FromArgb(60, 148, 212);
		private Color _back = Color.White;
		private Color _itemHover = Color.FromArgb(60, 148, 212);
		private Color _itemPressed = Color.FromArgb(60, 148, 212);
		private Color _fore = Color.Black;
		private Color _dropDownImageSeparator = Color.FromArgb(197, 197, 197);
		private RoundStyle _radiusstyle = RoundStyle.All;
		private int _backradius = 4;
		private Color _titleColor = Color.FromArgb(209, 228, 236);
		private bool _titleAnamorphosis = true;
		private int _titleRadius = 4;
		private RoundStyle _titleRadiusStyle = RoundStyle.All;
		private RoundStyle _itemRadiusStyle = RoundStyle.All;
		private int _itemRadius = 4;
		private bool _itemAnamorphosis = true;
		private bool _itemBorderShow = true;
		private Color _hoverFore = Color.White;
		private Color _arrow = Color.Black;
		private Color _baseFore = Color.Black;
		private Color _baseHoverFore = Color.White;
		private RoundStyle _baseItemRadiusStyle = RoundStyle.All;
		private int _baseItemRadius = 4;
		private bool _baseItemBorderShow = true;
		private bool _baseItemAnamorphosis = true;
		private Color _baseItemBorder = Color.FromArgb(60, 148, 212);
		private Color _baseItemHover = Color.FromArgb(60, 148, 212);
		private Color _baseItemPressed = Color.FromArgb(60, 148, 212);
		private Color _baseItemSplitter = Color.FromArgb(60, 148, 212);
		private bool _baseForeAnamorphosis;
		private int _baseForeAnamorphosisBorder = 4;
		private Color _baseForeAnamorphosisColor = Color.White;
		private Image _baseItemMouse = Resources.allbtn_highlight;
		private Image _baseItemDown = Resources.allbtn_down;
		private Rectangle _backrectangle = new Rectangle(10, 10, 10, 10);
		public Rectangle BackRectangle
		{
			get
			{
				return this._backrectangle;
			}
			set
			{
				this._backrectangle = value;
			}
		}
		public Image BaseItemMouse
		{
			get
			{
				return this._baseItemMouse;
			}
			set
			{
				this._baseItemMouse = value;
			}
		}
		public Image BaseItemDown
		{
			get
			{
				return this._baseItemDown;
			}
			set
			{
				this._baseItemDown = value;
			}
		}
		public bool BaseForeAnamorphosis
		{
			get
			{
				return this._baseForeAnamorphosis;
			}
			set
			{
				this._baseForeAnamorphosis = value;
			}
		}
		public int BaseForeAnamorphosisBorder
		{
			get
			{
				return this._baseForeAnamorphosisBorder;
			}
			set
			{
				this._baseForeAnamorphosisBorder = value;
			}
		}
		public Color BaseForeAnamorphosisColor
		{
			get
			{
				return this._baseForeAnamorphosisColor;
			}
			set
			{
				this._baseForeAnamorphosisColor = value;
			}
		}
		public Color BaseFore
		{
			get
			{
				return this._baseFore;
			}
			set
			{
				this._baseFore = value;
			}
		}
		public Color BaseItemPressed
		{
			get
			{
				return this._baseItemPressed;
			}
			set
			{
				this._baseItemPressed = value;
			}
		}
		public Color BaseItemSplitter
		{
			get
			{
				return this._baseItemSplitter;
			}
			set
			{
				this._baseItemSplitter = value;
			}
		}
		public Color BaseItemBorder
		{
			get
			{
				return this._baseItemBorder;
			}
			set
			{
				this._baseItemBorder = value;
			}
		}
		public Color BaseItemHover
		{
			get
			{
				return this._baseItemHover;
			}
			set
			{
				this._baseItemHover = value;
			}
		}
		public int BaseItemRadius
		{
			get
			{
				return this._baseItemRadius;
			}
			set
			{
				this._baseItemRadius = value;
			}
		}
		public RoundStyle BaseItemRadiusStyle
		{
			get
			{
				return this._baseItemRadiusStyle;
			}
			set
			{
				this._baseItemRadiusStyle = value;
			}
		}
		public bool BaseItemBorderShow
		{
			get
			{
				return this._baseItemBorderShow;
			}
			set
			{
				this._baseItemBorderShow = value;
			}
		}
		public bool BaseItemAnamorphosis
		{
			get
			{
				return this._baseItemAnamorphosis;
			}
			set
			{
				this._baseItemAnamorphosis = value;
			}
		}
		public Color BaseHoverFore
		{
			get
			{
				return this._baseHoverFore;
			}
			set
			{
				this._baseHoverFore = value;
			}
		}
		public Color TitleColor
		{
			get
			{
				return this._titleColor;
			}
			set
			{
				this._titleColor = value;
			}
		}
		public Color Arrow
		{
			get
			{
				return this._arrow;
			}
			set
			{
				this._arrow = value;
			}
		}
		public bool TitleAnamorphosis
		{
			get
			{
				return this._titleAnamorphosis;
			}
			set
			{
				this._titleAnamorphosis = value;
			}
		}
		public int TitleRadius
		{
			get
			{
				return this._titleRadius;
			}
			set
			{
				this._titleRadius = value;
			}
		}
		public RoundStyle TitleRadiusStyle
		{
			get
			{
				return this._titleRadiusStyle;
			}
			set
			{
				this._titleRadiusStyle = value;
			}
		}
		public int BackRadius
		{
			get
			{
				return this._backradius;
			}
			set
			{
				this._backradius = value;
			}
		}
		public RoundStyle RadiusStyle
		{
			get
			{
				return this._radiusstyle;
			}
			set
			{
				this._radiusstyle = value;
			}
		}
		public Color Base
		{
			get
			{
				return this._base;
			}
			set
			{
				this._base = value;
			}
		}
		public Color ItemBorder
		{
			get
			{
				return this._itemborder;
			}
			set
			{
				this._itemborder = value;
			}
		}
		public bool ItemBorderShow
		{
			get
			{
				return this._itemBorderShow;
			}
			set
			{
				this._itemBorderShow = value;
			}
		}
		public Color Back
		{
			get
			{
				return this._back;
			}
			set
			{
				this._back = value;
			}
		}
		public Color ItemHover
		{
			get
			{
				return this._itemHover;
			}
			set
			{
				this._itemHover = value;
			}
		}
		public Color ItemPressed
		{
			get
			{
				return this._itemPressed;
			}
			set
			{
				this._itemPressed = value;
			}
		}
		public RoundStyle ItemRadiusStyle
		{
			get
			{
				return this._itemRadiusStyle;
			}
			set
			{
				this._itemRadiusStyle = value;
			}
		}
		public int ItemRadius
		{
			get
			{
				return this._itemRadius;
			}
			set
			{
				this._itemRadius = value;
			}
		}
		public bool ItemAnamorphosis
		{
			get
			{
				return this._itemAnamorphosis;
			}
			set
			{
				this._itemAnamorphosis = value;
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
				this._fore = value;
			}
		}
		public Color HoverFore
		{
			get
			{
				return this._hoverFore;
			}
			set
			{
				this._hoverFore = value;
			}
		}
		public Color DropDownImageSeparator
		{
			get
			{
				return this._dropDownImageSeparator;
			}
			set
			{
				this._dropDownImageSeparator = value;
			}
		}
	}
}
