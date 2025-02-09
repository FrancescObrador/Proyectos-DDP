using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatronesGOF.AbstractFactory
{
    public class Catalogo
    {
        private IFabricaVehiculo _fabrica;

        public Catalogo(IFabricaVehiculo fabrica)
        {
            _fabrica = fabrica;
        }   

        public void MostrarVehiculos()
        {
            var automovil = _fabrica.CrearAutomovil();
            var scooter = _fabrica.CrearScooter();

            automovil.Mostrar();
            scooter.Mostrar();

        }
    }
}