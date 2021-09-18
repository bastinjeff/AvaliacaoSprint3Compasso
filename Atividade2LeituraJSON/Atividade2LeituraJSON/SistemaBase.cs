using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Atividade2LeituraJSON
{
	class SistemaBase : IDataService
	{
		public async Task Inicio()
		{
			var TarefasLista = new Task[3];

			TarefasLista[0] = new Task(() => ObterAtributosDeClasseAsync());
			TarefasLista[1] = new Task(() => ObterClassesAsync());
			TarefasLista[2] = new Task(() => ObterIdsFiltradosAsync());	

			foreach(var tarefa in TarefasLista)
			{
				tarefa.Start();
			}

			Task.WaitAll(TarefasLista);
			
			//Console.ReadLine();
		}

		public async Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync()
		{			
			using(var reader = File.ReadAllTextAsync("./JSON/atributos.json"))
			{
				Console.WriteLine(reader.Result.ToString());				
			}
			
			return new Atributos[1];
		}

		public async Task<IEnumerable<Classe>> ObterClassesAsync()
		{
			using (var reader = File.ReadAllTextAsync("./JSON/classes.json"))
			{
				Console.WriteLine(reader.Result.ToString());
			}

			return new Classe[1];
		}

		public async Task<IEnumerable<int>> ObterIdsFiltradosAsync()
		{
			using (var reader = File.ReadAllTextAsync("./JSON/ids_filtrados.json"))
			{
				Console.WriteLine(reader.Result.ToString());
			}

			return new int[1];
		}
	}
}
