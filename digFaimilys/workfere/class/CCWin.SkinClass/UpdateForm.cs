namespace xingwaWinFormUI.SkinClass
{
    using xingwaWinFormUI;
    using xingwaWinFormUI.SkinControl;
    using xingwaWinFormUI.Win32;
    using xingwaWinFormUI.Win32.Struct;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class UpdateForm
    {
        public static Bitmap BothAlpha(Bitmap p_Bitmap, bool p_CentralTransparent, bool p_Crossdirection)
        {
            Bitmap image = new Bitmap(p_Bitmap.Width, p_Bitmap.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(p_Bitmap, new Rectangle(0, 0, p_Bitmap.Width, p_Bitmap.Height));
            graphics.Dispose();
            Bitmap bitmap2 = new Bitmap(image.Width, image.Height);
            Graphics graphics2 = Graphics.FromImage(bitmap2);
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            System.Drawing.Point point2 = new System.Drawing.Point(bitmap2.Width, 0);
            System.Drawing.Point point3 = new System.Drawing.Point(bitmap2.Width, bitmap2.Height / 2);
            System.Drawing.Point point4 = new System.Drawing.Point(0, bitmap2.Height / 2);
            if (p_Crossdirection)
            {
                point = new System.Drawing.Point(0, 0);
                point2 = new System.Drawing.Point(bitmap2.Width / 2, 0);
                point3 = new System.Drawing.Point(bitmap2.Width / 2, bitmap2.Height);
                point4 = new System.Drawing.Point(0, bitmap2.Height);
            }
            System.Drawing.Point[] points = new System.Drawing.Point[] { point, point2, point3, point4 };
            PathGradientBrush brush = new PathGradientBrush(points, WrapMode.TileFlipY)
            {
                CenterPoint = new PointF(0f, 0f),
                FocusScales = new PointF((float)(bitmap2.Width / 2), 0f),
                CenterColor = Color.FromArgb(0, 0xff, 0xff, 0xff)
            };
            brush.SurroundColors = new Color[] { Color.FromArgb(0xff, 0xff, 0xff, 0xff) };
            if (p_Crossdirection)
            {
                brush.FocusScales = new PointF(0f, (float)bitmap2.Height);
                brush.WrapMode = WrapMode.TileFlipX;
            }
            if (p_CentralTransparent)
            {
                brush.CenterColor = Color.FromArgb(0xff, 0xff, 0xff, 0xff);
                brush.SurroundColors = new Color[] { Color.FromArgb(0, 0xff, 0xff, 0xff) };
            }
            graphics2.FillRectangle(brush, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
            graphics2.Dispose();
            BitmapData bitmapdata = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadOnly, bitmap2.PixelFormat);
            byte[] destination = new byte[bitmapdata.Stride * bitmapdata.Height];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
            bitmap2.UnlockBits(bitmapdata);
            BitmapData data2 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            byte[] buffer2 = new byte[data2.Stride * data2.Height];
            Marshal.Copy(data2.Scan0, buffer2, 0, buffer2.Length);
            int index = 0;
            for (int i = 0; i != data2.Height; i++)
            {
                index = (i * data2.Stride) + 3;
                for (int j = 0; j != data2.Width; j++)
                {
                    buffer2[index] = destination[index];
                    index += 4;
                }
            }
            Marshal.Copy(buffer2, 0, data2.Scan0, buffer2.Length);
            image.UnlockBits(data2);
            return image;
        }

        public static GraphicsPath CalculateControlGraphicsPath(Bitmap bitmap, int Alpha)
        {
            GraphicsPath path = new GraphicsPath();
            int x = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                x = 0;
                for (int j = 0; j < bitmap.Width; j++)
                {
                    if (bitmap.GetPixel(j, i).A < Alpha)
                    {
                        continue;
                    }
                    x = j;
                    int num4 = j;
                    num4 = x;
                    while (num4 < bitmap.Width)
                    {
                        if (bitmap.GetPixel(num4, i).A < Alpha)
                        {
                            break;
                        }
                        num4++;
                    }
                    path.AddRectangle(new Rectangle(x, i, num4 - x, 1));
                    j = num4;
                }
            }
            return path;
        }

        public static void CreateControlRegion(Control control, Bitmap bitmap, int Alpha)
        {
            if ((control != null) && (bitmap != null))
            {
                control.Width = bitmap.Width;
                control.Height = bitmap.Height;
                if (control is Form)
                {
                    Form form = (Form)control;
                    form.Width = control.Width;
                    form.Height = control.Height;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackgroundImage = bitmap;
                    GraphicsPath path = CalculateControlGraphicsPath(bitmap, Alpha);
                    form.Region = new Region(path);
                }
                else if (control is SkinButtom)
                {
                    SkinButtom buttom = (SkinButtom)control;
                    GraphicsPath path2 = CalculateControlGraphicsPath(bitmap, Alpha);
                    buttom.Region = new Region(path2);
                }
                else if (control is SkinProgressBar)
                {
                    SkinProgressBar bar = (SkinProgressBar)control;
                    GraphicsPath path3 = CalculateControlGraphicsPath(bitmap, Alpha);
                    bar.Region = new Region(path3);
                }
            }
        }

        public static void CreateRegion(Control control, Rectangle bounds)
        {
            CreateRegion(control, bounds, 8, RoundStyle.All);
        }

        public static void CreateRegion(Control ctrl, int RgnRadius)
        {
            int hRgn = xingwaWinFormUI.Win32.NativeMethods.CreateRoundRectRgn(0, 0, ctrl.ClientRectangle.Width + 1, ctrl.ClientRectangle.Height + 1, RgnRadius, RgnRadius);
            xingwaWinFormUI.Win32.NativeMethods.SetWindowRgn(ctrl.Handle, hRgn, true);
        }

        public static void CreateRegion(IntPtr hWnd, int radius, RoundStyle roundStyle, bool redraw)
        {
            xingwaWinFormUI.Win32.Struct.RECT lpRect = new xingwaWinFormUI.Win32.Struct.RECT();
            xingwaWinFormUI.Win32.NativeMethods.GetWindowRect(hWnd, ref lpRect);
            Rectangle rect = new Rectangle(System.Drawing.Point.Empty, lpRect.Size);
            if (roundStyle != RoundStyle.None)
            {
                using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, radius, roundStyle, true))
                {
                    using (Region region = new Region(path))
                    {
                        path.Widen(Pens.White);
                        region.Union(path);
                        IntPtr windowDC = xingwaWinFormUI.Win32.NativeMethods.GetWindowDC(hWnd);
                        try
                        {
                            using (Graphics graphics = Graphics.FromHdc(windowDC))
                            {
                                xingwaWinFormUI.Win32.NativeMethods.SetWindowRgn(hWnd, region.GetHrgn(graphics), redraw);
                            }
                        }
                        finally
                        {
                            xingwaWinFormUI.Win32.NativeMethods.ReleaseDC(hWnd, windowDC);
                        }
                    }
                    return;
                }
            }
            IntPtr hRgn = xingwaWinFormUI.Win32.NativeMethods.CreateRectRgn(0, 0, rect.Width, rect.Height);
            xingwaWinFormUI.Win32.NativeMethods.SetWindowRgn(hWnd, hRgn, redraw);
        }

        public static void CreateRegion(Control control, Rectangle bounds, int radius, RoundStyle roundStyle)
        {
            if (roundStyle != RoundStyle.None)
            {
                using (GraphicsPath path = GraphicsPathHelper.CreatePath(bounds, radius, roundStyle, true))
                {
                    Region region = new Region(path);
                    path.Widen(Pens.White);
                    region.Union(path);
                    control.Region = region;
                    return;
                }
            }
            if (control.Region != null)
            {
                control.Region = null;
            }
        }

        public static void CursorClick(int x, int y)
        {
            int dwFlags = 2;
            int num2 = 4;
            xingwaWinFormUI.Win32.NativeMethods.mouse_event(dwFlags, (x * 0x10000) / 0x400, (y * 0x10000) / 0x300, 0, 0);
            xingwaWinFormUI.Win32.NativeMethods.mouse_event(num2, (x * 0x10000) / 0x400, (y * 0x10000) / 0x300, 0, 0);
        }

        public static Bitmap GaryImg(Bitmap b)
        {
            Bitmap bitmap = b.Clone(new Rectangle(0, 0, b.Width, b.Height), PixelFormat.Format24bppRgb);
            b.Dispose();
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte[] destination = new byte[bitmap.Height * bitmapdata.Stride];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, destination.Length);
            int num = 0;
            int width = bitmap.Width;
            while (num < width)
            {
                int num3 = 0;
                int height = bitmap.Height;
                while (num3 < height)
                {
                    byte num5;
                    destination[((num3 * bitmapdata.Stride) + (num * 3)) + 2] = num5 = GetAvg(destination[(num3 * bitmapdata.Stride) + (num * 3)], destination[((num3 * bitmapdata.Stride) + (num * 3)) + 1], destination[((num3 * bitmapdata.Stride) + (num * 3)) + 2]);
                    destination[(num3 * bitmapdata.Stride) + (num * 3)] = destination[((num3 * bitmapdata.Stride) + (num * 3)) + 1] = num5;
                    num3++;
                }
                num++;
            }
            Marshal.Copy(destination, 0, bitmapdata.Scan0, destination.Length);
            bitmap.UnlockBits(bitmapdata);
            return bitmap;
        }

        private static byte GetAvg(byte b, byte g, byte r)
        {
            return (byte)(((r + g) + b) / 3);
        }

        public static Color GetImageAverageColor(Bitmap back)
        {
            return BitmapHelper.GetImageAverageColor(back);
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration)
        {
            Bitmap image = null;
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int)ef.Width, (int)ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, (float)0f, (float)0f);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                    graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                    graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                    for (int i = 0; i <= BlurConsideration; i++)
                                    {
                                        for (int j = 0; j <= BlurConsideration; j++)
                                        {
                                            graphics3.DrawImageUnscaled(bitmap2, i, j);
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, (float)(BlurConsideration / 2), (float)(BlurConsideration / 2));
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

        public static Image ImageLightEffect(string Str, Font F, Color ColorFore, Color ColorBack, int BlurConsideration, Rectangle rc, bool auto)
        {
            Bitmap image = null;
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap)
            {
                Trimming = auto ? StringTrimming.EllipsisWord : StringTrimming.None
            };
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF ef = graphics.MeasureString(Str, F);
                using (Bitmap bitmap2 = new Bitmap((int)ef.Width, (int)ef.Height))
                {
                    using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                    {
                        using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x10, ColorBack.R, ColorBack.G, ColorBack.B)))
                        {
                            using (SolidBrush brush2 = new SolidBrush(ColorFore))
                            {
                                graphics2.SmoothingMode = SmoothingMode.HighQuality;
                                graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                graphics2.DrawString(Str, F, brush, rc, format);
                                image = new Bitmap(bitmap2.Width + BlurConsideration, bitmap2.Height + BlurConsideration);
                                using (Graphics graphics3 = Graphics.FromImage(image))
                                {
                                    if (ColorBack != Color.Transparent)
                                    {
                                        graphics3.SmoothingMode = SmoothingMode.HighQuality;
                                        graphics3.InterpolationMode = InterpolationMode.HighQualityBilinear;
                                        graphics3.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                                        for (int i = 0; i <= BlurConsideration; i++)
                                        {
                                            for (int j = 0; j <= BlurConsideration; j++)
                                            {
                                                graphics3.DrawImageUnscaled(bitmap2, i, j);
                                            }
                                        }
                                    }
                                    graphics3.DrawString(Str, F, brush2, new Rectangle(new System.Drawing.Point(Convert.ToInt32((int)(BlurConsideration / 2)), Convert.ToInt32((int)(BlurConsideration / 2))), rc.Size), format);
                                }
                                return image;
                            }
                        }
                    }
                }
            }
        }

        public static Bitmap ResizeBitmap(Bitmap b, int dstWidth, int dstHeight)
        {
            Bitmap image = new Bitmap(dstWidth, dstHeight);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.Bilinear;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(b, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, b.Width, b.Height), GraphicsUnit.Pixel);
            graphics.Save();
            graphics.Dispose();
            return image;
        }
    }
}

