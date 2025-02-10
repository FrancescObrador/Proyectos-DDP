using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace builder
{
    public abstract class MenuBuilder
    {
        protected Menu menu = new Menu();

        public abstract void ConstruirPlato();
        public abstract void ConstruirAcompanamiento();
        public abstract void ConstruirBebida();
        public abstract void ConstruirJuguete();

        public Menu ObtenerMenu() => menu;
    }
}