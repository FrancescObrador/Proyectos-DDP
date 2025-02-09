using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatronesGOF.AbstractFactory
{
    public class Electricidad : ICombustible
    {
        public string ObtenerTipo()
        {
            return "Electricidad";
        }
    }
}