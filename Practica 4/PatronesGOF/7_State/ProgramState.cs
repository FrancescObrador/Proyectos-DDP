using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class ProgramState
    {
        static void Main()
        {
            var pedido = new Pedido();

            pedido.AgregaProducto(); // EnCurso
            pedido.Borra();          // EnCurso
            pedido.Valida();         // Cambia a Validado
            pedido.AgregaProducto(); // Validado
            pedido.Entrega();        // Cambia a Entregado
            pedido.Borra();          // Entregado
        }
    }
}
