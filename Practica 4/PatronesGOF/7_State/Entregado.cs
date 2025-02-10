using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class Entregado : IEstadoPedido
    {
        public void AgregaProducto(Pedido pedido)
        {
            Console.WriteLine("No se pueden agregar productos a un pedido entregado.");
        }

        public void Borra(Pedido pedido)
        {
            Console.WriteLine("No se pueden eliminar productos de un pedido entregado.");
        }

        public void Valida(Pedido pedido)
        {
            Console.WriteLine("No se puede validar un pedido entregado.");
        }

        public void Entrega(Pedido pedido)
        {
            Console.WriteLine("El pedido ya está entregado.");
        }
    }
}