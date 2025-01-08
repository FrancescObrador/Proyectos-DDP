

using System;
using System.Text;
using System.Collections.Generic;

using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


namespace RentACarGen.ApplicationCore.CEN.RentACar
{
/*
 *      Definition of the class CocheCEN
 *
 */
public partial class CocheCEN
{
private ICocheRepository _ICocheRepository;

public CocheCEN(ICocheRepository _ICocheRepository)
{
        this._ICocheRepository = _ICocheRepository;
}

public ICocheRepository get_ICocheRepository ()
{
        return this._ICocheRepository;
}

public void ModificarCoche (int p_Coche_OID, RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum p_categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.NumLicencia = p_Coche_OID;
        cocheEN.Categoria = p_categoria;
        cocheEN.Estado = p_estado;
        //Call to CocheRepository

        _ICocheRepository.ModificarCoche (cocheEN);
}

public void BorrarCoche (int numLicencia
                         )
{
        _ICocheRepository.BorrarCoche (numLicencia);
}

public CocheEN DamePorOID (int numLicencia
                           )
{
        CocheEN cocheEN = null;

        cocheEN = _ICocheRepository.DamePorOID (numLicencia);
        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> list = null;

        list = _ICocheRepository.DameTodos (first, size);
        return list;
}
public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheRepository

        _ICocheRepository.AsignarReserva (p_Coche_OID, p_reserva_OID);
}
public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        //Call to CocheRepository

        _ICocheRepository.DesasignarReserva (p_Coche_OID, p_reserva_OID);
}
}
}
