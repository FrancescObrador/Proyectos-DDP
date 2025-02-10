using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program_Command
    {
        static void Main()
        {
            // Crear el catálogo con un precio inicial
            var catalogo = new Catalogo(10000);
            Console.WriteLine($"Precio inicial: {catalogo.PrecioOcasión}");

            // Crear el comando para rebajar el precio en un 10%
            var rebajarPrecioCommand = new RebajarPrecioCommand(catalogo, 10);

            // Crear el invocador y asignar el comando
            var invoker = new Invoker();
            invoker.SetCommand(rebajarPrecioCommand);

            // Ejecutar el comando
            invoker.ExecuteCommand();

            // Anular el comando (restaurar el precio)
            invoker.UndoCommand();
        }
    }
}
