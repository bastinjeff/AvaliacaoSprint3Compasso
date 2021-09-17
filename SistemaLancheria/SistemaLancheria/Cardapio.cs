using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Cardapio
	{
		public Dictionary<int, Produto> ListaDeProdutos { get; private set; }

		public Cardapio()
		{
			InstanciaCardapio();
		}

		void InstanciaCardapio()
		{
			ListaDeProdutos = new Dictionary<int, Produto>()
			{
				{100, new Produto(100,5.70,"Cachorro Quente") },
				{101, new Produto(101,18.30,"X Completo") },
				{102, new Produto(102,16.50,"X Salada")},
				{103, new Produto(103,22.40,"Hamburguer") },
				{104, new Produto(104,10.00,"Coca 2L") },
				{105, new Produto(105,1.00,"Refrigerante") },
			};
		}
	}
}
