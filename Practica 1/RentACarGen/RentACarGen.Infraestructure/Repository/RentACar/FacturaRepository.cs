
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
 * Clase Factura:
 *
 */

namespace RentACarGen.Infraestructure.Repository.RentACar
{
public partial class FacturaRepository : BasicRepository, IFacturaRepository
{
public FacturaRepository() : base ()
{
}


public FacturaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FacturaEN ReadOIDDefault (int id
                                 )
{
        FacturaEN facturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                facturaEN = (FacturaEN)session.Get (typeof(FacturaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FacturaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FacturaEN>();
                        else
                                result = session.CreateCriteria (typeof(FacturaNH)).List<FacturaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);

                facturaNH.Fecha = factura.Fecha;


                facturaNH.EsPagada = factura.EsPagada;


                facturaNH.EsAnulada = factura.EsAnulada;


                facturaNH.Total = factura.Total;



                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (FacturaEN factura)
{
        FacturaNH facturaNH = new FacturaNH (factura);

        try
        {
                SessionInitializeTransaction ();
                if (factura.LineaFactura != null) {
                        foreach (RentACarGen.ApplicationCore.EN.RentACar.LineaFacturaEN item in factura.LineaFactura) {
                                item.Factura = factura;
                                LineaFacturaNH itemNH = new LineaFacturaNH (item);
                                session.Save (itemNH);
                        }
                }
                if (factura.Cliente != null) {
                        // Argumento OID y no colección.
                        facturaNH
                        .Cliente = (RentACarGen.ApplicationCore.EN.RentACar.ClienteEN)session.Load (typeof(RentACarGen.ApplicationCore.EN.RentACar.ClienteEN), factura.Cliente.DNI);

                        facturaNH.Cliente.Factura
                        .Add (facturaNH);
                }

                session.Save (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaNH.Id;
}

public void Modify (FacturaEN factura)
{
        try
        {
                SessionInitializeTransaction ();
                FacturaNH facturaNH = (FacturaNH)session.Load (typeof(FacturaNH), factura.Id);

                facturaNH.Fecha = factura.Fecha;


                facturaNH.EsPagada = factura.EsPagada;


                facturaNH.EsAnulada = factura.EsAnulada;


                facturaNH.Total = factura.Total;

                session.Update (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
