

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
{
/*
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteRepository _IClienteRepository;

public ClienteCEN(IClienteRepository _IClienteRepository)
{
        this._IClienteRepository = _IClienteRepository;
}

public IClienteRepository get_IClienteRepository ()
{
        return this._IClienteRepository;
}

public string CrearCliente (string p_DNI, string p_nombre, string p_direccion, string p_telefono)
{
        ClienteEN clienteEN = null;
        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_DNI;

        clienteEN.Nombre = p_nombre;

        clienteEN.Direccion = p_direccion;

        clienteEN.Telefono = p_telefono;



        oid = _IClienteRepository.CrearCliente (clienteEN);
        return oid;
}

public void BorrarCliente (string DNI
                           )
{
        _IClienteRepository.BorrarCliente (DNI);
}

public void Modificar (string p_Cliente_OID, string p_nombre, string p_direccion, string p_telefono)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_Cliente_OID;
        clienteEN.Nombre = p_nombre;
        clienteEN.Direccion = p_direccion;
        clienteEN.Telefono = p_telefono;
        //Call to ClienteRepository

        _IClienteRepository.Modificar (clienteEN);
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN> DameClientesCochesLujo ()
{
        return _IClienteRepository.DameClientesCochesLujo ();
}
}
}
