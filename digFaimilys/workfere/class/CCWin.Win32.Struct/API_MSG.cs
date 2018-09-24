using System;
using System.Windows.Forms;
namespace xingwaWinFormUI.Win32.Struct
{
	public struct API_MSG
	{
		public IntPtr Hwnd;
		public int Msg;
		public IntPtr WParam;
		public IntPtr LParam;
		public int Time;
		public POINT Pt;
		public Message ToMessage()
		{
			return new Message
			{
				HWnd = this.Hwnd,
				Msg = this.Msg,
				WParam = this.WParam,
				LParam = this.LParam
			};
		}
		public void FromMessage(ref Message msg)
		{
			this.Hwnd = msg.HWnd;
			this.Msg = msg.Msg;
			this.WParam = msg.WParam;
			this.LParam = msg.LParam;
		}
	}
}
