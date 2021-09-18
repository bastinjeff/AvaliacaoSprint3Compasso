using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Produto
	{
		public int CodigoDoProduto {get;}
		public int QuantidadeAtual { get; set; }
		public double ValorUnitario { get; }
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
