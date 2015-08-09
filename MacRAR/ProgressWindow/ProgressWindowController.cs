using System;

using Foundation;
using AppKit;


namespace MacRAR
{
	public class ProgressWindowController : NSObject
	{

		public bool Canceled { get; set;}

		[Outlet]
		AppKit.NSTextField lbl_outProcArq { get; set; }

		[Outlet]
		AppKit.NSProgressIndicator pgr_outProgressBar { get; set; }

		[Export("window")]
		public ProgressWindow Window { get; set;}

		public ProgressWindowController ()
		{
			NSBundle.LoadNib ("ProgressWindow", this);
		}

		public void ShowSheet(NSWindow inWindow) {
			NSApplication.SharedApplication.BeginSheet (Window, inWindow);
		}

		public void CloseSheet() {
			NSApplication.SharedApplication.EndSheet (Window);
			Window.Close();
		}

		[Export ("btn_actCancelar:")]
		void btn_actCancelar (Foundation.NSObject sender)
		{
			Canceled = true;
			this.CloseSheet();
//			this.RaiseProgressCanceled ();
		}

		public string LabelArqValue {
			get { return this.lbl_outProcArq.StringValue; }
			set { this.lbl_outProcArq.StringValue = value; }
		}

		public double ProgressBarValue {
			get { return this.pgr_outProgressBar.DoubleValue; }
			set { this.pgr_outProgressBar.DoubleValue = value; }
		}

		public double ProgressBarMinValue {
			get { return this.pgr_outProgressBar.MinValue; }
			set { this.pgr_outProgressBar.MinValue = value; }
		}

		public double ProgressBarMaxValue {
			get { return this.pgr_outProgressBar.MaxValue; }
			set { this.pgr_outProgressBar.MaxValue = value; }
		}

		public bool ProgressBarIndeterminate {
			get { return this.pgr_outProgressBar.Indeterminate; }
			set { this.pgr_outProgressBar.Indeterminate = value; }
		}

//		public delegate void ProgressWindowCanceledDelegate();
//		public event ProgressWindowCanceledDelegate ProgressCanceled;
//
//		internal void RaiseProgressCanceled() {
//			if (this.ProgressCanceled != null) {
//				this.ProgressCanceled();
//			}
//		}

	}
}

