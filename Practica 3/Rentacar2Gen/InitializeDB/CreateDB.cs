
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Rentacar2Gen.Infraestructure.CP;
using Rentacar2Gen.ApplicationCore.Exceptions;

using Rentacar2Gen.ApplicationCore.CP.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository;
using Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                ClienteRepository clienterepository = new ClienteRepository ();
                ClienteCEN clientecen = new ClienteCEN (clienterepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                ReservaRepository reservarepository = new ReservaRepository ();
                ReservaCEN reservacen = new ReservaCEN (reservarepository);
                LineaFacturaRepository lineafacturarepository = new LineaFacturaRepository ();
                LineaFacturaCEN lineafacturacen = new LineaFacturaCEN (lineafacturarepository);
                CocheRepository cocherepository = new CocheRepository ();
                CocheCEN cochecen = new CocheCEN (cocherepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                string idCliente1 = clientecen.CrearCliente ("9292", "Juan Ruiz", "dir", "telf");
                string idCliente2 = clientecen.CrearCliente ("9293", "Pedro Gomis", "dir", "telf");

                //Creamos Reservas
                int res1 = reservacen.CrearReserva ("9292", DateTime.Today, new DateTime (2023, 12, 12));
                int res2 = reservacen.CrearReserva ("9292", DateTime.Today, new DateTime (2023, 12, 12));


                //Creamos Coches
                int idCoche1 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre, 50);
                int idCoche2 = cochecen.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre, 120);
                int idCoche3 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre, 90);
                int idCoche4 = cochecen.CrearCoche (CategoriaCocheEnum.lujo, EstadoCocheEnum.libre, 250);
                int idCoche5 = cochecen.CrearCoche (CategoriaCocheEnum.estandar, EstadoCocheEnum.libre, 100);


                //Asignamos Coches a reservas (Reservamos)

                cochecen.AsignarReserva (idCoche1, res1);
                cochecen.AsignarReserva (idCoche2, res2);


                cochecen.Reservar (idCoche1);
                cochecen.Reservar (idCoche2);


                // Creamos facturas


                //int idFactura = facturacen.NuevaFactura ();

                //lineafacturacen.CrearLinea (idFactura, res1, 345);
                //lineafacturacen.CrearLinea (idFactura, res2, 500);


                // Consultas

                IList<ClienteEN> listaClientesLujo = clientecen.DameClientesCochesLujo ();

                Console.WriteLine ("La consulta de Clientes de Coches Lujo: ");

                foreach (ClienteEN cliente in listaClientesLujo) {
                        Console.WriteLine ("El cliente es: " + cliente.Nombre);
                }

                ReservaCP reservaCP = new ReservaCP(new SessionCPNHibernate());
                var precioFinal = reservaCP.RealizarReserva(res1, new DateTime(2025, 02, 9), new DateTime(2025, 02, 10), CategoriaCocheEnum.estandar, idCliente1);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Precio final de la factura de: " + precioFinal);
                Console.ResetColor();

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
