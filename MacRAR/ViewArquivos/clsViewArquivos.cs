using System;
using AppKit;
using Foundation ;

namespace MacRAR
{
	public class clsViewArquivos
	{

		private string dth;

		public string Nome { get; set;} = "";
		public string Tipo { get; set;} = "";
		public string Tamanho { get; set;} = "";
		public string Compactado { get; set;} = "";
		public string Compressao { get; set;} = "";
		public string DataHora {
			get {
				return dth;
			}
			set {
				DateTime dt;
				if (value.IndexOf (",") != -1) {
					dt = DateTime.Parse (value.Substring (0, value.IndexOf (",")).Trim ());
				} else {
					dt = DateTime.Parse (value);
				}
				dth = dt.ToString ();
			}
		}
		public string Atributos { get; set;} = "";
		public string CRC32 { get; set;} = "";
		public string OS { get; set;} = "";
		public string Compressor { get; set;} = "";
		public string Tags { get; set; } = "";

		public clsViewArquivos ()
		{
		}

		public clsViewArquivos (string nome, string tipo, string tamanho, string compactado, string compressao, string datahora, 
			string atributos, string crc32, string os, string compressor,string tags)
		{
			this.Nome = nome;
			this.Tipo = tipo;
			this.Tamanho = tamanho;
			this.Compactado = compactado;
			this.Compressao = compressao;
			this.DataHora = datahora;
			this.Atributos = atributos;
			this.CRC32 = crc32;
			this.OS = os;
			this.Compressor = compressor;
			this.Tags = tags;
		}
			
		public void SetStateArquivo(NSTableRowView tbv,NSTableCellView view, nint state)
		{

			// Compactado = 0
			// Excluido = 1
			// Adicionado = 2
			// Desfazer = 3

			NSTableCellView tagView = (NSTableCellView)tbv.ViewAtColumn(tbv.NumberOfColumns - 1);

			if (tagView != null) {
				string values = tagView.TextField.StringValue;
			}

			switch (state) {
			case 0:
				tbv.BackgroundColor = NSColor.White;
				view.ImageView.Image = NSImage.ImageNamed ("Compactado.ico");
				break;
			case 1:
				tbv.BackgroundColor = NSColor.Red;
				view.ImageView.Image = NSImage.ImageNamed ("Excluido.ico");
				break;
			case 2:
				tbv.BackgroundColor = NSColor.Green;
				view.ImageView.Image = NSImage.ImageNamed ("Adicionado.ico");
				break;
			case 3:



				break;

			}
		}

		public void SetTagsArquivo(NSTextField column,string value,bool soma = false)
		{
			if (soma) {
				column.StringValue = column.StringValue + value;
			} else {
				column.StringValue = value;
			}
		}

		public string GetTagsArquivo(NSTableView tbv,nint row)
		{
			NSTableCellView cell = (NSTableCellView)tbv.GetView(tbv.RowCount -1, row, false);
			string tags = cell.TextField.StringValue;
			string tag = string.Empty;
			if (tags.IndexOf ("|") > 0) {
				string[] aTags = tags.Split ('|');
				tag = aTags [0];
			} else {
				tag = tags;
			}
			return tag;
		}

//		public void HideShowTags(NSTableView tbView, bool hidden)
//		{
//			NSTableColumn[] tbColumns = tbView.TableColumns ();
//			tbColumns [tbView.ColumnCount - 1].Hidden = hidden;
//		}

	}

}

