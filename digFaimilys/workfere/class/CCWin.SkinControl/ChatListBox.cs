using workfere.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
    [ToolboxBitmap(typeof(ListBox))]
    public class ChatListBox : Control
    {
        public delegate void ChatListEventHandler(object sender, ChatListEventArgs e);
        public delegate void DragListEventHandler(object sender, DragListEventArgs e);
        private ContextMenuStrip subItemMenu;
        private ContextMenuStrip listsubItemMenu;
        private ChatListItemIcon iconSizeMode;
        private ChatListItemCollection items;
        private ChatListSubItem selectSubItem;
        private Color arrowColor = Color.FromArgb(101, 103, 103);
        private Color itemColor = Color.Transparent;
        private Color subItemColor = Color.Transparent;
        private Color itemMouseOnColor = Color.FromArgb(150, 230, 238, 241);
        private Color subItemMouseOnColor = Color.FromArgb(200, 252, 240, 193);
        private Color subItemSelectColor = Color.FromArgb(200, 252, 236, 172);
        private Point m_ptMousePos;
        public ChatListVScroll chatVScroll;
        private ChatListItem m_mouseOnItem;
        private bool m_bOnMouseEnterHeaded;
        private ChatListSubItem m_mouseOnSubItem;
        private bool MouseDowns;
        private ChatListSubItem MouseDowmSubItems;
        private int CursorY;
        private bool MouseMoveItems;
        private IContainer components;
        [Category("子项操作"), Description("用鼠标双击子项时发生")]
        public event ChatListBox.ChatListEventHandler DoubleClickSubItem;
        [Category("子项操作"), Description("在鼠标进入子项中的头像时发生")]
        public event ChatListBox.ChatListEventHandler MouseEnterHead;
        [Category("子项操作"), Description("在鼠标离开子项中的头像时发生")]
        public event ChatListBox.ChatListEventHandler MouseLeaveHead;
        [Category("子项操作"), Description("拖动子项操作完成后发生")]
        public event ChatListBox.DragListEventHandler DragSubItemDrop;
        [Category("行为"), Description("当用户右击分组时显示的快捷菜单。")]
        public ContextMenuStrip SubItemMenu
        {
            get
            {
                return this.subItemMenu;
            }
            set
            {
                if (this.subItemMenu != value)
                {
                    this.subItemMenu = value;
                }
            }
        }
        [Category("行为"), Description("当用户右击好友时显示的快捷菜单。")]
        public ContextMenuStrip ListSubItemMenu
        {
            get
            {
                return this.listsubItemMenu;
            }
            set
            {
                if (this.listsubItemMenu != value)
                {
                    this.listsubItemMenu = value;
                }
            }
        }
        [Category("Appearance"), DefaultValue(ChatListItemIcon.Large), Description("与列表关联的图标模式")]
        public ChatListItemIcon IconSizeMode
        {
            get
            {
                return this.iconSizeMode;
            }
            set
            {
                if (this.iconSizeMode == value)
                {
                    return;
                }
                this.iconSizeMode = value;
                base.Invalidate();
            }
        }
        [Category("Data"), Description("列表框中的项"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ChatListItemCollection Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ChatListItemCollection(this);
                }
                return this.items;
            }
        }
        [Browsable(false)]
        public ChatListSubItem SelectSubItem
        {
            get
            {
                return this.selectSubItem;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "50, 224, 239, 235"), Description("滚动条的背景颜色")]
        public Color ScrollBackColor
        {
            get
            {
                return this.chatVScroll.BackColor;
            }
            set
            {
                this.chatVScroll.BackColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "100, 110, 111, 112"), Description("滚动条滑块默认情况下的颜色")]
        public Color ScrollSliderDefaultColor
        {
            get
            {
                return this.chatVScroll.SliderDefaultColor;
            }
            set
            {
                this.chatVScroll.SliderDefaultColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "200, 110, 111, 112"), Description("滚动条滑块被点击或者鼠标移动到上面时候的颜色")]
        public Color ScrollSliderDownColor
        {
            get
            {
                return this.chatVScroll.SliderDownColor;
            }
            set
            {
                this.chatVScroll.SliderDownColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "Transparent"), Description("滚动条箭头的背景颜色")]
        public Color ScrollArrowBackColor
        {
            get
            {
                return this.chatVScroll.ArrowBackColor;
            }
            set
            {
                this.chatVScroll.ArrowBackColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "200, 148, 150, 151"), Description("滚动条箭头的颜色")]
        public Color ScrollArrowColor
        {
            get
            {
                return this.chatVScroll.ArrowColor;
            }
            set
            {
                this.chatVScroll.ArrowColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "101, 103, 103"), Description("列表项上面的箭头的颜色")]
        public Color ArrowColor
        {
            get
            {
                return this.arrowColor;
            }
            set
            {
                if (this.arrowColor == value)
                {
                    return;
                }
                this.arrowColor = value;
                base.Invalidate();
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "Transparent"), Description("列表项的背景色")]
        public Color ItemColor
        {
            get
            {
                return this.itemColor;
            }
            set
            {
                if (this.itemColor == value)
                {
                    return;
                }
                this.itemColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "Transparent"), Description("列表子项的背景色")]
        public Color SubItemColor
        {
            get
            {
                return this.subItemColor;
            }
            set
            {
                if (this.subItemColor == value)
                {
                    return;
                }
                this.subItemColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "150, 230, 238, 241"), Description("当鼠标移动到列表项上面的颜色")]
        public Color ItemMouseOnColor
        {
            get
            {
                return this.itemMouseOnColor;
            }
            set
            {
                this.itemMouseOnColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "200, 252, 240, 193"), Description("当鼠标移动到子项上面的颜色")]
        public Color SubItemMouseOnColor
        {
            get
            {
                return this.subItemMouseOnColor;
            }
            set
            {
                this.subItemMouseOnColor = value;
            }
        }
        [Category("颜色"), DefaultValue(typeof(Color), "200, 252, 236, 172"), Description("当列表子项被选中时候的颜色")]
        public Color SubItemSelectColor
        {
            get
            {
                return this.subItemSelectColor;
            }
            set
            {
                this.subItemSelectColor = value;
            }
        }
        public ChatListBox()
        {
            this.InitializeComponent();
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.ResizeRedraw = true;
            base.Size = new Size(150, 250);
            this.iconSizeMode = ChatListItemIcon.Large;
            this.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.ForeColor = Color.Black;
            this.items = new ChatListItemCollection(this);
            this.chatVScroll = new ChatListVScroll(this);
            this.BackColor = Color.FromArgb(50, 255, 255, 255);
        }
        protected virtual void OnDoubleClickSubItem(ChatListEventArgs e)
        {
            if (this.DoubleClickSubItem != null)
            {
                this.DoubleClickSubItem(this, e);
            }
        }
        protected virtual void OnMouseEnterHead(ChatListEventArgs e)
        {
            if (this.MouseEnterHead != null)
            {
                this.MouseEnterHead(this, e);
            }
        }
        protected virtual void OnMouseLeaveHead(ChatListEventArgs e)
        {
            if (this.MouseLeaveHead != null)
            {
                this.MouseLeaveHead(this, e);
            }
        }
        protected virtual void OnDragSubItemDrop(DragListEventArgs e)
        {
            if (this.DragSubItemDrop != null)
            {
                this.DragSubItemDrop(this, e);
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.chatVScroll.IsMouseDown = false;
            }
            this.MouseDowns = false;
            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                int count = this.items.Count;
                while (i < count)
                {
                    if (this.items[i].Bounds.Contains(this.m_ptMousePos))
                    {
                        if (!this.items[i].IsOpen && this.MouseMoveItems && this.m_mouseOnItem != this.MouseDowmSubItems.OwnerListItem)
                        {
                            try
                            {
                            ChatListSubItem qSubItem = this.MouseDowmSubItems.Clone();
                            this.MouseDowmSubItems.OwnerListItem.SubItems.Remove(this.MouseDowmSubItems);
                            this.MouseDowmSubItems.OwnerListItem.IsOpen = true;
                            this.MouseDowmSubItems.OwnerListItem = this.m_mouseOnItem;
                            
                                this.m_mouseOnItem.SubItems.AddAccordingToStatus(this.MouseDowmSubItems);
                           
                            this.m_mouseOnItem.IsOpen = true;
                            this.OnDragSubItemDrop(new DragListEventArgs(qSubItem, this.MouseDowmSubItems));
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        if (this.MouseDowmSubItems != null)
                        {
                            this.MouseDowmSubItems.OwnerListItem.IsOpen = true;
                        }
                    }
                    i++;
                }
            }
            this.MouseMoveItems = false;
            this.MouseDowmSubItems = null;
            base.OnMouseUp(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.Focus();
            this.m_ptMousePos = e.Location;
            if (this.chatVScroll.SliderBounds.Contains(this.m_ptMousePos))
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.chatVScroll.IsMouseDown = true;
                    this.chatVScroll.MouseDownY = e.Y;
                }
            }
            else
            {
                foreach (ChatListItem chatListItem in (IEnumerable)this.items)
                {
                    if (chatListItem.Bounds.Contains(this.m_ptMousePos))
                    {
                        if (!chatListItem.IsOpen)
                        {
                            this.selectSubItem = null;
                            base.Invalidate();
                            if (e.Button == MouseButtons.Left)
                            {
                                chatListItem.IsOpen = !chatListItem.IsOpen;
                            }
                            else
                            {
                                if (this.SubItemMenu != null)
                                {
                                    this.SubItemMenu.Show(this, this.m_ptMousePos.X, this.m_ptMousePos.Y);
                                }
                            }
                            return;
                        }
                        foreach (ChatListSubItem chatListSubItem in (IEnumerable)chatListItem.SubItems)
                        {
                            if (chatListSubItem.Bounds.Contains(this.m_ptMousePos))
                            {
                                this.selectSubItem = chatListSubItem;
                                base.Invalidate();
                                if (e.Button == MouseButtons.Left)
                                {
                                    this.CursorY = Cursor.Position.Y;
                                    this.MouseDowns = true;
                                    this.MouseDowmSubItems = chatListSubItem;
                                }
                                else
                                {
                                    if (this.ListSubItemMenu != null)
                                    {
                                        this.ListSubItemMenu.Show(this, this.m_ptMousePos.X, this.m_ptMousePos.Y);
                                    }
                                }
                                return;
                            }
                        }
                        if (new Rectangle(0, chatListItem.Bounds.Top, base.Width, 20).Contains(this.m_ptMousePos))
                        {
                            this.selectSubItem = null;
                            base.Invalidate();
                            if (e.Button == MouseButtons.Left)
                            {
                                chatListItem.IsOpen = !chatListItem.IsOpen;
                            }
                            else
                            {
                                if (this.SubItemMenu != null)
                                {
                                    this.SubItemMenu.Show(this, this.m_ptMousePos.X, this.m_ptMousePos.Y);
                                }
                            }
                            return;
                        }
                    }
                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.chatVScroll.Value -= 50;
            }
            if (e.Delta < 0)
            {
                this.chatVScroll.Value += 50;
            }
            base.OnMouseWheel(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TranslateTransform(0f, (float)(-(float)this.chatVScroll.Value));
            int width = this.chatVScroll.ShouldBeDraw ? (base.Width - 9) : base.Width;
            Rectangle rectItem = new Rectangle(0, 1, width, 25);
            Rectangle rectangle = new Rectangle(0, 26, width, (int)this.iconSizeMode);
            SolidBrush solidBrush = new SolidBrush(this.itemColor);
            try
            {
                int i = 0;
                int count = this.items.Count;
                while (i < count)
                {
                    this.DrawItem(graphics, this.items[i], rectItem, solidBrush);
                    if (this.items[i].IsOpen)
                    {
                        rectangle.Y = rectItem.Bottom + 1;
                        int j = 0;
                        int count2 = this.items[i].SubItems.Count;
                        while (j < count2)
                        {
                            this.DrawSubItem(graphics, this.items[i].SubItems[j], ref rectangle, solidBrush);
                            rectangle.Y = rectangle.Bottom + 1;
                            rectangle.Height = (int)this.iconSizeMode;
                            j++;
                        }
                        rectItem.Height = rectangle.Bottom - rectItem.Top - (int)this.iconSizeMode - 1;
                    }
                    this.items[i].Bounds = new Rectangle(rectItem.Location, rectItem.Size);
                    rectItem.Y = rectItem.Bottom + 1;
                    rectItem.Height = 25;
                    i++;
                }
                graphics.ResetTransform();
                this.chatVScroll.VirtualHeight = rectItem.Bottom - 26;
                if (this.chatVScroll.ShouldBeDraw)
                {
                    this.chatVScroll.ReDrawScroll(graphics);
                }
            }
            finally
            {
                solidBrush.Dispose();
            }
            base.OnPaint(e);
        }
        protected override void OnCreateControl()
        {
            new Thread((ParameterizedThreadStart)delegate
            {
                Rectangle rc = new Rectangle(0, 0, base.Width, base.Height);
                while (true)
                {
                    int i = 0;
                    int count = this.items.Count;
                    while (i < count)
                    {
                        if (this.items[i].IsOpen)
                        {
                            int j = 0;
                            int count2 = this.items[i].SubItems.Count;
                            while (j < count2)
                            {
                                if (this.items[i].SubItems[j].IsTwinkle)
                                {
                                    this.items[i].SubItems[j].IsTwinkleHide = !this.items[i].SubItems[j].IsTwinkleHide;
                                }
                                rc.Y = this.items[i].SubItems[j].Bounds.Y - this.chatVScroll.Value;
                                rc.Height = this.items[i].SubItems[j].Bounds.Height;
                                base.Invalidate(rc);
                                j++;
                            }
                        }
                        else
                        {
                            rc.Y = this.items[i].Bounds.Y - this.chatVScroll.Value;
                            rc.Height = this.items[i].Bounds.Height;
                            if (this.items[i].TwinkleSubItemNumber > 0)
                            {
                                this.items[i].IsTwinkleHide = !this.items[i].IsTwinkleHide;
                            }
                            base.Invalidate(rc);
                        }
                        i++;
                    }
                    Thread.Sleep(210);
                }
            })
            {
                IsBackground = true
            }.Start();
            base.OnCreateControl();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.m_ptMousePos = e.Location;
            if (this.chatVScroll.IsMouseDown)
            {
                this.chatVScroll.MoveSliderFromLocation(e.Y);
                return;
            }
            if (this.chatVScroll.ShouldBeDraw)
            {
                if (this.chatVScroll.Bounds.Contains(this.m_ptMousePos))
                {
                    this.ClearItemMouseOn();
                    this.ClearSubItemMouseOn();
                    this.chatVScroll.IsMouseOnSlider = true;
                    this.chatVScroll.IsMouseOnUp = true;
                    this.chatVScroll.IsMouseOnDown = true;
                    return;
                }
                this.chatVScroll.ClearAllMouseOn();
            }
            this.m_ptMousePos.Y = this.m_ptMousePos.Y + this.chatVScroll.Value;
            int i = 0;
            int count = this.items.Count;
            while (i < count)
            {
                if (this.items[i].Bounds.Contains(this.m_ptMousePos))
                {
                    if (this.items[i].IsOpen)
                    {
                        int j = 0;
                        int count2 = this.items[i].SubItems.Count;
                        while (j < count2)
                        {
                            if (this.items[i].SubItems[j].Bounds.Contains(this.m_ptMousePos))
                            {
                                if (this.m_mouseOnSubItem != null)
                                {
                                    if (this.items[i].SubItems[j].HeadRect.Contains(this.m_ptMousePos))
                                    {
                                        if (!this.m_bOnMouseEnterHeaded)
                                        {
                                            this.OnMouseEnterHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                                            this.m_bOnMouseEnterHeaded = true;
                                        }
                                    }
                                    else
                                    {
                                        if (this.m_bOnMouseEnterHeaded)
                                        {
                                            this.OnMouseLeaveHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                                            this.m_bOnMouseEnterHeaded = false;
                                        }
                                    }
                                    if (this.MouseDowns && Math.Abs(this.CursorY - Cursor.Position.Y) > 4)
                                    {
                                        for (int k = 0; k < this.Items.Count; k++)
                                        {
                                            if (this.Items[k].IsOpen)
                                            {
                                                this.Items[k].IsOpen = false;
                                            }
                                        }
                                        this.m_mouseOnSubItem.OwnerListItem.IsOpen = false;
                                        this.MouseMoveItems = true;
                                        Color color = Color.FromArgb(250, (int)this.SubItemSelectColor.R, (int)this.SubItemSelectColor.G, (int)this.SubItemSelectColor.B);
                                        string displayName = this.m_mouseOnSubItem.DisplayName;
                                        Size size = TextRenderer.MeasureText(displayName, this.Font);
                                        int num = 45 + size.Width + 10;
                                        int num2 = 45;
                                        Bitmap bitmap = new Bitmap(num * 2, num2 * 2);
                                        Graphics graphics = Graphics.FromImage(bitmap);
                                        graphics.FillRectangle(new SolidBrush(color), num, num2, num, num2);
                                        graphics.DrawImage(this.m_mouseOnSubItem.HeadImage, num, num2, 45, 45);
                                        if (size.Width > 0)
                                        {
                                            graphics.DrawString(displayName, this.Font, Brushes.Black, (float)(num + num2 + 5), (float)(num2 + (num2 - size.Height) / 2));
                                        }
                                        else
                                        {
                                            graphics.DrawString(this.m_mouseOnSubItem.NicName, this.Font, Brushes.Black, (float)(num + num2 + 5), (float)(num2 + (num2 - size.Height) / 2));
                                        }
                                        Cursor current = new Cursor(bitmap.GetHicon());
                                        Cursor.Current = current;
                                    }
                                }
                                if (this.items[i].SubItems[j].Equals(this.m_mouseOnSubItem))
                                {
                                    return;
                                }
                                this.ClearSubItemMouseOn();
                                this.ClearItemMouseOn();
                                this.m_mouseOnSubItem = this.items[i].SubItems[j];
                                base.Invalidate(new Rectangle(this.m_mouseOnSubItem.Bounds.X, this.m_mouseOnSubItem.Bounds.Y - this.chatVScroll.Value, this.m_mouseOnSubItem.Bounds.Width, this.m_mouseOnSubItem.Bounds.Height));
                                return;
                            }
                            else
                            {
                                j++;
                            }
                        }
                        this.ClearSubItemMouseOn();
                        if (new Rectangle(0, this.items[i].Bounds.Top - this.chatVScroll.Value, base.Width, 20).Contains(e.Location))
                        {
                            if (this.items[i].Equals(this.m_mouseOnItem))
                            {
                                return;
                            }
                            this.ClearItemMouseOn();
                            this.m_mouseOnItem = this.items[i];
                            base.Invalidate(new Rectangle(this.m_mouseOnItem.Bounds.X, this.m_mouseOnItem.Bounds.Y - this.chatVScroll.Value, this.m_mouseOnItem.Bounds.Width, this.m_mouseOnItem.Bounds.Height));
                            return;
                        }
                    }
                    else
                    {
                        if (this.items[i].Equals(this.m_mouseOnItem))
                        {
                            return;
                        }
                        this.ClearItemMouseOn();
                        this.ClearSubItemMouseOn();
                        this.m_mouseOnItem = this.items[i];
                        base.Invalidate(new Rectangle(this.m_mouseOnItem.Bounds.X, this.m_mouseOnItem.Bounds.Y - this.chatVScroll.Value, this.m_mouseOnItem.Bounds.Width, this.m_mouseOnItem.Bounds.Height));
                        return;
                    }
                }
                i++;
            }
            this.ClearItemMouseOn();
            this.ClearSubItemMouseOn();
            base.OnMouseMove(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.ClearItemMouseOn();
            this.ClearSubItemMouseOn();
            this.chatVScroll.ClearAllMouseOn();
            if (this.m_bOnMouseEnterHeaded)
            {
                this.OnMouseLeaveHead(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
                this.m_bOnMouseEnterHeaded = false;
            }
            base.OnMouseLeave(e);
        }
        protected override void OnClick(EventArgs e)
        {
            if (this.chatVScroll.IsMouseDown)
            {
                return;
            }
            if (!this.chatVScroll.ShouldBeDraw || !this.chatVScroll.Bounds.Contains(this.m_ptMousePos))
            {
                base.OnClick(e);
                return;
            }
            if (this.chatVScroll.UpBounds.Contains(this.m_ptMousePos))
            {
                this.chatVScroll.Value -= 50;
                return;
            }
            if (this.chatVScroll.DownBounds.Contains(this.m_ptMousePos))
            {
                this.chatVScroll.Value += 50;
                return;
            }
            if (!this.chatVScroll.SliderBounds.Contains(this.m_ptMousePos))
            {
                this.chatVScroll.MoveSliderToLocation(this.m_ptMousePos.Y);
            }
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            this.OnClick(e);
            if (this.chatVScroll.Bounds.Contains(base.PointToClient(Control.MousePosition)))
            {
                return;
            }
            if (this.selectSubItem != null)
            {
                this.OnDoubleClickSubItem(new ChatListEventArgs(this.m_mouseOnSubItem, this.selectSubItem));
            }
            base.OnDoubleClick(e);
        }
        protected virtual void DrawItem(Graphics g, ChatListItem item, Rectangle rectItem, SolidBrush sb)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.SetTabStops(0f, new float[]
			{
				20f
			});
            if (item.Equals(this.m_mouseOnItem))
            {
                sb.Color = this.itemMouseOnColor;
            }
            else
            {
                sb.Color = this.itemColor;
            }
            g.FillRectangle(sb, rectItem);
            if (item.IsOpen)
            {
                sb.Color = this.arrowColor;
                g.FillPolygon(sb, new Point[]
				{
					new Point(2, rectItem.Top + 11),
					new Point(12, rectItem.Top + 11),
					new Point(7, rectItem.Top + 16)
				});
            }
            else
            {
                sb.Color = this.arrowColor;
                g.FillPolygon(sb, new Point[]
				{
					new Point(5, rectItem.Top + 8),
					new Point(5, rectItem.Top + 18),
					new Point(10, rectItem.Top + 13)
				});
                if (item.TwinkleSubItemNumber > 0 && item.IsTwinkleHide)
                {
                    return;
                }
            }
            string s = "\t" + item.Text;
            sb.Color = this.ForeColor;
            stringFormat.Alignment = StringAlignment.Near;
            g.DrawString(s, this.Font, sb, rectItem, stringFormat);
            Size size = TextRenderer.MeasureText(item.Text, this.Font);
            stringFormat.Alignment = StringAlignment.Near;
            g.DrawString(string.Concat(new object[]
			{
				"[",
				item.SubItems.GetOnLineNumber(),
				"/",
				item.SubItems.Count,
				"]"
			}), this.Font, sb, new Rectangle(rectItem.X + Convert.ToInt32(size.Width) + 25, rectItem.Y, rectItem.Width - 15, rectItem.Height), stringFormat);
        }
        protected virtual void DrawSubItem(Graphics g, ChatListSubItem subItem, ref Rectangle rectSubItem, SolidBrush sb)
        {
            if (subItem.Equals(this.selectSubItem))
            {
                rectSubItem.Height = 53;
                sb.Color = this.subItemSelectColor;
                g.FillRectangle(sb, rectSubItem);
                this.DrawHeadImage(g, subItem, rectSubItem);
                this.DrawLargeSubItem(g, subItem, rectSubItem);
                subItem.Bounds = new Rectangle(rectSubItem.Location, rectSubItem.Size);
                return;
            }
            if (subItem.Equals(this.m_mouseOnSubItem))
            {
                sb.Color = this.subItemMouseOnColor;
            }
            else
            {
                sb.Color = this.subItemColor;
            }
            g.FillRectangle(sb, rectSubItem);
            this.DrawHeadImage(g, subItem, rectSubItem);
            if (this.iconSizeMode == ChatListItemIcon.Large)
            {
                this.DrawLargeSubItem(g, subItem, rectSubItem);
            }
            else
            {
                this.DrawSmallSubItem(g, subItem, rectSubItem);
            }
            subItem.Bounds = new Rectangle(rectSubItem.Location, rectSubItem.Size);
        }
        protected virtual void DrawHeadImage(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            if (subItem.IsTwinkle && subItem.IsTwinkleHide)
            {
                return;
            }
            int num = (rectSubItem.Height == 53) ? 40 : 20;
            subItem.HeadRect = new Rectangle(5, rectSubItem.Top + (rectSubItem.Height - num) / 2, num, num);
            if (subItem.HeadImage == null)
            {
                subItem.HeadImage = Resources._1_100;
            }
            if (subItem.Status == ChatListSubItem.UserStatus.OffLine)
            {
                g.DrawImage(subItem.GetDarkImage(), subItem.HeadRect);
            }
            else
            {
                g.DrawImage(subItem.HeadImage, subItem.HeadRect);
                if (subItem.Status == ChatListSubItem.UserStatus.QMe)
                {
                    g.DrawImage(Resources.QMe, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                }
                if (subItem.Status == ChatListSubItem.UserStatus.Away)
                {
                    g.DrawImage(Resources.Away, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                }
                if (subItem.Status == ChatListSubItem.UserStatus.Busy)
                {
                    g.DrawImage(Resources.Busy, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                }
                if (subItem.Status == ChatListSubItem.UserStatus.DontDisturb)
                {
                    g.DrawImage(Resources.Dont_Disturb, new Rectangle(subItem.HeadRect.Right - 11, subItem.HeadRect.Bottom - 11, 11, 11));
                }
            }
            if (subItem.Equals(this.selectSubItem))
            {
                g.DrawImage(Resources.MainPanel, subItem.HeadRect.X - 3, subItem.HeadRect.Y - 3, 46, 46);
                return;
            }
            Pen pen = new Pen(Color.FromArgb(200, 255, 255, 255));
            g.DrawRectangle(pen, subItem.HeadRect);
        }
        protected virtual void DrawLargeSubItem(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            rectSubItem.Height = 53;
            string displayName = subItem.DisplayName;
            Size size = TextRenderer.MeasureText(displayName, this.Font);
            TextRenderer.MeasureText(subItem.NicName, this.Font);
            StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap);
            stringFormat.Trimming = StringTrimming.Word;
            Rectangle r = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 8), new Size(base.Width - 9 - rectSubItem.Height, size.Height));
            Rectangle r2 = new Rectangle(new Point(rectSubItem.Height + size.Width, rectSubItem.Top + 8), new Size(base.Width - 9 - rectSubItem.Height - size.Width, size.Height));
            if (size.Width > 0)
            {
                g.DrawString(displayName, this.Font, Brushes.Black, r, stringFormat);
                g.DrawString("(" + subItem.NicName + ")", this.Font, Brushes.Gray, r2, stringFormat);
            }
            else
            {
                Rectangle r3 = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 8), new Size(base.Width - 9 - rectSubItem.Height, size.Height));
                g.DrawString(subItem.NicName, this.Font, Brushes.Black, r3, stringFormat);
            }
            Size size2 = TextRenderer.MeasureText(subItem.PersonalMsg, this.Font);
            Rectangle r4 = new Rectangle(new Point(rectSubItem.Height, rectSubItem.Top + 11 + this.Font.Height), new Size(base.Width - rectSubItem.Height, size2.Height));
            g.DrawString(subItem.PersonalMsg, this.Font, Brushes.Gray, r4, stringFormat);
        }
        protected virtual void DrawSmallSubItem(Graphics g, ChatListSubItem subItem, Rectangle rectSubItem)
        {
            rectSubItem.Height = 27;
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap;
            string text = subItem.DisplayName;
            if (string.IsNullOrEmpty(text))
            {
                text = subItem.NicName;
            }
            Size size = TextRenderer.MeasureText(text, this.Font);
            stringFormat.SetTabStops(0f, new float[]
			{
				(float)rectSubItem.Height
			});
            g.DrawString("\t" + text, this.Font, Brushes.Black, rectSubItem, stringFormat);
            stringFormat.SetTabStops(0f, new float[]
			{
				(float)(rectSubItem.Height + 5 + size.Width)
			});
            g.DrawString("\t" + subItem.PersonalMsg, this.Font, Brushes.Gray, rectSubItem, stringFormat);
        }
        private void ClearItemMouseOn()
        {
            if (this.m_mouseOnItem != null)
            {
                int num = 0;
                if (this.chatVScroll.ShouldBeDraw)
                {
                    num = 9;
                }
                base.Invalidate(new Rectangle(this.m_mouseOnItem.Bounds.X, this.m_mouseOnItem.Bounds.Y - this.chatVScroll.Value, this.m_mouseOnItem.Bounds.Width + num, this.m_mouseOnItem.Bounds.Height));
                this.m_mouseOnItem = null;
            }
        }
        private void ClearSubItemMouseOn()
        {
            if (this.m_mouseOnSubItem != null)
            {
                int num = 0;
                if (this.chatVScroll.ShouldBeDraw)
                {
                    num = 9;
                }
                base.Invalidate(new Rectangle(this.m_mouseOnSubItem.Bounds.X, this.m_mouseOnSubItem.Bounds.Y - this.chatVScroll.Value, this.m_mouseOnSubItem.Bounds.Width + num, this.m_mouseOnSubItem.Bounds.Height));
                this.m_mouseOnSubItem = null;
            }
        }
        public ChatListSubItem[] GetSubItemsById(int userId)
        {
            List<ChatListSubItem> list = new List<ChatListSubItem>();
            int i = 0;
            int count = this.items.Count;
            while (i < count)
            {
                int j = 0;
                int count2 = this.items[i].SubItems.Count;
                while (j < count2)
                {
                    if (userId == this.items[i].SubItems[j].ID)
                    {
                        list.Add(this.items[i].SubItems[j]);
                    }
                    j++;
                }
                i++;
            }
            return list.ToArray();
        }
        public ChatListSubItem[] GetSubItemsByNicName(string nicName)
        {
            List<ChatListSubItem> list = new List<ChatListSubItem>();
            int i = 0;
            int count = this.items.Count;
            while (i < count)
            {
                int j = 0;
                int count2 = this.items[i].SubItems.Count;
                while (j < count2)
                {
                    if (nicName == this.items[i].SubItems[j].NicName)
                    {
                        list.Add(this.items[i].SubItems[j]);
                    }
                    j++;
                }
                i++;
            }
            return list.ToArray();
        }
        public ChatListSubItem[] GetSubItemsByDisplayName(string displayName)
        {
            List<ChatListSubItem> list = new List<ChatListSubItem>();
            int i = 0;
            int count = this.items.Count;
            while (i < count)
            {
                int j = 0;
                int count2 = this.items[i].SubItems.Count;
                while (j < count2)
                {
                    if (displayName == this.items[i].SubItems[j].DisplayName)
                    {
                        list.Add(this.items[i].SubItems[j]);
                    }
                    j++;
                }
                i++;
            }
            return list.ToArray();
        }
        public ChatListSubItem[] GetSubItemsByIp(string Ip)
        {
            List<ChatListSubItem> list = new List<ChatListSubItem>();
            int i = 0;
            int count = this.items.Count;
            while (i < count)
            {
                int j = 0;
                int count2 = this.items[i].SubItems.Count;
                while (j < count2)
                {
                    if (Ip == this.items[i].SubItems[j].IpAddress)
                    {
                        list.Add(this.items[i].SubItems[j]);
                    }
                    j++;
                }
                i++;
            }
            return list.ToArray();
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
            base.ResumeLayout(false);
        }
    }
}
