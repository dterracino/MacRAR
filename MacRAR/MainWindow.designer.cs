// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MacRAR
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		[Outlet]
		AppKit.NSTableView tbv_Arquivos { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnAtributos { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnCompactado { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnCompressao { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnCompressor { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnCRC32 { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnDataHora { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnNome { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnOS { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnTamanho { get; set; }

		[Outlet]
		AppKit.NSTableColumn tbv_ColumnTipo { get; set; }

		[Action ("tb_actAbrir:")]
		partial void tb_actAbrir (Foundation.NSObject sender);

		[Action ("tb_ActConfig:")]
		partial void tb_ActConfig (Foundation.NSObject sender);

		[Action ("tb_ActSair:")]
		partial void tb_ActSair (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tbv_Arquivos != null) {
				tbv_Arquivos.Dispose ();
				tbv_Arquivos = null;
			}

			if (tbv_ColumnNome != null) {
				tbv_ColumnNome.Dispose ();
				tbv_ColumnNome = null;
			}

			if (tbv_ColumnTipo != null) {
				tbv_ColumnTipo.Dispose ();
				tbv_ColumnTipo = null;
			}

			if (tbv_ColumnTamanho != null) {
				tbv_ColumnTamanho.Dispose ();
				tbv_ColumnTamanho = null;
			}

			if (tbv_ColumnCompactado != null) {
				tbv_ColumnCompactado.Dispose ();
				tbv_ColumnCompactado = null;
			}

			if (tbv_ColumnCompressao != null) {
				tbv_ColumnCompressao.Dispose ();
				tbv_ColumnCompressao = null;
			}

			if (tbv_ColumnDataHora != null) {
				tbv_ColumnDataHora.Dispose ();
				tbv_ColumnDataHora = null;
			}

			if (tbv_ColumnAtributos != null) {
				tbv_ColumnAtributos.Dispose ();
				tbv_ColumnAtributos = null;
			}

			if (tbv_ColumnCRC32 != null) {
				tbv_ColumnCRC32.Dispose ();
				tbv_ColumnCRC32 = null;
			}

			if (tbv_ColumnOS != null) {
				tbv_ColumnOS.Dispose ();
				tbv_ColumnOS = null;
			}

			if (tbv_ColumnCompressor != null) {
				tbv_ColumnCompressor.Dispose ();
				tbv_ColumnCompressor = null;
			}
		}
	}
}
