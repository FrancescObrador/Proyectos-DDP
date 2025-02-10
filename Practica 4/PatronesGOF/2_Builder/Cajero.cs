using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace builder
{
    public class Cajero
    {
        public MenuBuilder builder { get; set; }

        public Cajero(MenuBuilder builder)
        {
            this.builder = builder;
        }

        public Menu CrearMenu()
        {
            builder.ConstruirPlato();
            builder.ConstruirAcompanamiento();
            builder.ConstruirBebida();
            builder.ConstruirJuguete();
            return builder.ObtenerMenu();
        }
    }
}