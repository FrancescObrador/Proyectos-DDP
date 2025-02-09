using Interfaces;
using PatronesGOF.AbstractFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Factories
{
    public class FabricaGasolina : IFabricaVehiculo
    {
        public IVehiculo CrearAutomovil()
        {
            return new Automovil(new Gasolina());
        }

        public IVehiculo CrearScooter()
        {
            return new Scooter(new Gasolina());
        }
    }
}