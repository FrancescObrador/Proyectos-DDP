
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using RentACarGen.ApplicationCore.EN.RentACar;
using RentACarGen.ApplicationCore.CEN.RentACar;
using RentACarGen.Infraestructure.Repository.RentACar;
using RentACarGen.Infraestructure.CP;
using RentACarGen.ApplicationCore.Exceptions;

using RentACarGen.ApplicationCore.CP.RentACar;
using RentACarGen.Infraestructure.Repository;

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
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

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
                ReservaRepository reservarepository = new ReservaRepository ();
                ReservaCEN reservacen = new ReservaCEN (reservarepository);
                CocheRepository cocherepository = new CocheRepository ();
                CocheCEN cochecen = new CocheCEN (cocherepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                LineaFacturaRepository lineafacturarepository = new LineaFacturaRepository ();
                LineaFacturaCEN lineafacturacen = new LineaFacturaCEN (lineafacturarepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                string clienteId = clientecen.New_ ("12345678Z", "Antonio", "direccion", "123456", "1234");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Cliente {clienteId} creado con �xito -----");
                Console.ForegroundColor = ConsoleColor.White;

                int cocheId = cochecen.New_ (RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum.estandar);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Coche {cocheId} creado con �xito -----");
                Console.ForegroundColor = ConsoleColor.White;

                int reservaId = reservacen.New_ (DateTime.Now, DateTime.Now, clienteId);

                cochecen.Reservar (cocheId, reservaId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Reserva {reservaId} realizada con �xito -----");
                Console.ForegroundColor = ConsoleColor.White;

                int facturaId = facturacen.New_ (DateTime.Now, false, false, 200, null, clienteId);
                int facturaId2 = facturacen.New_ (DateTime.Now, false, false, 300, null, clienteId);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Factura {facturaId} realizada con �xito -----");
                Console.ForegroundColor = ConsoleColor.White;

                int lineaFacturaId = lineafacturacen.New_ (200, facturaId, reservaId);
                IList<LineaFacturaEN> lineas = new List<LineaFacturaEN>();
                lineas.Add (lineafacturarepository.ReadOID (lineaFacturaId));

                foreach (LineaFacturaEN linea in lineas) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine ($ "----- lineaFactura {linea.NumLinea} realizada con �xito -----");
                        Console.ForegroundColor = ConsoleColor.White;
                }

                FacturaEN factura = facturarepository.ReadOID (facturaId);
                factura.LineaFactura = lineas;
                facturarepository.Modify (factura);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Factura {facturaId} modificada con exito -----");
                Console.ForegroundColor = ConsoleColor.White;


                cochecen.Desreservar (cocheId, reservaId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Reserva {reservaId} desreservada con exito -----");
                Console.ForegroundColor = ConsoleColor.White;

                facturacen.AnularFactura (facturaId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine ($ "----- Factura {facturaId} anulada con exito -----");
                Console.ForegroundColor = ConsoleColor.White;



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
