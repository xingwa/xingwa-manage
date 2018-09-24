using System;
using System.Drawing;
namespace xingwaWinFormUI.SkinClass
{
	public class ImageDrawRect
	{
		public static ContentAlignment anyRight = (ContentAlignment)1092;
		public static ContentAlignment anyTop = (ContentAlignment)7;
		public static ContentAlignment anyBottom = (ContentAlignment)1792;
		public static ContentAlignment anyCenter = (ContentAlignment)546;
		public static ContentAlignment anyMiddle = (ContentAlignment)112;
		public static void DrawRect(Graphics g, Bitmap img, Rectangle r, Rectangle lr, int index, int Totalindex)
		{
			if (img == null)
			{
				return;
			}
			int num = (index - 1) * img.Width / Totalindex;
			int num2 = 0;
			int left = r.Left;
			int top = r.Top;
			if (r.Height > img.Height && r.Width <= img.Width / Totalindex)
			{
				Rectangle srcRect = new Rectangle(num, num2, img.Width / Totalindex, lr.Top);
				Rectangle destRect = new Rectangle(left, top, r.Width, lr.Top);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num, num2 + lr.Top, img.Width / Totalindex, img.Height - lr.Top - lr.Bottom);
				destRect = new Rectangle(left, top + lr.Top, r.Width, r.Height - lr.Top - lr.Bottom);
				if (lr.Top + lr.Bottom == 0)
				{
					srcRect.Height--;
				}
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num, num2 + img.Height - lr.Bottom, img.Width / Totalindex, lr.Bottom);
				destRect = new Rectangle(left, top + r.Height - lr.Bottom, r.Width, lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				return;
			}
			if (r.Height <= img.Height && r.Width > img.Width / Totalindex)
			{
				Rectangle srcRect = new Rectangle(num, num2, lr.Left, img.Height);
				Rectangle destRect = new Rectangle(left, top, lr.Left, r.Height);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + lr.Left, num2, img.Width / Totalindex - lr.Left - lr.Right, img.Height);
				destRect = new Rectangle(left + lr.Left, top, r.Width - lr.Left - lr.Right, r.Height);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + img.Width / Totalindex - lr.Right, num2, lr.Right, img.Height);
				destRect = new Rectangle(left + r.Width - lr.Right, top, lr.Right, r.Height);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				return;
			}
			if (r.Height <= img.Height && r.Width <= img.Width / Totalindex)
			{
				Rectangle srcRect = new Rectangle((index - 1) * img.Width / Totalindex, 0, img.Width / Totalindex, img.Height - 1);
				g.DrawImage(img, new Rectangle(left, top, r.Width, r.Height), srcRect, GraphicsUnit.Pixel);
				return;
			}
			if (r.Height > img.Height && r.Width > img.Width / Totalindex)
			{
				Rectangle srcRect = new Rectangle(num, num2, lr.Left, lr.Top);
				Rectangle destRect = new Rectangle(left, top, lr.Left, lr.Top);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num, num2 + img.Height - lr.Bottom, lr.Left, lr.Bottom);
				destRect = new Rectangle(left, top + r.Height - lr.Bottom, lr.Left, lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num, num2 + lr.Top, lr.Left, img.Height - lr.Top - lr.Bottom);
				destRect = new Rectangle(left, top + lr.Top, lr.Left, r.Height - lr.Top - lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + lr.Left, num2, img.Width / Totalindex - lr.Left - lr.Right, lr.Top);
				destRect = new Rectangle(left + lr.Left, top, r.Width - lr.Left - lr.Right, lr.Top);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + img.Width / Totalindex - lr.Right, num2, lr.Right, lr.Top);
				destRect = new Rectangle(left + r.Width - lr.Right, top, lr.Right, lr.Top);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + img.Width / Totalindex - lr.Right, num2 + lr.Top, lr.Right, img.Height - lr.Top - lr.Bottom);
				destRect = new Rectangle(left + r.Width - lr.Right, top + lr.Top, lr.Right, r.Height - lr.Top - lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + img.Width / Totalindex - lr.Right, num2 + img.Height - lr.Bottom, lr.Right, lr.Bottom);
				destRect = new Rectangle(left + r.Width - lr.Right, top + r.Height - lr.Bottom, lr.Right, lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + lr.Left, num2 + img.Height - lr.Bottom, img.Width / Totalindex - lr.Left - lr.Right, lr.Bottom);
				destRect = new Rectangle(left + lr.Left, top + r.Height - lr.Bottom, r.Width - lr.Left - lr.Right, lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
				srcRect = new Rectangle(num + lr.Left, num2 + lr.Top, img.Width / Totalindex - lr.Left - lr.Right, img.Height - lr.Top - lr.Bottom);
				destRect = new Rectangle(left + lr.Left, top + lr.Top, r.Width - lr.Left - lr.Right, r.Height - lr.Top - lr.Bottom);
				g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
			}
		}
		public static void DrawRect(Graphics g, Bitmap img, Rectangle r, int index, int Totalindex)
		{
			if (img == null)
			{
				return;
			}
			int num = img.Width / Totalindex;
			int height = img.Height;
			int x = (index - 1) * num;
			int y = 0;
			int left = r.Left;
			int top = r.Top;
			Rectangle srcRect = new Rectangle(x, y, num, height);
			Rectangle destRect = new Rectangle(left, top, r.Width, r.Height);
			g.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel);
		}
		public static Rectangle HAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
		{
			if ((align & ImageDrawRect.anyRight) != (ContentAlignment)0)
			{
				withinThis.X += withinThis.Width - alignThis.Width;
			}
			else
			{
				if ((align & ImageDrawRect.anyCenter) != (ContentAlignment)0)
				{
					withinThis.X += (withinThis.Width - alignThis.Width + 1) / 2;
				}
			}
			withinThis.Width = alignThis.Width;
			return withinThis;
		}
		public static Rectangle VAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
		{
			if ((align & ImageDrawRect.anyBottom) != (ContentAlignment)0)
			{
				withinThis.Y += withinThis.Height - alignThis.Height;
			}
			else
			{
				if ((align & ImageDrawRect.anyMiddle) != (ContentAlignment)0)
				{
					withinThis.Y += (withinThis.Height - alignThis.Height + 1) / 2;
				}
			}
			withinThis.Height = alignThis.Height;
			return withinThis;
		}
	}
}
