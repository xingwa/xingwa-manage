using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public sealed class ControlPaintScroll
	{
		private ControlPaintScroll()
		{
		}
		public static void DrawCheckedFlag(Graphics g, Rectangle rect, Color color)
		{
			PointF[] points = new PointF[]
			{
				new PointF((float)rect.X + (float)rect.Width / 4.5f, (float)rect.Y + (float)rect.Height / 2.5f),
				new PointF((float)rect.X + (float)rect.Width / 2.5f, (float)rect.Bottom - (float)rect.Height / 3f),
				new PointF((float)rect.Right - (float)rect.Width / 4f, (float)rect.Y + (float)rect.Height / 4.5f)
			};
			using (Pen pen = new Pen(color, 2f))
			{
				g.DrawLines(pen, points);
			}
		}
		public static void DrawGlass(Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
		{
			ControlPaintScroll.DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
		}
		public static void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
		{
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddEllipse(glassRect);
				using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath))
				{
					pathGradientBrush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
					pathGradientBrush.SurroundColors = new Color[]
					{
						Color.FromArgb(alphaSurround, glassColor)
					};
					pathGradientBrush.CenterPoint = new PointF(glassRect.X + glassRect.Width / 2f, glassRect.Y + glassRect.Height / 2f);
					g.FillPath(pathGradientBrush, graphicsPath);
				}
			}
		}
		public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect)
		{
			ControlPaintScroll.DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, Point.Empty, RightToLeft.No);
		}
		public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset)
		{
			ControlPaintScroll.DrawBackgroundImage(g, backgroundImage, backColor, backgroundImageLayout, bounds, clipRect, scrollOffset, RightToLeft.No);
		}
		public static void DrawBackgroundImage(Graphics g, Image backgroundImage, Color backColor, ImageLayout backgroundImageLayout, Rectangle bounds, Rectangle clipRect, Point scrollOffset, RightToLeft rightToLeft)
		{
			if (g == null)
			{
				throw new ArgumentNullException("g");
			}
			if (backgroundImageLayout == ImageLayout.Tile)
			{
				using (TextureBrush textureBrush = new TextureBrush(backgroundImage, WrapMode.Tile))
				{
					if (scrollOffset != Point.Empty)
					{
						Matrix transform = textureBrush.Transform;
						transform.Translate((float)scrollOffset.X, (float)scrollOffset.Y);
						textureBrush.Transform = transform;
					}
					g.FillRectangle(textureBrush, clipRect);
					return;
				}
			}
			Rectangle rectangle = ControlPaintScroll.CalculateBackgroundImageRectangle(bounds, backgroundImage, backgroundImageLayout);
			if (rightToLeft == RightToLeft.Yes && backgroundImageLayout == ImageLayout.None)
			{
				rectangle.X += clipRect.Width - rectangle.Width;
			}
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				g.FillRectangle(solidBrush, clipRect);
			}
			if (!clipRect.Contains(rectangle))
			{
				if (backgroundImageLayout == ImageLayout.Stretch || backgroundImageLayout == ImageLayout.Zoom)
				{
					rectangle.Intersect(clipRect);
					g.DrawImage(backgroundImage, rectangle);
					return;
				}
				if (backgroundImageLayout == ImageLayout.None)
				{
					rectangle.Offset(clipRect.Location);
					Rectangle destRect = rectangle;
					destRect.Intersect(clipRect);
					Rectangle rectangle2 = new Rectangle(Point.Empty, destRect.Size);
					g.DrawImage(backgroundImage, destRect, rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height, GraphicsUnit.Pixel);
					return;
				}
				Rectangle destRect2 = rectangle;
				destRect2.Intersect(clipRect);
				Rectangle rectangle3 = new Rectangle(new Point(destRect2.X - rectangle.X, destRect2.Y - rectangle.Y), destRect2.Size);
				g.DrawImage(backgroundImage, destRect2, rectangle3.X, rectangle3.Y, rectangle3.Width, rectangle3.Height, GraphicsUnit.Pixel);
				return;
			}
			else
			{
				ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
				g.DrawImage(backgroundImage, rectangle, 0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imageAttributes);
				imageAttributes.Dispose();
			}
		}
		public static void DrawScrollBarTrack(Graphics g, Rectangle rect, Color begin, Color end, Orientation orientation)
		{
			LinearGradientMode mode = (orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
			Blend blend = new Blend();
			Blend arg_2D_0 = blend;
			float[] array = new float[3];
			array[0] = 1f;
			array[1] = 0.5f;
			arg_2D_0.Factors = array;
			blend.Positions = new float[]
			{
				0f,
				0.5f,
				1f
			};
			ControlPaintScroll.DrawGradientRect(g, rect, begin, end, begin, begin, blend, mode, true, false);
		}
		public static void DrawScrollBarThumb(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Orientation orientation, bool changeColor)
		{
			if (changeColor)
			{
				Color color = begin;
				begin = end;
				end = color;
			}
			bool flag = orientation == Orientation.Horizontal;
			LinearGradientMode mode = flag ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
			Blend blend = new Blend();
			Blend arg_3D_0 = blend;
			float[] array = new float[3];
			array[0] = 1f;
			array[1] = 0.5f;
			arg_3D_0.Factors = array;
			blend.Positions = new float[]
			{
				0f,
				0.5f,
				1f
			};
			if (flag)
			{
				rect.Inflate(0, -1);
			}
			else
			{
				rect.Inflate(-1, 0);
			}
			ControlPaintScroll.DrawGradientRoundRect(g, rect, begin, end, border, innerBorder, blend, mode, 4, RoundStyle.All, true, true);
		}
		public static void DrawScrollBarArraw(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Color fore, Orientation orientation, ArrowDirection arrowDirection, bool changeColor)
		{
			if (changeColor)
			{
				Color color = begin;
				begin = end;
				end = color;
			}
			LinearGradientMode mode = (orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
			rect.Inflate(-1, -1);
			Blend blend = new Blend();
			Blend arg_46_0 = blend;
			float[] array = new float[3];
			array[0] = 1f;
			array[1] = 0.5f;
			arg_46_0.Factors = array;
			blend.Positions = new float[]
			{
				0f,
				0.5f,
				1f
			};
			ControlPaintScroll.DrawGradientRoundRect(g, rect, begin, end, border, innerBorder, blend, mode, 4, RoundStyle.All, true, true);
			using (SolidBrush solidBrush = new SolidBrush(fore))
			{
				RenderHelperScrollBar.RenderArrowInternal(g, rect, arrowDirection, solidBrush);
			}
		}
		internal static void DrawGradientRect(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Blend blend, LinearGradientMode mode, bool drawBorder, bool drawInnerBorder)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, begin, end, mode))
			{
				linearGradientBrush.Blend = blend;
				g.FillRectangle(linearGradientBrush, rect);
			}
			if (drawBorder)
			{
				ControlPaint.DrawBorder(g, rect, border, ButtonBorderStyle.Solid);
			}
			if (drawInnerBorder)
			{
				rect.Inflate(-1, -1);
				ControlPaint.DrawBorder(g, rect, border, ButtonBorderStyle.Solid);
			}
		}
		internal static void DrawGradientRoundRect(Graphics g, Rectangle rect, Color begin, Color end, Color border, Color innerBorder, Blend blend, LinearGradientMode mode, int radios, RoundStyle roundStyle, bool drawBorder, bool drawInnderBorder)
		{
			using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(rect, radios, roundStyle, true))
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, begin, end, mode))
				{
					linearGradientBrush.Blend = blend;
					g.FillPath(linearGradientBrush, graphicsPath);
				}
				if (drawBorder)
				{
					using (Pen pen = new Pen(border))
					{
						g.DrawPath(pen, graphicsPath);
					}
				}
			}
			if (drawInnderBorder)
			{
				rect.Inflate(-1, -1);
				using (GraphicsPath graphicsPath2 = GraphicsPathHelper.CreatePath(rect, radios, roundStyle, true))
				{
					using (Pen pen2 = new Pen(innerBorder))
					{
						g.DrawPath(pen2, graphicsPath2);
					}
				}
			}
		}
		internal static Rectangle CalculateBackgroundImageRectangle(Rectangle bounds, Image backgroundImage, ImageLayout imageLayout)
		{
			Rectangle result = bounds;
			if (backgroundImage != null)
			{
				switch (imageLayout)
				{
				case ImageLayout.None:
					result.Size = backgroundImage.Size;
					return result;
				case ImageLayout.Tile:
					return result;
				case ImageLayout.Center:
				{
					result.Size = backgroundImage.Size;
					Size size = bounds.Size;
					if (size.Width > result.Width)
					{
						result.X = (size.Width - result.Width) / 2;
					}
					if (size.Height > result.Height)
					{
						result.Y = (size.Height - result.Height) / 2;
					}
					return result;
				}
				case ImageLayout.Stretch:
					result.Size = bounds.Size;
					return result;
				case ImageLayout.Zoom:
				{
					Size size2 = backgroundImage.Size;
					float num = (float)bounds.Width / (float)size2.Width;
					float num2 = (float)bounds.Height / (float)size2.Height;
					if (num >= num2)
					{
						result.Height = bounds.Height;
						result.Width = (int)((double)((float)size2.Width * num2) + 0.5);
						if (bounds.X >= 0)
						{
							result.X = (bounds.Width - result.Width) / 2;
						}
						return result;
					}
					result.Width = bounds.Width;
					result.Height = (int)((double)((float)size2.Height * num) + 0.5);
					if (bounds.Y >= 0)
					{
						result.Y = (bounds.Height - result.Height) / 2;
					}
					return result;
				}
				}
			}
			return result;
		}
	}
}
