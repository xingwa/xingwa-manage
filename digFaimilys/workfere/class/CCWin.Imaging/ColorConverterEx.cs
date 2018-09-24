using System;
namespace xingwaWinFormUI.Imaging
{
	public sealed class ColorConverterEx
	{
		private static readonly int[] BT907 = new int[]
		{
			2125,
			7154,
			721,
			10000
		};
		private static readonly int[] RMY = new int[]
		{
			500,
			419,
			81,
			1000
		};
		private static readonly int[] Y = new int[]
		{
			299,
			587,
			114,
			1000
		};
		private ColorConverterEx()
		{
		}
		public static HSL RgbToHsl(RGB rgb)
		{
			HSL hSL = new HSL();
			ColorConverterEx.RgbToHsl(rgb, hSL);
			return hSL;
		}
		public static void RgbToHsl(RGB rgb, HSL hsl)
		{
			double num = (double)rgb.R / 255.0;
			double num2 = (double)rgb.G / 255.0;
			double num3 = (double)rgb.G / 255.0;
			double num4 = Math.Min(Math.Min(num, num2), num3);
			double num5 = Math.Max(Math.Max(num, num2), num3);
			double num6 = num5 - num4;
			hsl.Luminance = (num5 + num4) / 2.0;
			if (num6 == 0.0)
			{
				hsl.Hue = 0;
				hsl.Saturation = 0.0;
				return;
			}
			hsl.Saturation = ((hsl.Luminance < 0.5) ? (num6 / (num5 + num4)) : (num6 / (2.0 - num5 - num4)));
			double num7 = ((num5 - num) / 6.0 + num6 / 2.0) / num6;
			double num8 = ((num5 - num2) / 6.0 + num6 / 2.0) / num6;
			double num9 = ((num5 - num3) / 6.0 + num6 / 2.0) / num6;
			double num10;
			if (num == num5)
			{
				num10 = num9 - num8;
			}
			else
			{
				if (num2 == num5)
				{
					num10 = 0.33333333333333331 + num7 - num9;
				}
				else
				{
					num10 = 0.66666666666666663 + num8 - num7;
				}
			}
			if (num10 < 0.0)
			{
				num10 += 1.0;
			}
			if (num10 > 1.0)
			{
				num10 -= 1.0;
			}
			hsl.Hue = (int)(num10 * 360.0);
		}
		public static RGB HslToRgb(HSL hsl)
		{
			RGB rGB = new RGB();
			ColorConverterEx.HslToRgb(hsl, rGB);
			return rGB;
		}
		public static void HslToRgb(HSL hsl, RGB rgb)
		{
			if (hsl.Saturation == 0.0)
			{
				rgb.R = (rgb.G = (rgb.B = (byte)(hsl.Luminance * 255.0)));
				return;
			}
			double num = (double)hsl.Hue / 360.0;
			double num2 = (hsl.Luminance < 0.5) ? (hsl.Luminance * (1.0 + hsl.Saturation)) : (hsl.Luminance + hsl.Saturation - hsl.Luminance * hsl.Saturation);
			double v = 2.0 * hsl.Luminance - num2;
			rgb.R = (byte)(255.0 * ColorConverterEx.HueToRGB(v, num2, num + 0.33333333333333331));
			rgb.G = (byte)(255.0 * ColorConverterEx.HueToRGB(v, num2, num));
			rgb.B = (byte)(255.0 * ColorConverterEx.HueToRGB(v, num2, num - 0.33333333333333331));
		}
		public static RGB RgbToGray(RGB source)
		{
			RGB rGB = new RGB();
			ColorConverterEx.RgbToGray(source, rGB);
			return rGB;
		}
		public static RGB RgbToGray(RGB source, GrayscaleStyle style)
		{
			RGB rGB = new RGB();
			ColorConverterEx.RgbToGray(source, rGB, style);
			return rGB;
		}
		public static void RgbToGray(RGB source, RGB dest)
		{
			ColorConverterEx.RgbToGray(source, dest, GrayscaleStyle.BT907);
		}
		public static void RgbToGray(RGB source, RGB dest, GrayscaleStyle style)
		{
			byte b = 127;
			switch (style)
			{
			case GrayscaleStyle.BT907:
				b = ColorConverterEx.GetGray(source, ColorConverterEx.BT907);
				break;
			case GrayscaleStyle.RMY:
				b = ColorConverterEx.GetGray(source, ColorConverterEx.RMY);
				break;
			case GrayscaleStyle.Y:
				b = ColorConverterEx.GetGray(source, ColorConverterEx.Y);
				break;
			}
			dest.R = (dest.G = (dest.B = b));
		}
		private static double HueToRGB(double v1, double v2, double vH)
		{
			if (vH < 0.0)
			{
				vH += 1.0;
			}
			if (vH > 1.0)
			{
				vH -= 1.0;
			}
			if (6.0 * vH < 1.0)
			{
				return v1 + (v2 - v1) * 6.0 * vH;
			}
			if (2.0 * vH < 1.0)
			{
				return v2;
			}
			if (3.0 * vH < 2.0)
			{
				return v1 + (v2 - v1) * (0.66666666666666663 - vH) * 6.0;
			}
			return v1;
		}
		private static byte GetGray(RGB rgb, int[] coefficient)
		{
			return (byte)(((int)rgb.R * coefficient[0] + (int)rgb.G * coefficient[1] + (int)rgb.B * coefficient[2]) / coefficient[3]);
		}
	}
}
