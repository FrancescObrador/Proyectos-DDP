
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
                LineaFacturaRepository lineafacturarepository = new LineaFacturaRepository ();
                LineaFacturaCEN lineafacturacen = new LineaFacturaCEN (lineafacturarepository);
                FacturaRepository facturarepository = new FacturaRepository ();
                FacturaCEN facturacen = new FacturaCEN (facturarepository);
                CocheRepository cocherepository = new CocheRepository ();
                CocheCEN cochecen = new CocheCEN (cocherepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                var cliente1 = clientecen.CrearCliente("123456789", "Juan", "calle aragon", "123456789", "1234");
                var coche1 = cochecen.CrearCoche(RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum.economico);
                var coche2 = cochecen.CrearCoche(RentACarGen.ApplicationCore.Enumerated.RentACar.CategoriaCocheEnum.lujo);

                var reserva1 = reservacen.CrearReserva(DateTime.Now, DateTime.Now, cliente1);

                var factura1 = facturacen.CrearFactura(DateTime.Now, false, false, 100, cliente1);

                facturacen.PagarFactura(factura1);

                clientecen.DameTodos(0, -1);

                

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
