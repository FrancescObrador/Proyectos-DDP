
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
 * Clase Coche:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
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


                cocheNH.PrecioDia = coche.PrecioDia;

                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cocheNH.NumLicencia;
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
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarReserva (int p_Coche_OID, int p_reserva_OID)
{
        Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN cocheEN = null;
        try
        {
                SessionInitializeTransaction ();
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);
                cocheEN.Reserva = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN)session.Load (typeof(Rentacar2Gen.Infraestructure.EN.RentaCar2.ReservaNH), p_reserva_OID);

                cocheEN.Reserva.Coche = cocheEN;




                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
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
                Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN cocheEN = null;
                cocheEN = (CocheEN)session.Load (typeof(CocheNH), p_Coche_OID);

                if (cocheEN.Reserva.Id == p_reserva_OID) {
                        cocheEN.Reserva = null;
                        Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN reservaEN = (Rentacar2Gen.ApplicationCore.EN.RentaCar2.ReservaEN)session.Load (typeof(Rentacar2Gen.Infraestructure.EN.RentaCar2.ReservaNH), p_reserva_OID);
                        reservaEN.Coche = null;
                }
                else
                        throw new ModelException ("The identifier " + p_reserva_OID + " in p_reserva_OID you are trying to unrelationer, doesn't exist in CocheEN");

                session.Update (cocheEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Modificar (CocheEN coche)
{
        try
        {
                SessionInitializeTransaction ();
                CocheNH cocheNH = (CocheNH)session.Load (typeof(CocheNH), coche.NumLicencia);

                cocheNH.Categoria = coche.Categoria;


                cocheNH.Estado = coche.Estado;


                cocheNH.PrecioDia = coche.PrecioDia;

                session.Update (cocheNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> DameCochesDisponibles (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.CategoriaCocheEnum ? p_categoria)
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CocheNH self where FROM CocheNH as co where co.Categoria = :p_categoria and co.Estado = 1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CocheNHdameCochesDisponiblesHQL");
                query.SetParameter ("p_categoria", p_categoria);

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.CocheEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in CocheRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
