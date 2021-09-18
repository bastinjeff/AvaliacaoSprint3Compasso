using System;
using System.Threading.Tasks;

namespace Atividade2LeituraJSON
{
	class Program
	{
		static async Task Main(string[] args)
		{
			await new SistemaBase().Inicio();
		}
	}
}
