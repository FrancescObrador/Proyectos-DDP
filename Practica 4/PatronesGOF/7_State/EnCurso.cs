using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class EnCurso : IEstadoPedido
    {
        public void AgregaProducto(Pedido pedido)
        {
            Console.WriteLine("Producto agregado al pedido en curso.");
        }

        public void Borra(Pedido pedido)
        {
            Console.WriteLine("Producto eliminado del pedido en curso.");
        }

        public void Valida(Pedido pedido)
        {
            pedido.CambiarEstado(new Validado());
            Console.WriteLine("Pedido validado.");
        }

        public void Entrega(Pedido pedido)
        {
            Console.WriteLine("No se puede entregar un pedido en curso.");
        }
    }
}