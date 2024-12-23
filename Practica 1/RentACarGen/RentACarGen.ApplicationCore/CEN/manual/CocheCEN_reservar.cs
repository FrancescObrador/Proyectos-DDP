
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


/*PROTECTED REGION ID(usingRentACarGen.ApplicationCore.CEN.RentACar_Coche_reservar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarGen.ApplicationCore.CEN.RentACar
{
public partial class CocheCEN
{
public void Reservar (int p_oid, int p_oid_reserva)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Coche_reservar) ENABLED START*/

        CocheEN cocheEN = _ICocheRepository.ReadOIDDefault (p_oid);

        if (cocheEN == null) {
                throw new ModelException ($ "El coche con ID {p_oid} no existe.");
        }

        try
        {
                if (cocheEN.Estado == Enumerated.RentACar.EstadoCocheEnum.libre) {
                        cocheEN.Estado = Enumerated.RentACar.EstadoCocheEnum.alquilado;

                        if (cocheEN.Reserva == null) {
                                cocheEN.Reserva = new ReservaEN ();
                                cocheEN.Reserva.Id = p_oid_reserva;
                        }

                        _ICocheRepository.ModifyDefault (cocheEN);
                        AsignarReserva (p_oid_reserva);
                }
                else{
                        throw new ModelException ("El coche no est� libre");
                }
        }
        catch (Exception e)
        {
                throw new ModelException ("Error en la reserva del coche", e);
        }

        /*PROTECTED REGION END*/
}
}
}
