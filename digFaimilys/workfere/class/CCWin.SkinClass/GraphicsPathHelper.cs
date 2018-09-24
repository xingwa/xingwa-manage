using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace xingwaWinFormUI.SkinClass
{
	public static class GraphicsPathHelper
	{
		public static GraphicsPath CreatePath(Rectangle rect, int radius, RoundStyle style, bool correction)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			int num = correction ? 1 : 0;
			switch (style)
			{
			case RoundStyle.None:
				graphicsPath.AddRectangle(rect);
				break;
			case RoundStyle.All:
				graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
				graphicsPath.AddArc(rect.Right - radius - num, rect.Y, radius, radius, 270f, 90f);
				graphicsPath.AddArc(rect.Right - radius - num, rect.Bottom - radius - num, radius, radius, 0f, 90f);
				graphicsPath.AddArc(rect.X, rect.Bottom - radius - num, radius, radius, 90f, 90f);
				break;
			case RoundStyle.Left:
				graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
				graphicsPath.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
				graphicsPath.AddArc(rect.X, rect.Bottom - radius - num, radius, radius, 90f, 90f);
				break;
			case RoundStyle.Right:
				graphicsPath.AddArc(rect.Right - radius - num, rect.Y, radius, radius, 270f, 90f);
				graphicsPath.AddArc(rect.Right - radius - num, rect.Bottom - radius - num, radius, radius, 0f, 90f);
				graphicsPath.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
				break;
			case RoundStyle.Top:
				graphicsPath.AddArc(rect.X, rect.Y, radius, radius, 180f, 90f);
				graphicsPath.AddArc(rect.Right - radius - num, rect.Y, radius, radius, 270f, 90f);
				graphicsPath.AddLine(rect.Right - num, rect.Bottom - num, rect.X, rect.Bottom - num);
				break;
			case RoundStyle.Bottom:
				graphicsPath.AddArc(rect.Right - radius - num, rect.Bottom - radius - num, radius, radius, 0f, 90f);
				graphicsPath.AddArc(rect.X, rect.Bottom - radius - num, radius, radius, 90f, 90f);
				graphicsPath.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
				break;
			case RoundStyle.BottomLeft:
				graphicsPath.AddArc(rect.X, rect.Bottom - radius - num, radius, radius, 90f, 90f);
				graphicsPath.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
				graphicsPath.AddLine(rect.Right - num, rect.Y, rect.Right - num, rect.Bottom - num);
				break;
			case RoundStyle.BottomRight:
				graphicsPath.AddArc(rect.Right - radius - num, rect.Bottom - radius - num, radius, radius, 0f, 90f);
				graphicsPath.AddLine(rect.X, rect.Bottom - num, rect.X, rect.Y);
				graphicsPath.AddLine(rect.X, rect.Y, rect.Right - num, rect.Y);
				break;
			}
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
	}
}
