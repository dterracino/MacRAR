using System;
using AppKit;
using CoreGraphics;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace MacRAR
{
	public class ViewArquivosDelegate : NSTableViewDelegate
	{

		private const string CellIdentifier = "Nome";
		private ViewArquivosDataSource DataSource;

		public ViewArquivosDelegate (ViewArquivosDataSource datasource)
		{
			this.DataSource = datasource;
		}

		public override NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, nint row)
		{

			NSTextField view = (NSTextField)tableView.MakeView (CellIdentifier, this);
			if (view == null) {
				view = new NSTextField ();
				view.Identifier = CellIdentifier;
				view.BackgroundColor = NSColor.Clear;
				view.Bordered = false;
				view.Selectable = false;
				view.Editable = false;
			}

			switch (tableColumn.Title) {
			case "Nome":
				view.StringValue = DataSource.ViewArquivos [(int)row].Nome;
				view.Alignment = NSTextAlignment.Left;
				break;
			case "Tipo":
				view.StringValue = DataSource.ViewArquivos [(int)row].Tipo;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "Tamanho":
				view.StringValue = DataSource.ViewArquivos [(int)row].Tamanho;
				view.Alignment = NSTextAlignment.Right;
				break;
			case "Compactado":
				view.StringValue = DataSource.ViewArquivos [(int)row].Compactado;
				view.Alignment = NSTextAlignment.Right;
				break;
			case "Compressão":
				view.StringValue = DataSource.ViewArquivos [(int)row].Compressao;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "Data/Hora":
				view.StringValue = DataSource.ViewArquivos [(int)row].DataHora;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "Atributos":
				view.StringValue = DataSource.ViewArquivos [(int)row].Atributos;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "CRC 32":
				view.StringValue = DataSource.ViewArquivos [(int)row].CRC32;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "OS":
				view.StringValue = DataSource.ViewArquivos [(int)row].OS;
				view.Alignment = NSTextAlignment.Center;
				break;
			case "Compressor":
				view.StringValue = DataSource.ViewArquivos [(int)row].Compressor;
				view.Alignment = NSTextAlignment.Left;
				break;
			}

			return view;
		}

	}
}

