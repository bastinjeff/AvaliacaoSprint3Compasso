using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class RealizaPedido
	{
		Mesas mesas;
		Cliente ClienteAtual;
		Cardapio cardapio;

		public RealizaPedido(Mesas mesas, Cliente ClienteAtual, Cardapio cardapio)
		{
			this.mesas = mesas;
			this.ClienteAtual = ClienteAtual;
			this.cardapio = cardapio;
		}
		public void Realizar()
		{
			EscolheMesa();
			EscolheProdutos();
		}

		void EscolheProdutos()
		{
			bool ContinuaLoopEscolhaProduto = true;
			bool ContinuaLoopPedidos = true;
			do
			{
				do
				{
					Console.Clear();

					ExibeOpcoesProdutos();
					Console.WriteLine();
					Console.WriteLine("Informe o Código:");
					int IDProduto = 0;
					int Retorno = SwitchCaseGenerico(ref ContinuaLoopEscolhaProduto, ref IDProduto);
					if(Retorno == 1)
					{
						if (cardapio.ListaDeProdutos.ContainsKey(IDProduto) && IDProduto != 999)
						{

							ClienteAtual.PedidoCliente.AdicionarProduto(cardapio.ListaDeProdutos[IDProduto]);
							Console.WriteLine("Produto Adicionado no pedido com sucesso!");
							Console.WriteLine("<Pressione Enter para Continuar>");
							Console.ReadLine();
						}
						else if(IDProduto == 999)
						{
							Console.WriteLine("Finalizando Pedido");
							Console.WriteLine("<Pressione Enter para Continuar>");
							Console.ReadLine();
							ContinuaLoopEscolhaProduto = false;
							ContinuaLoopPedidos = false;
						}
						else
						{
							ExibeErroForaDasOpcoes();
						}
					}
					
				} while (ContinuaLoopEscolhaProduto);
			} while (ContinuaLoopPedidos);
			Console.Clear();
			ExibePedido();			
		}

		void ExibePedido()
		{
			Console.WriteLine("A mesa {0} pediu os seguintes itens: ", ClienteAtual.IDMesa);
			Console.WriteLine("{0,-10} {1,-25} {2,0}", "Codigo", "Nome", "Quantidade");
			ClienteAtual.PedidoCliente.OrdenarLista();
			foreach (var pedido in ClienteAtual.PedidoCliente.ListaProdutos)
			{
				Console.WriteLine("{0,-10} {1,-25} {2,0}", pedido.CodigoDoProduto, pedido.DescricaoProduto, pedido.QuantidadeAtual);
			}
			Console.WriteLine("Com valor total de: R$ {0}", ClienteAtual.PedidoCliente.ValorTotal.ToString("0.00"));
		}

		void ExibeOpcoesProdutos()
		{
			Console.WriteLine("{0,-10} {1,-25} {2,-20}", "Codigo", "Produto", "Preço Unitário (R$)");
			foreach(var produto in cardapio.ListaDeProdutos.Values)
			{
				Console.WriteLine("{0,-10} {1,-25} {2,-20}", produto.CodigoDoProduto,
					produto.DescricaoProduto,
					"R$ " + produto.ValorUnitario.ToString("0.00"));
			}
			Console.WriteLine("{0,-10} {1,-25}", "999", "Encerra pedido");
		}

		int EscolheMesa()
		{
			try
			{
				bool ContinuaWhile = true;
				do
				{
					Console.Clear();
					ExibeMesas();
					Console.WriteLine();
					Console.Write("Qual o numero da Mesa?: ");
					int MesaEscolhida = 0;
					int Retorno = SwitchCaseGenerico(ref ContinuaWhile, ref MesaEscolhida);
					if(Retorno == 1)
					{
						if (!mesas.Mesa.ContainsKey(MesaEscolhida))
						{
							ExibeErroForaDasOpcoes();
						}
						else
						{
							RegistraMesa(MesaEscolhida);
							RegistraCliente(MesaEscolhida, 1);
							ContinuaWhile = false;
						}
					}else if(Retorno == -1)
					{

					}
					else
					{
						throw new Exception();
					}

				} while (ContinuaWhile);
				return 1;
			}
			catch (Exception e)
			{
				Console.WriteLine("Ocorreu um erro ao tentar escolher a mesa");
				Console.WriteLine("<Pressione Enter para Continuar>");
				Console.ReadLine();
				return 0;
			}
		}

		int SwitchCaseGenerico(ref bool ContinuaWhile, ref int OpcaoEscolhida)
		{
			try
			{
				int IntSwitch = PedeInteiroPositivo(ref OpcaoEscolhida);
				switch (IntSwitch)
				{
					case 1:
						return 1;
					case -1:
						ExibeErroOpcaoInvalida();
						return -1;
					default:
						return 0;
				}
			}catch(Exception e)
			{
				Console.WriteLine("Ocorreu um erro no Switch");
				return 0;
			}
		}

		void RegistraMesa(int MesaEscolhida)
		{
			mesas.Mesa[MesaEscolhida] = Mesas.Status.Ocupada;			
		}
		void RegistraCliente(int MesaEscolhida, int IDCliente)
		{
			ClienteAtual = new Cliente(IDCliente, MesaEscolhida);
		}

		int PedeInteiroPositivo(ref int InteiroRetornado)
		{
			bool Resultado = int.TryParse(Console.ReadLine(), out InteiroRetornado);
			if (Resultado)
			{
				if(InteiroRetornado < 0)
				{
					return -1;
				}
				return 1;
			}
			else return -1;
		}

		void ExibeMesas()
		{
			for(int i = 1; i <= mesas.Mesa.Count; i++)
			{
				Console.WriteLine("Mesa: {0} | Status: {1}", i, mesas.Mesa[i]);
			}
		}

		void ExibeErroOpcaoInvalida()
		{
			Console.WriteLine("Resposta Inválida, por favor digite um numero inteiro positivo");
			Console.WriteLine("<Tecle Enter para Continuar>");
			Console.ReadLine();
		}

		void ExibeErroForaDasOpcoes()
		{
			Console.WriteLine("Resposta Inválida, por favor digite entre as opções apresentadas");
			Console.WriteLine("<Tecle Enter para Continuar>");
			Console.ReadLine();
		}
	}
}
