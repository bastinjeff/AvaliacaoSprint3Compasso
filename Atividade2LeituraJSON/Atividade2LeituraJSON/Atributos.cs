using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2LeituraJSON
{
	[JsonObject("atributos")]
	class Atributos
	{
		[JsonProperty("classeId")]
		public int ClasseId { get; set; }

		[JsonProperty("forca")]
		public int Forca { get; set; }

		[JsonProperty("destreza")]
		public int Destreza { get; set; }

		[JsonProperty("inteligencia")]
		public int Inteligencia { get; set; }
	}
}
