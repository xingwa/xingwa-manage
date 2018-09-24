using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	internal class RenderHelperScrollBar
	{
		internal static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			RenderHelperScrollBar.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, 8, drawBorder, drawGlass, mode);
		}
		internal static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			RenderHelperScrollBar.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, 8, 0.45f, drawBorder, drawGlass, mode);
		}
		internal static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			if (drawBorder)
			{
				rect.Width--;
				rect.Height--;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
			{
				Color[] colors = new Color[]
				{
					RenderHelperScrollBar.GetColor(baseColor, 0, 35, 24, 9),
					RenderHelperScrollBar.GetColor(baseColor, 0, 13, 8, 3),
					baseColor,
					RenderHelperScrollBar.GetColor(baseColor, 0, 35, 24, 9)
				};
				linearGradientBrush.InterpolationColors = new ColorBlend
				{
					Positions = new float[]
					{
						0f,
						basePosition,
						basePosition + 0.05f,
						1f
					},
					Colors = colors
				};
				if (style != RoundStyle.None)
				{
					using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						g.FillPath(linearGradientBrush, graphicsPath);
					}
					if (baseColor.A > 80)
					{
						Rectangle rect2 = rect;
						if (mode == LinearGradientMode.Vertical)
						{
							rect2.Height = (int)((float)rect2.Height * basePosition);
						}
						else
						{
							rect2.Width = (int)((float)rect.Width * basePosition);
						}
						using (GraphicsPath graphicsPath2 = GraphicsPathHelper.CreatePath(rect2, roundWidth, RoundStyle.Top, false))
						{
							using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
							{
								g.FillPath(solidBrush, graphicsPath2);
							}
						}
					}
					if (drawGlass)
					{
						RectangleF glassRect = rect;
						if (mode == LinearGradientMode.Vertical)
						{
							glassRect.Y = (float)rect.Y + (float)rect.Height * basePosition;
							glassRect.Height = ((float)rect.Height - (float)rect.Height * basePosition) * 2f;
						}
						else
						{
							glassRect.X = (float)rect.X + (float)rect.Width * basePosition;
							glassRect.Width = ((float)rect.Width - (float)rect.Width * basePosition) * 2f;
						}
						ControlPaintEx.DrawGlass(g, glassRect, 170, 0);
					}
					if (!drawBorder)
					{
						goto IL_412;
					}
					using (GraphicsPath graphicsPath3 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						using (Pen pen = new Pen(borderColor))
						{
							g.DrawPath(pen, graphicsPath3);
						}
					}
					rect.Inflate(-1, -1);
					using (GraphicsPath graphicsPath4 = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
					{
						using (Pen pen2 = new Pen(innerBorderColor))
						{
							g.DrawPath(pen2, graphicsPath4);
						}
						goto IL_412;
					}
				}
				g.FillRectangle(linearGradientBrush, rect);
				if (baseColor.A > 80)
				{
					Rectangle rect3 = rect;
					if (mode == LinearGradientMode.Vertical)
					{
						rect3.Height = (int)((float)rect3.Height * basePosition);
					}
					else
					{
						rect3.Width = (int)((float)rect.Width * basePosition);
					}
					using (SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
					{
						g.FillRectangle(solidBrush2, rect3);
					}
				}
				if (drawGlass)
				{
					RectangleF glassRect2 = rect;
					if (mode == LinearGradientMode.Vertical)
					{
						glassRect2.Y = (float)rect.Y + (float)rect.Height * basePosition;
						glassRect2.Height = ((float)rect.Height - (float)rect.Height * basePosition) * 2f;
					}
					else
					{
						glassRect2.X = (float)rect.X + (float)rect.Width * basePosition;
						glassRect2.Width = ((float)rect.Width - (float)rect.Width * basePosition) * 2f;
					}
					ControlPaintEx.DrawGlass(g, glassRect2, 200, 0);
				}
				if (drawBorder)
				{
					using (Pen pen3 = new Pen(borderColor))
					{
						g.DrawRectangle(pen3, rect);
					}
					rect.Inflate(-1, -1);
					using (Pen pen4 = new Pen(innerBorderColor))
					{
						g.DrawRectangle(pen4, rect);
					}
				}
				IL_412:;
			}
		}
		internal static void RenderArrowInternal(Graphics g, Rectangle dropDownRect, ArrowDirection direction, Brush brush)
		{
			Point point = new Point(dropDownRect.Left + dropDownRect.Width / 2, dropDownRect.Top + dropDownRect.Height / 2);
			Point[] points;
			switch (direction)
			{
			case ArrowDirection.Left:
				points = new Point[]
				{
					new Point(point.X + 1, point.Y - 4),
					new Point(point.X + 1, point.Y + 4),
					new Point(point.X - 2, point.Y)
				};
				break;
			case ArrowDirection.Up:
				points = new Point[]
				{
					new Point(point.X - 4, point.Y + 1),
					new Point(point.X + 4, point.Y + 1),
					new Point(point.X, point.Y - 2)
				};
				break;
			default:
				if (direction != ArrowDirection.Right)
				{
					points = new Point[]
					{
						new Point(point.X - 4, point.Y - 1),
						new Point(point.X + 4, point.Y - 1),
						new Point(point.X, point.Y + 2)
					};
				}
				else
				{
					points = new Point[]
					{
						new Point(point.X - 2, point.Y - 4),
						new Point(point.X - 2, point.Y + 4),
						new Point(point.X + 1, point.Y)
					};
				}
				break;
			}
			g.FillPolygon(brush, points);
		}
		internal static void RenderAlphaImage(Graphics g, Image image, Rectangle imageRect, float alpha)
		{
			using (ImageAttributes imageAttributes = new ImageAttributes())
			{
				ColorMap[] map = new ColorMap[]
				{
					new ColorMap
					{
						OldColor = Color.FromArgb(255, 0, 255, 0),
						NewColor = Color.FromArgb(0, 0, 0, 0)
					}
				};
				imageAttributes.SetRemapTable(map, ColorAdjustType.Bitmap);
				float[][] array = new float[5][];
				float[][] arg_68_0 = array;
				int arg_68_1 = 0;
				float[] array2 = new float[5];
				array2[0] = 1f;
				arg_68_0[arg_68_1] = array2;
				float[][] arg_7F_0 = array;
				int arg_7F_1 = 1;
				float[] array3 = new float[5];
				array3[1] = 1f;
				arg_7F_0[arg_7F_1] = array3;
				float[][] arg_96_0 = array;
				int arg_96_1 = 2;
				float[] array4 = new float[5];
				array4[2] = 1f;
				arg_96_0[arg_96_1] = array4;
				float[][] arg_A9_0 = array;
				int arg_A9_1 = 3;
				float[] array5 = new float[5];
				array5[3] = alpha;
				arg_A9_0[arg_A9_1] = array5;
				array[4] = new float[]
				{
					0f,
					0f,
					0f,
					0f,
					1f
				};
				float[][] newColorMatrix = array;
				ColorMatrix newColorMatrix2 = new ColorMatrix(newColorMatrix);
				imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
				g.DrawImage(image, imageRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
			}
		}
		internal static Color GetColor(Color colorBase, int a, int r, int g, int b)
		{
			int a2 = (int)colorBase.A;
			int r2 = (int)colorBase.R;
			int g2 = (int)colorBase.G;
			int b2 = (int)colorBase.B;
			if (a + a2 > 255)
			{
				a = 255;
			}
			else
			{
				a = Math.Max(0, a + a2);
			}
			if (r + r2 > 255)
			{
				r = 255;
			}
			else
			{
				r = Math.Max(0, r + r2);
			}
			if (g + g2 > 255)
			{
				g = 255;
			}
			else
			{
				g = Math.Max(0, g + g2);
			}
			if (b + b2 > 255)
			{
				b = 255;
			}
			else
			{
				b = Math.Max(0, b + b2);
			}
			return Color.FromArgb(a, r, g, b);
		}
	}
}
