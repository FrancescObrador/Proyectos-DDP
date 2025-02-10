using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class MotorElectrico : IMotor
    {
        public void Acelerar() => Console.WriteLine("Motor eléctrico: Acelerando electricamente");
        public void Frenar() => Console.WriteLine("Motor eléctrico: Frenando electricamente");
        public void Detener() => Console.WriteLine("Motor eléctrico: Detenido.");
    }
}