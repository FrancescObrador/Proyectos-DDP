
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
 * Clase Coche:
 *
 */

namespace RentACarGen.Infraestructure.Repository.RentACar
{
public partial class CocheRepository : BasicRepository, ICocheRepository
{
public CocheRepository() : base ()
{
}


public CocheRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CocheEN ReadOIDDefault (int id
                               )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return cocheEN;
}

public System.Collections.Generic.IList<CocheEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CocheNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                        else
                                result = session.CreateCriteria (typeof(CocheNH)).List<CocheEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);

                cocheNH.Categoria = coche.Categoria;


                cocheNH.Estado = coche.Estado;


                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CocheEN coche)
{
        CocheNH cocheNH = new CocheNH (coche);

        try
        {
                SessionInitializeTransaction ();

                session.Save (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheNH.Id;
}

public void Modify (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.Id);

                cocheNH.Categoria = coche.Categoria;


                cocheNH.Estado = coche.Estado;

                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), id);
                session.Delete (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
