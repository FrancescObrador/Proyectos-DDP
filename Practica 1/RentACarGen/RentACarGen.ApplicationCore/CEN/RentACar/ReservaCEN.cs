

using System;
using System.Text;
using System.Collections.Generic;

using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


namespace RentACarGen.ApplicationCore.CEN.RentACar
{
/*
 *      Definition of the class ReservaCEN
 *
 */
public partial class ReservaCEN
{
private IReservaRepository _IReservaRepository;

public ReservaCEN(IReservaRepository _IReservaRepository)
{
        this._IReservaRepository = _IReservaRepository;
}

public IReservaRepository get_IReservaRepository ()
{
        return this._IReservaRepository;
}

public int New_ (Nullable<DateTime> p_inicio, Nullable<DateTime> p_final, string p_cliente)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();
        reservaEN.Inicio = p_inicio;

        reservaEN.Final = p_final;


        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                reservaEN.Cliente = new RentACarGen.ApplicationCore.EN.RentACar.ClienteEN ();
                reservaEN.Cliente.DNI = p_cliente;
        }



        oid = _IReservaRepository.New_ (reservaEN);
        return oid;
}

public void Destroy (int id
                     )
{
        _IReservaRepository.Destroy (id);
}
}
}
