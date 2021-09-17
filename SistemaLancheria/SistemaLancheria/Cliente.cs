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
		int IDMesa;
		Pedido PedidoCliente;

		public Cliente(int IDCliente, int IDMesa)
		{
			this.IDCliente = IDCliente;
			this.IDMesa = IDMesa;
		}
	}
}
