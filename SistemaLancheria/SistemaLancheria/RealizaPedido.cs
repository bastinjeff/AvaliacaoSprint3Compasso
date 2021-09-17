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

		public RealizaPedido(Mesas mesas, Cliente ClienteAtual)
		{
			this.mesas = mesas;
			this.ClienteAtual = ClienteAtual;
		}
		public void Realizar()
		{
			EscolheMesa();
		}

		int EscolheMesa()
		{
			bool ContinuaWhile = true;
			do
			{
				Console.Clear();				
				ExibeMesas();
				Console.WriteLine();
				Console.Write("Qual o numero da Mesa?: ");
				SwitchCaseMesa(ref ContinuaWhile);

			} while (ContinuaWhile);
			return 0;
		}

		void SwitchCaseMesa(ref bool ContinuaWhile)
		{
			int MesaEscolhida = -1;
			int IntSwitch = PedeInteiroMesa(ref MesaEscolhida);
			if (!mesas.Mesa.ContainsKey(MesaEscolhida) && IntSwitch == 1)
			{
				IntSwitch = -2;
			}
			switch (IntSwitch)
			{
				case 1:
					RegistraMesa(MesaEscolhida);
					ContinuaWhile = false;
					break;
				case -1:
					ExibeErroOpcaoInvalida();
					break;
				default:
					ExibeErroForaDasOpcoes();
					break;
			}
		}

		void RegistraMesa(int MesaEscolhida)
		{
			mesas.Mesa[MesaEscolhida] = Mesas.Status.Ocupada;
			ClienteAtual = new Cliente(1, MesaEscolhida);
		}

		int PedeInteiroMesa(ref int MesaEscolhida)
		{
			bool Resultado = int.TryParse(Console.ReadLine(), out MesaEscolhida);
			if (Resultado)
			{
				if (MesaEscolhida < 0)
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
