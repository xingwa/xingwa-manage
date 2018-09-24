using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
namespace xingwaWinFormUI.SkinControl
{
	public class ChatListItem
	{
		public class ChatListSubItemCollection : IList, ICollection, IEnumerable
		{
			private int count;
			private ChatListSubItem[] m_arrSubItems;
			private ChatListItem owner;
			public int Count
			{
				get
				{
					return this.count;
				}
			}
			public ChatListSubItem this[int index]
			{
				get
				{
					if (index < 0 || index > this.count)
					{
						throw new IndexOutOfRangeException("Index was outside the bounds of the array");
					}
					return this.m_arrSubItems[index];
				}
				set
				{
					if (index < 0 || index > this.count)
					{
						throw new IndexOutOfRangeException("Index was outside the bounds of the array");
					}
					this.m_arrSubItems[index] = value;
					if (this.owner.OwnerChatListBox != null)
					{
						this.owner.OwnerChatListBox.Invalidate(this.m_arrSubItems[index].Bounds);
					}
				}
			}
			bool IList.IsFixedSize
			{
				get
				{
					return false;
				}
			}
			bool IList.IsReadOnly
			{
				get
				{
					return false;
				}
			}
			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					if (!(value is ChatListSubItem))
					{
						throw new ArgumentException("Value cannot convert to ListSubItem");
					}
					this[index] = (ChatListSubItem)value;
				}
			}
			int ICollection.Count
			{
				get
				{
					return this.count;
				}
			}
			bool ICollection.IsSynchronized
			{
				get
				{
					return true;
				}
			}
			object ICollection.SyncRoot
			{
				get
				{
					return this;
				}
			}
			public ChatListSubItemCollection(ChatListItem owner)
			{
				this.owner = owner;
			}
			public void Sort()
			{
				Array.Sort<ChatListSubItem>(this.m_arrSubItems, 0, this.count, null);
				if (this.owner.ownerChatListBox != null)
				{
					this.owner.ownerChatListBox.Invalidate(this.owner.bounds);
				}
			}
			public int GetOnLineNumber()
			{
				int num = 0;
				int i = 0;
				int num2 = this.count;
				while (i < num2)
				{
					if (this.m_arrSubItems[i].Status != ChatListSubItem.UserStatus.OffLine)
					{
						num++;
					}
					i++;
				}
				return num;
			}
			private void EnsureSpace(int elements)
			{
				if (this.m_arrSubItems == null)
				{
					this.m_arrSubItems = new ChatListSubItem[Math.Max(elements, 4)];
					return;
				}
				if (elements + this.count > this.m_arrSubItems.Length)
				{
					ChatListSubItem[] array = new ChatListSubItem[Math.Max(this.m_arrSubItems.Length * 2, elements + this.count)];
					this.m_arrSubItems.CopyTo(array, 0);
					this.m_arrSubItems = array;
				}
			}
			public int IndexOf(ChatListSubItem subItem)
			{
				return Array.IndexOf<ChatListSubItem>(this.m_arrSubItems, subItem);
			}
			public void Add(ChatListSubItem subItem)
			{
				if (subItem == null)
				{
					throw new ArgumentNullException("SubItem cannot be null");
				}
				this.EnsureSpace(1);
				if (-1 == this.IndexOf(subItem))
				{
					subItem.OwnerListItem = this.owner;
					this.m_arrSubItems[this.count++] = subItem;
					if (this.owner.OwnerChatListBox != null)
					{
						this.owner.OwnerChatListBox.Invalidate();
					}
				}
			}
			public void AddRange(ChatListSubItem[] subItems)
			{
				if (subItems == null)
				{
					throw new ArgumentNullException("SubItems cannot be null");
				}
				this.EnsureSpace(subItems.Length);
				try
				{
					for (int i = 0; i < subItems.Length; i++)
					{
						ChatListSubItem chatListSubItem = subItems[i];
						if (chatListSubItem == null)
						{
							throw new ArgumentNullException("SubItem cannot be null");
						}
						if (-1 == this.IndexOf(chatListSubItem))
						{
							chatListSubItem.OwnerListItem = this.owner;
							this.m_arrSubItems[this.count++] = chatListSubItem;
						}
					}
				}
				finally
				{
					if (this.owner.OwnerChatListBox != null)
					{
						this.owner.OwnerChatListBox.Invalidate();
					}
				}
			}
			public void AddAccordingToStatus(ChatListSubItem subItem)
			{
				if (subItem.Status == ChatListSubItem.UserStatus.OffLine)
				{
					this.Add(subItem);
					return;
				}
				int i = 0;
				int num = this.count;
				while (i < num)
				{
					if (subItem.Status <= this.m_arrSubItems[i].Status)
					{
						this.Insert(i, subItem);
						return;
					}
					i++;
				}
				this.Add(subItem);
			}
			public void Remove(ChatListSubItem subItem)
			{
				int num = this.IndexOf(subItem);
				if (-1 != num)
				{
					this.RemoveAt(num);
				}
			}
			public void RemoveAt(int index)
			{
				if (index < 0 || index > this.count)
				{
					throw new IndexOutOfRangeException("Index was outside the bounds of the array");
				}
				this.count--;
				int i = index;
				int num = this.count;
				while (i < num)
				{
					this.m_arrSubItems[i] = this.m_arrSubItems[i + 1];
					i++;
				}
				if (this.owner.OwnerChatListBox != null)
				{
					this.owner.OwnerChatListBox.Invalidate();
				}
			}
			public void Clear()
			{
				this.count = 0;
				this.m_arrSubItems = null;
				if (this.owner.OwnerChatListBox != null)
				{
					this.owner.OwnerChatListBox.Invalidate();
				}
			}
			public void Insert(int index, ChatListSubItem subItem)
			{
				if (index < 0 || index > this.count)
				{
					throw new IndexOutOfRangeException("Index was outside the bounds of the array");
				}
				if (subItem == null)
				{
					throw new ArgumentNullException("SubItem cannot be null");
				}
				this.EnsureSpace(1);
				for (int i = this.count; i > index; i--)
				{
					this.m_arrSubItems[i] = this.m_arrSubItems[i - 1];
				}
				subItem.OwnerListItem = this.owner;
				this.m_arrSubItems[index] = subItem;
				this.count++;
				if (this.owner.OwnerChatListBox != null)
				{
					this.owner.OwnerChatListBox.Invalidate();
				}
			}
			public void CopyTo(Array array, int index)
			{
				if (array == null)
				{
					throw new ArgumentNullException("Array cannot be null");
				}
				this.m_arrSubItems.CopyTo(array, index);
			}
			public bool Contains(ChatListSubItem subItem)
			{
				return this.IndexOf(subItem) != -1;
			}
			int IList.Add(object value)
			{
				if (!(value is ChatListSubItem))
				{
					throw new ArgumentException("Value cannot convert to ListSubItem");
				}
				this.Add((ChatListSubItem)value);
				return this.IndexOf((ChatListSubItem)value);
			}
			void IList.Clear()
			{
				this.Clear();
			}
			bool IList.Contains(object value)
			{
				if (!(value is ChatListSubItem))
				{
					throw new ArgumentException("Value cannot convert to ListSubItem");
				}
				return this.Contains((ChatListSubItem)value);
			}
			int IList.IndexOf(object value)
			{
				if (!(value is ChatListSubItem))
				{
					throw new ArgumentException("Value cannot convert to ListSubItem");
				}
				return this.IndexOf((ChatListSubItem)value);
			}
			void IList.Insert(int index, object value)
			{
				if (!(value is ChatListSubItem))
				{
					throw new ArgumentException("Value cannot convert to ListSubItem");
				}
				this.Insert(index, (ChatListSubItem)value);
			}
			void IList.Remove(object value)
			{
				if (!(value is ChatListSubItem))
				{
					throw new ArgumentException("Value cannot convert to ListSubItem");
				}
				this.Remove((ChatListSubItem)value);
			}
			void IList.RemoveAt(int index)
			{
				this.RemoveAt(index);
			}
			void ICollection.CopyTo(Array array, int index)
			{
				this.CopyTo(array, index);
			}
			IEnumerator IEnumerable.GetEnumerator()
			{
				int i = 0;
				int num = this.count;
				while (i < num)
				{
					yield return this.m_arrSubItems[i];
					i++;
				}
				yield break;
			}
		}
		private string text = "Item";
		private bool isOpen;
		private int twinkleSubItemNumber;
		private bool isTwinkleHide;
		private Rectangle bounds;
		private ChatListBox ownerChatListBox;
		private ChatListItem.ChatListSubItemCollection subItems;
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
				if (this.ownerChatListBox != null)
				{
					this.ownerChatListBox.Invalidate(this.bounds);
				}
			}
		}
		[DefaultValue(false)]
		public bool IsOpen
		{
			get
			{
				return this.isOpen;
			}
			set
			{
				this.isOpen = value;
				if (this.ownerChatListBox != null)
				{
					this.ownerChatListBox.Invalidate();
				}
			}
		}
		[Browsable(false)]
		public int TwinkleSubItemNumber
		{
			get
			{
				return this.twinkleSubItemNumber;
			}
			set
			{
				this.twinkleSubItemNumber = value;
			}
		}
		public bool IsTwinkleHide
		{
			get
			{
				return this.isTwinkleHide;
			}
			set
			{
				this.isTwinkleHide = value;
			}
		}
		[Browsable(false)]
		public Rectangle Bounds
		{
			get
			{
				return this.bounds;
			}
			set
			{
				this.bounds = value;
			}
		}
		[Browsable(false)]
		public ChatListBox OwnerChatListBox
		{
			get
			{
				return this.ownerChatListBox;
			}
			set
			{
				this.ownerChatListBox = value;
			}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ChatListItem.ChatListSubItemCollection SubItems
		{
			get
			{
				if (this.subItems == null)
				{
					this.subItems = new ChatListItem.ChatListSubItemCollection(this);
				}
				return this.subItems;
			}
			set
			{
				if (this.subItems != value)
				{
					this.subItems = value;
				}
			}
		}
		public ChatListItem Clone()
		{
			return new ChatListItem
			{
				Bounds = this.Bounds,
				IsOpen = this.IsOpen,
				IsTwinkleHide = this.IsTwinkleHide,
				OwnerChatListBox = this.OwnerChatListBox,
				SubItems = this.SubItems,
				Text = this.text,
				TwinkleSubItemNumber = this.TwinkleSubItemNumber
			};
		}
		public ChatListItem()
		{
			if (this.text == null)
			{
				this.text = string.Empty;
			}
		}
		public ChatListItem(string text)
		{
			this.text = text;
		}
		public ChatListItem(string text, bool bOpen)
		{
			this.text = text;
			this.isOpen = bOpen;
		}
		public ChatListItem(ChatListSubItem[] subItems)
		{
			this.subItems.AddRange(subItems);
		}
		public ChatListItem(string text, ChatListSubItem[] subItems)
		{
			this.text = text;
			this.subItems.AddRange(subItems);
		}
		public ChatListItem(string text, bool bOpen, ChatListSubItem[] subItems)
		{
			this.text = text;
			this.isOpen = bOpen;
			this.subItems.AddRange(subItems);
		}
	}
}
