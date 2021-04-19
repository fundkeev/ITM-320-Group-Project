using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vehicles;
using VehicleFunctions;

namespace ITM_320_Group_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Login(); // simple login system

            MenuWrapper(); // go to the main menu after logging in

        }
        

        public static void Login()
        {
            string username;
            string password;

            do
            {
                Console.WriteLine("Car Dealership Sales System");
                Console.WriteLine("Type \"quit\" or \"q\" to exit.");
                Console.Write("Username: ");
                username = Console.ReadLine();
                if (username.ToLower() == "quit" || username.ToLower() == "q") { Environment.Exit(0); }

                Console.Write("Password: ");
                password = Console.ReadLine();
                if (password.ToLower() == "quit" || password.ToLower() == "q") { Environment.Exit(0); }

                if (username == "BSU" && password == "BRONCO")  // not secure in the least but it's just for show, really
                {
                    Console.WriteLine("Login Successful");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect username and/or password. Please try again.");
                    Console.ReadLine();
                    username = "";
                    Console.Clear();
                }
            } while (username == "");
        }

        public static void MenuWrapper()
        {
            try
            {
                int userinput = 0;

                do
                {
                    userinput = MainMenu();

                    switch (userinput)
                    {
                        case 1:
                            ViewVehicles myApp1 = new ViewVehicles();
                            Console.Clear();
                            myApp1.View();
                            Console.Clear();
                            break;

                        case 2:
                            AddVehicle myApp2 = new AddVehicle();
                            Console.Clear();
                            myApp2.Add();
                            Console.Clear();
                            break;

                        case 3:
                            Console.WriteLine("Execute 3"); // Levi app 1

                            // example to get a single vehicle via index number
                            VehicleList V = new VehicleList();
                            V.Open();
                            Vehicle myVehicle = V.Get(6);

                            // example to change something on that single vehicle. Selling it in this case
                            myVehicle.sellingPrice = 34590m;
                            myVehicle.ChangeStatus("Sold");
                            myVehicle.dateSold = DateTime.Now;

                            // saving that change back to the file. Replaces the index number parameter with the vehicle object parameter
                            V.Replace(6, myVehicle);

                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 4:
                            Console.WriteLine("Execute 4"); // Levi app 2
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 5:
                            Console.WriteLine("Execute 5"); // George app 1
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 6:
                            Console.WriteLine("Execute 6"); // George app 2
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 7:
                            Environment.Exit(0);  // exiting the whole application
                            break;

                        default:
                            Console.WriteLine("Please make sure you select option (1) to (7) only");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                } while (userinput != 4);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please make sure you select option (1) to (7) only");
                Console.ReadLine();
                Console.Clear();
                MenuWrapper();
            }
        }

        public static int MainMenu()
        {
            Console.WriteLine("Car Dealership Sales System");
            Console.WriteLine();

            Console.WriteLine("1. View Vehicles in DB (Keevin)");
            Console.WriteLine("2. Add New Vehicle to DB (Keevin)");
            Console.WriteLine("3. Name of Bus App Function 3 (Levi)");
            Console.WriteLine("4. Name of Bus App Function 4 (Levi)");
            Console.WriteLine("5. Name of Bus App Function 5 (George)");
            Console.WriteLine("6. Name of Bus App Function 6 (George)");
            Console.WriteLine("7. Exit");

            int result = Convert.ToInt16(Console.ReadLine());
            return result;
        }
    }
}
