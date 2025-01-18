
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
 * Clase Reserva:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
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
                        .Cliente = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN)session.Load (typeof(Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN), reserva.Cliente.DNI);

                        reservaNH.Cliente.Reserva
                        .Add (reservaNH);
                }

                session.Save (reservaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> DevuelveReservasAnyo (int ? p_anyo)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ReservaNH self where FROM ReservaNH res where Year(res.Inicio) = :p_anyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ReservaNHdevuelveReservasAnyoHQL");
                query.SetParameter ("p_anyo", p_anyo);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ReservaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
