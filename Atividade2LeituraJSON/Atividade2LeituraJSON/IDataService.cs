using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2LeituraJSON
{
	interface IDataService
	{
		Task<IEnumerable<Classe>> ObterClassesAsync();
		Task<IEnumerable<int>> ObterIdsFiltradosAsync();
		Task<IEnumerable<Atributos>> ObterAtributosDeClasseAsync();
	}
}
