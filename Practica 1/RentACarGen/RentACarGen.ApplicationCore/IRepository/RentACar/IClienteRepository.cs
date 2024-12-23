
using System;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;

namespace RentACarGen.ApplicationCore.IRepository.RentACar
{
public partial interface IClienteRepository
{
void setSessionCP (GenericSessionCP session);

ClienteEN ReadOIDDefault (string DNI
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



string New_ (ClienteEN cliente);

void Modify (ClienteEN cliente);


void Destroy (string DNI
              );



ClienteEN ReadOID (string DNI
                   );


System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size);
}
}
