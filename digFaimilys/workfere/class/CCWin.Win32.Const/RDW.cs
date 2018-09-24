using System;
namespace xingwaWinFormUI.Win32.Const
{
	public class RDW
	{
		public const int RDW_INVALIDATE = 1;
		public const int RDW_INTERNALPAINT = 2;
		public const int RDW_ERASE = 4;
		public const int RDW_VALIDATE = 8;
		public const int RDW_NOINTERNALPAINT = 16;
		public const int RDW_NOERASE = 32;
		public const int RDW_NOCHILDREN = 64;
		public const int RDW_ALLCHILDREN = 128;
		public const int RDW_UPDATENOW = 256;
		public const int RDW_ERASENOW = 512;
		public const int RDW_FRAME = 1024;
		public const int RDW_NOFRAME = 2048;
		private RDW()
		{
		}
	}
}
