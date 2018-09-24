using xingwaWinFormUI.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	internal class ImageProcessBox : Control
	{
		private Image baseImage;
		private Color dotColor;
		private Color lineColor;
		private Rectangle selectedRectangle;
		private Size magnifySize;
		private int magnifyTimes;
		private bool isDrawOperationDot;
		private bool isSetClip;
		private bool isShowInfo;
		private bool autoSizeFromImage;
		private bool isDrawed;
		private bool isStartDraw;
		private bool isMoving;
		private bool canReset;
		private bool m_bMouseEnter;
		private bool m_bLockH;
		private bool m_bLockW;
		private Point m_ptOriginal;
		private Point m_ptCurrent;
		private Point m_ptTempStarPos;
		private Rectangle[] m_rectDots;
		private Rectangle m_rectClip;
		private Bitmap m_bmpDark;
		private Pen m_pen;
		private SolidBrush m_sb;
		private IContainer components;
		[Category("Custom"), Description("获取或设置用于被操作的图像")]
		public Image BaseImage
		{
			get
			{
				return this.baseImage;
			}
			set
			{
				this.baseImage = value;
				this.BuildBitmap();
			}
		}
		[Category("Custom"), DefaultValue(typeof(Color), "Yellow"), Description("获取或设置操作框点的颜色")]
		public Color DotColor
		{
			get
			{
				return this.dotColor;
			}
			set
			{
				this.dotColor = value;
			}
		}
		[Category("Custom"), DefaultValue(typeof(Color), "Cyan"), Description("获取或设置操作框线条的颜色")]
		public Color LineColor
		{
			get
			{
				return this.lineColor;
			}
			set
			{
				this.lineColor = value;
			}
		}
		[Browsable(false)]
		public Rectangle SelectedRectangle
		{
			get
			{
				Rectangle result = this.selectedRectangle;
				result.Width++;
				result.Height++;
				return result;
			}
		}
		[Category("Custom"), DefaultValue(typeof(Size), "15,15"), Description("获取或设置放大图像的原图大小尺寸")]
		public Size MagnifySize
		{
			get
			{
				return this.magnifySize;
			}
			set
			{
				this.magnifySize = value;
				if (this.magnifySize.Width < 5)
				{
					this.magnifySize.Width = 5;
				}
				if (this.magnifySize.Width > 20)
				{
					this.magnifySize.Width = 20;
				}
				if (this.magnifySize.Height < 5)
				{
					this.magnifySize.Height = 5;
				}
				if (this.magnifySize.Height > 20)
				{
					this.magnifySize.Height = 20;
				}
			}
		}
		[Category("Custom"), DefaultValue(7), Description("获取或设置图像放大的倍数")]
		public int MagnifyTimes
		{
			get
			{
				return this.magnifyTimes;
			}
			set
			{
				this.magnifyTimes = value;
				if (this.magnifyTimes < 3)
				{
					this.magnifyTimes = 3;
				}
				if (this.magnifyTimes > 10)
				{
					this.magnifyTimes = 10;
				}
			}
		}
		[Category("Custom"), DefaultValue(true), Description("获取或设置是否绘制操作框点")]
		public bool IsDrawOperationDot
		{
			get
			{
				return this.isDrawOperationDot;
			}
			set
			{
				if (value == this.isDrawOperationDot)
				{
					return;
				}
				this.isDrawOperationDot = value;
				base.Invalidate();
			}
		}
		[Category("Custom"), DefaultValue(true), Description("获取或设置是否限制鼠标操作区域")]
		public bool IsSetClip
		{
			get
			{
				return this.isSetClip;
			}
			set
			{
				this.isSetClip = value;
			}
		}
		[Category("Custom"), DefaultValue(true), Description("获取或设置是否绘制信息展示")]
		public bool IsShowInfo
		{
			get
			{
				return this.isShowInfo;
			}
			set
			{
				this.isShowInfo = value;
			}
		}
		[Category("Custom"), DefaultValue(true), Description("获取或设置是否根据图像大小自动调整控件尺寸")]
		public bool AutoSizeFromImage
		{
			get
			{
				return this.autoSizeFromImage;
			}
			set
			{
				if (value && this.baseImage != null)
				{
					base.Width = this.baseImage.Width;
					base.Height = this.baseImage.Height;
				}
				this.autoSizeFromImage = value;
			}
		}
		[Browsable(false)]
		public bool IsDrawed
		{
			get
			{
				return this.isDrawed;
			}
		}
		[Browsable(false)]
		public bool IsStartDraw
		{
			get
			{
				return this.isStartDraw;
			}
		}
		[Browsable(false)]
		public bool IsMoving
		{
			get
			{
				return this.isMoving;
			}
		}
		[Browsable(false)]
		public bool CanReset
		{
			get
			{
				return this.canReset;
			}
			set
			{
				this.canReset = value;
				if (!this.canReset)
				{
					this.Cursor = Cursors.Default;
				}
			}
		}
		public ImageProcessBox()
		{
			this.InitializeComponent();
			this.InitMember();
			this.ForeColor = Color.White;
			this.BackColor = Color.Black;
			this.Dock = DockStyle.Fill;
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}
		private void InitMember()
		{
			this.dotColor = Color.Yellow;
			this.lineColor = Color.Cyan;
			this.magnifySize = new Size(15, 15);
			this.magnifyTimes = 7;
			this.isDrawOperationDot = true;
			this.isSetClip = true;
			this.isShowInfo = true;
			this.autoSizeFromImage = true;
			this.canReset = true;
			this.m_pen = new Pen(this.lineColor, 1f);
			this.m_sb = new SolidBrush(this.dotColor);
			this.selectedRectangle = default(Rectangle);
			this.ClearDraw();
			this.m_rectDots = new Rectangle[8];
			for (int i = 0; i < 8; i++)
			{
				this.m_rectDots[i] = new Rectangle(-10, -10, 5, 5);
			}
		}
		~ImageProcessBox()
		{
			this.m_pen.Dispose();
			this.m_sb.Dispose();
			this.m_bmpDark.Dispose();
			this.baseImage.Dispose();
		}
		public void DeleResource()
		{
			this.m_pen.Dispose();
			this.m_sb.Dispose();
			if (this.baseImage != null)
			{
				this.m_bmpDark.Dispose();
				this.baseImage.Dispose();
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && (!this.IsDrawed || this.Cursor != Cursors.Default))
			{
				this.m_rectClip = this.DisplayRectangle;
				if (this.baseImage != null && this.isSetClip)
				{
					if (e.X > this.baseImage.Width || e.Y > this.baseImage.Height)
					{
						return;
					}
					this.m_rectClip.Intersect(new Rectangle(0, 0, this.baseImage.Width, this.baseImage.Height));
				}
				Cursor.Clip = base.RectangleToScreen(this.m_rectClip);
				this.isStartDraw = true;
				this.m_ptOriginal = e.Location;
			}
			base.Focus();
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			this.m_ptCurrent = e.Location;
			this.m_bMouseEnter = true;
			if (this.isDrawed && this.canReset)
			{
				this.SetCursorStyle(e.Location);
				if (this.isStartDraw && this.isDrawOperationDot)
				{
					if (this.m_rectDots[0].Contains(e.Location))
					{
						this.isDrawed = false;
						this.m_ptOriginal.X = this.selectedRectangle.Right;
						this.m_ptOriginal.Y = this.selectedRectangle.Bottom;
					}
					else
					{
						if (this.m_rectDots[1].Contains(e.Location))
						{
							this.isDrawed = false;
							this.m_ptOriginal.Y = this.selectedRectangle.Bottom;
							this.m_bLockW = true;
						}
						else
						{
							if (this.m_rectDots[2].Contains(e.Location))
							{
								this.isDrawed = false;
								this.m_ptOriginal.X = this.selectedRectangle.X;
								this.m_ptOriginal.Y = this.selectedRectangle.Bottom;
							}
							else
							{
								if (this.m_rectDots[3].Contains(e.Location))
								{
									this.isDrawed = false;
									this.m_ptOriginal.X = this.selectedRectangle.Right;
									this.m_bLockH = true;
								}
								else
								{
									if (this.m_rectDots[4].Contains(e.Location))
									{
										this.isDrawed = false;
										this.m_ptOriginal.X = this.selectedRectangle.X;
										this.m_bLockH = true;
									}
									else
									{
										if (this.m_rectDots[5].Contains(e.Location))
										{
											this.isDrawed = false;
											this.m_ptOriginal.X = this.selectedRectangle.Right;
											this.m_ptOriginal.Y = this.selectedRectangle.Y;
										}
										else
										{
											if (this.m_rectDots[6].Contains(e.Location))
											{
												this.isDrawed = false;
												this.m_ptOriginal.Y = this.selectedRectangle.Y;
												this.m_bLockW = true;
											}
											else
											{
												if (this.m_rectDots[7].Contains(e.Location))
												{
													this.isDrawed = false;
													this.m_ptOriginal = this.selectedRectangle.Location;
												}
												else
												{
													if (this.selectedRectangle.Contains(e.Location))
													{
														this.isDrawed = false;
														this.isMoving = true;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				base.OnMouseMove(e);
				return;
			}
			if (this.isStartDraw)
			{
				if (this.isMoving)
				{
					Point location = this.selectedRectangle.Location;
					this.selectedRectangle.X = this.m_ptTempStarPos.X + e.X - this.m_ptOriginal.X;
					this.selectedRectangle.Y = this.m_ptTempStarPos.Y + e.Y - this.m_ptOriginal.Y;
					if (this.selectedRectangle.X < 0)
					{
						this.selectedRectangle.X = 0;
					}
					if (this.selectedRectangle.Y < 0)
					{
						this.selectedRectangle.Y = 0;
					}
					if (this.selectedRectangle.Right > this.m_rectClip.Width)
					{
						this.selectedRectangle.X = this.m_rectClip.Width - this.selectedRectangle.Width - 1;
					}
					if (this.selectedRectangle.Bottom > this.m_rectClip.Height)
					{
						this.selectedRectangle.Y = this.m_rectClip.Height - this.selectedRectangle.Height - 1;
					}
					if (base.Location == location)
					{
						return;
					}
				}
				else
				{
					if (Math.Abs(e.X - this.m_ptOriginal.X) > 1 || Math.Abs(e.Y - this.m_ptOriginal.Y) > 1)
					{
						if (!this.m_bLockW)
						{
							this.selectedRectangle.X = ((this.m_ptOriginal.X - e.X < 0) ? this.m_ptOriginal.X : e.X);
							this.selectedRectangle.Width = Math.Abs(this.m_ptOriginal.X - e.X);
						}
						if (!this.m_bLockH)
						{
							this.selectedRectangle.Y = ((this.m_ptOriginal.Y - e.Y < 0) ? this.m_ptOriginal.Y : e.Y);
							this.selectedRectangle.Height = Math.Abs(this.m_ptOriginal.Y - e.Y);
						}
					}
				}
				base.Invalidate();
			}
			if (this.baseImage != null && !this.isDrawed && !this.isMoving && this.isShowInfo)
			{
				base.Invalidate();
			}
			base.OnMouseMove(e);
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			this.m_bMouseEnter = false;
			base.Invalidate();
			base.OnMouseLeave(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.selectedRectangle.Width >= 4 && this.selectedRectangle.Height >= 4)
				{
					this.isDrawed = true;
				}
				else
				{
					this.ClearDraw();
				}
				this.isMoving = (this.m_bLockH = (this.m_bLockW = false));
				this.isStartDraw = false;
				this.m_ptTempStarPos = this.selectedRectangle.Location;
				Cursor.Clip = default(Rectangle);
			}
			else
			{
				if (e.Button == MouseButtons.Right)
				{
					this.ClearDraw();
				}
			}
			base.Invalidate();
			base.OnMouseUp(e);
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == 'w')
			{
				NativeMethods.SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y - 1);
			}
			else
			{
				if (e.KeyChar == 's')
				{
					NativeMethods.SetCursorPos(Control.MousePosition.X, Control.MousePosition.Y + 1);
				}
				else
				{
					if (e.KeyChar == 'a')
					{
						NativeMethods.SetCursorPos(Control.MousePosition.X - 1, Control.MousePosition.Y);
					}
					else
					{
						if (e.KeyChar == 'd')
						{
							NativeMethods.SetCursorPos(Control.MousePosition.X + 1, Control.MousePosition.Y);
						}
					}
				}
			}
			base.OnKeyPress(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (this.baseImage != null)
			{
				graphics.DrawImage(this.m_bmpDark, 0, 0);
				graphics.DrawImage(this.baseImage, this.selectedRectangle, this.selectedRectangle, GraphicsUnit.Pixel);
			}
			this.DrawOperationBox(graphics);
			if (this.baseImage != null && !this.isDrawed && !this.isMoving && this.m_bMouseEnter && this.isShowInfo)
			{
				this.DrawInfo(e.Graphics);
			}
			base.OnPaint(e);
		}
		protected virtual void DrawOperationBox(Graphics g)
		{
			string text = string.Concat(new object[]
			{
				"X:",
				this.selectedRectangle.X,
				" Y:",
				this.selectedRectangle.Y,
				" W:",
				this.selectedRectangle.Width + 1,
				" H:",
				this.selectedRectangle.Height + 1
			});
			Size size = TextRenderer.MeasureText(text, this.Font);
			int num = this.selectedRectangle.X;
			int num2 = this.selectedRectangle.Y - size.Height - 5;
			if (!this.m_rectClip.IsEmpty && num + size.Width >= this.m_rectClip.Right)
			{
				num -= size.Width;
			}
			if (num2 <= 0)
			{
				num2 += size.Height + 10;
			}
			this.m_sb.Color = Color.FromArgb(125, 0, 0, 0);
			g.FillRectangle(this.m_sb, num, num2, size.Width, size.Height);
			this.m_sb.Color = this.ForeColor;
			g.DrawString(text, this.Font, this.m_sb, (float)num, (float)num2);
			if (!this.isDrawOperationDot)
			{
				this.m_pen.Width = 3f;
				this.m_pen.Color = this.lineColor;
				g.DrawRectangle(this.m_pen, this.selectedRectangle);
				return;
			}
			this.m_rectDots[0].Y = (this.m_rectDots[1].Y = (this.m_rectDots[2].Y = this.selectedRectangle.Y - 2));
			this.m_rectDots[5].Y = (this.m_rectDots[6].Y = (this.m_rectDots[7].Y = this.selectedRectangle.Bottom - 2));
			this.m_rectDots[0].X = (this.m_rectDots[3].X = (this.m_rectDots[5].X = this.selectedRectangle.X - 2));
			this.m_rectDots[2].X = (this.m_rectDots[4].X = (this.m_rectDots[7].X = this.selectedRectangle.Right - 2));
			this.m_rectDots[3].Y = (this.m_rectDots[4].Y = this.selectedRectangle.Y + this.selectedRectangle.Height / 2 - 2);
			this.m_rectDots[1].X = (this.m_rectDots[6].X = this.selectedRectangle.X + this.selectedRectangle.Width / 2 - 2);
			this.m_pen.Width = 1f;
			this.m_pen.Color = this.lineColor;
			g.DrawRectangle(this.m_pen, this.selectedRectangle);
			this.m_sb.Color = this.dotColor;
			Rectangle[] rectDots = this.m_rectDots;
			for (int i = 0; i < rectDots.Length; i++)
			{
				Rectangle rect = rectDots[i];
				g.FillRectangle(this.m_sb, rect);
			}
			if (this.selectedRectangle.Width <= 10 || this.selectedRectangle.Height <= 10)
			{
				g.DrawRectangle(this.m_pen, this.selectedRectangle);
			}
		}
		protected virtual void DrawInfo(Graphics g)
		{
			int num = this.m_ptCurrent.X + 20;
			int num2 = this.m_ptCurrent.Y + 20;
			int num3 = this.magnifySize.Width * this.magnifyTimes + 8;
			int num4 = this.magnifySize.Width * this.magnifyTimes + 12 + this.Font.Height * 3;
			if (!this.m_rectClip.IsEmpty)
			{
				if (num + num3 >= this.m_rectClip.Right)
				{
					num -= num3 + 30;
				}
				if (num2 + num4 >= this.m_rectClip.Bottom)
				{
					num2 -= num4 + 30;
				}
			}
			else
			{
				if (num + num3 >= base.ClientRectangle.Width)
				{
					num -= num3 + 30;
				}
				if (num2 + num4 >= base.ClientRectangle.Height)
				{
					num2 -= num4 + 30;
				}
			}
			Rectangle rect = new Rectangle(num + 2, num2 + 2, num3 - 4, this.magnifySize.Width * this.magnifyTimes + 4);
			this.m_sb.Color = Color.FromArgb(200, 0, 0, 0);
			g.FillRectangle(this.m_sb, num, num2, num3, num4);
			this.m_pen.Width = 2f;
			this.m_pen.Color = Color.White;
			g.DrawRectangle(this.m_pen, rect);
			using (Bitmap bitmap = new Bitmap(this.magnifySize.Width, this.magnifySize.Height, PixelFormat.Format32bppArgb))
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.SetClip(new Rectangle(0, 0, this.magnifySize.Width, this.magnifySize.Height));
					graphics.DrawImage(this.baseImage, -(this.m_ptCurrent.X - this.magnifySize.Width / 2), -(this.m_ptCurrent.Y - this.magnifySize.Height / 2));
				}
				using (Bitmap bitmap2 = this.MagnifyImage(bitmap, this.magnifyTimes))
				{
					g.DrawImage(bitmap2, num + 4, num2 + 4);
				}
			}
			this.m_pen.Width = (float)(this.magnifyTimes - 2);
			this.m_pen.Color = Color.FromArgb(125, 0, 255, 255);
			int num5 = num + (num3 + ((this.magnifySize.Width % 2 == 0) ? this.magnifyTimes : 0)) / 2;
			int num6 = num2 + 2 + (rect.Height + ((this.MagnifySize.Height % 2 == 0) ? this.magnifyTimes : 0)) / 2;
			g.DrawLine(this.m_pen, num5, num2 + 4, num5, rect.Bottom - 2);
			g.DrawLine(this.m_pen, num + 4, num6, num + num3 - 4, num6);
			this.m_sb.Color = this.ForeColor;
			Color pixel = ((Bitmap)this.baseImage).GetPixel(this.m_ptCurrent.X, this.m_ptCurrent.Y);
			g.DrawString(string.Concat(new object[]
			{
				"Size: ",
				this.selectedRectangle.Width + 1,
				" x ",
				this.selectedRectangle.Height + 1
			}), this.Font, this.m_sb, (float)(num + 2), (float)(rect.Bottom + 2));
			g.DrawString(string.Concat(new object[]
			{
				pixel.A,
				",",
				pixel.R,
				",",
				pixel.G,
				",",
				pixel.B
			}), this.Font, this.m_sb, (float)(num + 2), (float)(rect.Bottom + 2 + this.Font.Height));
			g.DrawString(string.Concat(new string[]
			{
				"0x",
				pixel.A.ToString("X").PadLeft(2, '0'),
				pixel.R.ToString("X").PadLeft(2, '0'),
				pixel.G.ToString("X").PadLeft(2, '0'),
				pixel.B.ToString("X").PadLeft(2, '0')
			}), this.Font, this.m_sb, (float)(num + 2), (float)(rect.Bottom + 2 + this.Font.Height * 2));
			this.m_sb.Color = pixel;
			g.FillRectangle(this.m_sb, num + num3 - 2 - this.Font.Height, num2 + num4 - 2 - this.Font.Height, this.Font.Height, this.Font.Height);
			g.DrawRectangle(Pens.Cyan, num + num3 - 2 - this.Font.Height, num2 + num4 - 2 - this.Font.Height, this.Font.Height, this.Font.Height);
			g.FillRectangle(this.m_sb, num5 - this.magnifyTimes / 2, num6 - this.magnifyTimes / 2, this.magnifyTimes, this.magnifyTimes);
			g.DrawRectangle(Pens.Cyan, num5 - this.magnifyTimes / 2, num6 - this.magnifyTimes / 2, this.magnifyTimes - 1, this.magnifyTimes - 1);
		}
		private Bitmap MagnifyImage(Bitmap bmpSrc, int times)
		{
			Bitmap bitmap = new Bitmap(bmpSrc.Width * times, bmpSrc.Height * times, PixelFormat.Format32bppArgb);
			BitmapData bitmapData = bmpSrc.LockBits(new Rectangle(0, 0, bmpSrc.Width, bmpSrc.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			BitmapData bitmapData2 = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			byte[] array = new byte[bitmapData.Height * bitmapData.Stride];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			byte[] array2 = new byte[bitmapData2.Height * bitmapData2.Stride];
			Marshal.Copy(bitmapData2.Scan0, array2, 0, array2.Length);
			int i = 0;
			int height = bmpSrc.Height;
			while (i < height)
			{
				int j = 0;
				int width = bmpSrc.Width;
				while (j < width)
				{
					for (int k = 0; k < times; k++)
					{
						for (int l = 0; l < times; l++)
						{
							array2[(j * times + l) * 4 + (i * times + k) * bitmapData2.Stride] = array[j * 4 + i * bitmapData.Stride];
							array2[(j * times + l) * 4 + (i * times + k) * bitmapData2.Stride + 1] = array[j * 4 + i * bitmapData.Stride + 1];
							array2[(j * times + l) * 4 + (i * times + k) * bitmapData2.Stride + 2] = array[j * 4 + i * bitmapData.Stride + 2];
							array2[(j * times + l) * 4 + (i * times + k) * bitmapData2.Stride + 3] = array[j * 4 + i * bitmapData.Stride + 3];
						}
					}
					j++;
				}
				i++;
			}
			Marshal.Copy(array2, 0, bitmapData2.Scan0, array2.Length);
			bmpSrc.UnlockBits(bitmapData);
			bitmap.UnlockBits(bitmapData2);
			return bitmap;
		}
		private void SetCursorStyle(Point loc)
		{
			if (this.m_rectDots[0].Contains(loc) || this.m_rectDots[7].Contains(loc))
			{
				this.Cursor = Cursors.SizeNWSE;
				return;
			}
			if (this.m_rectDots[1].Contains(loc) || this.m_rectDots[6].Contains(loc))
			{
				this.Cursor = Cursors.SizeNS;
				return;
			}
			if (this.m_rectDots[2].Contains(loc) || this.m_rectDots[5].Contains(loc))
			{
				this.Cursor = Cursors.SizeNESW;
				return;
			}
			if (this.m_rectDots[3].Contains(loc) || this.m_rectDots[4].Contains(loc))
			{
				this.Cursor = Cursors.SizeWE;
				return;
			}
			if (this.selectedRectangle.Contains(loc))
			{
				this.Cursor = Cursors.SizeAll;
				return;
			}
			this.Cursor = Cursors.Default;
		}
		private void BuildBitmap()
		{
			if (this.baseImage == null)
			{
				return;
			}
			this.m_bmpDark = new Bitmap(this.baseImage);
			using (Graphics graphics = Graphics.FromImage(this.m_bmpDark))
			{
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(125, 0, 0, 0));
				graphics.FillRectangle(solidBrush, 0, 0, this.m_bmpDark.Width, this.m_bmpDark.Height);
				solidBrush.Dispose();
			}
		}
		public void ClearDraw()
		{
			this.isDrawed = false;
			this.selectedRectangle.X = (this.selectedRectangle.Y = -100);
			this.selectedRectangle.Width = (this.selectedRectangle.Height = 0);
			this.Cursor = Cursors.Default;
			base.Invalidate();
		}
		public void SetSelectRect(Rectangle rect)
		{
			rect.Intersect(this.DisplayRectangle);
			if (rect.IsEmpty)
			{
				return;
			}
			rect.Width--;
			rect.Height--;
			if (this.selectedRectangle == rect)
			{
				return;
			}
			this.selectedRectangle = rect;
			base.Invalidate();
		}
		public void SetSelectRect(Point pt, Size se)
		{
			Rectangle right = new Rectangle(pt, se);
			right.Intersect(this.DisplayRectangle);
			if (right.IsEmpty)
			{
				return;
			}
			right.Width--;
			right.Height--;
			if (this.selectedRectangle == right)
			{
				return;
			}
			this.selectedRectangle = right;
			base.Invalidate();
		}
		public void SetSelectRect(int x, int y, int w, int h)
		{
			Rectangle right = new Rectangle(x, y, w, h);
			right.Intersect(this.DisplayRectangle);
			if (right.IsEmpty)
			{
				return;
			}
			right.Width--;
			right.Height--;
			if (this.selectedRectangle == right)
			{
				return;
			}
			this.selectedRectangle = right;
			base.Invalidate();
		}
		public void SetInfoPoint(Point pt)
		{
			if (this.m_ptCurrent == pt)
			{
				return;
			}
			this.m_ptCurrent = pt;
			this.m_bMouseEnter = true;
			base.Invalidate();
		}
		public void SetInfoPoint(int x, int y)
		{
			if (this.m_ptCurrent.X == x && this.m_ptCurrent.Y == y)
			{
				return;
			}
			this.m_ptCurrent.X = x;
			this.m_ptCurrent.Y = y;
			this.m_bMouseEnter = true;
			base.Invalidate();
		}
		public Bitmap GetResultBmp()
		{
			if (this.baseImage != null)
			{
				Bitmap bitmap = new Bitmap(this.selectedRectangle.Width + 1, this.selectedRectangle.Height + 1);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					graphics.DrawImage(this.baseImage, -this.selectedRectangle.X, -this.selectedRectangle.Y);
				}
				return bitmap;
			}
			return null;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
	}
}
