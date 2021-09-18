using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLancheria
{
	class Cliente
	{
		public int IDCliente { get; }
		public int IDMesa { get; private set; }
		public Pedido PedidoCliente { get; private set; }
		public Cliente(int IDCliente, int IDMesa)
		{
			this.IDCliente = IDCliente;
			this.IDMesa = IDMesa;
			PedidoCliente = new Pedido();
		}
	}
}
