using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public interface IMotor
    {
        void Acelerar();
        void Frenar();
        void Detener();
    }
}