using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class LancheriaBase
	{
        Mesas mesas;
        Cliente cliente;
        Cardapio cardapio;

        public LancheriaBase(int QtdMesas)
		{
            mesas = new Mesas(QtdMesas);
            cardapio = new Cardapio();
		}

		public void IniciarSistema()
		{
            MenuInicial();
            Console.Clear();
            Console.WriteLine("<Fim do Programa, tecle enter para fechar>");
            Console.ReadLine();
		}

        void MenuInicial()
		{
            bool ContinuaWhile = true;
            do
            {
                ApresentacaoInicial();
                SwitchCaseInicial(ref ContinuaWhile);
			    
            } while (ContinuaWhile);
		}

        void SwitchCaseInicial(ref bool ContinuaWhile)
		{
            switch (PedeInteiro())
            {
                case 1:
                    new RealizaPedido(mesas, cliente, cardapio).Realizar();                  
                    ContinuaWhile = false;
                    break;
                case -1:
                    Console.WriteLine("Resposta Inválida, por favor digite um numero inteiro positivo");
                    Console.WriteLine("<Tecle Enter para Continuar>");
                    Console.ReadLine();
                    break;
                case 2:
                    ContinuaWhile = false;
                    break;
                default:
                    Console.WriteLine("Resposta Inválida, por favor digite entre as opções apresentadas");
                    Console.WriteLine("<Tecle Enter para Continuar>");
                    Console.ReadLine();
                    break;
            }
        }

	    void ApresentacaoInicial()
		{
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");
        }

        int PedeInteiro()
		{
			int Inteiro;
			bool Resultado = int.TryParse(Console.ReadLine(), out Inteiro);
            if (Resultado)
            {
                if(Inteiro == -1)
				{
                    return -2;
				}
                return Inteiro;
            }
            else return -1;
		}
	}
}
