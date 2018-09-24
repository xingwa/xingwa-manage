using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinClass
{
	public static class RegionHelper
	{
		public static void CreateRegion(Control control, Rectangle bounds, int radius, RoundStyle roundStyle)
		{
			using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(bounds, radius, roundStyle, true))
			{
				Region region = new Region(graphicsPath);
				graphicsPath.Widen(Pens.White);
				region.Union(graphicsPath);
				if (control.Region != null)
				{
					control.Region.Dispose();
				}
				control.Region = region;
			}
		}
		public static void CreateRegion(Control control, Rectangle bounds)
		{
			RegionHelper.CreateRegion(control, bounds, 8, RoundStyle.All);
		}
	}
}
