using System;
using System.Drawing;
using System.Runtime.InteropServices;
namespace xingwaWinFormUI.SkinControl
{
	[StructLayout(LayoutKind.Sequential)]
	public class REOBJECT
	{
		public int cbStruct = Marshal.SizeOf(typeof(REOBJECT));
		public int cp;
		public Guid clsid;
		public IntPtr poleobj;
		public IStorage pstg;
		public IOleClientSite polesite;
		public Size sizel;
		public uint dvAspect;
		public uint dwFlags;
		public uint dwUser;
	}
}
