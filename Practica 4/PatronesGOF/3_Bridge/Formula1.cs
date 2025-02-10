using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class Formula1
    {
        protected IMotor _motor;

        public Formula1(IMotor motor)
        {
            _motor = motor;
        }

        public void CambiarMotor(IMotor motor)
        {
            _motor = motor;
        }

        public void Acelerar()
        {
            _motor.Acelerar();
        }
        public void Frenar()
        {
            _motor.Frenar();
        }
        public void Detener()
        {
            _motor.Detener();
        }
    }
}