using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Atividade2LeituraJSON
{
	class SistemaBase : IDataService
	{
		AtributosRoot atributosRoot = new AtributosRoot();
		ClassesRoot classesRoot = new ClassesRoot();
		IdsRoot idsRoot = new IdsRoot();
		public async Task Inicio()
		{
			var TarefasLista = new Task[3];

			TarefasLista[0] = new Task(() => atributosRoot.Atributos = ObterAtributosDeClasseAsync().Result);
			TarefasLista[1] = new Task(() => classesRoot.Classes = ObterClassesAsync().Result);
			TarefasLista[2] = new Task(() => idsRoot.Ids = ObterIdsFiltradosAsync().Result);	

			foreach(var tarefa in TarefasLista)
			{
				tarefa.Start();
			}

			Task.WaitAll(TarefasLista);

			foreach(var id in idsRoot.Ids)
			{
				Console.WriteLine(id);
			}

			//Console.ReadLine();
		}

		public async Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/atributos.json");
			Console.WriteLine(reader);
			var Root = JsonConvert.DeserializeObject<AtributosRoot>(reader);

			return Root.Atributos;
		}

		public async Task<IEnumerable<Classe>> ObterClassesAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/classes.json");
			Console.WriteLine(reader);
			var Root = JsonConvert.DeserializeObject<ClassesRoot>(reader);

			return Root.Classes;
		}

		public async Task<IEnumerable<int>> ObterIdsFiltradosAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/ids_filtrados.json");
			Console.WriteLine(reader);
			var Root = JsonConvert.DeserializeObject<IdsRoot>(reader);

			return Root.Ids;
		}
	}
}
