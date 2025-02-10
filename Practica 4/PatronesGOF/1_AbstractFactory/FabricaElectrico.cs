using PatronesGOF.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatronesGOF.AbstractFactory
{
    public class FabricaElectrico : IFabricaVehiculo
    {

        public IVehiculo CrearAutomovil()
        {
            return new Automovil(new Electricidad());
        }

        public IVehiculo CrearScooter()
        {
            return new Scooter(new Electricidad());
        }
    }
}