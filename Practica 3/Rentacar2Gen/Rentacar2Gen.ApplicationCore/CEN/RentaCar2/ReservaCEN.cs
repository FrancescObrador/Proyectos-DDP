

using System;
using System.Text;
using System.Collections.Generic;

using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;


namespace Rentacar2Gen.ApplicationCore.CEN.RentaCar2
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

public int CrearReserva (string p_cliente, Nullable<DateTime> p_inicio, Nullable<DateTime> p_final)
{
        ReservaEN reservaEN = null;
        int oid;

        //Initialized ReservaEN
        reservaEN = new ReservaEN ();

        if (p_cliente != null) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                reservaEN.Cliente = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN ();
                reservaEN.Cliente.DNI = p_cliente;
        }

        reservaEN.Inicio = p_inicio;

        reservaEN.Final = p_final;



        oid = _IReservaRepository.CrearReserva (reservaEN);
        return oid;
}

public void BorrarReserva (int id
                           )
{
        _IReservaRepository.BorrarReserva (id);
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> DevuelveReservasAnyo (int ? p_anyo)
{
        return _IReservaRepository.DevuelveReservasAnyo (p_anyo);
}
}
}
