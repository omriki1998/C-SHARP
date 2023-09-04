using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03
{
    internal class UserInterface
    {
        public static void RunGarage()
        {
            string welcomeMsg = @"==================================================================
          _____          _____            _____ ______
         / ____|   /\   |  __ \     /\   / ____|  ____|
        | |  __   /  \  | |__) |   /  \ | |  __| |__   
        | | |_ | / /\ \ |  _  /   / /\ \| | |_ |  __|  
        | |__| |/ ____ \| | \ \  / ____ \ |__| | |____ 
        \______/_/    \_\_|  \_\/_/    \_\_____|______|
==================================================================
                         WELCOME TO THE                           
                       BEST GARAGE IN TOWN                            
==================================================================
     Your one-stop solution for all your automotive needs!
==================================================================";

            Console.WriteLine(welcomeMsg);
            Garage garage = new Garage();
            displayMenu(garage);
        }

        private static void displayMenu(Garage i_Garage)
        {
            bool validUserChoice = false;
            bool quit = false;

            while (!quit || !validUserChoice)
            {
                Console.WriteLine(string.Format("Please select one of the following options:\n" +
                        "1. Add new vehicle to the garage\n" +
                        "2. Display the list of vehicles in the garage\n" +
                        "3. Change a vehicle status\n" +
                        "4. Inflate tire in a specific vehicle\n" +
                        "5. Fuel a vehicle\n" +
                        "6. Charge an electric vehicle\n" +
                        "7. Display full details of a specific vehicle\n" +
                        "8. Quit Garage"));
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            displayAddNewVehicleToGarageMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "2":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayListOfVehiclesInGarageMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "3":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayChangeVehicleStatusMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "4":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayInflateTireMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "5":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayFillFuelMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "6":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayChargeBatteryMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "7":
                            i_Garage.ValidatesGarageIsNotEmpty();
                            displayFullDetailsOfVehicleMenu(i_Garage);
                            validUserChoice = true;
                            break;
                        case "8":
                            quit = true;
                            validUserChoice = true;
                            Console.WriteLine("Goodbye...");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Option selected is invalid! \n");
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void displayAddNewVehicleToGarageMenu(Garage i_Garage)
        {
            bool validInput = false;
            string userInput = string.Empty;
            bool validLicensePlate = false;

            while (!validInput)
            {
                Console.WriteLine("Please enter the license plate for the desired vehicle: ");
                userInput = Console.ReadLine();
                try
                {
                    validLicensePlate = Vehicle.isValidLicensePlate(userInput);
                    if (i_Garage.IsVehicleInGarage(userInput))
                    {
                        i_Garage.updateExistingVehicle(userInput);
                        Console.WriteLine("Vehicle exists in garage. Vehicle put into repair.");
                    }
                    else
                    {
                        addNewVehicle(i_Garage, userInput);
                        Console.WriteLine("Vehicle added to garage for repair succesfully!");
                    }

                    validInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayListOfVehiclesInGarageMenu(Garage i_Garage)
        {
            List<string> licensePlates = new List<string>();

            Console.WriteLine(string.Format("Please choose the status of cars that you wish to see:\n" +
            "1. Repair\n" +
            "2. Done\n" +
            "3. Paid\n" +
            "4. All"));
            try
            {
                licensePlates = i_Garage.GetListOfCarsInGarage(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < licensePlates.Count; i++)
            {
                Console.WriteLine(string.Format("{0}. {1}\n", i + 1, licensePlates[i]));
            }
        }

        private static void displayChangeVehicleStatusMenu(Garage i_Garage)
        {
            string userLicensePlate = string.Empty;

            try
            {
                Console.WriteLine("What is the license plate of your vehicle?");
                userLicensePlate = Console.ReadLine();
                i_Garage.ValidateVehicleInGarage(userLicensePlate);
                Console.WriteLine("Please choose the new status:\n" +
                    "1. Repair\n" +
                    "2. Done\n" +
                    "3. Paid");
                i_Garage.ChangeVehicleStatus(userLicensePlate, Console.ReadLine());
                Console.WriteLine("Vehicle status updated succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayInflateTireMenu(Garage i_Garage)
        {
            Console.WriteLine("Please enter the desired vehicle license plate: ");

            string userInput = Console.ReadLine();
            try
            {
                i_Garage.ValidateVehicleInGarage(userInput);
                i_Garage.InflateTiresToMax(userInput);
                Console.WriteLine("Vehicle tires inflated succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayFillFuelMenu(Garage i_Garage)
        {
            string userLicensePlate = string.Empty;
            string fuelType = string.Empty;

            Console.WriteLine("What is the license plate of your vehicle?");
            try
            {
                userLicensePlate = Console.ReadLine();
                i_Garage.ValidateVehicleInGarage(userLicensePlate);
                Console.WriteLine("Please choose the fuel type:\n" +
                    "1. Octan95\n" +
                    "2. Octan96\n" +
                    "3. Octan98\n" +
                    "4. Soler");
                fuelType = Console.ReadLine();
                Console.WriteLine("Please enter the amount of litres to fill: ");
                i_Garage.AddFuel(userLicensePlate, fuelType, Console.ReadLine());
                Console.WriteLine("Operation finished succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayChargeBatteryMenu(Garage i_Garage)
        {
            string userLicensePlate = string.Empty;

            Console.WriteLine("What is the license plate of your vehicle?");

            try
            {
                userLicensePlate = Console.ReadLine();
                i_Garage.ValidateVehicleInGarage(userLicensePlate);
                Console.WriteLine("Please enter the amount of energy to charge in minutes: ");
                i_Garage.ChargeBattery(userLicensePlate, Console.ReadLine());
                Console.WriteLine("Operation finished succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void displayFullDetailsOfVehicleMenu(Garage i_Garage)
        {
            string userLicensePlate = string.Empty;

            Console.WriteLine("Please enter license plate:");
            userLicensePlate = Console.ReadLine();
            try
            {
                i_Garage.ValidateVehicleInGarage(userLicensePlate);
                GarageVehicle currentVehicle = i_Garage.GetVehicleData(userLicensePlate);
                Console.WriteLine(currentVehicle.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addNewVehicle(Garage i_Garage, string i_LicensePlate)
        {
            Vehicle currentVehicle = null;
            bool isValidInput = false;
            string ownerName = string.Empty;
            string ownerPhoneNumber = string.Empty;

            Console.WriteLine(string.Format("Please choose one of the following vehicles:\n" +
                "1. FuelCar\n" +
                "2. FuelMotorcycle\n" +
                "3. ElectricCar\n" +
                "4. ElectricMotorcycle\n" +
                "5. Lorry"));
            while (!isValidInput)
            {
                try
                {
                    currentVehicle = VehicleFactory.CreateVehicle(Console.ReadLine(), i_LicensePlate);
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (KeyValuePair<string, Action<string>> kvp in currentVehicle.QuestionsToCreateNewVehicle)
            {
                isValidInput = false;

                Console.WriteLine(kvp.Key);
                while (!isValidInput)
                {
                    try
                    {
                        kvp.Value.Invoke(Console.ReadLine());
                        isValidInput = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine("Please enter the name of the owner: ");
            isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    ownerName = GarageVehicle.isValidOwnerNameAndAssign(Console.ReadLine());
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Please enter the phone number of the owner: ");
            isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    ownerPhoneNumber = GarageVehicle.isValidOwnerPhoneNumberAndAssign(Console.ReadLine());
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            i_Garage.PutNewVehicleInGarage(currentVehicle, ownerName, ownerPhoneNumber);
        }
    }
}
