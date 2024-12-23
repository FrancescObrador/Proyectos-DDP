
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface ICocheRepository
{
void setSessionCP (GenericSessionCP session);

CocheEN ReadOIDDefault (int id
                        );

void ModifyDefault (CocheEN coche);

System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size);



int New_ (CocheEN coche);

void Modify (CocheEN coche);


void Destroy (int id
              );






CocheEN ReadOID (int id
                 );


System.Collections.Generic.IList<CocheEN> ReadAll (int first, int size);
}
}
