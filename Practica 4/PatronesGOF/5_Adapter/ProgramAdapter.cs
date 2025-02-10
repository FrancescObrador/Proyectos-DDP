using Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program_Adapter
    {
        static void Main()
        {

            IDocumento documentoHTML = new DocumentoHTML();
            documentoHTML.SetContenido("<html>Hola</html>");
            documentoHTML.Dibuja();
            documentoHTML.Imprime();

            Console.WriteLine("------------------------");

            // Documento PDF usando el Adapter
            IDocumento documentoPDF = new PDFAdapter();
            documentoPDF.SetContenido("Contenido PDF");
            documentoPDF.Dibuja();
            documentoPDF.Imprime();

        }
    }
}
