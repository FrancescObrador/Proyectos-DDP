

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class LineaFacturaCEN
 *
 */
public partial class LineaFacturaCEN
{
private ILineaFacturaRepository _ILineaFacturaRepository;

public LineaFacturaCEN(ILineaFacturaRepository _ILineaFacturaRepository)
{
        this._ILineaFacturaRepository = _ILineaFacturaRepository;
}

public ILineaFacturaRepository get_ILineaFacturaRepository ()
{
        return this._ILineaFacturaRepository;
}
}
}
