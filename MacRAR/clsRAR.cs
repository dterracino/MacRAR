using System;
using System.IO;

using Foundation;
using AppKit;
using System.Collections.Generic ;

namespace MacRAR
{
	public class clsRAR
	{
		public string OpenRAR(string path, MainWindow  window, NSTableView TableView)
		{
			if (path.Length > 0) {
				clsIOPrefs ioPrefs = new clsIOPrefs ();
				string txtRAR = ioPrefs.GetStringValue ("CaminhoRAR");
				if (txtRAR.Length > 0) {
					string[] launchArgs = {"vt",  path};
					NSPipe pipeOut = new NSPipe();
					NSTask t =  new NSTask();
					t.LaunchPath = txtRAR;
					t.Arguments = launchArgs;
					t.StandardOutput = pipeOut;
					t.Launch ();
					ViewArquivosDataSource datasource = new ViewArquivosDataSource ();
					do {
						NSDate DateLoop = new NSDate ();
						DateLoop = DateLoop.AddSeconds (0.1);
						NSRunLoop.Current.RunUntil(DateLoop);
						string txtRET = pipeOut.ReadHandle.ReadDataToEndOfFile ().ToString ();
						int pos = txtRET.IndexOf ("Name:");
						if (pos > 0) {
							if(!TableView.Enabled) {
								TableView.Enabled = true;
								TableView.Hidden = false;
								window.tb_outAdicionarActive = true;
								window.tb_outAtualizarActive = true;
								window.tb_outExtrairActive = true;
								window.tb_outRemoverActive = true;
								window.tb_outDesfazerActive = true;
							}
							txtRET = txtRET.Substring (pos);
							List<string> nomes = new List<string>();
							do {
								pos = txtRET.IndexOf ("Name:",pos + 1);
								if (pos < 0) {
									nomes.Add (txtRET.Trim());
									break;
								}
								nomes.Add(txtRET.Substring(0, pos - 2).Trim());
								txtRET = txtRET.Substring(pos);
								pos = 0;
							} while (true);
							if (nomes.Count > 0) {
								foreach (string nome in nomes) {
									clsViewArquivos viewArquivos = new clsViewArquivos ();
									string[] colunas = nome.Split ('\n');
									string tipo = colunas [1].Substring (colunas [1].IndexOf (":") + 1).Trim();
									viewArquivos.Nome = colunas [0].Substring (colunas [0].IndexOf (":") + 1).Trim();
									viewArquivos.Tipo = colunas [1].Substring (colunas [1].IndexOf (":") + 1).Trim();
									if (tipo == "File") {
										viewArquivos.Tamanho = colunas [2].Substring (colunas [2].IndexOf (":") + 1).Trim();
										viewArquivos.Compactado = colunas [3].Substring (colunas [3].IndexOf (":") + 1).Trim();
										viewArquivos.Compressao = colunas [4].Substring (colunas [4].IndexOf (":") + 1).Trim();
										viewArquivos.DataHora = colunas [5].Substring (colunas [5].IndexOf (":") + 1).Trim();
										viewArquivos.Atributos = colunas [6].Substring (colunas [6].IndexOf (":") + 1).Trim();
										viewArquivos.CRC32 = colunas [7].Substring (colunas [7].IndexOf (":") + 1).Trim();
										viewArquivos.OS = colunas [8].Substring (colunas [8].IndexOf (":") + 1).Trim();
										viewArquivos.Compressor = colunas [9].Substring (colunas [9].IndexOf (":") + 1).Trim();
									} else {
										viewArquivos.Tamanho = "";
										viewArquivos.Compactado = "";
										viewArquivos.Compressao = "";
										viewArquivos.DataHora = colunas [2].Substring (colunas [2].IndexOf (":") + 1).Trim();
										viewArquivos.Atributos = colunas [3].Substring (colunas [3].IndexOf (":") + 1).Trim();
										viewArquivos.CRC32 = colunas [4].Substring (colunas [4].IndexOf (":") + 1).Trim();
										viewArquivos.OS = colunas [5].Substring (colunas [5].IndexOf (":") + 1).Trim();
										viewArquivos.Compressor = colunas [6].Substring (colunas [6].IndexOf (":") + 1).Trim();
									}
									viewArquivos.Tags = "0";
									datasource.ViewArquivos.Add (viewArquivos);
									viewArquivos = null;
								}
							}
						} else {
							TableView.Enabled = false;
							TableView.Hidden = true;
							NSAlert alert = new NSAlert () {
								AlertStyle = NSAlertStyle.Warning,
								InformativeText = "Não foi possível processar o arquivo:\r\n" + path,
								MessageText = "Abrir Arquivo", 
							};
							alert.RunSheetModal (window);
						}
					} while(t.IsRunning);
					pipeOut.Dispose ();
					pipeOut = null;
					TableView.DataSource = datasource;
					TableView.Delegate = new ViewArquivosDelegate (datasource);
					t.Terminate ();
					t.Dispose ();
					t = null;
				}
				ioPrefs = null;
			}
			return path;
		}
	}
}

