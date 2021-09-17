using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Pedido
	{
		public double ValorTotal
		{
			get
			{
				return ValorTotal;
			}
			set
			{
				ValorTotal += value;
			}
		}

		public List<Produto> ListaProdutos { get; }

		public Pedido()
		{

		}

		public void AdicionarListaProdutos(Produto ProdutoNovo)
		{
			ListaProdutos.Add(ProdutoNovo);
		}

		public void RemoverDeListaProdutosID(int IDRemocao)
		{
			ListaProdutos.RemoveAt(IDRemocao);
		}
	}
}
