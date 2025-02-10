using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public interface IEstadoPedido
    {
        void AgregaProducto(Pedido pedido);
        void Borra(Pedido pedido);
        void Valida(Pedido pedido);
        void Entrega(Pedido pedido);
    }
}