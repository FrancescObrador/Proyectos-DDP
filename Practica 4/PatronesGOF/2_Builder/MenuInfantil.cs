using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace builder
{
    public class MenuInfantil : MenuBuilder
    {
        public override void ConstruirPlato()
        {
            menu.PlatoPrincipal = "Hamburguesa";
        }

        public override void ConstruirAcompanamiento()
        {
            menu.Acompanamiento = "Patatas fritas";
        }

        public override void ConstruirBebida()
        {
            menu.Bebida = "Zumo de manzana";
        }

        public override void ConstruirJuguete()
        {
            menu.Juguete = "Carta TCG Pokemon";
        }
    }
}