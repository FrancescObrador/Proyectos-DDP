

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
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

public int CrearCoche (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum p_categoria, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum p_estado, float p_precioDia)
{
        CocheEN cocheEN = null;
        int oid;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Categoria = p_categoria;

        cocheEN.Estado = p_estado;

        cocheEN.PrecioDia = p_precioDia;



        oid = _ICocheRepository.CrearCoche (cocheEN);
        return oid;
}

public void BorrarCoche (int numLicencia
                         )
{
        _ICocheRepository.BorrarCoche (numLicencia);
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
public void Modificar (int p_Coche_OID, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum p_categoria, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoCocheEnum p_estado, float p_precioDia)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.NumLicencia = p_Coche_OID;
        cocheEN.Categoria = p_categoria;
        cocheEN.Estado = p_estado;
        cocheEN.PrecioDia = p_precioDia;
        //Call to CocheRepository

        _ICocheRepository.Modificar (cocheEN);
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> DameCochesDisponibles (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum ? p_categoria)
{
        return _ICocheRepository.DameCochesDisponibles (p_categoria);
}
}
}
