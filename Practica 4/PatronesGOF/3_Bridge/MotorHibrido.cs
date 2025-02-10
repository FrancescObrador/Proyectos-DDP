using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class MotorHibrido : IMotor
    {
        public void Acelerar() => Console.WriteLine("Motor híbrido: Acelerando atope");
        public void Frenar() => Console.WriteLine("Motor híbrido: Frenando atope");
        public void Detener() => Console.WriteLine("Motor híbrido: Detenido.");
    }
}