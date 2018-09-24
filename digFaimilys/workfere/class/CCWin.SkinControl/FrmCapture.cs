using workfere.Properties;
using xingwaWinFormUI.Win32;
using xingwaWinFormUI.Win32.Struct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
    public class FrmCapture : Form
    {
        private RtfRichTextBox RcTxt;
        private bool isCaptureCursor;
        private MouseHook m_MHook;
        private List<Bitmap> m_layer;
        private bool m_isStartDraw;
        private Point m_ptOriginal;
        private Point m_ptCurrent;
        private Bitmap m_bmpLayerCurrent;
        private Bitmap m_bmpLayerShow;
        private IContainer components;
        private Panel panel1;
        private ToolButton tBtn_Ellipse;
        private ToolButton tBtn_Rect;
        private ToolButton tBtn_Arrow;
        private ToolButton tBtn_Brush;
        private ToolButton tBtn_Text;
        private ToolButton tBtn_Finish;
        private ToolButton tBtn_Close;
        private ToolButton tBtn_Save;
        private ToolButton tBtn_Cancel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ImageProcessBox imgpb;
        private Panel panel2;
        private ColorBox colorBox1;
        private ToolButton toolButton1;
        private ToolButton toolButton3;
        private ToolButton toolButton2;
        private TextBox textBox1;
        private Timer timer1;
        public bool IsCaptureCursor
        {
            get
            {
                return this.isCaptureCursor;
            }
            set
            {
                this.isCaptureCursor = value;
            }
        }
        public bool ImgProcessBoxIsShowInfo
        {
            get
            {
                return this.imgpb.IsShowInfo;
            }
            set
            {
                this.imgpb.IsShowInfo = value;
            }
        }
        public Color ImgProcessBoxDotColor
        {
            get
            {
                return this.imgpb.DotColor;
            }
            set
            {
                this.imgpb.DotColor = value;
            }
        }
        public Color ImgProcessBoxLineColor
        {
            get
            {
                return this.imgpb.LineColor;
            }
            set
            {
                this.imgpb.LineColor = value;
            }
        }
        public Size ImgProcessBoxMagnifySize
        {
            get
            {
                return this.imgpb.MagnifySize;
            }
            set
            {
                this.imgpb.MagnifySize = value;
            }
        }
        public int ImgProcessBoxMagnifyTimes
        {
            get
            {
                return this.imgpb.MagnifyTimes;
            }
            set
            {
                this.imgpb.MagnifyTimes = value;
            }
        }
        public FrmCapture()
        {
            this.InitializeComponent();
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            base.TopMost = true;
            base.ShowInTaskbar = false;
            this.m_MHook = new MouseHook();
            base.FormClosing += delegate(object s, FormClosingEventArgs e)
            {
                this.m_MHook.UnLoadHook();
                this.DelResource();
            };
            this.imgpb.MouseLeave += delegate(object s, EventArgs e)
            {
                this.Cursor = Cursors.Default;
            };
            this.m_layer = new List<Bitmap>();
        }
        public FrmCapture(RtfRichTextBox rcTxt)
        {
            this.InitializeComponent();
            this.RcTxt = rcTxt;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Location = new Point(0, 0);
            base.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            base.TopMost = true;
            base.ShowInTaskbar = false;
            this.m_MHook = new MouseHook();
            base.FormClosing += delegate(object s, FormClosingEventArgs e)
            {
                this.m_MHook.UnLoadHook();
                this.DelResource();
            };
            this.imgpb.MouseLeave += delegate(object s, EventArgs e)
            {
                this.Cursor = Cursors.Default;
            };
            this.m_layer = new List<Bitmap>();
        }
        private void DelResource()
        {
            if (this.m_bmpLayerCurrent != null)
            {
                this.m_bmpLayerCurrent.Dispose();
            }
            if (this.m_bmpLayerShow != null)
            {
                this.m_bmpLayerShow.Dispose();
            }
            this.m_layer.Clear();
            this.imgpb.DeleResource();
            GC.Collect();
        }
        private void InitMember()
        {
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel1.BackColor = Color.White;
            this.panel2.BackColor = Color.White;
            this.panel1.Height = this.tBtn_Finish.Bottom + 3;
            this.panel1.Width = this.tBtn_Finish.Right + 3;
            this.panel2.Height = this.colorBox1.Height;
            this.panel1.Paint += delegate(object s, PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, this.panel1.Width - 1, this.panel1.Height - 1);
            };
            this.panel2.Paint += delegate(object s, PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(Pens.SteelBlue, 0, 0, this.panel2.Width - 1, this.panel2.Height - 1);
            };
            this.tBtn_Rect.Click += new EventHandler(this.selectToolButton_Click);
            this.tBtn_Ellipse.Click += new EventHandler(this.selectToolButton_Click);
            this.tBtn_Arrow.Click += new EventHandler(this.selectToolButton_Click);
            this.tBtn_Brush.Click += new EventHandler(this.selectToolButton_Click);
            this.tBtn_Text.Click += new EventHandler(this.selectToolButton_Click);
            this.tBtn_Close.Click += delegate(object s, EventArgs e)
            {
                base.Close();
            };
            this.textBox1.BorderStyle = BorderStyle.None;
            this.textBox1.Visible = false;
            this.textBox1.ForeColor = Color.Red;
            this.colorBox1.ColorChanged += delegate(object s, ColorChangedEventArgs e)
            {
                this.textBox1.ForeColor = e.Color;
            };
        }
        private void FrmCapture_Load(object sender, EventArgs e)
        {
            this.InitMember();
            this.imgpb.BaseImage = this.GetScreen();
            this.m_MHook.SetHook();
            this.m_MHook.MHookEvent += new MouseHook.MHookEventHandler(this.m_MHook_MHookEvent);
            this.imgpb.IsDrawOperationDot = false;
            base.BeginInvoke(new MethodInvoker(delegate
            {
                base.Enabled = false;
            }));
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
        }
        private void m_MHook_MHookEvent(object sender, MHookEventArgs e)
        {
            if (!base.Enabled)
            {
                this.imgpb.SetInfoPoint(Control.MousePosition.X, Control.MousePosition.Y);
            }
            if (e.MButton == ButtonStatus.LeftDown || e.MButton == ButtonStatus.RightDown)
            {
                base.Enabled = true;
                this.imgpb.IsDrawOperationDot = true;
            }
            if (e.MButton == ButtonStatus.RightUp)
            {
                if (!this.imgpb.IsDrawed)
                {
                    base.BeginInvoke(new MethodInvoker(delegate
                    {
                        base.Close();
                    }));
                }
                base.Enabled = false;
                this.imgpb.ClearDraw();
                this.imgpb.CanReset = true;
                this.imgpb.IsDrawOperationDot = false;
                this.m_layer.Clear();
                this.m_bmpLayerCurrent = null;
                this.m_bmpLayerShow = null;
                this.ClearToolBarBtnSelected();
                this.panel1.Visible = false;
                this.panel2.Visible = false;
            }
            if (!base.Enabled)
            {
                this.FoundAndDrawWindowRect();
            }
        }
        private void selectToolButton_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = ((ToolButton)sender).IsSelected;
            if (this.panel2.Visible)
            {
                this.imgpb.CanReset = false;
            }
            else
            {
                this.imgpb.CanReset = (this.m_layer.Count == 0);
            }
            this.SetToolBarLocation();
        }
        private void imageProcessBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.imgpb.Cursor != Cursors.SizeAll && this.imgpb.Cursor != Cursors.Default)
            {
                this.panel1.Visible = false;
            }
            if (e.Button == MouseButtons.Left && this.imgpb.IsDrawed && this.HaveSelectedToolButton() && this.imgpb.SelectedRectangle.Contains(e.Location))
            {
                if (this.tBtn_Text.IsSelected)
                {
                    this.textBox1.Location = e.Location;
                    this.textBox1.Visible = true;
                    this.textBox1.Focus();
                    return;
                }
                this.m_isStartDraw = true;
                Cursor.Clip = this.imgpb.SelectedRectangle;
            }
            this.m_ptOriginal = e.Location;
        }
        private void imageProcessBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.m_ptCurrent = e.Location;
            if (this.imgpb.SelectedRectangle.Contains(e.Location) && this.HaveSelectedToolButton() && this.imgpb.IsDrawed)
            {
                this.Cursor = Cursors.Cross;
            }
            else
            {
                if (!this.imgpb.SelectedRectangle.Contains(e.Location))
                {
                    this.Cursor = Cursors.Default;
                }
            }
            if (this.imgpb.IsStartDraw && this.panel1.Visible)
            {
                this.SetToolBarLocation();
            }
            if (this.m_isStartDraw && this.m_bmpLayerShow != null)
            {
                using (Graphics graphics = Graphics.FromImage(this.m_bmpLayerShow))
                {
                    int num = 1;
                    if (this.toolButton2.IsSelected)
                    {
                        num = 3;
                    }
                    if (this.toolButton3.IsSelected)
                    {
                        num = 5;
                    }
                    Pen pen = new Pen(this.colorBox1.SelectedColor, (float)num);
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    if (this.tBtn_Rect.IsSelected)
                    {
                        int num2 = (e.X - this.m_ptOriginal.X > 0) ? this.m_ptOriginal.X : e.X;
                        int num3 = (e.Y - this.m_ptOriginal.Y > 0) ? this.m_ptOriginal.Y : e.Y;
                        graphics.Clear(Color.Transparent);
                        graphics.DrawRectangle(pen, num2 - this.imgpb.SelectedRectangle.Left, num3 - this.imgpb.SelectedRectangle.Top, Math.Abs(e.X - this.m_ptOriginal.X), Math.Abs(e.Y - this.m_ptOriginal.Y));
                        this.imgpb.Invalidate();
                    }
                    if (this.tBtn_Ellipse.IsSelected)
                    {
                        graphics.DrawLine(Pens.Red, 0, 0, 200, 200);
                        graphics.Clear(Color.Transparent);
                        graphics.DrawEllipse(pen, this.m_ptOriginal.X - this.imgpb.SelectedRectangle.Left, this.m_ptOriginal.Y - this.imgpb.SelectedRectangle.Top, e.X - this.m_ptOriginal.X, e.Y - this.m_ptOriginal.Y);
                        this.imgpb.Invalidate();
                    }
                    if (this.tBtn_Arrow.IsSelected)
                    {
                        graphics.Clear(Color.Transparent);
                        AdjustableArrowCap customEndCap = new AdjustableArrowCap(4f, 4f, true);
                        pen.CustomEndCap = customEndCap;
                        graphics.DrawLine(pen, (Point)((Size)this.m_ptOriginal - (Size)this.imgpb.SelectedRectangle.Location), (Point)((Size)this.m_ptCurrent - (Size)this.imgpb.SelectedRectangle.Location));
                        this.imgpb.Invalidate();
                    }
                    if (this.tBtn_Brush.IsSelected)
                    {
                        Point pt = (Point)((Size)this.m_ptOriginal - (Size)this.imgpb.SelectedRectangle.Location);
                        pen.LineJoin = LineJoin.Round;
                        graphics.DrawLine(pen, pt, (Point)((Size)e.Location - (Size)this.imgpb.SelectedRectangle.Location));
                        this.m_ptOriginal = e.Location;
                        this.imgpb.Invalidate();
                    }
                    pen.Dispose();
                }
            }
        }
        private void imageProcessBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.imgpb.IsDrawed)
            {
                base.Enabled = false;
                this.imgpb.IsDrawOperationDot = false;
            }
            else
            {
                if (!this.panel1.Visible)
                {
                    this.SetToolBarLocation();
                    this.panel1.Visible = true;
                    this.m_bmpLayerCurrent = this.imgpb.GetResultBmp();
                    this.m_bmpLayerShow = new Bitmap(this.m_bmpLayerCurrent.Width, this.m_bmpLayerCurrent.Height);
                }
            }
            if (this.imgpb.Cursor == Cursors.SizeAll && this.m_ptOriginal != e.Location)
            {
                this.m_bmpLayerCurrent = this.imgpb.GetResultBmp();
            }
            if (!this.m_isStartDraw)
            {
                return;
            }
            Cursor.Clip = Rectangle.Empty;
            this.m_isStartDraw = false;
            if (e.Location == this.m_ptOriginal && !this.tBtn_Brush.IsSelected)
            {
                return;
            }
            this.SetLayer();
        }
        private void imageProcessBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.m_layer.Count > 0)
            {
                graphics.DrawImage(this.m_layer[this.m_layer.Count - 1], this.imgpb.SelectedRectangle.Location);
            }
            if (this.m_bmpLayerShow != null)
            {
                graphics.DrawImage(this.m_bmpLayerShow, this.imgpb.SelectedRectangle.Location);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.textBox1.Text, this.textBox1.Font);
            this.textBox1.Size = (size.IsEmpty ? new Size(50, this.textBox1.Font.Height) : size);
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            this.textBox1.Visible = false;
            if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                this.textBox1.Text = "";
                return;
            }
            using (Graphics graphics = Graphics.FromImage(this.m_bmpLayerCurrent))
            {
                SolidBrush solidBrush = new SolidBrush(this.colorBox1.SelectedColor);
                graphics.DrawString(this.textBox1.Text, this.textBox1.Font, solidBrush, (float)(this.textBox1.Left - this.imgpb.SelectedRectangle.Left), (float)(this.textBox1.Top - this.imgpb.SelectedRectangle.Top));
                solidBrush.Dispose();
                this.textBox1.Text = "";
                this.SetLayer();
                this.imgpb.Invalidate();
            }
        }
        private void textBox1_Resize(object sender, EventArgs e)
        {
            int num = 10;
            if (this.toolButton2.IsSelected)
            {
                num = 12;
            }
            if (this.toolButton3.IsSelected)
            {
                num = 14;
            }
            if (this.textBox1.Font.Height == num)
            {
                return;
            }
            this.textBox1.Font = new Font(this.Font.FontFamily, (float)num);
        }
        private void tBtn_Cancel_Click(object sender, EventArgs e)
        {
            using (Graphics graphics = Graphics.FromImage(this.m_bmpLayerShow))
            {
                graphics.Clear(Color.Transparent);
            }
            if (this.m_layer.Count > 0)
            {
                this.m_layer.RemoveAt(this.m_layer.Count - 1);
                if (this.m_layer.Count > 0)
                {
                    this.m_bmpLayerCurrent = this.m_layer[this.m_layer.Count - 1].Clone(new Rectangle(0, 0, this.m_bmpLayerCurrent.Width, this.m_bmpLayerCurrent.Height), this.m_bmpLayerCurrent.PixelFormat);
                }
                else
                {
                    this.m_bmpLayerCurrent = this.imgpb.GetResultBmp();
                }
                this.imgpb.Invalidate();
                this.imgpb.CanReset = (this.m_layer.Count == 0 && !this.HaveSelectedToolButton());
                return;
            }
            base.Enabled = false;
            this.imgpb.ClearDraw();
            this.imgpb.IsDrawOperationDot = false;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
        }
        private void tBtn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "位图(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = "CAPTURE_" + this.GetTimeString();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        this.m_bmpLayerCurrent.Clone(new Rectangle(0, 0, this.m_bmpLayerCurrent.Width, this.m_bmpLayerCurrent.Height), PixelFormat.Format24bppRgb).Save(saveFileDialog.FileName, ImageFormat.Bmp);
                        base.Close();
                        return;
                    case 2:
                        this.m_bmpLayerCurrent.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        base.Close();
                        break;
                    default:
                        return;
                }
            }
        }
        private void tBtn_Finish_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.m_bmpLayerCurrent);
            if (this.RcTxt != null)
            {
                this.RcTxt.Paste();
            }
            base.Close();
        }
        private void imageProcessBox1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.m_bmpLayerCurrent);
            if (this.RcTxt != null)
            {
                this.RcTxt.Paste();
            }
            base.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!base.Enabled)
            {
                this.imgpb.SetInfoPoint(Control.MousePosition.X, Control.MousePosition.Y);
            }
        }
        private void FoundAndDrawWindowRect()
        {
            NativeMethods.Point pt = default(NativeMethods.Point);
            pt.x = Control.MousePosition.X;
            pt.y = Control.MousePosition.Y;
            IntPtr intPtr = NativeMethods.ChildWindowFromPointEx(NativeMethods.GetDesktopWindow(), pt, 3u);
            if (intPtr != IntPtr.Zero)
            {
                IntPtr intPtr2 = intPtr;
                while (true)
                {
                    NativeMethods.ScreenToClient(intPtr2, ref pt);
                    intPtr2 = NativeMethods.ChildWindowFromPointEx(intPtr2, pt, 0u);
                    if (intPtr2 == IntPtr.Zero || intPtr2 == intPtr)
                    {
                        break;
                    }
                    intPtr = intPtr2;
                    pt.x = Control.MousePosition.X;
                    pt.y = Control.MousePosition.Y;
                }
                RECT rECT = default(RECT);
                NativeMethods.GetWindowRect(intPtr, ref rECT);
                this.imgpb.SetSelectRect(new Rectangle(rECT.Left, rECT.Top, rECT.Right - rECT.Left, rECT.Bottom - rECT.Top));
            }
        }
        private Bitmap GetScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            if (this.isCaptureCursor)
            {
                using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                {
                    NativeMethods.PCURSORINFO pCURSORINFO;
                    pCURSORINFO.cbSize = Marshal.SizeOf(typeof(NativeMethods.PCURSORINFO));
                    NativeMethods.GetCursorInfo(out pCURSORINFO);
                    if (pCURSORINFO.hCursor != IntPtr.Zero)
                    {
                        Cursor cursor = new Cursor(pCURSORINFO.hCursor);
                        graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                        cursor.Draw(graphics, new Rectangle((Point)((Size)Control.MousePosition - (Size)cursor.HotSpot), cursor.Size));
                    }
                }
            }
            using (Graphics graphics2 = Graphics.FromImage(bitmap))
            {
                graphics2.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            }
            return bitmap;
        }
        private void SetToolBarLocation()
        {
            int num = this.imgpb.SelectedRectangle.Left;
            int num2 = this.imgpb.SelectedRectangle.Bottom + 5;
            int num3 = this.panel2.Visible ? (this.panel2.Height + 2) : 0;
            if (num2 + this.panel1.Height + num3 >= base.Height)
            {
                num2 = this.imgpb.SelectedRectangle.Top - this.panel1.Height - 10 - this.imgpb.Font.Height;
            }
            if (num2 - num3 <= 0)
            {
                if (this.imgpb.SelectedRectangle.Top - 5 - this.imgpb.Font.Height >= 0)
                {
                    num2 = this.imgpb.SelectedRectangle.Top + 5;
                }
                else
                {
                    num2 = this.imgpb.SelectedRectangle.Top + 10 + this.imgpb.Font.Height;
                }
            }
            if (num + this.panel1.Width >= base.Width)
            {
                num = base.Width - this.panel1.Width - 5;
            }
            this.panel1.Left = num;
            this.panel2.Left = num;
            this.panel1.Top = num2;
            this.panel2.Top = ((this.imgpb.SelectedRectangle.Top > num2) ? (num2 - num3) : (this.panel1.Bottom + 2));
        }
        private bool HaveSelectedToolButton()
        {
            return this.tBtn_Rect.IsSelected || this.tBtn_Ellipse.IsSelected || this.tBtn_Arrow.IsSelected || this.tBtn_Brush.IsSelected || this.tBtn_Text.IsSelected;
        }
        private void ClearToolBarBtnSelected()
        {
            this.tBtn_Rect.IsSelected = (this.tBtn_Ellipse.IsSelected = (this.tBtn_Arrow.IsSelected = (this.tBtn_Brush.IsSelected = (this.tBtn_Text.IsSelected = false))));
        }
        private void SetLayer()
        {
            if (base.IsDisposed)
            {
                return;
            }
            using (Graphics graphics = Graphics.FromImage(this.m_bmpLayerCurrent))
            {
                graphics.DrawImage(this.m_bmpLayerShow, 0, 0);
            }
            Bitmap item = this.m_bmpLayerCurrent.Clone(new Rectangle(0, 0, this.m_bmpLayerCurrent.Width, this.m_bmpLayerCurrent.Height), this.m_bmpLayerCurrent.PixelFormat);
            this.m_layer.Add(item);
        }
        private string GetTimeString()
        {
            DateTime now = DateTime.Now;
            return now.Date.ToShortDateString().Replace("/", "") + "_" + now.ToLongTimeString().Replace(":", "");
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
            this.components = new Container();
            this.panel1 = new Panel();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.panel2 = new Panel();
            this.textBox1 = new TextBox();
            this.timer1 = new Timer(this.components);
            this.toolButton1 = new ToolButton();
            this.toolButton3 = new ToolButton();
            this.toolButton2 = new ToolButton();
            this.colorBox1 = new ColorBox();
            this.tBtn_Finish = new ToolButton();
            this.tBtn_Close = new ToolButton();
            this.tBtn_Save = new ToolButton();
            this.tBtn_Cancel = new ToolButton();
            this.tBtn_Text = new ToolButton();
            this.tBtn_Brush = new ToolButton();
            this.tBtn_Arrow = new ToolButton();
            this.tBtn_Ellipse = new ToolButton();
            this.tBtn_Rect = new ToolButton();
            this.imgpb = new ImageProcessBox();
            this.panel1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox2).BeginInit();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.tBtn_Finish);
            this.panel1.Controls.Add(this.tBtn_Close);
            this.panel1.Controls.Add(this.tBtn_Save);
            this.panel1.Controls.Add(this.tBtn_Cancel);
            this.panel1.Controls.Add(this.tBtn_Text);
            this.panel1.Controls.Add(this.tBtn_Brush);
            this.panel1.Controls.Add(this.tBtn_Arrow);
            this.panel1.Controls.Add(this.tBtn_Ellipse);
            this.panel1.Controls.Add(this.tBtn_Rect);
            this.panel1.Location = new Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(294, 25);
            this.panel1.TabIndex = 1;
            this.pictureBox2.Image = Resources.separator;
            this.pictureBox2.Location = new Point(199, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(1, 17);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox1.Image = Resources.separator;
            this.pictureBox1.Location = new Point(138, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(1, 17);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.panel2.Controls.Add(this.toolButton1);
            this.panel2.Controls.Add(this.toolButton3);
            this.panel2.Controls.Add(this.toolButton2);
            this.panel2.Controls.Add(this.colorBox1);
            this.panel2.Location = new Point(12, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(250, 32);
            this.panel2.TabIndex = 2;
            this.textBox1.Location = new Point(12, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 19);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
            this.textBox1.Resize += new EventHandler(this.textBox1_Resize);
            this.textBox1.Validating += new CancelEventHandler(this.textBox1_Validating);
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.toolButton1.BtnImage = Resources.small;
            this.toolButton1.IsSelected = true;
            this.toolButton1.IsSelectedBtn = true;
            this.toolButton1.IsSingleSelectedBtn = true;
            this.toolButton1.Location = new Point(3, 6);
            this.toolButton1.Name = "toolButton1";
            this.toolButton1.Size = new Size(21, 21);
            this.toolButton1.TabIndex = 4;
            this.toolButton3.BtnImage = Resources.large;
            this.toolButton3.IsSelected = false;
            this.toolButton3.IsSelectedBtn = true;
            this.toolButton3.IsSingleSelectedBtn = true;
            this.toolButton3.Location = new Point(57, 6);
            this.toolButton3.Name = "toolButton3";
            this.toolButton3.Size = new Size(21, 21);
            this.toolButton3.TabIndex = 3;
            this.toolButton2.BtnImage = Resources.middle;
            this.toolButton2.IsSelected = false;
            this.toolButton2.IsSelectedBtn = true;
            this.toolButton2.IsSingleSelectedBtn = true;
            this.toolButton2.Location = new Point(30, 6);
            this.toolButton2.Name = "toolButton2";
            this.toolButton2.Size = new Size(21, 21);
            this.toolButton2.TabIndex = 2;
            this.colorBox1.Location = new Point(85, 0);
            this.colorBox1.Name = "colorBox1";
            this.colorBox1.Size = new Size(165, 35);
            this.colorBox1.TabIndex = 0;
            this.colorBox1.Text = "colorBox1";
            this.tBtn_Finish.BtnImage = Resources.ok;
            this.tBtn_Finish.IsSelected = false;
            this.tBtn_Finish.IsSelectedBtn = false;
            this.tBtn_Finish.IsSingleSelectedBtn = false;
            this.tBtn_Finish.Location = new Point(233, 3);
            this.tBtn_Finish.Name = "tBtn_Finish";
            this.tBtn_Finish.Size = new Size(68, 21);
            this.tBtn_Finish.TabIndex = 8;
            this.tBtn_Finish.Text = "Finish ";
            this.tBtn_Finish.Click += new EventHandler(this.tBtn_Finish_Click);
            this.tBtn_Close.BtnImage = Resources.close;
            this.tBtn_Close.IsSelected = false;
            this.tBtn_Close.IsSelectedBtn = false;
            this.tBtn_Close.IsSingleSelectedBtn = false;
            this.tBtn_Close.Location = new Point(206, 3);
            this.tBtn_Close.Name = "tBtn_Close";
            this.tBtn_Close.Size = new Size(21, 21);
            this.tBtn_Close.TabIndex = 7;
            this.tBtn_Save.BtnImage = Resources.save;
            this.tBtn_Save.IsSelected = false;
            this.tBtn_Save.IsSelectedBtn = false;
            this.tBtn_Save.IsSingleSelectedBtn = false;
            this.tBtn_Save.Location = new Point(172, 3);
            this.tBtn_Save.Name = "tBtn_Save";
            this.tBtn_Save.Size = new Size(21, 21);
            this.tBtn_Save.TabIndex = 6;
            this.tBtn_Save.Click += new EventHandler(this.tBtn_Save_Click);
            this.tBtn_Cancel.BtnImage = Resources.cancel;
            this.tBtn_Cancel.IsSelected = false;
            this.tBtn_Cancel.IsSelectedBtn = false;
            this.tBtn_Cancel.IsSingleSelectedBtn = false;
            this.tBtn_Cancel.Location = new Point(145, 3);
            this.tBtn_Cancel.Name = "tBtn_Cancel";
            this.tBtn_Cancel.Size = new Size(21, 21);
            this.tBtn_Cancel.TabIndex = 5;
            this.tBtn_Cancel.Click += new EventHandler(this.tBtn_Cancel_Click);
            this.tBtn_Text.BtnImage = Resources.text;
            this.tBtn_Text.IsSelected = false;
            this.tBtn_Text.IsSelectedBtn = true;
            this.tBtn_Text.IsSingleSelectedBtn = false;
            this.tBtn_Text.Location = new Point(111, 3);
            this.tBtn_Text.Name = "tBtn_Text";
            this.tBtn_Text.Size = new Size(21, 21);
            this.tBtn_Text.TabIndex = 4;
            this.tBtn_Brush.BtnImage = Resources.brush;
            this.tBtn_Brush.IsSelected = false;
            this.tBtn_Brush.IsSelectedBtn = true;
            this.tBtn_Brush.IsSingleSelectedBtn = false;
            this.tBtn_Brush.Location = new Point(84, 3);
            this.tBtn_Brush.Name = "tBtn_Brush";
            this.tBtn_Brush.Size = new Size(21, 21);
            this.tBtn_Brush.TabIndex = 3;
            this.tBtn_Arrow.BtnImage = Resources.arrow;
            this.tBtn_Arrow.IsSelected = false;
            this.tBtn_Arrow.IsSelectedBtn = true;
            this.tBtn_Arrow.IsSingleSelectedBtn = false;
            this.tBtn_Arrow.Location = new Point(57, 3);
            this.tBtn_Arrow.Name = "tBtn_Arrow";
            this.tBtn_Arrow.Size = new Size(21, 21);
            this.tBtn_Arrow.TabIndex = 2;
            this.tBtn_Ellipse.BtnImage = Resources.ellips;
            this.tBtn_Ellipse.IsSelected = false;
            this.tBtn_Ellipse.IsSelectedBtn = true;
            this.tBtn_Ellipse.IsSingleSelectedBtn = false;
            this.tBtn_Ellipse.Location = new Point(30, 3);
            this.tBtn_Ellipse.Name = "tBtn_Ellipse";
            this.tBtn_Ellipse.Size = new Size(21, 21);
            this.tBtn_Ellipse.TabIndex = 1;
            this.tBtn_Rect.BtnImage = Resources.rect;
            this.tBtn_Rect.IsSelected = false;
            this.tBtn_Rect.IsSelectedBtn = true;
            this.tBtn_Rect.IsSingleSelectedBtn = false;
            this.tBtn_Rect.Location = new Point(3, 3);
            this.tBtn_Rect.Name = "tBtn_Rect";
            this.tBtn_Rect.Size = new Size(21, 21);
            this.tBtn_Rect.TabIndex = 0;
            this.imgpb.BackColor = Color.Black;
            this.imgpb.BaseImage = null;
            this.imgpb.CanReset = true;
            this.imgpb.Cursor = Cursors.Default;
            this.imgpb.Dock = DockStyle.Fill;
            this.imgpb.ForeColor = Color.White;
            this.imgpb.Location = new Point(0, 0);
            this.imgpb.Name = "imgpb";
            this.imgpb.Size = new Size(363, 247);
            this.imgpb.TabIndex = 0;
            this.imgpb.Text = "imageProcessBox1";
            this.imgpb.Paint += new PaintEventHandler(this.imageProcessBox1_Paint);
            this.imgpb.DoubleClick += new EventHandler(this.imageProcessBox1_DoubleClick);
            this.imgpb.MouseDown += new MouseEventHandler(this.imageProcessBox1_MouseDown);
            this.imgpb.MouseMove += new MouseEventHandler(this.imageProcessBox1_MouseMove);
            this.imgpb.MouseUp += new MouseEventHandler(this.imageProcessBox1_MouseUp);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(363, 247);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.imgpb);
            this.Cursor = Cursors.Default;
            base.Name = "FrmCapture";
            this.Text = "FrmCapture";
            base.Load += new EventHandler(this.FrmCapture_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((ISupportInitialize)this.pictureBox2).EndInit();
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}