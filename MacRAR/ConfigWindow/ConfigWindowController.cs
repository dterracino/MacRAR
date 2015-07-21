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

		[Outlet]
		AppKit.NSSlider sld_Compressao { get; set; }


		public ConfigWindowController ()
		{
			NSBundle.LoadNib ("ConfigWindow", this);
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			this.txt_RAR.StringValue  = ioPrefs.GetStringValue ("CaminhoRAR");
			this.txt_UNRAR.StringValue  = ioPrefs.GetStringValue ("CaminhoUNRAR");
			string retConv = ioPrefs.GetStringValue ("Compressao");
			if (retConv.Length > 0) {
				this.sld_Compressao.IntValue =Convert.ToInt32(ioPrefs.GetStringValue ("Compressao"));
			} else {
				this.sld_Compressao.IntValue = 5;
			}
			ioPrefs = null;
			this.sld_Compressao.AllowsTickMarkValuesOnly = true;
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
			int sldVlr = this.sld_Compressao.IntValue;
			if (sldVlr < 5) {
				sldVlr = sldVlr + 1;
			}
			ioPrefs.SetStringValue ("Compressao", sldVlr.ToString());
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

