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

			// This pattern allows you reuse existing views when they are no-longer in use.
			// If the returned view is null, you instance up a new view
			// If a non-null view is returned, you modify it enough to reflect the new data
			NSTableCellView view = (NSTableCellView)tableView.MakeView (tableColumn.Title, this);
			if (view == null) {
				view = new NSTableCellView ();
				if (tableColumn.Title == "Nome") {
					view.ImageView = new NSImageView (new CGRect (0, 0, 17, 17));
					view.AddSubview (view.ImageView);
					view.TextField = new NSTextField (new CGRect (20, 0, 2, 17));
				} else {
					view.TextField = new NSTextField (new CGRect (0, 0, 2, 17));
				}
				view.TextField.AutoresizingMask = NSViewResizingMask.WidthSizable;
				view.AddSubview (view.TextField);
				view.Identifier = tableColumn.Title;
				view.TextField.BackgroundColor = NSColor.Clear;
				view.TextField.Bordered = false;
				view.TextField.Selectable = false;
				view.TextField.Editable = true;

				view.TextField.EditingEnded += (sender, e) => {

					// Take action based on type

					switch(view.Identifier) {
					case "Nome":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Nome = view.TextField.StringValue;
						break;
					case "Tipo":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Tipo = view.TextField.StringValue;
						break;
					case "Tamanho":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Tamanho = view.TextField.StringValue;
						break;
					case "Compactado":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Compactado = view.TextField.StringValue;
						break;
					case "Compressão":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Compressao = view.TextField.StringValue;
						break;
					case "Data/Hora":
						DataSource.ViewArquivos [(int)view.TextField.Tag].DataHora = view.TextField.StringValue;
						break;
					case "Atributos":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Atributos = view.TextField.StringValue;
						break;
					case "CRC 32":
						DataSource.ViewArquivos [(int)view.TextField.Tag].CRC32 = view.TextField.StringValue;
						break;
					case "OS":
						DataSource.ViewArquivos [(int)view.TextField.Tag].OS = view.TextField.StringValue;
						break;
					case "Compressor":
						DataSource.ViewArquivos [(int)view.TextField.Tag].Compressor = view.TextField.StringValue;
						break;
					}
				};
			}

			// Tag view
			view.TextField.Tag = row;

			// Setup view based on the column selected
			switch (tableColumn.Title) {
			case "Nome":
				view.ImageView.Image = NSImage.ImageNamed ("Compactado.ico");
				view.TextField.Alignment = NSTextAlignment.Left ;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Nome;
				break;
			case "Tipo":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Tipo;
				break;
			case "Tamanho":
				view.TextField.Alignment = NSTextAlignment.Right;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Tamanho;
				break;
			case "Compactado":
				view.TextField.Alignment = NSTextAlignment.Right;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Compactado;
				break;
			case "Compressão":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Compressao;
				break;
			case "Data/Hora":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].DataHora;
				break;
			case "Atributos":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Atributos;
				break;
			case "CRC 32":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].CRC32;
				break;
			case "OS":
				view.TextField.Alignment = NSTextAlignment.Center;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].OS;
				break;
			case "Compressor":
				view.TextField.Alignment = NSTextAlignment.Left;
				view.TextField.StringValue = DataSource.ViewArquivos [(int)row].Compressor;
				break;
			}
			return view;
		}

		public override bool ShouldSelectRow (NSTableView tableView, nint row)
		{
			return true;
		}

	}
}

