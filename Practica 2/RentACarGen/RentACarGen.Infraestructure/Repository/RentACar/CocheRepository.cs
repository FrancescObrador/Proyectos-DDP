
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


public CocheEN ReadOIDDefault (int numLicencia
                               )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), numLicencia);
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
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.NumLicencia);

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


public int CrearCoche (CocheEN coche)
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

        return cocheNH.NumLicencia;
}

public void ModificarCoche (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.NumLicencia);

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
public void BorrarCoche (int numLicencia
                         )
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), numLicencia);
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

//Sin e: DamePorOID
//Con e: CocheEN
public CocheEN DamePorOID (int numLicencia
                           )
{
        CocheEN cocheEN = null;

        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Get (typeof(CocheNH), numLicencia);
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

public System.Collections.Generic.IList<CocheEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<CocheEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CocheNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CocheEN>();
                else
                        result = session.CreateCriteria (typeof(CocheNH)).List<CocheEN>();
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

        return result;
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        RentACarGen.ApplicationCore.EN.RentACar.CocheEN cocheEN = null;
        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);
                cocheEN.Reserva = (RentACarGen.ApplicationCore.EN.RentACar.ReservaEN)session.Load (typeof(RentACarGen.Infraestructure.EN.RentACar.ReservaNH), p_reserva_OID);

                cocheEN.Reserva.Coche = cocheEN;




                session.Update (cocheEN);
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

public void DesasignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        try
        {
                SessionInitializeTransaction ();
                RentACarGen.ApplicationCore.EN.RentACar.CocheEN cocheEN = null;
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);

                if (cocheEN.Reserva.Id == p_reserva_OID) {
                        cocheEN.Reserva = null;
                        RentACarGen.ApplicationCore.EN.RentACar.ReservaEN reservaEN = (RentACarGen.ApplicationCore.EN.RentACar.ReservaEN)session.Load (typeof(RentACarGen.Infraestructure.EN.RentACar.ReservaNH), p_reserva_OID);
                        reservaEN.Coche = null;
                }
                else
                        throw new ModelException ("The identifier " + p_reserva_OID + " in p_reserva_OID you are trying to unrelationer, doesn't exist in CocheEN");

                session.Update (cocheEN);
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
