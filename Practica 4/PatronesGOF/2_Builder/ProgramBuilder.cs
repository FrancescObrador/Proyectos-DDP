using builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
   class Program_Builder
    {
        static void Main()
        {
            MenuBuilder builder = new MenuInfantil();
            Cajero cajero = new Cajero(builder);
            Menu menu = cajero.CrearMenu();

            Console.WriteLine("Menú Infantil: \n" + menu.MostrarMenu());

            cajero.builder = new MenuInfantilNuggets();
            Menu menu2 = cajero.CrearMenu();

            Console.WriteLine("\nMenú Infantil Nuggets: \n" + menu2.MostrarMenu());
        }
    }
}
  