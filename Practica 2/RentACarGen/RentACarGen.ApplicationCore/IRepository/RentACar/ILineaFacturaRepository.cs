
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface ILineaFacturaRepository
{
void setSessionCP (GenericSessionCP session);

LineaFacturaEN ReadOIDDefault (int numLinea
                               );

void ModifyDefault (LineaFacturaEN lineaFactura);

System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size);



int CrearLinea (LineaFacturaEN lineaFactura);

LineaFacturaEN DamePorOID (int numLinea
                           );


System.Collections.Generic.IList<LineaFacturaEN> DameTodos (int first, int size);
}
}
