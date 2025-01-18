
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
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


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> DevuelveReservasAnyo (int ? p_anyo);
}
}
