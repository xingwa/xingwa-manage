using xingwaWinFormUI.SkinClass;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinFormProfessionalRenderer : SkinFormRenderer
	{
		private SkinFormColorTable _colorTable;
		public SkinFormColorTable ColorTable
		{
			get
			{
				if (this._colorTable == null)
				{
					this._colorTable = new SkinFormColorTable();
				}
				return this._colorTable;
			}
		}
		public SkinFormProfessionalRenderer()
		{
		}
		public SkinFormProfessionalRenderer(SkinFormColorTable colortable)
		{
			this._colorTable = colortable;
		}
		public override Region CreateRegion(MainWinForm form)
		{
			Rectangle rect = new Rectangle(Point.Empty, form.Size);
			Region result;
			using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(rect, form.Radius, form.RoundStyle, false))
			{
				result = new Region(graphicsPath);
			}
			return result;
		}
		public override void InitSkinForm(MainWinForm form)
		{
			form.BackColor = this.ColorTable.Back;
		}
		protected override void OnRenderSkinFormCaption(SkinFormCaptionRenderEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clipRectangle = e.ClipRectangle;
			MainWinForm skinForm = e.SkinForm;
			Rectangle iconRect = skinForm.IconRect;
			Rectangle empty = Rectangle.Empty;
			bool controlBox = skinForm.ControlBox;
			bool flag = skinForm.ControlBox && skinForm.MinimizeBox;
			bool flag2 = skinForm.ControlBox && skinForm.MaximizeBox;
			bool flag3 = skinForm.ControlBox && skinForm.SysBottomVisibale;
			int num = 0;
			if (controlBox)
			{
				num += skinForm.CloseBoxSize.Width + skinForm.ControlBoxOffset.X;
			}
			if (flag2)
			{
				num += skinForm.MaxSize.Width + skinForm.ControlBoxSpace;
			}
			if (flag)
			{
				num += skinForm.MiniSize.Width + skinForm.ControlBoxSpace;
			}
			if (flag3)
			{
				num += skinForm.SysBottomSize.Width + skinForm.ControlBoxSpace;
			}
			empty = new Rectangle(iconRect.Right + 3, skinForm.BorderWidth, clipRectangle.Width - iconRect.Right - num - 6, clipRectangle.Height - skinForm.BorderWidth);
			using (new AntiAliasGraphics(graphics))
			{
				this.DrawCaptionBackground(graphics, clipRectangle, e.Active);
				if (skinForm.ShowDrawIcon && skinForm.Icon != null)
				{
					this.DrawIcon(graphics, iconRect, skinForm.Icon);
				}
				if (!string.IsNullOrEmpty(skinForm.Text))
				{
					this.DrawCaptionText(graphics, empty, skinForm.Text, skinForm.CaptionFont, skinForm.EffectCaption, skinForm.EffectBack, skinForm.EffectWidth, skinForm.ForeColor);
				}
			}
		}
		protected override void OnRenderSkinFormBorder(SkinFormBorderRenderEventArgs e)
		{
			Graphics graphics = e.Graphics;
			using (new AntiAliasGraphics(graphics))
			{
				this.DrawBorder(graphics, e.ClipRectangle, e.SkinForm.RoundStyle, e.SkinForm.Radius, e.SkinForm);
			}
		}
		protected override void OnRenderSkinFormControlBox(SkinFormControlBoxRenderEventArgs e)
		{
			MainWinForm form = e.Form;
			Graphics graphics = e.Graphics;
			Rectangle clipRectangle = e.ClipRectangle;
			ControlBoxState controlBoxtate = e.ControlBoxtate;
			bool active = e.Active;
			bool minimizeBox = form.ControlBox && form.MinimizeBox;
			bool maximizeBox = form.ControlBox && form.MaximizeBox;
			switch (e.ControlBoxStyle)
			{
			case ControlBoxStyle.Minimize:
				this.RenderSkinFormMinimizeBoxInternal(graphics, clipRectangle, controlBoxtate, active, form);
				return;
			case ControlBoxStyle.Maximize:
				this.RenderSkinFormMaximizeBoxInternal(graphics, clipRectangle, controlBoxtate, active, minimizeBox, form.WindowState == FormWindowState.Maximized, form);
				return;
			case ControlBoxStyle.Close:
				this.RenderSkinFormCloseBoxInternal(graphics, clipRectangle, controlBoxtate, active, minimizeBox, maximizeBox, form);
				return;
			case ControlBoxStyle.SysBottom:
				this.RenderSkinFormSysBottomInternal(graphics, clipRectangle, controlBoxtate, active, form);
				return;
			default:
				return;
			}
		}
		private void DrawCaptionBackground(Graphics g, Rectangle captionRect, bool active)
		{
			Color baseColor = active ? this.ColorTable.CaptionActive : this.ColorTable.CaptionDeactive;
			RenderHelper.RenderBackgroundInternal(g, captionRect, baseColor, this.ColorTable.Border, this.ColorTable.InnerBorder, RoundStyle.None, 0, 0.25f, false, false, LinearGradientMode.Vertical);
		}
		private void DrawIcon(Graphics g, Rectangle iconRect, Icon icon)
		{
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.DrawIcon(icon, iconRect);
		}
		private void DrawCaptionText(Graphics g, Rectangle textRect, string text, Font font, bool Effect, Color EffetBack, int EffectWidth, Color FrmColor)
		{
			if (Effect)
			{
				Size size = TextRenderer.MeasureText(text, font);
				Image image = UpdateForm.ImageLightEffect(text, font, FrmColor, EffetBack, EffectWidth, new Rectangle(0, 0, textRect.Width, size.Height), true);
				g.DrawImage(image, textRect.X - EffectWidth / 2, textRect.Y - EffectWidth / 2);
			}
		}
		private void DrawBorder(Graphics g, Rectangle rect, RoundStyle roundStyle, int radius, MainWinForm frm)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
			rect.Width--;
			rect.Height--;
			using (GraphicsPath graphicsPath = GraphicsPathHelper.CreatePath(rect, radius, roundStyle, false))
			{
				using (Pen pen = new Pen(this.ColorTable.Border))
				{
					g.DrawPath(pen, graphicsPath);
				}
			}
			rect.Inflate(-1, -1);
			using (GraphicsPath graphicsPath2 = GraphicsPathHelper.CreatePath(rect, radius, roundStyle, false))
			{
				using (Pen pen2 = new Pen(this.ColorTable.InnerBorder))
				{
					g.DrawPath(pen2, graphicsPath2);
				}
			}
		}
		public ImageAttributes Trank(Bitmap btm, int Alphas)
		{
			Bitmap image = (Bitmap)btm.Clone();
			Graphics.FromImage(image);
			float num = (float)Alphas / 100f;
			float[][] array = new float[5][];
			float[][] arg_3A_0 = array;
			int arg_3A_1 = 0;
			float[] array2 = new float[5];
			array2[0] = 1f;
			arg_3A_0[arg_3A_1] = array2;
			float[][] arg_51_0 = array;
			int arg_51_1 = 1;
			float[] array3 = new float[5];
			array3[1] = 1f;
			arg_51_0[arg_51_1] = array3;
			float[][] arg_68_0 = array;
			int arg_68_1 = 2;
			float[] array4 = new float[5];
			array4[2] = 1f;
			arg_68_0[arg_68_1] = array4;
			float[][] arg_7B_0 = array;
			int arg_7B_1 = 3;
			float[] array5 = new float[5];
			array5[3] = num;
			arg_7B_0[arg_7B_1] = array5;
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
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetColorMatrix(newColorMatrix2, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			return imageAttributes;
		}
		private void RenderSkinFormMinimizeBoxInternal(Graphics g, Rectangle rect, ControlBoxState state, bool active, MainWinForm form)
		{
			Color color = this.ColorTable.ControlBoxActive;
			Bitmap bitmap;
			if (state == ControlBoxState.Pressed)
			{
				bitmap = (Bitmap)form.MiniDownBack;
				color = this.ColorTable.ControlBoxPressed;
			}
			else
			{
				if (state == ControlBoxState.Hover)
				{
					bitmap = (Bitmap)form.MiniMouseBack;
					color = this.ColorTable.ControlBoxHover;
				}
				else
				{
					bitmap = (Bitmap)form.MiniNormlBack;
					color = (active ? this.ColorTable.ControlBoxActive : this.ColorTable.ControlBoxDeactive);
				}
			}
			if (bitmap != null)
			{
				g.DrawImage(bitmap, rect);
				return;
			}
			RoundStyle style = RoundStyle.BottomLeft;
			using (new AntiAliasGraphics(g))
			{
				RenderHelper.RenderBackgroundInternal(g, rect, color, color, this.ColorTable.ControlBoxInnerBorder, style, 6, 0.38f, true, false, LinearGradientMode.Vertical);
				using (Pen pen = new Pen(this.ColorTable.Border))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
				}
				using (GraphicsPath graphicsPath = this.CreateMinimizeFlagPath(rect))
				{
					g.FillPath(Brushes.White, graphicsPath);
					using (Pen pen2 = new Pen(color))
					{
						g.DrawPath(pen2, graphicsPath);
					}
				}
			}
		}
		private void RenderSkinFormSysBottomInternal(Graphics g, Rectangle rect, ControlBoxState state, bool active, MainWinForm form)
		{
			Color color = this.ColorTable.ControlBoxActive;
			Bitmap bitmap;
			if (state == ControlBoxState.Pressed)
			{
				bitmap = (Bitmap)form.SysBottomDown;
				color = this.ColorTable.ControlBoxPressed;
			}
			else
			{
				if (state == ControlBoxState.Hover)
				{
					bitmap = (Bitmap)form.SysBottomMouse;
					color = this.ColorTable.ControlBoxHover;
				}
				else
				{
					bitmap = (Bitmap)form.SysBottomNorml;
					color = (active ? this.ColorTable.ControlBoxActive : this.ColorTable.ControlBoxDeactive);
				}
			}
			if (bitmap != null)
			{
				g.DrawImage(bitmap, rect);
				return;
			}
			RoundStyle style = RoundStyle.BottomLeft;
			using (new AntiAliasGraphics(g))
			{
				RenderHelper.RenderBackgroundInternal(g, rect, color, color, this.ColorTable.ControlBoxInnerBorder, style, 6, 0.38f, true, false, LinearGradientMode.Vertical);
				using (Pen pen = new Pen(this.ColorTable.Border))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
				}
			}
		}
		private void RenderSkinFormMaximizeBoxInternal(Graphics g, Rectangle rect, ControlBoxState state, bool active, bool minimizeBox, bool maximize, MainWinForm form)
		{
			Color color = this.ColorTable.ControlBoxActive;
			Bitmap bitmap;
			if (state == ControlBoxState.Pressed)
			{
				bitmap = (maximize ? ((Bitmap)form.RestoreDownBack) : ((Bitmap)form.MaxDownBack));
				color = this.ColorTable.ControlBoxPressed;
			}
			else
			{
				if (state == ControlBoxState.Hover)
				{
					bitmap = (maximize ? ((Bitmap)form.RestoreMouseBack) : ((Bitmap)form.MaxMouseBack));
					color = this.ColorTable.ControlBoxHover;
				}
				else
				{
					bitmap = (maximize ? ((Bitmap)form.RestoreNormlBack) : ((Bitmap)form.MaxNormlBack));
					color = (active ? this.ColorTable.ControlBoxActive : this.ColorTable.ControlBoxDeactive);
				}
			}
			if (bitmap != null)
			{
				g.DrawImage(bitmap, rect);
				return;
			}
			RoundStyle style = minimizeBox ? RoundStyle.None : RoundStyle.BottomLeft;
			using (new AntiAliasGraphics(g))
			{
				RenderHelper.RenderBackgroundInternal(g, rect, color, color, this.ColorTable.ControlBoxInnerBorder, style, 6, 0.38f, true, false, LinearGradientMode.Vertical);
				using (Pen pen = new Pen(this.ColorTable.Border))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
				}
				using (GraphicsPath graphicsPath = this.CreateMaximizeFlafPath(rect, maximize))
				{
					g.FillPath(Brushes.White, graphicsPath);
					using (Pen pen2 = new Pen(color))
					{
						g.DrawPath(pen2, graphicsPath);
					}
				}
			}
		}
		private void RenderSkinFormCloseBoxInternal(Graphics g, Rectangle rect, ControlBoxState state, bool active, bool minimizeBox, bool maximizeBox, MainWinForm form)
		{
			Color color = this.ColorTable.ControlBoxActive;
			Bitmap bitmap;
			if (state == ControlBoxState.Pressed)
			{
				bitmap = (Bitmap)form.CloseDownBack;
				color = this.ColorTable.ControlCloseBoxPressed;
			}
			else
			{
				if (state == ControlBoxState.Hover)
				{
					bitmap = (Bitmap)form.CloseMouseBack;
					color = this.ColorTable.ControlCloseBoxHover;
				}
				else
				{
					bitmap = (Bitmap)form.CloseNormlBack;
					color = (active ? this.ColorTable.ControlBoxActive : this.ColorTable.ControlBoxDeactive);
				}
			}
			if (bitmap != null)
			{
				g.DrawImage(bitmap, rect);
				return;
			}
			RoundStyle style = (minimizeBox || maximizeBox) ? RoundStyle.BottomRight : RoundStyle.Bottom;
			using (new AntiAliasGraphics(g))
			{
				RenderHelper.RenderBackgroundInternal(g, rect, color, color, this.ColorTable.ControlBoxInnerBorder, style, 6, 0.38f, true, false, LinearGradientMode.Vertical);
				using (Pen pen = new Pen(this.ColorTable.Border))
				{
					g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
				}
				using (GraphicsPath graphicsPath = this.CreateCloseFlagPath(rect))
				{
					g.FillPath(Brushes.White, graphicsPath);
					using (Pen pen2 = new Pen(color))
					{
						g.DrawPath(pen2, graphicsPath);
					}
				}
			}
		}
		private GraphicsPath CreateCloseFlagPath(Rectangle rect)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(pointF.X, pointF.Y - 2f, pointF.X - 2f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y - 4f, pointF.X - 6f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X - 6f, pointF.Y - 4f, pointF.X - 2f, pointF.Y);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y, pointF.X - 6f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X - 6f, pointF.Y + 4f, pointF.X - 2f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X - 2f, pointF.Y + 4f, pointF.X, pointF.Y + 2f);
			graphicsPath.AddLine(pointF.X, pointF.Y + 2f, pointF.X + 2f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X + 2f, pointF.Y + 4f, pointF.X + 6f, pointF.Y + 4f);
			graphicsPath.AddLine(pointF.X + 6f, pointF.Y + 4f, pointF.X + 2f, pointF.Y);
			graphicsPath.AddLine(pointF.X + 2f, pointF.Y, pointF.X + 6f, pointF.Y - 4f);
			graphicsPath.AddLine(pointF.X + 6f, pointF.Y - 4f, pointF.X + 2f, pointF.Y - 4f);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		private GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(new RectangleF(pointF.X - 6f, pointF.Y + 1f, 12f, 3f));
			return graphicsPath;
		}
		private GraphicsPath CreateMaximizeFlafPath(Rectangle rect, bool maximize)
		{
			PointF pointF = new PointF((float)rect.X + (float)rect.Width / 2f, (float)rect.Y + (float)rect.Height / 2f);
			GraphicsPath graphicsPath = new GraphicsPath();
			if (maximize)
			{
				graphicsPath.AddLine(pointF.X - 3f, pointF.Y - 3f, pointF.X - 6f, pointF.Y - 3f);
				graphicsPath.AddLine(pointF.X - 6f, pointF.Y - 3f, pointF.X - 6f, pointF.Y + 5f);
				graphicsPath.AddLine(pointF.X - 6f, pointF.Y + 5f, pointF.X + 3f, pointF.Y + 5f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y + 5f, pointF.X + 3f, pointF.Y + 1f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y + 1f, pointF.X + 6f, pointF.Y + 1f);
				graphicsPath.AddLine(pointF.X + 6f, pointF.Y + 1f, pointF.X + 6f, pointF.Y - 6f);
				graphicsPath.AddLine(pointF.X + 6f, pointF.Y - 6f, pointF.X - 3f, pointF.Y - 6f);
				graphicsPath.CloseFigure();
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 4f, pointF.Y, 5f, 3f));
				graphicsPath.AddLine(pointF.X - 1f, pointF.Y - 4f, pointF.X + 4f, pointF.Y - 4f);
				graphicsPath.AddLine(pointF.X + 4f, pointF.Y - 4f, pointF.X + 4f, pointF.Y - 1f);
				graphicsPath.AddLine(pointF.X + 4f, pointF.Y - 1f, pointF.X + 3f, pointF.Y - 1f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y - 1f, pointF.X + 3f, pointF.Y - 3f);
				graphicsPath.AddLine(pointF.X + 3f, pointF.Y - 3f, pointF.X - 1f, pointF.Y - 3f);
				graphicsPath.CloseFigure();
			}
			else
			{
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 6f, pointF.Y - 4f, 12f, 8f));
				graphicsPath.AddRectangle(new RectangleF(pointF.X - 3f, pointF.Y - 1f, 6f, 3f));
			}
			return graphicsPath;
		}
	}
}
