using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public partial class MainWindow : NSWindow
	{
		public MainWindow (IntPtr handle) : base (handle)
		{
		}

		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
		}

		public override void AwakeFromNib ()
		{
			base.AwakeFromNib ();
		
		}

		partial void tb_ActConfig (Foundation.NSObject sender)
		{
			ConfigWindowController sheet = new ConfigWindowController();
			sheet.ShowConfigWindow (this);
		}

		partial void tb_actAbrir (Foundation.NSObject sender)
		{
			clsOpenRAR oRAR = new clsOpenRAR ();
			oRAR.OpenRAR (this);
			oRAR = null;
		}

		partial void tb_ActSair (Foundation.NSObject sender)
		{
			PerformClose (this);

		}

	}
}
