using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunGarage();
        }

        public static void RunGarage()
        {
            Console.WriteLine("Welcome to the best garage in town!");
            Garage garage = new Garage(); 
            while (true)
            {
                displayMenu(garage);
                Console.ReadLine();

                //DisplayListOfVehiclesInGarage(garage, "Some readline license plate");
                Console.ReadLine();
            }
        }

        private static void displayMenu(Garage i_Garage)
        {
            bool validUserChoice = false;
            while(!validUserChoice)
            {
                Console.WriteLine(string.Format("Please select one of the following options:\n" +
                        "1. Add new vehicle to the garage\n" +
                        "2. Display the list of vehicles in the garage\n" +
                        "3. Change a vehicle status\n" +
                        "4. Inflate tire in a specific vehicle\n" +
                        "5. Fuel a vehicle\n" +
                        "6. Charge an electric vehicle\n" +
                        "7. Display full details of a specific vehicle\n"));

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
            }
        }

        private static void displayAddNewVehicleToGarageMenu(Garage i_Garage)
        {
            bool validInput = false;
            string userInput = string.Empty;

            while (!validInput)
            {
                Console.WriteLine("Please enter the license plate for the desired vehicle: ");
                userInput = Console.ReadLine();
                try
                {
                    bool validLicensePlate = Vehicle.isValidLicensePlate(userInput);
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
            bool validInput = false;
            List<string> licensePlates = new List<string>();

            Console.WriteLine(String.Format("Please choose the status of cars that you wish to see or press Q to exit:\n" + //ADD Q OPTION
            "1. Repair\n" +
            "2. Done\n" +
            "3. Paid"));
            while (!validInput)
            {
                try
                {
                    licensePlates = i_Garage.GetListOfCarsInGarage(Console.ReadLine());
                    validInput = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            for (int i = 0; i < licensePlates.Count; i++)
            {
                Console.WriteLine(String.Format("{0}. {1}\n", i + 1, licensePlates[i]));
            }
            Console.WriteLine("Press enter to return to main menu");
            Console.ReadLine();
            displayMenu(i_Garage);
        }

        private static void displayChangeVehicleStatusMenu(Garage i_Garage)
        {
            bool isValidInput = false;
            bool isValidLicensePlate = false;
            string userLicensePlate = String.Empty;

            while (!isValidInput)
            {
                try 
                {
                    if(!isValidLicensePlate)
                    { 
                        Console.WriteLine("What is the license plate of your vehicle?");
                        userLicensePlate = Console.ReadLine();
                        i_Garage.ValidateVehicleInGarage(userLicensePlate);
                        isValidLicensePlate = true;
                    }
                    Console.WriteLine("Please choose the new status:\n" +
                        "1. Repair\n" +
                        "2. Done\n" +
                        "3. Paid");
                    string newStatus = Console.ReadLine();
                    i_Garage.ChangeVehicleStatus(userLicensePlate, newStatus);
                    isValidInput = true;
                    Console.WriteLine("Vehicle status updated succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayInflateTireMenu(Garage i_garage)
        {
            bool inflateSucceeded = false;
            Console.WriteLine("Please enter the desired vehicle license plate: ");

            while (!inflateSucceeded)
            {
                string userInput = Console.ReadLine();
                try
                {
                    i_garage.ValidateVehicleInGarage(userInput);
                    i_garage.InflateTiresToMax(userInput);
                    Console.WriteLine("Vehicle tires inflated succesfully");
                    inflateSucceeded = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayFillFuelMenu(Garage i_Garage)
        {
            bool isValidLicensePlate = false;
            bool isValidFuelType = false;
            bool isValidInput = false;
            string userLicensePlate = String.Empty;

            Console.WriteLine("What is the license plate of your vehicle?");
            while (!isValidInput)
            {
                try
                {
                    if (!isValidLicensePlate)
                    {
                        userLicensePlate = Console.ReadLine();
                        i_Garage.ValidateVehicleInGarage(userLicensePlate);
                        isValidLicensePlate = true;
                    }
                    if (!isValidFuelType)
                    {
                        Console.WriteLine("Please choose the fuel type:\n" +
                            "1. Octan95\n" +
                            "2. Octan96\n" +
                            "3. Octan98\n" +
                            "4. Soler");
                        string fuelType = Console.ReadLine();
                        Console.WriteLine("Please enter the amount of litres to fill: ");
                        i_Garage.AddFuel(userLicensePlate, fuelType, Console.ReadLine());
                    }
                    Console.WriteLine("Operation finished succesfully");
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayChargeBatteryMenu(Garage i_Garage)
        {
            bool isValidLicensePlate = false;
            bool isValidInput = false;
            string userLicensePlate = String.Empty;

            Console.WriteLine("What is the license plate of your vehicle?");
            while (!isValidInput)
            {
                try
                {
                    if (!isValidLicensePlate)
                    {
                        userLicensePlate = Console.ReadLine();
                        i_Garage.ValidateVehicleInGarage(userLicensePlate);
                        isValidLicensePlate = true;
                    }
                    Console.WriteLine("Please enter the amount of energy to charge in minutes: ");
                    i_Garage.ChargeBattery(userLicensePlate, Console.ReadLine());
                    Console.WriteLine("Operation finished succesfully");
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void displayFullDetailsOfVehicleMenu(Garage i_Garage)
        {
            Console.WriteLine("Please enter license plate:");
            string userLicensePlate = Console.ReadLine();
            GarageVehicle currentVehicle = i_Garage.GetVehicleData(userLicensePlate);
            Console.WriteLine(currentVehicle.ToString());
        }

        private static void addNewVehicle(Garage i_Garage, string i_LicensePlate)
        {
            Vehicle currentVehicle = null;
            bool isValidInput = false;
            string ownerName = String.Empty;
            string ownerPhoneNumber = String.Empty;

            Console.WriteLine(String.Format("Please choose one of the following vehicles:\n" +
                "1. FuelCar\n" +
                "2. FuelMotorcycle\n" +
                "3. ElectricCar\n" +
                "4. ElectricMotorcycle\n" +
                "5. Lorry"));
            while (!isValidInput)
            {
                try
                {
                    currentVehicle = VehicleFactory.CreateVehicle(Console.ReadLine());
                    isValidInput = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach(KeyValuePair<string, Action<string>> kvp in currentVehicle.QuestionsToCreateNewVehicle)
            {
                isValidInput = false;
                    
                Console.WriteLine(kvp.Key);
                while (!isValidInput)
                {
                    try
                    {
                        kvp.Value(Console.ReadLine());
                        isValidInput = true;
                    }
                    catch(Exception ex)
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            i_Garage.PutNewVehicleInGarage(currentVehicle, ownerName, ownerPhoneNumber);
        }

        private static Tire createNewTire()
        {
            Tire newTire = null;

            return newTire;
        }

        private static void DisplayListOfVehiclesInGarage(Garage i_Garage, string i_LicensePlate)
        {
            GarageVehicle garageVehicle = i_Garage.GetVehicleData(i_LicensePlate);
            Console.WriteLine(garageVehicle.ToString());
        }
    }
}
