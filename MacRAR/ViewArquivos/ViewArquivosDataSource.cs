using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace MacRAR
{
	public class ViewArquivosDataSource : NSTableViewDataSource
	{

		public List<clsViewArquivos> ViewArquivos = new List<clsViewArquivos>();

		public ViewArquivosDataSource ()
		{
		}

		public override nint GetRowCount (NSTableView tableView)
		{
			return ViewArquivos.Count;
		}

		public void Sort(string key, bool ascending) {

			// Take action based on key
			switch (key) {

			case "Nome":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Nome.CompareTo (y.Nome));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Nome.CompareTo (y.Nome));
				}
				break;
			case "Tipo":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Tipo.CompareTo (y.Tipo));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Tipo.CompareTo (y.Tipo));
				}
				break;
			case "Tamanho":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Tamanho.CompareTo (y.Tamanho));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Tamanho.CompareTo (y.Tamanho));
				}
				break;
			case "Compactado":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Compactado.CompareTo (y.Compactado));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Compactado.CompareTo (y.Compactado));
				}
				break;
			case "Compressao":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Compressao.CompareTo (y.Compressao));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Compressao.CompareTo (y.Compressao));
				}
				break;
			case "Data/Hora":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.DataHora.CompareTo (y.DataHora));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.DataHora.CompareTo (y.DataHora));
				}
				break;
			case "Atributos":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Atributos.CompareTo (y.Atributos));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Atributos.CompareTo (y.Atributos));
				}
				break;
			case "CRC 32":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.CRC32.CompareTo (y.CRC32));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.CRC32.CompareTo (y.CRC32));
				}
				break;
			case "OS":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.OS.CompareTo (y.OS));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.OS.CompareTo (y.OS));
				}
				break;
			case "Compressor":
				if (ascending) {
					ViewArquivos.Sort ((x, y) => x.Compressor.CompareTo (y.Compressor));
				} else {
					ViewArquivos.Sort ((x, y) => -1 * x.Compressor.CompareTo (y.Compressor));
				}
				break;
			}

		}

		public override void SortDescriptorsChanged (NSTableView tableView, NSSortDescriptor[] oldDescriptors)
		{
			// Sort the data

			NSSortDescriptor[] tbSort = tableView.SortDescriptors;
			Sort (tbSort[0].Key, tbSort[0].Ascending);
			//Sort (oldDescriptors[0].Key, oldDescriptors[0].Ascending);
			tableView.ReloadData ();
		}
			
	}
}

