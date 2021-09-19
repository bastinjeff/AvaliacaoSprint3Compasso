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

		List<Classe> ClassesFiltradas = new List<Classe>();

		public async Task Inicio()
		{
			await ConseguirDadosAsync();

			PercorrerClasses();

			AtribuirAtributos();

			ExibeOutputFinal();

			Console.WriteLine("<PROGRAMA FINALIZADO, PRESSIONE ENTER PARA SAIR>");
			Console.ReadLine();
			return;
		}

		void ExibeOutputFinal()
		{

			foreach (var classe in ClassesFiltradas.OrderBy((x) => x.Id))
			{
				Console.WriteLine(@$"       ----    ----        ---         ");
				Console.WriteLine(@$"Id: {classe.Id}                          ");
				Console.WriteLine(@$"Nome: {classe.NomeClasse}                ");
				Console.WriteLine(@$"      Atributos                        ");
				Console.WriteLine(@$"FOR: {classe.Atributos.Forca}            ");
				Console.WriteLine(@$"DES: {classe.Atributos.Destreza}         ");
				Console.WriteLine(@$"INT: {classe.Atributos.Inteligencia}     ");
				Console.WriteLine(@"                                        ");
			}
		}

		void AtribuirAtributos()
		{
			var Bloqueio = new object();

			List<Atributos> ListaAtributos = atributosRoot.Atributos.ToList();

			Parallel.ForEach(ClassesFiltradas, (classe) => 
			{
				Atributos AtributoAtribuir = ListaAtributos.Find((x) => x.ClasseId == classe.Id);

				lock (Bloqueio)
				{
					classe.Atributos = AtributoAtribuir;
				}
			
			});
		}

		void PercorrerClasses()
		{
			var Bloqueio = new object();

			Parallel.ForEach(classesRoot.Classes, (classe) =>
			{
				if (idsRoot.Ids.Contains(classe.Id))
				{
					lock (Bloqueio)
					{
						ClassesFiltradas.Add(classe);
					}
				}

			});
		}

		async Task ConseguirDadosAsync()
		{
			var TarefasLista = new Task[3];

			TarefasLista[0] = new Task(() => atributosRoot.Atributos = ObterAtributosDeClasseAsync().Result);
			TarefasLista[1] = new Task(() => classesRoot.Classes = ObterClassesAsync().Result);
			TarefasLista[2] = new Task(() => idsRoot.Ids = ObterIdsFiltradosAsync().Result);

			Parallel.ForEach(TarefasLista, Tarefa => Tarefa.Start());

			Task.WaitAll(TarefasLista);
		}

		public async Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/atributos.json");
			var Root = JsonConvert.DeserializeObject<AtributosRoot>(reader);

			return Root.Atributos;
		}

		public async Task<IEnumerable<Classe>> ObterClassesAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/classes.json");
			var Root = JsonConvert.DeserializeObject<ClassesRoot>(reader);

			return Root.Classes;
		}

		public async Task<IEnumerable<int>> ObterIdsFiltradosAsync()
		{
			var reader = await File.ReadAllTextAsync("./JSON/ids_filtrados.json");
			var Root = JsonConvert.DeserializeObject<IdsRoot>(reader);

			return Root.Ids;
		}
	}
}
