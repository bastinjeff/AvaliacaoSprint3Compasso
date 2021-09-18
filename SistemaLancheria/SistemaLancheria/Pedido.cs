using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	[JsonObject]
	class Pedido
	{
		[JsonProperty]
		public double ValorTotal { get; private set; }

		[JsonProperty]
		public List<Produto> ListaProdutos { get; private set; }

		public Pedido()
		{
			ListaProdutos = new List<Produto>();
		}

		public int AdicionarProduto(Produto ProdutoNovo, int Quantidade)
		{
			if (AdicionarListaProdutos(ProdutoNovo, Quantidade))
			{
				ValorTotal += ProdutoNovo.ValorUnitario * Quantidade;
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public bool AdicionarListaProdutos(Produto ProdutoNovo, int Quantidade)
		{
			try
			{
				if (ListaProdutos.Contains(ProdutoNovo))
				{
					ListaProdutos.Find((x) => x == ProdutoNovo).QuantidadeAtual+= Quantidade;
				}
				else
				{
					ListaProdutos.Add(ProdutoNovo);
					ListaProdutos.Find((x) => x == ProdutoNovo).QuantidadeAtual+= Quantidade;
				}
				return true;
			}catch(Exception e)
			{
				Console.WriteLine("Ocorreu um erro ao tentar adicionar à lista de produtos");
				return false;
			}				
		}

		public void OrdenarLista()
		{
			ListaProdutos = ListaProdutos.OrderBy((x) => x.CodigoDoProduto).ToList();
		}
	}
}
