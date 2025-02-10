using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    public class Pedido
    {
        private IEstadoPedido _estado;

        public Pedido()
        {
            _estado = new EnCurso(); // Estado inicial
        }

        public void CambiarEstado(IEstadoPedido nuevoEstado)
        {
            _estado = nuevoEstado;
        }

        public void AgregaProducto()
        {
            _estado.AgregaProducto(this);
        }

        public void Borra()
        {
            _estado.Borra(this);
        }

        public void Valida()
        {
            _estado.Valida(this);
        }

        public void Entrega()
        {
            _estado.Entrega(this);
        }
    }
}