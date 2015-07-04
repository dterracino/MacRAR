using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class ConfigWindowController : NSObject 
	{

		[Export("window")]
		public ConfigWindow Window { get; set;}

		[Outlet]
		public NSTextField txt_RAR { get; set; }

		[Outlet]
		public NSTextField txt_UNRAR { get; set; }

		public ConfigWindowController ()
		{
			NSBundle.LoadNib ("ConfigWindow", this);
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			this.txt_RAR.StringValue  = ioPrefs.GetStringValue ("CaminhoRAR");
			this.txt_UNRAR.StringValue  = ioPrefs.GetStringValue ("CaminhoUNRAR");
			ioPrefs = null;
		}

		public void ShowConfigWindow(NSWindow inWindow) {
			NSApplication.SharedApplication.BeginSheet (Window, inWindow);
		}

		public void CloseConfigWindow() {
			NSApplication.SharedApplication.EndSheet (Window);
			Window.Close();
		}

		[Export ("btn_Cancela:")]
		void btn_Cancela (NSObject sender) {
			CloseConfigWindow();
		}

		[Export ("btn_Confirma:")]
		void btn_Confirma (NSObject sender) {
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			ioPrefs.SetStringValue("CaminhoRAR",this.txt_RAR.StringValue);
			ioPrefs.SetStringValue ("CaminhoUNRAR", this.txt_UNRAR.StringValue);
			ioPrefs = null;
			CloseConfigWindow();
		}

		[Export ("btn_CaminhoRAR:")]
		void btn_CaminhoRAR (NSObject sender)
		{
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			this.txt_RAR.StringValue = ioPrefs.OpenFileDialog (Window);
			ioPrefs = null;
		}

		[Export ("btn_CaminhoUNRAR:")]
		void btn_CaminhoUNRAR (NSObject sender)
		{
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			this.txt_UNRAR.StringValue = ioPrefs.OpenFileDialog (Window);
			ioPrefs = null;
		}
			
	}
}

