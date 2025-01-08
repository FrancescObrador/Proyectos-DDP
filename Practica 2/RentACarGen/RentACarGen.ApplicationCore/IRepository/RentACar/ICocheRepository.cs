
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface ICocheRepository
{
void setSessionCP (GenericSessionCP session);

CocheEN ReadOIDDefault (int numLicencia
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



int CrearCoche (CocheEN coche);

void ModificarCoche (CocheEN coche);


void BorrarCoche (int numLicencia
                  );


CocheEN DamePorOID (int numLicencia
                    );


System.Collections.Generic.IList<CocheEN> DameTodos (int first, int size);



void AsignarReserva (int p_Coche_OID, int p_reserva_OID);


void DesasignarReserva (int p_Coche_OID, int p_reserva_OID);
}
}
