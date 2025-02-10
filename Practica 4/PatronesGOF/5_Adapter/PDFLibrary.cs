using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    public class PDFLibrary
    {
        public void SetContent(string content)
        {
            Console.WriteLine("PDF: Contenido cargado en el PDF.");
        }

        public void Render()
        {
            Console.WriteLine("PDF: Renderizando el documento PDF.");
        }

        public void PrintPDF()
        {
            Console.WriteLine("PDF: Imprimiendo el PDF.");
        }
    }
}