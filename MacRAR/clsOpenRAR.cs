using System;

using Foundation;
using AppKit;
using System.Collections.Generic ;

namespace MacRAR
{
	public class clsOpenRAR
	{

		public void OpenRAR(NSWindow window)
		{
			string[] filetypes = {"rar"};
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			string path = ioPrefs.OpenFileDialog (window, filetypes);
			if (path.Length > 0) {
				string txtRAR = ioPrefs.GetStringValue ("CaminhoRAR");
				if (txtRAR.Length > 0) {
					string[] launchArgs = {"vt",  path};
					NSPipe pipeOut = new NSPipe ();
					NSTask t =  new NSTask();
					t.LaunchPath = txtRAR;
					t.Arguments = launchArgs;
					t.StandardOutput = pipeOut;
					t.Launch ();
					t.WaitUntilExit ();
					t.Dispose ();
					t = null;
					string txtRET = pipeOut.ReadHandle.ReadDataToEndOfFile ().ToString ();
					pipeOut.Dispose ();
					pipeOut = null;
					int pos = txtRET.IndexOf ("Name:");
					if (pos > 0) {
						txtRET = txtRET.Substring (pos);
						List<string> nomes = new List<string>();
						do {
							pos = txtRET.IndexOf ("Name:",pos + 1);
							if (pos<0) {
								nomes.Add (txtRET.Trim());
								break;
							}
							nomes.Add(txtRET.Substring(0, pos - 2).Trim());
							txtRET = txtRET.Substring(pos);
							pos = 0;
						} while (true);
					} else {
						NSAlert alert = new NSAlert () {
							AlertStyle = NSAlertStyle.Warning,
							InformativeText = "Não foi possível processar o arquivo:\r\n" + path,
							MessageText = "Abrir Arquivo", 
						};
						alert.BeginSheet (window);
					}


				}

			}
			ioPrefs = null;
		}
	}
}

