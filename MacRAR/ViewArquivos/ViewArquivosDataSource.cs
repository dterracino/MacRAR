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

	}
}

