using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class clsOpenRAR
	{

		public void OpenRAR(NSWindow window)
		{
			string[] filetypes = {"rar"};
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			string path = ioPrefs.OpenFileDialog (window, filetypes);
			ioPrefs = null;
			if (path.Length > 0) {
			


			}

		}
	}
}

