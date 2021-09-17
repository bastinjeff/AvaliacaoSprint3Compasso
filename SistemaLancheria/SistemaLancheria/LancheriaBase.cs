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

        public LancheriaBase(int QtdMesas)
		{
            mesas = new Mesas(QtdMesas);
		}

		public void IniciarSistema()
		{
            MenuInicial();
        #if DEBUG_MENU
            Console.WriteLine("Fim do Programa, tecle enter para fechar");
            Console.ReadLine();
        #endif
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
                    Console.WriteLine("Entrou!");                   
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
                    Console.WriteLine("Resposta Inválçida, por favor digite entre as opções apresentadas");
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
