using System;

using Foundation;
using AppKit;
using System.Collections.Generic;

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

		public bool tb_outAdicionarActive {
			get {
				return this.tb_outAdicionar.Active;
			}
			set {
				this.tb_outAdicionar.Active = value;
			}
		}

		public bool tb_outAtualizarActive {
			get {
				return this.tb_outAtualizar.Active;
			}
			set {
				this.tb_outAtualizar.Active = value;
			}
		}

		public bool tb_outExtrairActive {
			get {
				return this.tb_outExtrair.Active;
			}
			set {
				this.tb_outExtrair.Active = value;
			}
		}

		public bool tb_outRemoverActive {
			get {
				return this.tb_outRemover.Active;
			}
			set {
				this.tb_outRemover.Active = value;
			}
		}

		public string rarFile = string.Empty;

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

			this.tb_outAdicionarActive = false;
			this.tb_outAtualizarActive = false;
			this.tb_outExtrairActive = false;
			this.tb_outRemoverActive = false;

		}

		partial void tb_ActConfig (Foundation.NSObject sender)
		{
			ConfigWindowController sheet = new ConfigWindowController();
			sheet.ShowConfigWindow (this);
		}

		partial void tb_actAbrir (Foundation.NSObject sender)
		{
			clsOpenRAR oRAR = new clsOpenRAR ();
			rarFile = oRAR.OpenRAR (this, this.tbv_Arquivos, this.chk_outSelAll  );
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

		partial void tb_ActAdicionar (NSObject sender)
		{
			
		}

		partial void tb_ActExtrair (NSObject sender)
		{

		}

		partial void tb_actAtualizar (NSObject sender)
		{
	
		}

		partial void tb_actRemover (NSObject sender)
		{
			NSIndexSet nSelRows = this.tbv_Arquivos.SelectedRows ;
			if(nSelRows.Count>0)
			{
				nuint[] nRows = nSelRows.ToArray ();
				foreach(nint lRow in nRows)
				{
					NSTableCellView view = (NSTableCellView)tbv_Arquivos.GetView(0,lRow,false);
					NSTableRowView tbv = tbv_Arquivos.GetRowView(lRow,false);
					clsViewArquivos clvarq = new clsViewArquivos();
					clvarq.SetStateArquivo(tbv,view,1);
					clvarq=null;
				}
			}
		}

	}
}
