using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagementSystem_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bikeManager manager = new bikeManager();
            manager.createTable();

            Console.WriteLine("Bike Rental Management System:");
            Console.WriteLine("1. Add a Bike");
            Console.WriteLine("2. View All Bikes:");
            Console.WriteLine("3. Update a Bike");
            Console.WriteLine("4. Delete a Bike");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choose an option:");

            string option = Console.ReadLine();
            //ool trusted = true;
            switch (option)
            {
                case "1":
                    {
                        Console.Write("EnterBikeBrand");
                        string brand = Console.ReadLine();
                        Console.Write("EnterBikeName");
                        string model = Console.ReadLine();
                        Console.Write("EnterBikeRentalPrice");
                        String rentalPrice = Console.ReadLine();
                        manager.createBike(new Bike());
                        break;

                    }

                    case "2":
                    {  
                        Console.Clear();
                        manager.readBike();
                        break;
                            
                        }
                case "3":
                    {
                        Console.Clear();
                        Console.Write("EnterYourId");
                        string id = Console.ReadLine();

                        manager.updateBike();
                        break;

                    }
                case "4":
                    {
                        Console.Clear();
                        Console.Write("EnterYourId");
                        string id = Console.ReadLine();

                        Console.Write("EnterNewBikeBrand");
                        string newbrand = Console.ReadLine();
                        Console.Write("EnterBikeName");
                        string newmodel = Console.ReadLine();
                        Console.Write("EnterBikeRentalPrice");
                        String newrentalPrice = Console.ReadLine();

                        manager.deleteBike();
                        break;

                    }
                case "5":
                    {
                        Console.Clear();
                        Console.Write("EnterYourId");
                        string id = Console.ReadLine();
                        break;

                    }
               case" default":
                    {
                        Environment.Exit(0);
                        break;

                    }

            }



        }
    }
    public class Bike
    {
        public int BikeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public string RentalPrice { get; set; }


        public Bike(string brand, string model, string rentalPrice)
        {
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;

        }
        public Bike() { }

        public override string ToString()
        {
            return $"bikeId : {BikeId}, brand: {Brand}, model: {Model}, rentalPrice: ${RentalPrice}.00";
        }

        public virtual string dispalyInfo()
        {
            return ToString();
        }

    } 

    public class bikeManager
    {
        private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB; database=bikeManagement;   TrustedConnection = True";

        public void createTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                 IF NOT EXISTS (SELECT * from sys.tables where name ='bikes'
                 BEGIN
                 CREATE TABLE bikes(
            
                       BikeId INT, 
                       Brand  NVARCHAR(20),
                      Model  NVARCHAR(20),
                      RentalPrice DECIMAL

                         );
                END

                 ";

                command.ExecuteNonQuery();





            }

        }
        public void createBike(Bike bike)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                        INSERT INTO bikes
                        VAlUES (@brand,@model,@rentalPrice) 

                 ";

               

                command.ExecuteNonQuery();

            }

        }

        public void readBike()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var data = new List<Bike>();

                var command = connection.CreateCommand();
                command.CommandText = @"
                        SELECT * from bikes

                 ";

                var obj = new object();
                command.Parameters.Add(obj);
                obj .Equals(data);




                command.ExecuteNonQuery();





            }

        }

        public void deleteBike()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                       SELECT * from where id =bikeId
                        

                 ";

                command.ExecuteNonQuery();





            }

        }

        public void updateBike()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                         SELECT * from where id =bikeId

                 ";



                command.ExecuteNonQuery();





            }

        }


    }

}
