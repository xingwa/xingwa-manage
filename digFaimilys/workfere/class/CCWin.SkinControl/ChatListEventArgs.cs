using System;
namespace xingwaWinFormUI.SkinControl
{
	public class ChatListEventArgs
	{
		private ChatListSubItem mouseOnSubItem;
		private ChatListSubItem selectSubItem;
		public ChatListSubItem MouseOnSubItem
		{
			get
			{
				return this.mouseOnSubItem;
			}
		}
		public ChatListSubItem SelectSubItem
		{
			get
			{
				return this.selectSubItem;
			}
		}
		public ChatListEventArgs(ChatListSubItem mouseonsubitem, ChatListSubItem selectsubitem)
		{
			this.mouseOnSubItem = mouseonsubitem;
			this.selectSubItem = selectsubitem;
		}
	}
}
