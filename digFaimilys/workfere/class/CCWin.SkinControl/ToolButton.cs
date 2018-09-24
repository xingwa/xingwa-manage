using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using workfere.Properties;

namespace xingwaWinFormUI.SkinControl
{
    internal class ToolButton : Control
    {
        private IContainer components;
        private Image btnImage;
        private bool isSelectedBtn;
        private bool isSingleSelectedBtn;
        private bool isSelected;
        private bool m_bMouseEnter;

        public Image BtnImage
        {
            get
            {
                return this.btnImage;
            }
            set
            {
                this.btnImage = value;
                base.Invalidate();
            }
        }

        public bool IsSelectedBtn
        {
            get
            {
                return this.isSelectedBtn;
            }
            set
            {
                this.isSelectedBtn = value;
                if (!this.isSelectedBtn)
                {
                    this.isSingleSelectedBtn = false;
                }
            }
        }

        public bool IsSingleSelectedBtn
        {
            get
            {
                return this.isSingleSelectedBtn;
            }
            set
            {
                this.isSingleSelectedBtn = value;
                if (this.isSingleSelectedBtn)
                {
                    this.isSelectedBtn = true;
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                if (value == this.isSelected)
                {
                    return;
                }
                this.isSelected = value;
                base.Invalidate();
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                base.Width = TextRenderer.MeasureText(this.Text, this.Font).Width + 21;
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
            this.components = new Container();
        }

        public ToolButton()
        {
            this.InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.m_bMouseEnter = true;
            base.Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.m_bMouseEnter = false;
            base.Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.isSelectedBtn)
            {
                if (this.isSelected)
                {
                    if (!this.isSingleSelectedBtn)
                    {
                        this.isSelected = false;
                        base.Invalidate();
                    }
                }
                else
                {
                    this.isSelected = true;
                    base.Invalidate();
                    int i = 0;
                    int count = base.Parent.Controls.Count;
                    while (i < count)
                    {
                        if (base.Parent.Controls[i] is ToolButton && base.Parent.Controls[i] != this && ((ToolButton)base.Parent.Controls[i]).isSelected)
                        {
                            ((ToolButton)base.Parent.Controls[i]).IsSelected = false;
                        }
                        i++;
                    }
                }
            }
            base.Focus();
            base.OnClick(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            this.OnClick(e);
            base.OnDoubleClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (this.m_bMouseEnter)
            {
                graphics.FillRectangle(Brushes.LightBlue, base.ClientRectangle);
                graphics.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            }
            if (this.btnImage == null)
            {
                graphics.DrawImage(Resources.none, new Rectangle(2, 2, 17, 17));
            }
            else
            {
                graphics.DrawImage(this.btnImage, new Rectangle(2, 2, 17, 17));
            }
            graphics.DrawString(this.Text, this.Font, Brushes.Black, 21f, (float)((base.Height - this.Font.Height) / 2));
            if (this.isSelected)
            {
                graphics.DrawRectangle(Pens.DarkCyan, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
            }
            base.OnPaint(e);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, TextRenderer.MeasureText(this.Text, this.Font).Width + 21, 21, specified);
        }
    }
}