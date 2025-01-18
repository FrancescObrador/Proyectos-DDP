
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Factura_nuevaFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class FacturaCEN
{
public int NuevaFactura (string p_cliente)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Factura_nuevaFactura_customized) ENABLED START*/

        FacturaEN facturaEN = null;

        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();

        if (p_cliente != null) {
                facturaEN.Cliente = new ClienteEN ();
                facturaEN.Cliente.DNI = p_cliente;
        }

        facturaEN.Fecha = DateTime.Today;
        facturaEN.EsPagada = false;
        facturaEN.EsAnulada = false;


        //Call to FacturaRepository


        oid = _IFacturaRepository.NuevaFactura (facturaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
