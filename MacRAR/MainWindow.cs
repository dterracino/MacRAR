using System;

using Foundation;
using AppKit;

namespace MacRAR
{

	public class TestDelegate : NSWindowDelegate
	{
		public override bool WindowShouldClose (NSObject sender)
		{

			NSAlert alert = new NSAlert () {
				AlertStyle = NSAlertStyle.Warning,
				InformativeText = "Deseja realmente encerrar o MacRAR ?",
				MessageText = "Encerrar MacRAR", 
			};
			alert.AddButton ("Não");
			alert.AddButton ("Sim");
			nint result = alert.RunModal ();
			if (result == 1001) {
				NSApplication.SharedApplication.Terminate (this);
				return true;
			} else {
				return false;
			}
		}
	}

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
		
			this.Delegate = new TestDelegate();

		}

		partial void tb_ActConfig (Foundation.NSObject sender)
		{
			ConfigWindowController sheet = new ConfigWindowController();
			sheet.ShowConfigWindow (this);
		}

		partial void tb_actAbrir (Foundation.NSObject sender)
		{
			clsOpenRAR oRAR = new clsOpenRAR ();
			oRAR.OpenRAR (this, this.tbv_Arquivos, this.chk_outSelAll  );
			oRAR = null;
		}

		partial void tb_ActSair (Foundation.NSObject sender)
		{
			PerformClose (this);
		}

		partial void chk_actSelAll (Foundation.NSObject sender)
		{
			if(this.chk_outSelAll.State == NSCellStateValue.On)
			{
				this.tbv_Arquivos.SelectAll (this);
			}
			else{
				this.tbv_Arquivos.DeselectAll(this);
			}
		}

	}
}
