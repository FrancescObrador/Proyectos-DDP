
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
 * Clase Cliente:
 *
 */

namespace RentACarGen.Infraestructure.Repository.RentACar
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
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
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




                clienteNH.Pass = cliente.Pass;

                session.Update (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (ClienteEN cliente)
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
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteNH.DNI;
}

public void Modify (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteNH clienteNH = (ClienteNH)session.Load (typeof(ClienteNH), cliente.DNI);

                clienteNH.Nombre = cliente.Nombre;


                clienteNH.Direccion = cliente.Direccion;


                clienteNH.Telefono = cliente.Telefono;


                clienteNH.Pass = cliente.Pass;

                session.Update (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string DNI
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
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ClienteEN
public ClienteEN ReadOID (string DNI
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

public System.Collections.Generic.IList<ClienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClienteNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                else
                        result = session.CreateCriteria (typeof(ClienteNH)).List<ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is RentACarGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new RentACarGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
