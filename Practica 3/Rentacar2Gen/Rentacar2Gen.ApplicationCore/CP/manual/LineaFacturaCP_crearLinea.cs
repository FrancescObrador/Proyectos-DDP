
using System;
using System.Text;

using System.Collections.Generic;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;



/*PROTECTED REGION ID(usingRentacar2Gen.ApplicationCore.CP.RentaCar2_LineaFactura_crearLinea) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Rentacar2Gen.ApplicationCore.CP.RentaCar2
{
public partial class LineaFacturaCP : GenericBasicCP
{
public Rentacar2Gen.ApplicationCore.EN.RentaCar2.LineaFacturaEN CrearLinea (int p_factura, int p_reserva, double p_precio)
{
        /*PROTECTED REGION ID(Rentacar2Gen.ApplicationCore.CP.RentaCar2_LineaFactura_crearLinea) ENABLED START*/

        LineaFacturaCEN lineaFacturaCEN = null;
            FacturaCEN facturaCEN = null;

        Rentacar2Gen.ApplicationCore.EN.RentaCar2.LineaFacturaEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                lineaFacturaCEN = new  LineaFacturaCEN (CPSession.UnitRepo.LineaFacturaRepository);
                facturaCEN = new FacturaCEN(CPSession.UnitRepo.FacturaRepository);



                int oid;
                //Initialized LineaFacturaEN
                LineaFacturaEN lineaFacturaEN;
                lineaFacturaEN = new LineaFacturaEN ();

                if (p_factura != -1) {
                        lineaFacturaEN.Factura = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN ();
                        lineaFacturaEN.Factura.Id = p_factura;
                }


                if (p_reserva != -1) {
                        lineaFacturaEN.Reserva = new Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN ();
                        lineaFacturaEN.Reserva.Id = p_reserva;
                }

                lineaFacturaEN.Precio = p_precio;

                oid = lineaFacturaCEN.get_ILineaFacturaRepository ().CrearLinea (lineaFacturaEN);

                result = lineaFacturaCEN.get_ILineaFacturaRepository ().ReadOIDDefault (oid);
                result.Factura.Total += (float)lineaFacturaEN.Precio;

                facturaCEN.get_IFacturaRepository().ModifyDefault(result.Factura);


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
