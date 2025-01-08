
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



string CrearCliente (ClienteEN cliente);

void ModificarCliente (ClienteEN cliente);


void BorrarCliente (string DNI
                    );



ClienteEN DamePorOID (string DNI
                      );


System.Collections.Generic.IList<ClienteEN> DameTodos (int first, int size);
}
}
