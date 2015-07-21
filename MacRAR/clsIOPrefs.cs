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
			return this.OpenFileDialog (window, FileTypes,"Selecione");
		}

		public string OpenFileDialog (NSWindow window, string[] FileTypes, string title, bool canchoosedirectories = false, bool canchoosefiles = true)
		{
			string path = string.Empty;
			try {
				NSOpenPanel dlg = NSOpenPanel.OpenPanel;
				//dlg.Prompt = "Selecione um Arquivo";
				dlg.Title = title;
				dlg.CanChooseFiles = canchoosefiles;
				dlg.CanChooseDirectories = canchoosedirectories;
				dlg.AllowedFileTypes = FileTypes; 
				dlg.AllowsMultipleSelection=false;
				dlg.ResolvesAliases=true;
				dlg.ReleasedWhenClosed = true;

//				dlg.BeginSheet(window, (i) => { 
//					try
//					{
//						if(dlg.Url != null)
//						{
//
//
//							var urlString = dlg.Url.Path;
//
//							if(!string.IsNullOrEmpty(urlString))
//							{
//								Console.WriteLine(urlString);
//							}
//						}
//					}
//					finally
//					{
//						dlg.Dispose();
//					}
//				});
//



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
			} catch (Exception) {
				//
			}
			return path;
		}




	}
}

