using System;
using System.IO;

using Foundation;
using AppKit;
using System.Collections.Generic;
using System.Threading.Tasks;

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

					ProgressWindowController sheet = null;
					TableView.InvokeOnMainThread (delegate {
						sheet = new ProgressWindowController  ();
						sheet.ShowSheet (window);
					});

					bool Cancela = false;

					do {
						string txtRET = pipeOut.ReadHandle.ReadDataToEndOfFile ().ToString ();
						int pos = txtRET.IndexOf ("Name:");
						if (pos > 0) {
							TableView.InvokeOnMainThread(delegate{
								if(!TableView.Enabled) {
									TableView.Enabled = true;
									TableView.Hidden = false;
									window.tb_outAdicionarActive = true;
									window.tb_outAtualizarActive = true;
									window.tb_outExtrairActive = true;
									window.tb_outRemoverActive = true;
									window.tb_outDesfazerActive = true;
								}
							});

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

								sheet.InvokeOnMainThread(delegate{
									sheet.ProgressBarMinValue = 0;
									sheet.ProgressBarMaxValue = nomes.Count;
								});

								double conta = 0;

								foreach (string nome in nomes) {

									clsViewArquivos viewArquivos = new clsViewArquivos ();
									string[] colunas = nome.Split ('\n');
									string tipo = colunas [1].Substring (colunas [1].IndexOf (":") + 1).Trim();
									viewArquivos.Nome = colunas [0].Substring (colunas [0].IndexOf (":") + 1).Trim();
									viewArquivos.Tipo = colunas [1].Substring (colunas [1].IndexOf (":") + 1).Trim();

									++conta;

									sheet.InvokeOnMainThread(delegate{
										sheet.LabelArqValue = "Processando arquivo: " + viewArquivos.Nome;
										sheet.ProgressBarValue = conta;
									});

//									NSApplication.SharedApplication.InvokeOnMainThread (() => {
//										sheet.LabelArqValue = "Processando arquivo: " + viewArquivos.Nome;
//										sheet.ProgressBarValue = conta;
//									});

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

									sheet.InvokeOnMainThread(delegate{
										Cancela = sheet.Canceled;
									});
									if(Cancela) {
										break;
									}
								}
							}
						} else {

							TableView.InvokeOnMainThread (delegate {
								TableView.Enabled = false;
								TableView.Hidden = true;
								sheet.CloseSheet();
								NSAlert alert = new NSAlert () {
									AlertStyle = NSAlertStyle.Critical,
									InformativeText = "Não foi possível processar o arquivo:\r\n" + path,
									MessageText = "Abrir Arquivo", 
								};
								alert.RunSheetModal(window);
							});

						}

						if(Cancela) {
							break;
						}

					} while(t.IsRunning);

					sheet.InvokeOnMainThread (delegate {
						sheet.CloseSheet ();
						sheet = null;
					});

					pipeOut.Dispose ();
					pipeOut = null;

					TableView.InvokeOnMainThread (delegate {
						TableView.DataSource = datasource;
						TableView.Delegate = new ViewArquivosDelegate (datasource);
					});

					t.Terminate ();
					t.Dispose ();
					t = null;
				}
				ioPrefs = null;
			}
			return path;
		}

        public void ExtractRAR(MainWindow  window, NSTableView TableView, NSIndexSet nSelRows, string rarFile, string extractPath) {
			clsIOPrefs ioPrefs = new clsIOPrefs ();
			string txtRAR = ioPrefs.GetStringValue ("CaminhoRAR");
			if (txtRAR.Length > 0) {
				
				if (nSelRows.Count > 0) {

                    ProgressWindowController sheet = null;
                    TableView.InvokeOnMainThread (delegate {
                        sheet = new ProgressWindowController  ();
                        sheet.ShowSheet (window);
                    });

                    sheet.InvokeOnMainThread(delegate{
                        sheet.ProgressBarMinValue = 0;
                        sheet.ProgressBarMaxValue = nSelRows.Count;
                    });

                    double conta = 0;
                    bool Cancela = false;

					nuint[] nRows = nSelRows.ToArray ();

                    ViewArquivosDataSource datasource = null;
                    TableView.InvokeOnMainThread(delegate
                        {
                            datasource = (ViewArquivosDataSource)TableView.DataSource;
                        });
					
					foreach (int lRow in nRows) {
						string NomeArq = datasource.ViewArquivos [lRow].Nome;

                        ++conta;

                        sheet.InvokeOnMainThread(delegate{
                            sheet.LabelArqValue = "Extraindo arquivo: " + NomeArq;
                            sheet.ProgressBarValue = conta;
                        });

						string[] launchArgs = { "x", rarFile, NomeArq, extractPath };
						NSPipe pipeOut = new NSPipe ();
						NSTask t = new NSTask ();
						t.LaunchPath = txtRAR;
						t.Arguments = launchArgs;
						t.StandardOutput = pipeOut;
						t.Launch ();
                        t.WaitUntilExit();

                        //string txtRET = pipeOut.ReadHandle.ReadDataToEndOfFile ().ToString ();

                        sheet.InvokeOnMainThread(delegate{
                            Cancela = sheet.Canceled;
                        });
                        if(Cancela) {
                            break;
                        }

                    }

                    sheet.InvokeOnMainThread (delegate {
                        sheet.CloseSheet ();
                        sheet = null;
                    });

                    if (!Cancela)
                    {
                        TableView.InvokeOnMainThread (delegate {
                            NSAlert alert = new NSAlert () {
                                AlertStyle = NSAlertStyle.Informational,
                                InformativeText = "Arquivo(s) extraido(s) com sucesso !",
                                MessageText = "Extrair Arquivos", 
                            };
                            alert.RunSheetModal(window);
                        });

                    }

				}
			}
		}
	}
}
