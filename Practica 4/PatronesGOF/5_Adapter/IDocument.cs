using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adapter
{
    public interface IDocumento
    {
        void SetContenido(string contenido);
        void Dibuja();
        void Imprime();
    }
}