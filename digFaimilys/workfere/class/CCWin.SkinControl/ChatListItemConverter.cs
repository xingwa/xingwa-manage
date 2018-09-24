using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
namespace xingwaWinFormUI.SkinControl
{
	public class ChatListItemConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("DestinationType cannot be null");
			}
			if (destinationType == typeof(InstanceDescriptor) && value is ChatListItem)
			{
				ConstructorInfo constructorInfo = null;
				ChatListItem chatListItem = (ChatListItem)value;
				ChatListSubItem[] array = null;
				if (chatListItem.SubItems.Count > 0)
				{
					array = new ChatListSubItem[chatListItem.SubItems.Count];
					chatListItem.SubItems.CopyTo(array, 0);
				}
				if (chatListItem.Text != null && array != null)
				{
					constructorInfo = typeof(ChatListItem).GetConstructor(new Type[]
					{
						typeof(string),
						typeof(ChatListSubItem[])
					});
				}
				if (constructorInfo != null)
				{
					return new InstanceDescriptor(constructorInfo, new object[]
					{
						chatListItem.Text,
						array
					}, false);
				}
				if (array != null)
				{
					constructorInfo = typeof(ChatListItem).GetConstructor(new Type[]
					{
						typeof(ChatListSubItem[])
					});
				}
				if (constructorInfo != null)
				{
					return new InstanceDescriptor(constructorInfo, new object[]
					{
						array
					}, false);
				}
				if (chatListItem.Text != null)
				{
					constructorInfo = typeof(ChatListItem).GetConstructor(new Type[]
					{
						typeof(string),
						typeof(bool)
					});
				}
				if (constructorInfo != null)
				{
					return new InstanceDescriptor(constructorInfo, new object[]
					{
						chatListItem.Text,
						chatListItem.IsOpen
					});
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
