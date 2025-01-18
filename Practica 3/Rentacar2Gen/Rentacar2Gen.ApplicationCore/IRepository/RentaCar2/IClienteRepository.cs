
using System;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;

namespace Rentacar2Gen.ApplicationCore.IRepository.RentaCar2
{
public partial interface IClienteRepository
{
void setSessionCP (GenericSessionCP session);

ClienteEN ReadOIDDefault (string DNI
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



string CrearCliente (ClienteEN cliente);

void BorrarCliente (string DNI
                    );


void Modificar (ClienteEN cliente);


System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN> DameClientesCochesLujo ();
}
}
