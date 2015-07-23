using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class progressWindowController : NSObject 
	{

		[Export("window")]
		public progressWindow  Window { get; set;}

		[Outlet]
		AppKit.NSProgressIndicator pb_Arquivos { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_ProcArq { get; set; }

		public string lblProcArq {
			get { return lbl_ProcArq.StringValue ; }
			set { lbl_ProcArq.StringValue = value; }
		}

		public void ShowSheet(NSWindow inWindow) {
			NSApplication.SharedApplication.BeginSheet (Window, inWindow);
		}

		public void CloseSheet() {
			NSApplication.SharedApplication.EndSheet (Window);
			Window.Close();
		}

		[Export ("btn_actCancela:")]
		void LoginCancel (NSObject sender) {
			
			CloseSheet();
			//RaiseLoginCanceled ();
		}

		public progressWindowController ()
		{
			// Load the .xib file for the sheet
			NSBundle.LoadNib ("progressWindow", this);
		}
	}
}

