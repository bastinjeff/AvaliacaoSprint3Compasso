using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2LeituraJSON
{
	class IdsRoot
	{
		[JsonProperty("ids")]
		public IEnumerable<int> Ids { get; set; }
	}
}
