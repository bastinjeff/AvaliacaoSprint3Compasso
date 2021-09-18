using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2LeituraJSON
{
	[JsonObject("classes")]
	class Classe
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nomeClasse")]
		public string NomeClasse { get; set; }
		[JsonProperty("atributos")]
		public Atributos Atributos { get; set; }
	}
}
