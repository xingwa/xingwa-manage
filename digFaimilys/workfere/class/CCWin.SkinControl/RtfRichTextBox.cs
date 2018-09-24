using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	[ToolboxBitmap(typeof(RichTextBox))]
	public class RtfRichTextBox : RichTextBox
	{
		[Flags]
		private enum EmfToWmfBitsFlags
		{
			EmfToWmfBitsFlagsDefault = 0,
			EmfToWmfBitsFlagsEmbedEmf = 1,
			EmfToWmfBitsFlagsIncludePlaceable = 2,
			EmfToWmfBitsFlagsNoXORClip = 4
		}
		public enum RtfColor
		{
			Black,
			Maroon,
			Green,
			Olive,
			Navy,
			Purple,
			Teal,
			Gray,
			Silver,
			Red,
			Lime,
			Yellow,
			Blue,
			Fuchsia,
			Aqua,
			White
		}
		private const string RTF_HEADER = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052";
		private static bool hasGdiPlus;
		private float xDpi;
		private float yDpi;
		private RtfRichTextBox.RtfColor textColor;
		private RtfRichTextBox.RtfColor highlightColor = RtfRichTextBox.RtfColor.White;
		private Dictionary<string, Bitmap> emotions = new Dictionary<string, Bitmap>();
		private Dictionary<RtfRichTextBox.RtfColor, string> rtfColor = new Dictionary<RtfRichTextBox.RtfColor, string>();
		private Dictionary<string, string> rtfFontFamily = new Dictionary<string, string>();
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (RtfRichTextBox.LoadLibrary("msftedit.dll") != IntPtr.Zero)
				{
					createParams.ExStyle |= 32;
					createParams.ClassName = "RICHEDIT50W";
				}
				return createParams;
			}
		}
		public Dictionary<string, Bitmap> Emotions
		{
			get
			{
				return this.emotions;
			}
		}
		public bool HasEmotion
		{
			get
			{
				if (RtfRichTextBox.hasGdiPlus)
				{
					foreach (string current in this.emotions.Keys)
					{
						if (this.Text.IndexOf(current, StringComparison.CurrentCultureIgnoreCase) > -1)
						{
							return true;
						}
					}
					return false;
				}
				return false;
			}
		}
		public RtfRichTextBox.RtfColor HiglightColor
		{
			get
			{
				return this.highlightColor;
			}
			set
			{
				this.highlightColor = value;
			}
		}
		public new string Rtf
		{
			get
			{
				return this.RemoveBadChars(base.Rtf);
			}
			set
			{
				base.Rtf = value;
			}
		}
		public RtfRichTextBox.RtfColor TextColor
		{
			get
			{
				return this.textColor;
			}
			set
			{
				this.textColor = value;
			}
		}
		[DllImport("gdiplus.dll")]
		private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize, byte[] _buffer, int _mappingMode, RtfRichTextBox.EmfToWmfBitsFlags _flags);
		static RtfRichTextBox()
		{
			try
			{
				RtfRichTextBox.GdipEmfToWmfBits(IntPtr.Zero, 0u, null, 0, RtfRichTextBox.EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
				RtfRichTextBox.hasGdiPlus = true;
			}
			catch (Exception)
			{
			}
		}
		public RtfRichTextBox()
		{
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Aqua, "\\red0\\green255\\blue255");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Black, "\\red0\\green0\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Blue, "\\red0\\green0\\blue255");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Fuchsia, "\\red255\\green0\\blue255");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Gray, "\\red128\\green128\\blue128");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Green, "\\red0\\green128\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Lime, "\\red0\\green255\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Maroon, "\\red128\\green0\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Navy, "\\red0\\green0\\blue128");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Olive, "\\red128\\green128\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Purple, "\\red128\\green0\\blue128");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Red, "\\red255\\green0\\blue0");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Silver, "\\red192\\green192\\blue192");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Teal, "\\red0\\green128\\blue128");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.White, "\\red255\\green255\\blue255");
			this.rtfColor.Add(RtfRichTextBox.RtfColor.Yellow, "\\red255\\green255\\blue0");
			this.rtfFontFamily.Add(FontFamily.GenericMonospace.Name, "\\fmodern");
			this.rtfFontFamily.Add(FontFamily.GenericSansSerif.Name, "\\fswiss");
			this.rtfFontFamily.Add(FontFamily.GenericSerif.Name, "\\froman");
			this.rtfFontFamily.Add("UNKNOWN", "\\fnil");
			using (Graphics graphics = base.CreateGraphics())
			{
				this.xDpi = graphics.DpiX;
				this.yDpi = graphics.DpiY;
			}
		}
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr LoadLibrary(string lpFileName);
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
		}
		public RtfRichTextBox(RtfRichTextBox.RtfColor _textColor) : this()
		{
			this.textColor = _textColor;
		}
		public RtfRichTextBox(RtfRichTextBox.RtfColor _textColor, RtfRichTextBox.RtfColor _highlightColor) : this()
		{
			this.textColor = _textColor;
			this.highlightColor = _highlightColor;
		}
		public void AppendRtf(string _rtf)
		{
			base.Select(this.TextLength, 0);
			base.SelectionColor = Color.Black;
			base.SelectedRtf = _rtf;
		}
		public void AppendTextAsRtf(string _text)
		{
			this.AppendTextAsRtf(_text, this.Font);
		}
		public void AppendTextAsRtf(string _text, Font _font)
		{
			this.AppendTextAsRtf(_text, _font, this.textColor);
		}
		public void AppendTextAsRtf(string _text, Font _font, RtfRichTextBox.RtfColor _textColor)
		{
			this.AppendTextAsRtf(_text, _font, _textColor, this.highlightColor);
		}
		public void AppendTextAsRtf(string _text, Font _font, RtfRichTextBox.RtfColor _textColor, RtfRichTextBox.RtfColor _backColor)
		{
			base.Select(this.TextLength, 0);
			this.InsertTextAsRtf(_text, _font, _textColor, _backColor);
		}
		private string GetColorTable(RtfRichTextBox.RtfColor _textColor, RtfRichTextBox.RtfColor _backColor)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\colortbl ;");
			stringBuilder.Append(this.rtfColor[_textColor]);
			stringBuilder.Append(";");
			stringBuilder.Append(this.rtfColor[_backColor]);
			stringBuilder.Append(";}\\n");
			return stringBuilder.ToString();
		}
		private string GetDocumentArea(string _text, Font _font)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\\viewkind4\\uc1\\pard\\cf1\\f0\\fs20");
			stringBuilder.Append("\\highlight2");
			if (_font.Bold)
			{
				stringBuilder.Append("\\b");
			}
			if (_font.Italic)
			{
				stringBuilder.Append("\\i");
			}
			if (_font.Strikeout)
			{
				stringBuilder.Append("\\strike");
			}
			if (_font.Underline)
			{
				stringBuilder.Append("\\ul");
			}
			stringBuilder.Append("\\f0");
			stringBuilder.Append("\\fs");
			stringBuilder.Append((int)Math.Round((double)(2f * _font.SizeInPoints)));
			stringBuilder.Append(" ");
			stringBuilder.Append(_text.Replace("\n", "\\par "));
			stringBuilder.Append("\\highlight0");
			if (_font.Bold)
			{
				stringBuilder.Append("\\b0");
			}
			if (_font.Italic)
			{
				stringBuilder.Append("\\i0");
			}
			if (_font.Strikeout)
			{
				stringBuilder.Append("\\strike0");
			}
			if (_font.Underline)
			{
				stringBuilder.Append("\\ulnone");
			}
			stringBuilder.Append("\\f0");
			stringBuilder.Append("\\fs20");
			stringBuilder.Append("\\cf0\\fs17}");
			return stringBuilder.ToString();
		}
		private string GetFontTable(Font _font)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\fonttbl{\\f0");
			stringBuilder.Append("\\");
			if (this.rtfFontFamily.ContainsKey(_font.FontFamily.Name))
			{
				stringBuilder.Append(this.rtfFontFamily[_font.FontFamily.Name]);
			}
			else
			{
				stringBuilder.Append(this.rtfFontFamily["UNKNOWN"]);
			}
			stringBuilder.Append("\\fcharset134 ");
			stringBuilder.Append(_font.Name);
			stringBuilder.Append(";}}");
			return stringBuilder.ToString();
		}
		private string GetImagePrefix(Image _image)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int value = (int)Math.Round((double)((float)_image.Width / this.xDpi * 2540f));
			int value2 = (int)Math.Round((double)((float)_image.Height / this.yDpi * 2540f));
			int value3 = (int)Math.Round((double)((float)_image.Width / this.xDpi * 1440f));
			int value4 = (int)Math.Round((double)((float)_image.Height / this.yDpi * 1440f));
			stringBuilder.Append("{\\pict\\wmetafile8");
			stringBuilder.Append("\\picw");
			stringBuilder.Append(value);
			stringBuilder.Append("\\pich");
			stringBuilder.Append(value2);
			stringBuilder.Append("\\picwgoal");
			stringBuilder.Append(value3);
			stringBuilder.Append("\\pichgoal");
			stringBuilder.Append(value4);
			stringBuilder.Append(" ");
			return stringBuilder.ToString();
		}
		private string GetRtfImage(Image _image)
		{
			MemoryStream memoryStream = null;
			Graphics graphics = null;
			Metafile metafile = null;
			string result;
			try
			{
				memoryStream = new MemoryStream();
				Graphics graphics2;
				graphics = (graphics2 = base.CreateGraphics());
				try
				{
					IntPtr hdc = graphics.GetHdc();
					metafile = new Metafile(memoryStream, hdc);
					graphics.ReleaseHdc(hdc);
				}
				finally
				{
					if (graphics2 != null)
					{
						((IDisposable)graphics2).Dispose();
					}
				}
				Graphics graphics3;
				graphics = (graphics3 = Graphics.FromImage(metafile));
				try
				{
					graphics.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height));
				}
				finally
				{
					if (graphics3 != null)
					{
						((IDisposable)graphics3).Dispose();
					}
				}
				IntPtr henhmetafile = metafile.GetHenhmetafile();
				uint num = RtfRichTextBox.GdipEmfToWmfBits(henhmetafile, 0u, null, 1, RtfRichTextBox.EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
				byte[] array = new byte[num];
				RtfRichTextBox.GdipEmfToWmfBits(henhmetafile, num, array, 1, RtfRichTextBox.EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(string.Format("{0:X2}", array[i]));
				}
				result = stringBuilder.ToString();
			}
			finally
			{
				if (graphics != null)
				{
					graphics.Dispose();
				}
				if (metafile != null)
				{
					metafile.Dispose();
				}
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
			}
			return result;
		}
		public void InsertEmotion()
		{
			if (RtfRichTextBox.hasGdiPlus)
			{
				foreach (string current in this.emotions.Keys)
				{
					int num = base.Find(current, RichTextBoxFinds.None);
					if (num > -1)
					{
						base.Select(num, current.Length);
						this.InsertImage(this.emotions[current]);
					}
				}
			}
		}
		public void InsertImage(Image _image)
		{
			if (RtfRichTextBox.hasGdiPlus)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052");
				stringBuilder.Append(this.GetFontTable(this.Font));
				stringBuilder.Append(this.GetImagePrefix(_image));
				stringBuilder.Append(this.GetRtfImage(_image));
				stringBuilder.Append("}");
				base.SelectedRtf = stringBuilder.ToString();
			}
		}
		public void InsertRtf(string _rtf)
		{
			base.SelectedRtf = _rtf;
		}
		public void InsertTextAsRtf(string _text)
		{
			this.InsertTextAsRtf(_text, this.Font);
		}
		public void InsertTextAsRtf(string _text, Font _font)
		{
			this.InsertTextAsRtf(_text, _font, this.textColor);
		}
		public void InsertTextAsRtf(string _text, Font _font, RtfRichTextBox.RtfColor _textColor)
		{
			this.InsertTextAsRtf(_text, _font, _textColor, this.highlightColor);
		}
		public void InsertTextAsRtf(string _text, Font _font, RtfRichTextBox.RtfColor _textColor, RtfRichTextBox.RtfColor _backColor)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052");
			stringBuilder.Append(this.GetFontTable(_font));
			stringBuilder.Append(this.GetColorTable(_textColor, _backColor));
			stringBuilder.Append(this.GetDocumentArea(_text, _font));
			base.SelectedRtf = stringBuilder.ToString();
		}
		private string RemoveBadChars(string _originalRtf)
		{
			return _originalRtf.Replace("\0", "");
		}
	}
}
