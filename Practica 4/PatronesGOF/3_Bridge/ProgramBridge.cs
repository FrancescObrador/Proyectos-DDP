using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program_Brige
    {
        static void Main()
        {
            Formula1 f1 = new Formula1(new MotorCombustion());

            Console.WriteLine("Fórmula 1 con motor de combustión:");
            f1.Acelerar();
            f1.Frenar();
            f1.Detener();

            Console.WriteLine("\nFórmula 1 con motor eléctrico:");
            f1.CambiarMotor(new MotorElectrico());
            f1.Acelerar();
            f1.Frenar();
            f1.Detener();

            Console.WriteLine("\nFórmula 1 con motor híbrido:");
            f1.CambiarMotor(new MotorHibrido());
            f1.Acelerar();
            f1.Frenar();
            f1.Detener();

        }
    }
}
