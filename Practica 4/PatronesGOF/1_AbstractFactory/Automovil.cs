using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatronesGOF.AbstractFactory
{
    public class Automovil : IVehiculo
    {
        private ICombustible _combustible;

        public Automovil(ICombustible combustible)
        {
            _combustible = combustible;
        }

        public void Mostrar()
        {
            Console.WriteLine("Automóvil " + _combustible.ObtenerTipo());
        }
    }
}