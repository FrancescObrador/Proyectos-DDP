using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class GrupoDeEmpresas : IEmpresa
    {
        private string nombre;
        private List<IEmpresa> filiales = new List<IEmpresa>();

        public GrupoDeEmpresas(string nombre)
        {
            this.nombre = nombre;
        }

        public void AddFilial(IEmpresa filial)
        {
            filiales.Add(filial);
        }

        public int GetTotalVehiculos()
        {

            int vehiculos = 0;
            foreach (var filial in filiales)
            {
                vehiculos += filial.GetTotalVehiculos();
                filial.MostrarVehiculos();
            }

            return vehiculos;
        }

        public void MostrarVehiculos()
        {
            Console.WriteLine("\nLas filiales del grupo: ");
            int vehiculos = GetTotalVehiculos();
            Console.WriteLine($"El grupo de empresas {nombre} tiene en total {vehiculos} vehículos");
        }
    }
}