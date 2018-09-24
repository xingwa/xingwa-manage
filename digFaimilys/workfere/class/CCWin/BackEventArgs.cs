using System;
using System.Drawing;
namespace xingwaWinFormUI
{
	public class BackEventArgs
	{
		private Image beforeBack;
		private Image afterBack;
		public Image BeforeBack
		{
			get
			{
				return this.beforeBack;
			}
		}
		public Image AfterBack
		{
			get
			{
				return this.afterBack;
			}
		}
		public BackEventArgs(Image beforeBack, Image afterBack)
		{
			this.beforeBack = beforeBack;
			this.afterBack = afterBack;
		}
	}
}
