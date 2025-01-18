
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface ICocheRepository
{
void setSessionCP (GenericSessionCP session);

CocheEN ReadOIDDefault (int numLicencia
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



int CrearCoche (CocheEN coche);

void BorrarCoche (int numLicencia
                  );


void AsignarReserva (int p_Coche_OID, int p_reserva_OID);

void DesasignarReserva (int p_Coche_OID, int p_reserva_OID);



void Modificar (CocheEN coche);


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> DameCochesDisponibles (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum ? p_categoria);
}
}
