
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Factura_pagarFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class FacturaCEN
{
public void PagarFactura (int p_oid)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Factura_pagarFactura) ENABLED START*/

        FacturaEN en = _IFacturaRepository.ReadOIDDefault (p_oid);

        if (!(en.EsPagada == true))
                throw new ModelException ("Para poder pagar una factura esta debe estar sin pagar");

        en.EsPagada = true;

        _IFacturaRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
