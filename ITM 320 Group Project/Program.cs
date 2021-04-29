using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vehicles;
using VehicleFunctions;
using DatedProfit;
using MPGofLot;
using ChangeCarStatusToSold;
using CreateNewLoan;

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
                            ViewVehicles myApp1 = new ViewVehicles(); // Keevin app 1
                            Console.Clear();
                            myApp1.View();
                            Console.Clear();
                            break;

                        case 2:
                            AddVehicle myApp2 = new AddVehicle(); // Keevin app 2
                            Console.Clear();
                            myApp2.Add();
                            Console.Clear();
                            break;

                        case 3:
                            Profit myApp3 = new Profit(); // Levi app 1
                            myApp3.Input();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 4:
                            GetAvailableMPG myApp4 = new GetAvailableMPG(); // Levi app 2
                            myApp4.GetAvgMPG();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 5:
                            UpdateSaleStatus newSale = new UpdateSaleStatus(); // George app 1
                            Console.Clear();
                            newSale.updateSold();
                            Console.Clear();
                            break;

                        case 6:
                            LoanCalculation myLoan = new LoanCalculation(); // George app 2
                            Console.Clear();
                            myLoan.CalcLoan();
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
                } while (userinput != 7);
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
            Console.WriteLine("3. Calculate Profit Between Two Dates (Levi)");
            Console.WriteLine("4. Calculate Average MPG of Available Vehicles (Levi)");
            Console.WriteLine("5. Change Pending Vehicle Status to Sold (George)");
            Console.WriteLine("6. Calculate Loan (George)");
            Console.WriteLine("7. Exit");

            int result = Convert.ToInt16(Console.ReadLine());
            return result;
        }
    }
}
