
using System;
using System.Text;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.Exceptions;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using Rentacar2Gen.ApplicationCore.CP.RentaCar2;
using Rentacar2Gen.Infraestructure.EN.RentaCar2;


/*
 * Clase LineaFactura:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLinea (LineaFacturaEN lineaFactura)
{
        LineaFacturaNH lineaFacturaNH = new LineaFacturaNH (lineaFactura);

        try
        {
                SessionInitializeTransaction ();
                if (lineaFactura.Factura != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Factura = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.FacturaEN), lineaFactura.Factura.Id);

                        lineaFacturaNH.Factura.LineaFactura
                        .Add (lineaFacturaNH);
                }
                if (lineaFactura.Reserva != null) {
                        // Argumento OID y no colección.
                        lineaFacturaNH
                        .Reserva = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN), lineaFactura.Reserva.Id);

                        lineaFacturaNH.Reserva.LineaFactura
                                = lineaFacturaNH;
                }

                session.Save (lineaFacturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in LineaFacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaFacturaNH.NumLinea;
}
}
}
