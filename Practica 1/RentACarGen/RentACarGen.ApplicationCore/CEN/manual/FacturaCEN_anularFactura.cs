
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


/*PROTECTED REGION ID(usingRentACarGen.ApplicationCore.CEN.RentACar_Factura_anularFactura) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarGen.ApplicationCore.CEN.RentACar
{
public partial class FacturaCEN
{
public void AnularFactura (int p_oid)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Factura_anularFactura) ENABLED START*/

        var factura = _IFacturaRepository.ReadOID (p_oid);

        if (factura.EsPagada) {
                throw new Exception ("No se puede anular una factura pagada");
        }

        if (!factura.EsAnulada) {
                factura.EsAnulada = true;
                _IFacturaRepository.ModifyDefault (factura);
        }

        /*PROTECTED REGION END*/
}
}
}
