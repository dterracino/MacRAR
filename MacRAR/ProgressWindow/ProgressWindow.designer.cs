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
	[Register ("ProgressWindow")]
	partial class ProgressWindow
	{
		[Outlet]
		AppKit.NSTextField lbl_outProcArq { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator pgr_outProgressBar { get; set; }

		[Outlet]
		MacRAR.ProgressWindow window { get; set; }

		[Action ("btn_actCancelar:")]
		partial void btn_actCancelar (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (window != null) {
				window.Dispose ();
				window = null;
			}

			if (lbl_outProcArq != null) {
				lbl_outProcArq.Dispose ();
				lbl_outProcArq = null;
			}

			if (pgr_outProgressBar != null) {
				pgr_outProgressBar.Dispose ();
				pgr_outProgressBar = null;
			}
		}
	}
}
