

using System;
using System.Text;
using System.Collections.Generic;

using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;
using Newtonsoft.Json;


namespace RentACarGen.ApplicationCore.CEN.RentACar
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

public string New_ (string p_DNI, string p_nombre, string p_direccion, string p_telefono)
{
        ClienteEN clienteEN = null;
        string oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_DNI;

        clienteEN.Nombre = p_nombre;

        clienteEN.Direccion = p_direccion;

        clienteEN.Telefono = p_telefono;



        oid = _IClienteRepository.New_ (clienteEN);
        return oid;
}

public void Modify (string p_Cliente_OID, string p_nombre, string p_direccion, string p_telefono)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.DNI = p_Cliente_OID;
        clienteEN.Nombre = p_nombre;
        clienteEN.Direccion = p_direccion;
        clienteEN.Telefono = p_telefono;
        //Call to ClienteRepository

        _IClienteRepository.Modify (clienteEN);
}

public void Destroy (string DNI
                     )
{
        _IClienteRepository.Destroy (DNI);
}

public string Login (string p_Cliente_OID, string p_pass)
{
        string result = null;
        ClienteEN en = _IClienteRepository.ReadOIDDefault (p_Cliente_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.DNI);

        return result;
}




private string Encode ()
{
        var payload = new Dictionary<string, object>(){
                {}
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string DNI)
{
        ClienteEN en = _IClienteRepository.ReadOIDDefault (DNI);
        string token = Encode ();

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerDNI (decodedToken);

                ClienteEN en = _IClienteRepository.ReadOIDDefault (id);

                if (en != null && ((string)en.DNI).Equals (ObtenerDNI (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}
}
}
