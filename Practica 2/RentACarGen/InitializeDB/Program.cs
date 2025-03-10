
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


using RentACarGen.Infraestructure.EN.RentACar;


namespace InitializeDB
{
class Program
{
static void Main (string[] args)
{
        System.Console.WriteLine ("-----------------------------------------------------------------------------");
        System.Console.WriteLine ("A new database called: RentACarGenNHibernate will be created (the previous information will be deleted).");
        System.Console.WriteLine ("-----------------------------------------------------------------------------");
        /*PROTECTED REGION ID(initializeData) ENABLED START*/


        try
        {
                CreateDB.Create ("RentACarGenNHibernate", "nhibernateUser", "nhibernatePass");
                var cfg = new Configuration ();
                cfg.Configure ();
                cfg.AddAssembly (typeof(ClienteNH).Assembly);
                new SchemaExport (cfg).Execute (true, true, false);
                System.Console.WriteLine ("-------------------------------------");
                System.Console.WriteLine ("Database schema created successfully");
                System.Console.WriteLine ("-------------------------------------");


                System.Console.WriteLine ("-------------------------------------------------------");
                System.Console.WriteLine ("Let's initialize the data of your database! ");
                System.Console.WriteLine ("-------------------------------------------------------");

                CreateDB.InitializeData ();
                System.Console.WriteLine ("-----------------------------------------");
                System.Console.WriteLine ("The data has been inserted successfully!!");
                System.Console.WriteLine ("-----------------------------------------");
        }
        /*PROTECTED REGION END*/
        catch (Exception e)
        {
                System.Console.WriteLine (e.Message.ToString () + '\n' + e.StackTrace);
        }

        finally
        {
                System.Console.WriteLine ("Powered by OOH4RIA. Press any key to exit....");
                Console.ReadLine ();
        }
}
}
}
