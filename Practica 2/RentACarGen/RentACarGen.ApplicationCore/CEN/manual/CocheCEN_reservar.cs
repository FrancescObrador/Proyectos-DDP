
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
public bool Reservar (int p_numLicencia, int p_idReserva)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Coche_reservar) ENABLED START*/

        CocheEN cocheEN = DamePorOID (p_numLicencia);

        if (cocheEN.Estado == Enumerated.RentACar.EstadoCocheEnum.libre) {
                cocheEN.Estado = Enumerated.RentACar.EstadoCocheEnum.alquilado;

                ModificarCoche (cocheEN.NumLicencia, cocheEN.Categoria, cocheEN.Estado);
                AsignarReserva (cocheEN.NumLicencia, p_idReserva);

                return true;
        }

        return false;
        /*PROTECTED REGION END*/
}
}
}
