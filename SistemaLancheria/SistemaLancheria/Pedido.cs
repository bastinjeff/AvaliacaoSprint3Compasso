using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Pedido
	{
		public double ValorTotal { get; private set; }

		public List<Produto> ListaProdutos { get; }

		public Pedido()
		{
			ListaProdutos = new List<Produto>();
		}

		public int AdicionarProduto(Produto ProdutoNovo)
		{
			if (AdicionarListaProdutos(ProdutoNovo))
			{
				ValorTotal += ProdutoNovo.ValorUnitario;
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public bool AdicionarListaProdutos(Produto ProdutoNovo)
		{
			try
			{
				ListaProdutos.Add(ProdutoNovo);
				return true;
			}catch(Exception e)
			{
				Console.WriteLine("Ocorreu um erro ao tentar adicionar à lista de produtos");
				return false;
			}
				
		}
	}
}
