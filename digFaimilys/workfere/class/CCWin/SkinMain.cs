using xingwaWinFormUI.SkinClass;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace xingwaWinFormUI
{
	public class SkinMain : Form
	{
		private IContainer components;
		public SkinForm skin;
		private Image skinback;
		private Color _skintrankcolor = Color.Transparent;
		private bool _skinshowintaskbar = true;
		private bool _skinmobile = true;
		private bool show;
		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
		public new FormBorderStyle FormBorderStyle
		{
			get
			{
				return base.FormBorderStyle;
			}
			set
			{
				base.FormBorderStyle = FormBorderStyle.None;
			}
		}
		[Category("Skin"), Description("该窗体的背景图像")]
		public Image SkinBack
		{
			get
			{
				return this.skinback;
			}
			set
			{
				if (this.skinback != value)
				{
					this.skinback = value;
					if (value != null && this.show && !base.DesignMode)
					{
						UpdateForm.CreateControlRegion(this, this.TrankBack(), 255);
					}
					base.Invalidate();
					if (this.skin != null)
					{
						this.skin.BackgroundImage = this.TrankBack();
					}
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(Color), "Color.Transparent"), Description("背景需要透明的颜色")]
		public Color SkinTrankColor
		{
			get
			{
				return this._skintrankcolor;
			}
			set
			{
				if (this._skintrankcolor != value)
				{
					this._skintrankcolor = value;
					base.Invalidate();
					if (this.skin != null)
					{
						this.skin.BackgroundImage = this.TrankBack();
					}
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "true"), Description("绘图层是否出现在Windows任务栏中。")]
		public bool SkinShowInTaskbar
		{
			get
			{
				return this._skinshowintaskbar;
			}
			set
			{
				if (this._skinshowintaskbar != value)
				{
					this._skinshowintaskbar = value;
				}
			}
		}
		[Category("Skin"), DefaultValue(typeof(bool), "true"), Description("窗体是否可以移动")]
		public bool SkinMobile
		{
			get
			{
				return this._skinmobile;
			}
			set
			{
				if (this._skinmobile != value)
				{
					this._skinmobile = value;
				}
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
			this.BackColor = SystemColors.Control;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(284, 262);
			base.ControlBox = false;
			this.FormBorderStyle = FormBorderStyle.None;
			base.Name = "SkinMain";
			base.ShowInTaskbar = false;
			this.Text = "SkinMain";
			base.ResumeLayout(false);
		}
		public SkinMain()
		{
			this.InitializeComponent();
			this.SetStyles();
			this.Init();
		}
		private void Init()
		{
			base.ShowInTaskbar = false;
		}
		private void SetStyles()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
			base.AutoScaleMode = AutoScaleMode.None;
		}
		public Bitmap TrankBack()
		{
			Bitmap bitmap = new Bitmap(this.SkinBack);
			if (this.SkinTrankColor != Color.Transparent)
			{
				bitmap.MakeTransparent(this.SkinTrankColor);
			}
			return new Bitmap(bitmap, base.Size);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			if (this.SkinBack != null)
			{
				graphics.DrawImage(this.TrankBack(), 0, 0, base.Width, base.Height);
			}
			base.OnPaint(e);
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			base.Owner.Close();
			base.OnClosing(e);
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			if (!base.DesignMode)
			{
				if (this.skin != null)
				{
					this.skin.Visible = base.Visible;
				}
				else
				{
					UpdateForm.CreateControlRegion(this, this.TrankBack(), 255);
					this.show = true;
					this.skin = new SkinForm(this);
					this.skin.Show();
				}
			}
			base.OnVisibleChanged(e);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			if (this.SkinBack != null && this.show)
			{
				UpdateForm.CreateControlRegion(this, this.TrankBack(), 255);
				this.skin.Size = base.Size;
			}
			base.OnSizeChanged(e);
		}
	}
}
