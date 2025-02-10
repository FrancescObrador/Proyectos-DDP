using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class MotorCombustion : IMotor
    {
        public void Acelerar() => Console.WriteLine("Motor de combustión: Acelerando");
        public void Frenar() => Console.WriteLine("Motor de combustión: Frenando");
        public void Detener() => Console.WriteLine("Motor de combustión: Detenido.");
    }
}