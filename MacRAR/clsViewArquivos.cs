using System;

namespace MacRAR
{
	public class clsViewArquivos
	{

		public string Nome { get; set;} = "";
		public string Tipo { get; set;} = "";
		public string Tamanho { get; set;} = "";
		public string Compactado { get; set;} = "";
		public string Compressao { get; set;} = "";
		public string DataHora { get; set;} = "";
		public string Atributos { get; set;} = "";
		public string CRC32 { get; set;} = "";
		public string OS { get; set;} = "";
		public string Compressor { get; set;} = "";

		public clsViewArquivos ()
		{
		}

		public clsViewArquivos (string nome, string tipo, string tamanho, string compactado, string compressao, string datahora, 
			string atributos, string crc32, string os, string compressor)
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
		}
	}
}

