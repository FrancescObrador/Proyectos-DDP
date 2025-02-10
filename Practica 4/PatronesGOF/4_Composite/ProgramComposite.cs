using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program_Composite
    {
        static void Main()
        {
           
            var empresaA = new Empresa("Empresa A", 10);
            var empresaB = new Empresa("Empresa B", 200);

            var grupo = new GrupoDeEmpresas("Grupo CD");
            var empresaC = new Empresa("Empresa C", 100);
            var empresaD = new Empresa("Empresa D", 50);

            grupo.AddFilial(empresaC);
            grupo.AddFilial(empresaD);

            empresaA.MostrarVehiculos();
            empresaB.MostrarVehiculos();

            grupo.MostrarVehiculos();

            Console.WriteLine("-------------------\n");
            Console.WriteLine("Anidacion a 2 niveles de composite:");
            var macroGrupo = new GrupoDeEmpresas("Grupo ABCD");
            macroGrupo.AddFilial(empresaA);
            macroGrupo.AddFilial(empresaB);
            macroGrupo.AddFilial(grupo);

            macroGrupo.MostrarVehiculos();


        }
    }
}
