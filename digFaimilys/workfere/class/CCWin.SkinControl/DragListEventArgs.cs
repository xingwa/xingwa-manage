using System;
namespace xingwaWinFormUI.SkinControl
{
	public class DragListEventArgs
	{
		private ChatListSubItem qsubitem;
		private ChatListSubItem hsubitem;
		public ChatListSubItem QSubItem
		{
			get
			{
				return this.qsubitem;
			}
		}
		public ChatListSubItem HSubItem
		{
			get
			{
				return this.hsubitem;
			}
		}
		public DragListEventArgs(ChatListSubItem QSubItem, ChatListSubItem HSubItem)
		{
			this.qsubitem = QSubItem;
			this.hsubitem = HSubItem;
		}
	}
}
