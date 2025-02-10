using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command
{
    public class Catalogo
    {
        public double PrecioOcasión { get; set; }

        public Catalogo(double precioInicial)
        {
            PrecioOcasión = precioInicial;
        }

        public void RebajarPrecio(double porcentaje)
        {
            PrecioOcasión -= PrecioOcasión * (porcentaje / 100);
            Console.WriteLine($"Precio rebajado: {PrecioOcasión}");
        }

        public void RestaurarPrecio(double precioAnterior)
        {
            PrecioOcasión = precioAnterior;
            Console.WriteLine($"Precio restaurado: {PrecioOcasión}");
        }
    }
}