using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class clsIOPrefs
	{

		public string GetStringValue(string key)
		{
			string value = string.Empty;
			try {
				value = NSUserDefaults.StandardUserDefaults.StringForKey(key); 
				if (value == null)
					value = "";
				
			} catch (Exception) {
//				
			}

			return value;
		}

		public void SetStringValue(string key,string value)
		{
			try {
				NSUserDefaults.StandardUserDefaults.SetString(value.ToString (), key); 
				NSUserDefaults.StandardUserDefaults.Synchronize ();

			} catch (Exception) {
				
			}
		}

		public string OpenFileDialog(NSWindow window)
		{
			string[] FileTypes = { "" };
			return this.OpenFileDialog (window, FileTypes);
		}
			


		public string OpenFileDialog (NSWindow window, string[] FileTypes)
		{
			string path = string.Empty;
			NSOpenPanel dlg = NSOpenPanel.OpenPanel;
			//dlg.Prompt = "Selecione um Arquivo";
			dlg.Title = "Selecione";
			dlg.CanChooseFiles = true;
			dlg.CanChooseDirectories = false;
			dlg.AllowedFileTypes = FileTypes; 
			dlg.ReleasedWhenClosed = true;
			nint retDlg = dlg.RunModal ();
			if (retDlg == 1) {
				NSUrl url = dlg.Urls [0];
				if (url != null) {
					path = url.Path;
				}
			}
			NSDate DateLoop = new NSDate ();
			DateLoop = DateLoop.AddSeconds (0.1);
			NSRunLoop.Current.RunUntil(DateLoop );
			dlg.Dispose ();
			dlg = null;
			return path;
		}
	}
}

//				dlg.BeginSheet (window, result => {
//					if (result == 1) {
//						if (dlg.Url != null) {
//							path = dlg.Url.Path;
//						}   
//					}
//				});
