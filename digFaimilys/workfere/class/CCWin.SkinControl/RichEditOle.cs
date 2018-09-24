using xingwaWinFormUI.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace xingwaWinFormUI.SkinControl
{
	public class RichEditOle
	{
		private SkinRichTextBox _richEdit;
		private IRichEditOle _richEditOle;
		public IRichEditOle IRichEditOle
		{
			get
			{
				if (this._richEditOle == null)
				{
					this._richEditOle = NativeMethods.SendMessage(this._richEdit.Handle, 1084, 0);
				}
				return this._richEditOle;
			}
		}
		public RichEditOle(SkinRichTextBox richEdit)
		{
			this._richEdit = richEdit;
		}
		public void InsertControl(Control control)
		{
			if (control != null)
			{
				Guid clsid = Marshal.GenerateGuidForType(control.GetType());
				ILockBytes lockBytes;
				NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out lockBytes);
				IStorage storage;
				NativeMethods.StgCreateDocfileOnILockBytes(lockBytes, 4114u, 0u, out storage);
				IOleClientSite oleClientSite;
				this.IRichEditOle.GetClientSite(out oleClientSite);
				REOBJECT rEOBJECT = new REOBJECT();
				rEOBJECT.cp = this._richEdit.TextLength;
				rEOBJECT.clsid = clsid;
				rEOBJECT.pstg = storage;
				rEOBJECT.poleobj = Marshal.GetIUnknownForObject(control);
				rEOBJECT.polesite = oleClientSite;
				rEOBJECT.dvAspect = 1u;
				rEOBJECT.dwFlags = 2u;
				rEOBJECT.dwUser = 1u;
				this.IRichEditOle.InsertObject(rEOBJECT);
				Marshal.ReleaseComObject(lockBytes);
				Marshal.ReleaseComObject(oleClientSite);
				Marshal.ReleaseComObject(storage);
			}
		}
		public bool InsertImageFromFile(string strFilename)
		{
			ILockBytes lockBytes;
			NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out lockBytes);
			IStorage storage;
			NativeMethods.StgCreateDocfileOnILockBytes(lockBytes, 4114u, 0u, out storage);
			IOleClientSite oleClientSite;
			this.IRichEditOle.GetClientSite(out oleClientSite);
			FORMATETC fORMATETC = default(FORMATETC);
			fORMATETC.cfFormat = (CLIPFORMAT)0;
			fORMATETC.ptd = IntPtr.Zero;
			fORMATETC.dwAspect = DVASPECT.DVASPECT_CONTENT;
			fORMATETC.lindex = -1;
			fORMATETC.tymed = TYMED.TYMED_NULL;
			Guid guid = new Guid("{00000112-0000-0000-C000-000000000046}");
			Guid guid2 = new Guid("{00000000-0000-0000-0000-000000000000}");
			object obj;
			NativeMethods.OleCreateFromFile(ref guid2, strFilename, ref guid, 1u, ref fORMATETC, oleClientSite, storage, out obj);
			if (obj == null)
			{
				Marshal.ReleaseComObject(lockBytes);
				Marshal.ReleaseComObject(oleClientSite);
				Marshal.ReleaseComObject(storage);
				return false;
			}
			IOleObject oleObject = (IOleObject)obj;
			Guid clsid = default(Guid);
			oleObject.GetUserClassID(ref clsid);
			NativeMethods.OleSetContainedObject(oleObject, true);
			REOBJECT rEOBJECT = new REOBJECT();
			rEOBJECT.cp = this._richEdit.TextLength;
			rEOBJECT.clsid = clsid;
			rEOBJECT.pstg = storage;
			rEOBJECT.poleobj = Marshal.GetIUnknownForObject(oleObject);
			rEOBJECT.polesite = oleClientSite;
			rEOBJECT.dvAspect = 1u;
			rEOBJECT.dwFlags = 2u;
			rEOBJECT.dwUser = 0u;
			this.IRichEditOle.InsertObject(rEOBJECT);
			Marshal.ReleaseComObject(lockBytes);
			Marshal.ReleaseComObject(oleClientSite);
			Marshal.ReleaseComObject(storage);
			Marshal.ReleaseComObject(oleObject);
			return true;
		}
		public REOBJECT InsertOleObject(IOleObject oleObject, int index)
		{
			if (oleObject == null)
			{
				return null;
			}
			ILockBytes lockBytes;
			NativeMethods.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out lockBytes);
			IStorage storage;
			NativeMethods.StgCreateDocfileOnILockBytes(lockBytes, 4114u, 0u, out storage);
			IOleClientSite oleClientSite;
			this.IRichEditOle.GetClientSite(out oleClientSite);
			Guid clsid = default(Guid);
			oleObject.GetUserClassID(ref clsid);
			NativeMethods.OleSetContainedObject(oleObject, true);
			REOBJECT rEOBJECT = new REOBJECT();
			rEOBJECT.cp = this._richEdit.TextLength;
			rEOBJECT.clsid = clsid;
			rEOBJECT.pstg = storage;
			rEOBJECT.poleobj = Marshal.GetIUnknownForObject(oleObject);
			rEOBJECT.polesite = oleClientSite;
			rEOBJECT.dvAspect = 1u;
			rEOBJECT.dwFlags = 2u;
			rEOBJECT.dwUser = (uint)index;
			this.IRichEditOle.InsertObject(rEOBJECT);
			Marshal.ReleaseComObject(lockBytes);
			Marshal.ReleaseComObject(oleClientSite);
			Marshal.ReleaseComObject(storage);
			return rEOBJECT;
		}
		public void UpdateObjects()
		{
			int objectCount = this.IRichEditOle.GetObjectCount();
			for (int i = 0; i < objectCount; i++)
			{
				REOBJECT rEOBJECT = new REOBJECT();
				this.IRichEditOle.GetObject(i, rEOBJECT, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
				Point positionFromCharIndex = this._richEdit.GetPositionFromCharIndex(rEOBJECT.cp);
				Rectangle rc = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, 50, 50);
				this._richEdit.Invalidate(rc, false);
			}
		}
		public void UpdateObjects(int pos)
		{
			REOBJECT rEOBJECT = new REOBJECT();
			this.IRichEditOle.GetObject(pos, rEOBJECT, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
			this.UpdateObjects(rEOBJECT);
		}
		public void UpdateObjects(REOBJECT reObj)
		{
			Point positionFromCharIndex = this._richEdit.GetPositionFromCharIndex(reObj.cp);
			Size sizeFromMillimeter = this.GetSizeFromMillimeter(reObj);
			Rectangle rc = new Rectangle(positionFromCharIndex, sizeFromMillimeter);
			this._richEdit.Invalidate(rc, false);
		}
		private Size GetSizeFromMillimeter(REOBJECT lpreobject)
		{
			Size result;
			using (Graphics graphics = Graphics.FromHwnd(this._richEdit.Handle))
			{
				Point[] array = new Point[1];
				graphics.PageUnit = GraphicsUnit.Millimeter;
				array[0] = new Point(lpreobject.sizel.Width / 100, lpreobject.sizel.Height / 100);
				graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, array);
				result = new Size(array[0]);
			}
			return result;
		}
	}
}
