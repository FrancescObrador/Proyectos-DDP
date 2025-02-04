using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatronesGOF.AbstractFactory
{
    public class Scooter : IVehiculo
    {
        private ICombustible _combustible;

        public Scooter(ICombustible combustible)
        {
            _combustible = combustible;
        }

        public void Mostrar()
        {
            Console.WriteLine("Scooter" + _combustible.ObtenerTipo());
        }
    }
}