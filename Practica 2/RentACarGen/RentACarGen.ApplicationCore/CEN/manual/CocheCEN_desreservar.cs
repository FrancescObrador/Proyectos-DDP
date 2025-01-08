
using System;
using System.Text;
using System.Collections.Generic;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.IRepository.RentACar;


/*PROTECTED REGION ID(usingRentACarGen.ApplicationCore.CEN.RentACar_Coche_desreservar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace RentACarGen.ApplicationCore.CEN.RentACar
{
public partial class CocheCEN
{
public bool Desreservar (int p_numLicencia, int p_idReserva)
{
        /*PROTECTED REGION ID(RentACarGen.ApplicationCore.CEN.RentACar_Coche_desreservar) ENABLED START*/

        CocheEN cocheEN = DamePorOID (p_numLicencia);

        if (cocheEN.Estado == Enumerated.RentACar.EstadoCocheEnum.alquilado) {
                cocheEN.Estado = Enumerated.RentACar.EstadoCocheEnum.libre;

                _ICocheRepository.ModifyDefault (cocheEN);
                DesasignarReserva (cocheEN.NumLicencia, p_idReserva);

                return true;
        }

        return false;

        /*PROTECTED REGION END*/
}
}
}
