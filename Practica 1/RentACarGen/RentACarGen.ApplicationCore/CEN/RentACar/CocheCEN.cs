

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

public void Modify (int p_Coche_OID, RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum p_categoria, RentACarGen.ApplicationCore.Enumerated.RentACar.EstadoCocheEnum p_estado)
{
        CocheEN cocheEN = null;

        //Initialized CocheEN
        cocheEN = new CocheEN ();
        cocheEN.Id = p_Coche_OID;
        cocheEN.Categoria = p_categoria;
        cocheEN.Estado = p_estado;
        //Call to CocheRepository

        _ICocheRepository.Modify (cocheEN);
}

public void Destroy (int id
                     )
{
        _ICocheRepository.Destroy (id);
}

public CocheEN ReadOID (int id
                        )
{
        CocheEN cocheEN = null;

        cocheEN = _ICocheRepository.ReadOID (id);
        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> list = null;

        list = _ICocheRepository.ReadAll (first, size);
        return list;
}
}
}
