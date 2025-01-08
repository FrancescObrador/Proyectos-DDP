
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface IFacturaRepository
{
void setSessionCP (GenericSessionCP session);

FacturaEN ReadOIDDefault (int id
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int CrearFactura (FacturaEN factura);

void ModificarFactura (FacturaEN factura);


FacturaEN DamePorOID (int id
                      );


System.Collections.Generic.IList<FacturaEN> DameTodos (int first, int size);
}
}
