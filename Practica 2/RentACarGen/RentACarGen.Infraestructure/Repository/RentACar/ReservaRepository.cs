
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
 * Clase Reserva:
 *
 */

namespace RentACarGen.Infraestructure.Repository.RentACar
{
public partial class ReservaRepository : BasicRepository, IReservaRepository
{
public ReservaRepository() : base ()
{
}


public ReservaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ReservaEN ReadOIDDefault (int id
                                 )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReservaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                        else
                                result = session.CreateCriteria (typeof(ReservaNH)).List<ReservaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReservaEN reserva)
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), reserva.Id);

                reservaNH.Inicio = reserva.Inicio;


                reservaNH.Final = reserva.Final;




                session.Update (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearReserva (ReservaEN reserva)
{
        ReservaNH reservaNH = new ReservaNH (reserva);

        try
        {
                SessionInitializeTransaction ();
                if (reserva.Cliente != null) {
                        // Argumento OID y no colección.
                        reservaNH
                        .Cliente = (RentACarGen.ApplicationCore.EN.RentACar.ClienteEN)session.Load (typeof(RentACarGen.ApplicationCore.EN.RentACar.ClienteEN), reserva.Cliente.DNI);

                        reservaNH.Cliente.Reserva
                        .Add (reservaNH);
                }

                session.Save (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reservaNH.Id;
}

public void BorrarReserva (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                ReservaNH reservaNH = (ReservaNH)session.Load (typeof(ReservaNH), id);
                session.Delete (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorOID
//Con e: ReservaEN
public ReservaEN DamePorOID (int id
                             )
{
        ReservaEN reservaEN = null;

        try
        {
                SessionInitializeTransaction ();
                reservaEN = (ReservaEN)session.Get (typeof(ReservaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return reservaEN;
}

public System.Collections.Generic.IList<ReservaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ReservaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReservaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReservaEN>();
                else
                        result = session.CreateCriteria (typeof(ReservaNH)).List<ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
