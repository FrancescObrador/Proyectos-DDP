
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


/*PROTECTED REGION ID(usingRentACarGen.ApplicationCore.CEN.RentACar_Factura_pagarFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarGen.ApplicationCore.CEN.RentACar
{
public partial class FacturaCEN
{
public void PagarFactura (int p_oid)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Factura_pagarFactura) ENABLED START*/

        var factura = _IFacturaRepository.DamePorOID (p_oid);

        if (factura != null && !factura.EsPagada) {
                factura.EsPagada = true;
                _IFacturaRepository.ModificarFactura (factura);
        }

        /*PROTECTED REGION END*/
}
}
}
