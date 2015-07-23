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
	[Register ("progressWindow")]
	partial class progressWindow
	{
		[Outlet]
		AppKit.NSButton btn_outCancela { get; set; }

		[Outlet]
		AppKit.NSTextField lbl_ProcArq { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator pb_Arquivos { get; set; }

		[Outlet]
		MacRAR.progressWindow window { get; set; }

		[Action ("btn_actCancela:")]
		partial void btn_actCancela (Foundation.NSObject sender);

		[Action ("btn_Cancela:")]
		partial void btn_Cancela (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (window != null) {
				window.Dispose ();
				window = null;
			}

			if (pb_Arquivos != null) {
				pb_Arquivos.Dispose ();
				pb_Arquivos = null;
			}

			if (btn_outCancela != null) {
				btn_outCancela.Dispose ();
				btn_outCancela = null;
			}

			if (lbl_ProcArq != null) {
				lbl_ProcArq.Dispose ();
				lbl_ProcArq = null;
			}
		}
	}
}
