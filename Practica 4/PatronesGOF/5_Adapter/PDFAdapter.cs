using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    public class PDFAdapter : IDocumento
    {
        private readonly PDFLibrary _pdf;

        public PDFAdapter()
        {
            _pdf = new PDFLibrary();
        }

        public void SetContenido(string contenido)
        {
            _pdf.SetContent(contenido);
        }

        public void Dibuja()
        {
            _pdf.Render();
        }

        public void Imprime()
        {
            _pdf.PrintPDF();
        }
    }
}