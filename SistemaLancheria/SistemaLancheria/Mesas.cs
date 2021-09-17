using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Mesas
	{
		public enum Status
		{
			Vaga,
			Ocupada
		}

		public Dictionary<int, Status> Mesa { get; private set; }

		public Mesas(int QtdMesas)
		{
			InstanciaMesas(QtdMesas);
		}

		void InstanciaMesas(int QtdMesas)
		{
			Mesa = new Dictionary<int, Status>();
			for(int i = 0; i < QtdMesas; i++)
			{
				Mesa.Add(i + 1, Status.Vaga);
			}
		}
	}
}
