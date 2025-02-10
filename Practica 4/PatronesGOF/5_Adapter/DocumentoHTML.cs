using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    public class DocumentoHTML : IDocumento
    {
        private string _contenido;

        public void SetContenido(string contenido)
        {
            _contenido = contenido;
            Console.WriteLine("HTML: Contenido establecido.");
        }

        public void Dibuja()
        {
            Console.WriteLine($"HTML: Dibujando documento: {_contenido}");
        }

        public void Imprime()
        {
            Console.WriteLine($"HTML: Imprimiendo documento: {_contenido}");
        }
    }
}