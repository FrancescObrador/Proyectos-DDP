using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace builder
{
    public class MenuInfantilNuggets : MenuBuilder
    {
        public override void ConstruirPlato()
        {
            menu.PlatoPrincipal = "Pack de 9 nuggets";
        }

        public override void ConstruirAcompanamiento()
        {
            menu.Acompanamiento = "Patatas fritas";
        }

        public override void ConstruirBebida()
        {
            menu.Bebida = "Zumo de naranja";
        }

        public override void ConstruirJuguete()
        {
            menu.Juguete = "Hot wheels";
        }
    }
}