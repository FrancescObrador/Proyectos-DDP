
using System;
using System.Text;

using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using System.Linq;
using System.Security.Cryptography;



/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CP.RentaCar2_Reserva_RealizarReserva) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CP.RentaCar2
{
public partial class ReservaCP : GenericBasicCP
{
public float RealizarReserva(int p_oid, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum categoriaCoche, string nif)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CP.RentaCar2_Reserva_RealizarReserva) ENABLED START*/

        ReservaCEN reservaCEN = null;
        CocheCEN cocheCEN = null;
        FacturaCEN facturaCEN = null;

            float result = 0;

        try
        {
                CPSession.SessionInitializeTransaction ();
                reservaCEN = new  ReservaCEN (CPSession.UnitRepo.ReservaRepository);
                cocheCEN = new CocheCEN (CPSession.UnitRepo.CocheRepository);
                facturaCEN = new FacturaCEN (CPSession.UnitRepo.FacturaRepository);

                int reservaId = reservaCEN.CrearReserva (nif, fechaInicio, fechaFin);


                IList<CocheEN> cochesEN = cocheCEN.DameCochesDisponibles (categoriaCoche);

                if (cochesEN.Count > 0) {
                        // Asignar coche
                        CocheEN cocheEN = cochesEN.FirstOrDefault ();

                        // 1
                        cocheCEN.AsignarReserva (cocheEN.NumLicencia, reservaId);
                    
                        //2
                        cocheCEN.Reservar(cocheEN.NumLicencia);
                        cocheEN.Estado = Enumerated.RentaCar2.EstadoCocheEnum.alquilado;

                        //3
                        TimeSpan? diasAlquilado = fechaFin - fechaInicio;

                        var precio = (float)(cocheEN.PrecioDia * diasAlquilado.Value.TotalDays);

                        // 4
                        int facturaId = facturaCEN.NuevaFactura (nif);

                        // 5
                        LineaFacturaCP lineaFacturaCP = new LineaFacturaCP(CPSession);
                        bool insideTransactonTemp = CPSession.InsideTransaction;
                        CPSession.InsideTransaction = false;
                        LineaFacturaEN lineaFactura = lineaFacturaCP.CrearLinea (facturaId, reservaId, precio);
                        CPSession.InsideTransaction = insideTransactonTemp;


                   ReservaEN reservaEN = reservaCEN.get_IReservaRepository().ReadOIDDefault(reservaId);
                
                   
                    result = precio; 
                }

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        
        }
            return result;

        /*PROTECTED REGION END*/
}
}
}
