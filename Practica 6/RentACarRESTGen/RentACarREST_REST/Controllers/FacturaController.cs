using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RentACarREST_REST.DTO;
using RentACarREST_REST.DTOA;
using RentACarREST_REST.CAD;
using RentACarREST_REST.Assemblers;
using RentACarREST_REST.AssemblersDTO;
using RentACarRESTGen.ApplicationCore.EN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CEN.RentACarREST;
using RentACarRESTGen.ApplicationCore.CP.RentACarREST;


/*PROTECTED REGION ID(usingRentACarREST_REST_FacturaControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace RentACarREST_REST.Controllers
{
[ApiController]
[Route ("~/api/Factura")]
public class FacturaController : BasicController
{
// Voy a generar el readAll






























[HttpPost]

[Route ("~/api/Factura/Factura_dameTotal")]

public ActionResult<double>

Factura_dameTotal (int p_oid)
{
        // CP, returnValue
        FacturaCP facturaCP = null;

        double returnValue;

        try
        {
                session.SessionInitializeTransaction ();




                facturaCP = new FacturaCP (session, unitRepo);

                // Operation
                returnValue = facturaCP.DameTotal (p_oid);
                session.Commit ();
        }

        catch (Exception e)
        {
                session.RollBack ();

                StatusCodeResult result = StatusCode (500);
                if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) && e.Message.Equals ("El token es incorrecto")) result = StatusCode (403);
                else if (e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.ModelException) || e.GetType () == typeof(RentACarRESTGen.ApplicationCore.Exceptions.DataLayerException)) result = StatusCode (400);
                return result;
        }
        finally
        {
                session.SessionClose ();
        }

        // Return 200 - OK
        return returnValue;
}





/*PROTECTED REGION ID(RentACarREST_REST_FacturaControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
