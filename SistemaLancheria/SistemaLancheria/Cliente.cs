using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Cliente
	{
		int IDCliente;
		Pedido PedidoCliente;

		public Cliente(int IDCliente)
		{
			this.IDCliente = IDCliente;
		}
	}
}
