using xingwaWinFormUI.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinForm : Form
	{
		private SkinMain Main;
		private Point mouseOffset;
		private bool isMouseDown;
		private IContainer components;
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= 524288;
				return createParams;
			}
		}
		public SkinForm(SkinMain main)
		{
			this.InitializeComponent();
			this.Main = main;
			this.SetStyles();
			this.Init();
		}
		private void Init()
		{
			base.TopMost = this.Main.TopMost;
			base.ShowInTaskbar = this.Main.SkinShowInTaskbar;
			base.FormBorderStyle = FormBorderStyle.None;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.Location = this.Main.Location;
			base.Icon = this.Main.Icon;
			base.ShowIcon = this.Main.ShowIcon;
			base.Size = this.Main.Size;
			this.Text = this.Main.Text;
			Bitmap bitmap = new Bitmap(this.Main.SkinBack, base.Size);
			if (this.Main.SkinTrankColor != Color.Transparent)
			{
				bitmap.MakeTransparent(this.Main.SkinTrankColor);
			}
			this.BackgroundImage = bitmap;
			this.Main.Owner = this;
			base.MouseDown += new MouseEventHandler(this.Frm_MouseDown);
			base.MouseMove += new MouseEventHandler(this.Frm_MouseMove);
			base.MouseUp += new MouseEventHandler(this.Frm_MouseUp);
			base.LocationChanged += new EventHandler(this.Frm_LocationChanged);
			this.Main.MouseDown += new MouseEventHandler(this.Frm_MouseDown);
			this.Main.MouseMove += new MouseEventHandler(this.Frm_MouseMove);
			this.Main.MouseUp += new MouseEventHandler(this.Frm_MouseUp);
			this.Main.LocationChanged += new EventHandler(this.Frm_LocationChanged);
		}
		private void Frm_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.Main.SkinMobile && e.Button == MouseButtons.Left)
			{
				this.mouseOffset = new Point(-e.X, -e.Y);
				this.isMouseDown = true;
			}
		}
		private void Frm_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.Main.SkinMobile)
			{
				Form form = (Form)sender;
				if (this.isMouseDown)
				{
					Point mousePosition = Control.MousePosition;
					mousePosition.Offset(this.mouseOffset.X, this.mouseOffset.Y);
					form.Location = mousePosition;
				}
			}
		}
		private void Frm_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.Main.SkinMobile && e.Button == MouseButtons.Left)
			{
				this.isMouseDown = false;
				if (base.Top < 0)
				{
					base.Top = (this.Main.Top = 0);
				}
			}
		}
		private void Frm_LocationChanged(object sender, EventArgs e)
		{
			Form form = (Form)sender;
			if (form == this)
			{
				this.Main.Location = form.Location;
				return;
			}
			base.Location = form.Location;
		}
		private void SetStyles()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
			base.AutoScaleMode = AutoScaleMode.None;
		}
		public void SetBits()
		{
			if (this.BackgroundImage != null)
			{
				Bitmap bitmap = new Bitmap(this.BackgroundImage, base.Width, base.Height);
				if (!Image.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Image.IsAlphaPixelFormat(bitmap.PixelFormat))
				{
					throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");
				}
				IntPtr hgdiobj = IntPtr.Zero;
				IntPtr dC = NativeMethods.GetDC(IntPtr.Zero);
				IntPtr intPtr = IntPtr.Zero;
				IntPtr intPtr2 = NativeMethods.CreateCompatibleDC(dC);
				try
				{
					NativeMethods.Point point = new NativeMethods.Point(base.Left, base.Top);
					NativeMethods.Size size = new NativeMethods.Size(base.Width, base.Height);
					NativeMethods.BLENDFUNCTION bLENDFUNCTION = default(NativeMethods.BLENDFUNCTION);
					NativeMethods.Point point2 = new NativeMethods.Point(0, 0);
					intPtr = bitmap.GetHbitmap(Color.FromArgb(0));
					hgdiobj = NativeMethods.SelectObject(intPtr2, intPtr);
					bLENDFUNCTION.BlendOp = 0;
					bLENDFUNCTION.SourceConstantAlpha = byte.Parse("255");
					bLENDFUNCTION.AlphaFormat = 1;
					bLENDFUNCTION.BlendFlags = 0;
					NativeMethods.UpdateLayeredWindow(base.Handle, dC, ref point, ref size, intPtr2, ref point2, 0, ref bLENDFUNCTION, 2);
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						NativeMethods.SelectObject(intPtr2, hgdiobj);
						NativeMethods.DeleteObject(intPtr);
					}
					NativeMethods.ReleaseDC(IntPtr.Zero, dC);
					NativeMethods.DeleteDC(intPtr2);
				}
			}
		}
		protected override void OnBackgroundImageChanged(EventArgs e)
		{
			base.OnBackgroundImageChanged(e);
			this.SetBits();
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.SetBits();
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
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(259, 271);
			base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "SkinForm";
			this.Text = "SkinForm";
			base.ResumeLayout(false);
		}
	}
}
