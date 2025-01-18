
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface ILineaFacturaRepository
{
void setSessionCP (GenericSessionCP session);

LineaFacturaEN ReadOIDDefault (int numLinea
                               );

void ModifyDefault (LineaFacturaEN lineaFactura);

System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size);



int CrearLinea (LineaFacturaEN lineaFactura);
}
}
