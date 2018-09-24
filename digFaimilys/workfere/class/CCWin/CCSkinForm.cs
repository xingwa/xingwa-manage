using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using workfere.Properties;
using xingwaWinFormUI.Win32;

namespace xingwaWinFormUI
{
    public class CCSkinForm : Form
    {
        public class CommonClass
        {
            public static void SetTaskMenu(Form form)
            {
                int windowLong = NativeMethods.GetWindowLong(new HandleRef(form, form.Handle), -16);
                NativeMethods.SetWindowLong(new HandleRef(form, form.Handle), -16, windowLong | 524288 | 131072);
            }
        }

        private MainWinForm Main;
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

        public CCSkinForm(MainWinForm main)
        {
            this.Main = main;
            this.InitializeComponent();
            this.SetStyles();
            this.Init();
        }

        private void Init()
        {
            base.TopMost = this.Main.TopMost;
            this.Main.BringToFront();
            base.ShowInTaskbar = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(this.Main.Location.X - 5, this.Main.Location.Y - 5);
            base.Icon = this.Main.Icon;
            base.ShowIcon = this.Main.ShowIcon;
            base.Width = this.Main.Width + 10;
            base.Height = this.Main.Height + 10;
            this.Text = this.Main.Text;
            this.Main.LocationChanged += new EventHandler(this.Main_LocationChanged);
            this.Main.SizeChanged += new EventHandler(this.Main_SizeChanged);
            this.Main.VisibleChanged += new EventHandler(this.Main_VisibleChanged);
            this.SetBits();
            this.CanPenetrate();
        }

        private void SetStyles()
        {
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
            base.UpdateStyles();
        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {
            base.Location = new Point(this.Main.Left - 5, this.Main.Top - 5);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            base.Width = this.Main.Width + 10;
            base.Height = this.Main.Height + 10;
            this.SetBits();
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                base.Visible = this.Main.Visible;
            }
            catch
            {
            }
        }

        private void CanPenetrate()
        {
            NativeMethods.GetWindowLong(base.Handle, -20);
            NativeMethods.SetWindowLong(base.Handle, -20, 524320);
        }

        public void SetBits()
        {
            try
            {
                Bitmap bitmap = new Bitmap(this.Main.Width + 10, this.Main.Height + 10);
                Rectangle rectangle = new Rectangle(20, 20, 20, 20);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                ImageDrawRect.DrawRect(graphics, Resources.main_light_bkg_top123, base.ClientRectangle, Rectangle.FromLTRB(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), 1, 1);
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
            catch
            {
            }
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
            this.BackgroundImageLayout = ImageLayout.None;
            base.ClientSize = new Size(259, 271);
            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "SkinFormTwo";
            this.Text = "SkinForm";
            base.TopMost = true;
            base.ResumeLayout(false);
        }
    }
}