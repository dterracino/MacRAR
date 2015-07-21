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
			nint result = alert.RunSheetModal ((NSWindow)sender);
			//nint result = alert.RunModal ();
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

		public bool tb_outDesfazerActive {
			get {
				return this.tb_outDesfazer.Active;
			}
			set {
				this.tb_outDesfazer.Active = value;
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
			this.tb_outDesfazerActive = false;

		}

		partial void tb_ActConfig (Foundation.NSObject sender)
		{
			ConfigWindowController sheet = new ConfigWindowController();
			sheet.ShowConfigWindow (this);
		}

		partial void tb_actAbrir (Foundation.NSObject sender)
		{
			this.procBtn(4);
		}

		partial void tb_ActSair (Foundation.NSObject sender)
		{
			PerformClose (this);
		}

		partial void btn_SelTudo (Foundation.NSObject sender)
		{
			this.tbv_Arquivos.SelectAll (this);
		}

		partial void tb_ActAdicionar (NSObject sender)
		{
			
		}

		partial void tb_ActExtrair (NSObject sender)
		{
			this.procBtn(3);
		}

		partial void tb_actAtualizar (NSObject sender)
		{
	
		}


		partial void tb_actDesfazer (Foundation.NSObject sender)
		{
			this.procBtn(2);
		}

		partial void tb_actRemover (NSObject sender)
		{
			this.procBtn(1);
		}

		private void procBtn(int state = 1)
		{

			if (state == 4) {
				string[] filetypes = {"rar"};
				NSOpenPanel dlg = NSOpenPanel.OpenPanel;
				dlg.Title = "Selecione";
				dlg.CanChooseFiles = true;
				dlg.CanChooseDirectories = false;
				dlg.AllowedFileTypes =filetypes; 
				dlg.AllowsMultipleSelection=false;
				dlg.ResolvesAliases=true;
				dlg.ReleasedWhenClosed = true;
				dlg.BeginSheet(this, (i) => { 
					try
					{
						if(dlg.Url != null)
						{
							var urlString = dlg.Url.Path;
							if(!string.IsNullOrEmpty(urlString))
							{
								clsRAR orar = new clsRAR();
								orar.OpenRAR(urlString, this, this.tbv_Arquivos);
								orar=null;
							}
						}
					}
					finally
					{
						dlg.Dispose();
					}
				});
			} else {
				NSIndexSet nSelRows = this.tbv_Arquivos.SelectedRows ;
				if (nSelRows.Count > 0) {
					nuint[] nRows = nSelRows.ToArray ();
					if (nRows.Length > 0) {
						ViewArquivosDataSource datasource = (ViewArquivosDataSource)this.tbv_Arquivos.DataSource;
						clsViewArquivos cvarqs = new clsViewArquivos ();
						string aState = string.Empty;
						foreach (nint lRow in nRows) {
							switch (state) {
							case 1:
								aState = "1";
								break;
							case 2:
								aState = cvarqs.GetTagsArquivo (datasource, (int)lRow, 1);
								break;
							case 3:
								break;
							}
							if(state != 3){
								cvarqs.SetTagsArquivo (datasource, (int)lRow, aState);
							}else {


								//							clsOpenRAR orar = new clsOpenRAR();
								//							orar.ExtractRAR(this, this.tbv_Arquivos);
								//							orar=null;
							}

							//					clsViewArquivos clvarq = new clsViewArquivos();
							//					clvarq.SetStateArquivo(tbv_Arquivos.GetRowView(lRow,false),(NSTableCellView)tbv_Arquivos.GetView(0,lRow,false),1);
							//
							//
							//					clvarq=null;

						}
						cvarqs = null;
						datasource = null;
						this.tbv_Arquivos.ReloadData ();
					}
				} else {
					string mText = string.Empty;
					string iText = string.Empty;
					switch (state) {
					case 1:
						mText = "Remover Arquivo(s)";
						iText = "Selecione ao menos um aquivo para Remover !";
						break;
					case 2:
						mText = "Desfazer Ação";
						iText = "Selecione ao menos um arquivo para\r\n Desfazer a Ação !";
						break;
					case 3:
						mText = "Extrair Arquivos";
						iText = "Selecione ao menos um arquivo para Extrair !";
						break;
					}

					NSAlert alert = new NSAlert () {

						AlertStyle = NSAlertStyle.Warning,
						InformativeText = iText,
						MessageText = mText , 
					};
					alert.RunSheetModal (this);
				}

			}
		}

	}
}
