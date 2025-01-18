
using System;
using System.Text;
using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_desreservar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
public partial class CocheCEN
{
public void Desreservar (int p_oid)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CEN.RentaCar2_Coche_desreservar) ENABLED START*/

        CocheEN en = _ICocheRepository.ReadOIDDefault (p_oid);

        if (!(en.Estado == Enumerated.RentaCar2.EstadoCocheEnum.alquilado))
                throw new ModelException ("Para poder desreservar el coche debe estar alquilado");

        en.Estado = Enumerated.RentaCar2.EstadoCocheEnum.libre;

        _ICocheRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
