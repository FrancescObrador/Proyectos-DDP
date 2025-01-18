
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
 * Clase Cliente:
 *
 */

namespace Rentacar2Gen.Infraestructure.Repository.RentaCar2
{
public partial class ClienteRepository : BasicRepository, IClienteRepository
{
public ClienteRepository() : base ()
{
}


public ClienteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ClienteEN ReadOIDDefault (string DNI
                                 )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteNH), DNI);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClienteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                        else
                                result = session.CreateCriteria (typeof(ClienteNH)).List<ClienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteNH clienteNH = (ClienteNH)session.Load (typeof(ClienteNH), cliente.DNI);

                clienteNH.Nombre = cliente.Nombre;


                clienteNH.Direccion = cliente.Direccion;


                clienteNH.Telefono = cliente.Telefono;



                session.Update (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string CrearCliente (ClienteEN cliente)
{
        ClienteNH clienteNH = new ClienteNH (cliente);

        try
        {
                SessionInitializeTransaction ();

                session.Save (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteNH.DNI;
}

public void BorrarCliente (string DNI
                           )
{
        try
        {
                SessionInitializeTransaction ();
                ClienteNH clienteNH = (ClienteNH)session.Load (typeof(ClienteNH), DNI);
                session.Delete (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Modificar (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteNH clienteNH = (ClienteNH)session.Load (typeof(ClienteNH), cliente.DNI);

                clienteNH.Nombre = cliente.Nombre;


                clienteNH.Direccion = cliente.Direccion;


                clienteNH.Telefono = cliente.Telefono;

                session.Update (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN> DameClientesCochesLujo ()
{
        System.Collections.Generic.IList<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ClienteNH self where select cli FROM ClienteNH as cli inner join cli.Reserva as res where res.Coche is not empty and res.Coche.Categoria =  3";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ClienteNHdameClientesCochesLujoHQL");

                result = query.List<Rentacar2Gen.ApplicationCore.EN.RentaCar2.ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Rentacar2Gen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Rentacar2Gen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
