using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace builder
{
    public class Menu
    {
        public string PlatoPrincipal { get; set; } = "no";
        public string Acompanamiento { get; set; } = "no";
        public string Bebida { get; set; } = "no";
        public string Juguete { get; set; } = "no"; 

        public string MostrarMenu()
        {
            return $"Plato principal: {PlatoPrincipal}\nAcompañamiento: {Acompanamiento}\nBebida: {Bebida}\nJuguete: {Juguete}";
        }
    }
}