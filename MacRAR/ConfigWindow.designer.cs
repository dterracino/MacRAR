// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacRAR
{
	[Register ("ConfigWindow")]
	partial class ConfigWindow
	{
		[Outlet]
		AppKit.NSTextField txt_RAR { get; set; }

		[Outlet]
		AppKit.NSTextField txt_UNRAR { get; set; }

		[Outlet]
		MacRAR.ConfigWindow window { get; set; }

		[Action ("btn_CaminhoRAR:")]
		partial void btn_CaminhoRAR (Foundation.NSObject sender);

		[Action ("btn_CaminhoUNRAR:")]
		partial void btn_CaminhoUNRAR (Foundation.NSObject sender);

		[Action ("btn_Cancela:")]
		partial void btn_Cancela (Foundation.NSObject sender);

		[Action ("btn_Confirma:")]
		partial void btn_Confirma (Foundation.NSObject sender);

		[Action ("x:")]
		partial void x (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txt_RAR != null) {
				txt_RAR.Dispose ();
				txt_RAR = null;
			}

			if (txt_UNRAR != null) {
				txt_UNRAR.Dispose ();
				txt_UNRAR = null;
			}

			if (window != null) {
				window.Dispose ();
				window = null;
			}
		}
	}
}
