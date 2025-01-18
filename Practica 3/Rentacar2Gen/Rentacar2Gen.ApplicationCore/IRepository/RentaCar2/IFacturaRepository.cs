
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IFacturaRepository
{
void setSessionCP (GenericSessionCP session);

FacturaEN ReadOIDDefault (int id
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);





void Modificar (FacturaEN factura);


int NuevaFactura (FacturaEN factura);
}
}
