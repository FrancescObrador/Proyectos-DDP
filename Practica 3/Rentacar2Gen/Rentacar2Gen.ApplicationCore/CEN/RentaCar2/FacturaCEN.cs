

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaRepository _IFacturaRepository;

public FacturaCEN(IFacturaRepository _IFacturaRepository)
{
        this._IFacturaRepository = _IFacturaRepository;
}

public IFacturaRepository get_IFacturaRepository ()
{
        return this._IFacturaRepository;
}

public void Modificar (int p_Factura_OID, Nullable<DateTime> p_fecha, bool p_esPagada, bool p_esAnulada, float p_total)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Id = p_Factura_OID;
        facturaEN.Fecha = p_fecha;
        facturaEN.EsPagada = p_esPagada;
        facturaEN.EsAnulada = p_esAnulada;
        facturaEN.Total = p_total;
        //Call to FacturaRepository

        _IFacturaRepository.Modificar (facturaEN);
}
}
}
