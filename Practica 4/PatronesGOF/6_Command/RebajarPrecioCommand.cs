using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    public class RebajarPrecioCommand : ICommand
    {
        private readonly Catalogo _catalogo;
        private readonly double _porcentaje;
        private double _precioAnterior;

        public RebajarPrecioCommand(Catalogo catalogo, double porcentaje)
        {
            _catalogo = catalogo;
            _porcentaje = porcentaje;
        }

        public void Execute()
        {
            _precioAnterior = _catalogo.PrecioOcasión;
            _catalogo.RebajarPrecio(_porcentaje);
        }

        public void Undo()
        {
            _catalogo.RestaurarPrecio(_precioAnterior);
        }
    }
}