
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
 * Clase Factura:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modificar (FacturaEN factura)
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int NuevaFactura (FacturaEN factura)
{
        FacturaNH facturaNH = new FacturaNH (factura);

        try
        {
                SessionInitializeTransaction ();
                if (factura.Cliente != null) {
                        // Argumento OID y no colección.
                        facturaNH
                        .Cliente = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN), factura.Cliente.DNI);

                        facturaNH.Cliente.Factura
                        .Add (facturaNH);
                }

                session.Save (facturaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in FacturaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return facturaNH.Id;
}
}
}
