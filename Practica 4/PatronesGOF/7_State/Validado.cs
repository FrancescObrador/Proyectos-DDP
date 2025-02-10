using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class Validado : IEstadoPedido
    {
        public void AgregaProducto(Pedido pedido)
        {
            Console.WriteLine("No se pueden agregar productos a un pedido validado.");
        }

        public void Borra(Pedido pedido)
        {
            Console.WriteLine("No se pueden eliminar productos de un pedido validado.");
        }

        public void Valida(Pedido pedido)
        {
            Console.WriteLine("El pedido ya está validado.");
        }

        public void Entrega(Pedido pedido)
        {
            pedido.CambiarEstado(new Entregado());
            Console.WriteLine("Pedido entregado.");
        }
    }
}