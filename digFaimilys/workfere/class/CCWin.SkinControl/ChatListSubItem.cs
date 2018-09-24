using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	public class ChatListSubItem : IComparable
	{
		public enum UserStatus
		{
			QMe = 1,
			Online,
			Away,
			Busy,
			DontDisturb,
			OffLine
		}
		private int id;
		private object tag;
		private string nicName;
		private string displayName;
		private string personalMsg;
		private string ipAddress;
		private int updPort;
		private int tcpPort;
		private Image headImage;
		private ChatListSubItem.UserStatus status;
		private bool isTwinkle;
		private bool isTwinkleHide;
		private Rectangle bounds;
		private Rectangle headRect;
		private ChatListItem ownerListItem;
		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		public object Tag
		{
			get
			{
				return this.tag;
			}
			set
			{
				this.tag = value;
			}
		}
		public string NicName
		{
			get
			{
				return this.nicName;
			}
			set
			{
				this.nicName = value;
				this.RedrawSubItem();
			}
		}
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				this.displayName = value;
				this.RedrawSubItem();
			}
		}
		public string PersonalMsg
		{
			get
			{
				return this.personalMsg;
			}
			set
			{
				this.personalMsg = value;
				this.RedrawSubItem();
			}
		}
		public string IpAddress
		{
			get
			{
				return this.ipAddress;
			}
			set
			{
				if (this.CheckIpAddress(value))
				{
					this.ipAddress = value;
				}
			}
		}
		public int UpdPort
		{
			get
			{
				return this.updPort;
			}
			set
			{
				this.updPort = value;
			}
		}
		public int TcpPort
		{
			get
			{
				return this.tcpPort;
			}
			set
			{
				this.tcpPort = value;
			}
		}
		public Image HeadImage
		{
			get
			{
				return this.headImage;
			}
			set
			{
				this.headImage = value;
				this.RedrawSubItem();
			}
		}
		public ChatListSubItem.UserStatus Status
		{
			get
			{
				return this.status;
			}
			set
			{
				if (this.status == value)
				{
					return;
				}
				this.status = value;
				if (this.ownerListItem != null)
				{
					this.ownerListItem.SubItems.Sort();
				}
			}
		}
		public bool IsTwinkle
		{
			get
			{
				return this.isTwinkle;
			}
			set
			{
				if (this.isTwinkle == value)
				{
					return;
				}
				if (this.ownerListItem == null)
				{
					return;
				}
				this.isTwinkle = value;
				if (this.isTwinkle)
				{
					this.ownerListItem.TwinkleSubItemNumber++;
					return;
				}
				this.ownerListItem.TwinkleSubItemNumber--;
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
		public Rectangle HeadRect
		{
			get
			{
				return this.headRect;
			}
			set
			{
				this.headRect = value;
			}
		}
		[Browsable(false)]
		public ChatListItem OwnerListItem
		{
			get
			{
				return this.ownerListItem;
			}
			set
			{
				this.ownerListItem = value;
			}
		}
		public ChatListSubItem Clone()
		{
			return new ChatListSubItem
			{
				Bounds = this.Bounds,
				DisplayName = this.DisplayName,
				HeadImage = this.HeadImage,
				HeadRect = this.HeadRect,
				ID = this.ID,
				IpAddress = this.IpAddress,
				IsTwinkle = this.IsTwinkle,
				IsTwinkleHide = this.isTwinkleHide,
				NicName = this.NicName,
				OwnerListItem = this.OwnerListItem.Clone(),
				PersonalMsg = this.PersonalMsg,
				Status = this.Status,
				TcpPort = this.TcpPort,
				UpdPort = this.UpdPort,
				Tag = this.Tag
			};
		}
		private void RedrawSubItem()
		{
			if (this.ownerListItem != null && this.ownerListItem.OwnerChatListBox != null)
			{
				this.ownerListItem.OwnerChatListBox.Invalidate(this.bounds);
			}
		}
		public Bitmap GetDarkImage()
		{
			Bitmap bitmap = new Bitmap(this.headImage);
			Bitmap bitmap2 = bitmap.Clone(new Rectangle(0, 0, this.headImage.Width, this.headImage.Height), PixelFormat.Format24bppRgb);
			bitmap.Dispose();
			BitmapData bitmapData = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadWrite, bitmap2.PixelFormat);
			byte[] array = new byte[bitmap2.Height * bitmapData.Stride];
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			int i = 0;
			int width = bitmap2.Width;
			while (i < width)
			{
				int j = 0;
				int height = bitmap2.Height;
				while (j < height)
				{
					array[j * bitmapData.Stride + i * 3] = (array[j * bitmapData.Stride + i * 3 + 1] = (array[j * bitmapData.Stride + i * 3 + 2] = this.GetAvg(array[j * bitmapData.Stride + i * 3], array[j * bitmapData.Stride + i * 3 + 1], array[j * bitmapData.Stride + i * 3 + 2])));
					j++;
				}
				i++;
			}
			Marshal.Copy(array, 0, bitmapData.Scan0, array.Length);
			bitmap2.UnlockBits(bitmapData);
			return bitmap2;
		}
		private byte GetAvg(byte b, byte g, byte r)
		{
			return Convert.ToByte((r + g + b) / 3);
		}
		private bool CheckIpAddress(string str)
		{
			if (str == null)
			{
				return false;
			}
			string[] array = str.Split(new char[]
			{
				'.'
			});
			if (array.Length != 4)
			{
				return false;
			}
			for (int i = 0; i < 4; i++)
			{
				try
				{
					if (Convert.ToInt32(str[i]) > 255)
					{
						bool result = false;
						return result;
					}
				}
				catch (FormatException)
				{
					bool result = false;
					return result;
				}
			}
			return true;
		}
		int IComparable.CompareTo(object obj)
		{
			if (!(obj is ChatListSubItem))
			{
				throw new NotImplementedException("obj is not ChatListSubItem");
			}
			ChatListSubItem chatListSubItem = obj as ChatListSubItem;
			return this.status.CompareTo(chatListSubItem.status);
		}
		public ChatListSubItem()
		{
			this.status = ChatListSubItem.UserStatus.Online;
			this.displayName = "displayName";
			this.nicName = "nicName";
			this.personalMsg = "Personal Message ...";
		}
		public ChatListSubItem(string nicname)
		{
			this.nicName = nicname;
		}
		public ChatListSubItem(string nicname, ChatListSubItem.UserStatus status)
		{
			this.nicName = nicname;
			this.status = status;
		}
		public ChatListSubItem(string nicname, string displayname, string personalmsg)
		{
			this.nicName = nicname;
			this.displayName = displayname;
			this.personalMsg = personalmsg;
		}
		public ChatListSubItem(string nicname, string displayname, string personalmsg, ChatListSubItem.UserStatus status)
		{
			this.nicName = nicname;
			this.displayName = displayname;
			this.personalMsg = personalmsg;
			this.status = status;
		}
		public ChatListSubItem(int id, string nicname, string displayname, string personalmsg, ChatListSubItem.UserStatus status, Bitmap head)
		{
			this.id = id;
			this.nicName = nicname;
			this.displayName = displayname;
			this.personalMsg = personalmsg;
			this.status = status;
			this.headImage = head;
		}
	}
}
