using System;
using System.Collections;
namespace xingwaWinFormUI.SkinControl
{
	public class ChatListItemCollection : IList, ICollection, IEnumerable
	{
		private int count;
		private ChatListItem[] m_arrItem;
		private ChatListBox owner;
		public int Count
		{
			get
			{
				return this.count;
			}
		}
		public ChatListItem this[int index]
		{
			get
			{
				if (index < 0 || index >= this.count)
				{
					throw new IndexOutOfRangeException("Index was outside the bounds of the array");
				}
				return this.m_arrItem[index];
			}
			set
			{
				if (index < 0 || index >= this.count)
				{
					throw new IndexOutOfRangeException("Index was outside the bounds of the array");
				}
				this.m_arrItem[index] = value;
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
				if (!(value is ChatListItem))
				{
					throw new ArgumentException("Value cannot convert to ListItem");
				}
				this[index] = (ChatListItem)value;
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
		public ChatListItemCollection(ChatListBox owner)
		{
			this.owner = owner;
		}
		private void EnsureSpace(int elements)
		{
			if (this.m_arrItem == null)
			{
				this.m_arrItem = new ChatListItem[Math.Max(elements, 4)];
				return;
			}
			if (this.count + elements > this.m_arrItem.Length)
			{
				ChatListItem[] array = new ChatListItem[Math.Max(this.count + elements, this.m_arrItem.Length * 2)];
				this.m_arrItem.CopyTo(array, 0);
				this.m_arrItem = array;
			}
		}
		public int IndexOf(ChatListItem item)
		{
			return Array.IndexOf<ChatListItem>(this.m_arrItem, item);
		}
		public void Add(ChatListItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Item cannot be null");
			}
			this.EnsureSpace(1);
			if (-1 == this.IndexOf(item))
			{
				item.OwnerChatListBox = this.owner;
				this.m_arrItem[this.count++] = item;
				this.owner.Invalidate();
			}
		}
		public void AddRange(ChatListItem[] items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("Items cannot be null");
			}
			this.EnsureSpace(items.Length);
			try
			{
				for (int i = 0; i < items.Length; i++)
				{
					ChatListItem chatListItem = items[i];
					if (chatListItem == null)
					{
						throw new ArgumentNullException("Item cannot be null");
					}
					if (-1 == this.IndexOf(chatListItem))
					{
						chatListItem.OwnerChatListBox = this.owner;
						this.m_arrItem[this.count++] = chatListItem;
					}
				}
			}
			finally
			{
				this.owner.Invalidate();
			}
		}
		public void Remove(ChatListItem item)
		{
			int num = this.IndexOf(item);
			if (-1 != num)
			{
				this.RemoveAt(num);
			}
		}
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.count)
			{
				throw new IndexOutOfRangeException("Index was outside the bounds of the array");
			}
			this.count--;
			int i = index;
			int num = this.count;
			while (i < num)
			{
				this.m_arrItem[i] = this.m_arrItem[i + 1];
				i++;
			}
			this.owner.Invalidate();
		}
		public void Clear()
		{
			this.count = 0;
			this.m_arrItem = null;
			this.owner.Invalidate();
		}
		public void Insert(int index, ChatListItem item)
		{
			if (index < 0 || index >= this.count)
			{
				throw new IndexOutOfRangeException("Index was outside the bounds of the array");
			}
			if (item == null)
			{
				throw new ArgumentNullException("Item cannot be null");
			}
			this.EnsureSpace(1);
			for (int i = this.count; i > index; i--)
			{
				this.m_arrItem[i] = this.m_arrItem[i - 1];
			}
			item.OwnerChatListBox = this.owner;
			this.m_arrItem[index] = item;
			this.count++;
			this.owner.Invalidate();
		}
		public bool Contains(ChatListItem item)
		{
			return this.IndexOf(item) != -1;
		}
		public void CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array cannot be null");
			}
			this.m_arrItem.CopyTo(array, index);
		}
		int IList.Add(object value)
		{
			if (!(value is ChatListItem))
			{
				throw new ArgumentException("Value cannot convert to ListItem");
			}
			this.Add((ChatListItem)value);
			return this.IndexOf((ChatListItem)value);
		}
		void IList.Clear()
		{
			this.Clear();
		}
		bool IList.Contains(object value)
		{
			if (!(value is ChatListItem))
			{
				throw new ArgumentException("Value cannot convert to ListItem");
			}
			return this.Contains((ChatListItem)value);
		}
		int IList.IndexOf(object value)
		{
			if (!(value is ChatListItem))
			{
				throw new ArgumentException("Value cannot convert to ListItem");
			}
			return this.IndexOf((ChatListItem)value);
		}
		void IList.Insert(int index, object value)
		{
			if (!(value is ChatListItem))
			{
				throw new ArgumentException("Value cannot convert to ListItem");
			}
			this.Insert(index, (ChatListItem)value);
		}
		void IList.Remove(object value)
		{
			if (!(value is ChatListItem))
			{
				throw new ArgumentException("Value cannot convert to ListItem");
			}
			this.Remove((ChatListItem)value);
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
				yield return this.m_arrItem[i];
				i++;
			}
			yield break;
		}
	}
}
