using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class RenderHelper
	{
		public static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			RenderHelper.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, 8, drawBorder, drawGlass, mode);
		}
		public static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, bool drawBorder, bool drawGlass, LinearGradientMode mode)
		{
			RenderHelper.RenderBackgroundInternal(g, rect, baseColor, borderColor, innerBorderColor, style, 8, 0.45f, drawBorder, drawGlass, mode);
		}
		public static void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
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
					RenderHelper.GetColor(baseColor, 0, 35, 24, 9),
					RenderHelper.GetColor(baseColor, 0, 13, 8, 3),
					baseColor,
					RenderHelper.GetColor(baseColor, 0, 35, 24, 9)
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
					if (drawGlass)
					{
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
				if (drawGlass)
				{
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
		private static Color GetColor(Color colorBase, int a, int r, int g, int b)
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
