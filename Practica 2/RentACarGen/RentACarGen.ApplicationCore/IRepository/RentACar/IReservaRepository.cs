
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface IReservaRepository
{
void setSessionCP (GenericSessionCP session);

ReservaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ReservaEN reserva);

System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size);



int CrearReserva (ReservaEN reserva);

void BorrarReserva (int id
                    );


ReservaEN DamePorOID (int id
                      );


System.Collections.Generic.IList<ReservaEN> DameTodos (int first, int size);
}
}
