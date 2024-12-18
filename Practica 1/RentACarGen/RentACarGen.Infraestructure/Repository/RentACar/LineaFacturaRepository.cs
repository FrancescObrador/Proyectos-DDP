
using System;
using System.Text;
using RentACarGen.ApplicationCore.CEN.RentACar;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.Exceptions;
using RentACarGen.ApplicationCore.IRepository.RentACar;
using RentACarGen.ApplicationCore.CP.RentACar;
using RentACarGen.Infraestructure.EN.RentACar;


/*
 * Clase LineaFactura:
 *
 */

namespace RentACarGen.Infraestructure.Repository.RentACar
{
public partial class LineaFacturaRepository : BasicRepository, ILineaFacturaRepository
{
public LineaFacturaRepository() : base ()
{
}


public LineaFacturaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LineaFacturaEN ReadOIDDefault (int numLinea
                                      )
{
        LineaFacturaEN lineaFacturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaFacturaEN = (LineaFacturaEN)session.Get (typeof(LineaFacturaNH), numLinea);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaEN;
}

public System.Collections.Generic.IList<LineaFacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaFacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaFacturaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaFacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaFacturaNH)).List<LineaFacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaFacturaEN lineaFactura)
{
        try
        {
                SessionInitializeTransaction ();
                LineaFacturaNH lineaFacturaNH = (LineaFacturaNH)session.Load (typeof(LineaFacturaNH), lineaFactura.NumLinea);

                lineaFacturaNH.Precio = lineaFactura.Precio;



                session.Update (lineaFacturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaFacturaEN lineaFactura)
{
        LineaFacturaNH lineaFacturaNH = new LineaFacturaNH (lineaFactura);

        try
        {
                SessionInitializeTransaction ();
                if (lineaFactura.Factura != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Factura = (RentACarGen.ApplicationCore.EN.RentACar.FacturaEN)session.Load (typeof(RentACarGen.ApplicationCore.EN.RentACar.FacturaEN), lineaFactura.Factura.Id);

                        lineaFacturaNH.Factura.LineaFactura
                        .Add (lineaFacturaNH);
                }
                if (lineaFactura.Reserva != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Reserva = (RentACarGen.ApplicationCore.EN.RentACar.ReservaEN)session.Load (typeof(RentACarGen.ApplicationCore.EN.RentACar.ReservaEN), lineaFactura.Reserva.Id);

                        lineaFacturaNH.Reserva.LineaFactura
                                = lineaFacturaNH;
                }

                session.Save (lineaFacturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaNH.NumLinea;
}
}
}
