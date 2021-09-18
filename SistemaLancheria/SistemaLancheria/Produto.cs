using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	[JsonObject]
	class Produto
	{
		[JsonProperty]
		public int CodigoDoProduto {get;}

		[JsonProperty]
		public int QuantidadeAtual { get; set; }

		[JsonProperty]
		public double ValorUnitario { get; }

		[JsonProperty]
		public string DescricaoProduto { get; }

		public Produto(int CodigoDoProduto, double ValorUnitario, string DescricaoProduto)
		{
			this.CodigoDoProduto = CodigoDoProduto;
			this.ValorUnitario = ValorUnitario;
			this.DescricaoProduto = DescricaoProduto;
			QuantidadeAtual = 0;
		}

	}
}
