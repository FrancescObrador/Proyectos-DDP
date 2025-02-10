using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class Empresa : IEmpresa
    {

        private string nombre;
        private int vehiculos;

        public Empresa(string nombre, int vehiculos)
        {
            this.nombre = nombre;
            this.vehiculos = vehiculos;
        }

        public int GetTotalVehiculos() => vehiculos;

        public void MostrarVehiculos()
        {
            Console.WriteLine($"La empresa {nombre} tiene {vehiculos} vehículos");
        }
    }
}