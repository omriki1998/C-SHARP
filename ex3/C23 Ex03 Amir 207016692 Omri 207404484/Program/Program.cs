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

                        switch (Console.ReadLine())
                        {
                            case "1": 
                                displayAddNewVehicleToGarageMenu(i_Garage);
                                validUserChoice = true;
                                break;
                            case "2":
                                displayListOfVehiclesInGarageMenu(i_Garage);
                                validUserChoice = true;
                                break;
                            case "3":
                                displayChangeVehicleStatusMenu(i_Garage);
                                validUserChoice = true;
                                break;
                            case "4":
                                displayInflateTireMenu();
                                validUserChoice = true;
                                break;
                            case "5":
                                displayFillFuelMenu();
                                validUserChoice = true;
                                break;
                            case "6":
                                displayChargeBatteryMenu();
                                validUserChoice = true;
                                break;
                            case "7":
                                displayFullDetailsOfVehicleMenu();
                                validUserChoice = true;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Option selected is invalid! \n");
                                continue;
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
                    if (i_Garage.isVehicleInGarage(userInput))
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
            Console.WriteLine("What is the license plate of your vehicle?");
            string userLicensePlate = Console.ReadLine();
            if (i_Garage.isVehicleInGarage(userLicensePlate))
            {
                Console.WriteLine("Please choose the new status:\n" +
                    "1. Repair\n" +
                    "2. Done\n" +
                    "3. Paid");
                string newStatus = Console.ReadLine();
                try
                {
                    i_Garage.ChangeVehicleStatus(userLicensePlate, newStatus);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //Vehicle not in garage exception.. How to send? Need to add. 
            }
        }

        private static void displayInflateTireMenu()
        {

        }

        private static void displayFillFuelMenu()
        {

        }

        private static void displayChargeBatteryMenu()
        {

        }

        private static void displayFullDetailsOfVehicleMenu()
        {

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
                        Console.WriteLine(ex.ToString());
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

        private static string[] getVehicleDetailsFromUser()
        {
            string[] newVehicleDetails = new string[7];
            string modelName = String.Empty;
            string licensePlate = String.Empty;
            string energyPrecentage = String.Empty;
            string tireManufacturer = String.Empty;
            string tirePressure = String.Empty;
            string maxTirePressure = String.Empty;
            string numOfTires = String.Empty;

            string msgToUser = String.Format("Model: {0}\n" +
                "License plate: {1}\n" +
                "Percentage of energy: {2}\n" +
                "Tire manufacturer: {3}\n" +
                "Tire pressure: {4}\n" +
                "Maximum tire pressure: {5}\n" +
                "Number of tires: {6}\n", modelName, licensePlate, energyPrecentage, tireManufacturer, tirePressure, maxTirePressure, numOfTires);

            return newVehicleDetails;
        }

        private static void DisplayListOfVehiclesInGarage(Garage i_Garage, string i_LicensePlate)
        {
            GarageVehicle garageVehicle = i_Garage.GetVehicleData(i_LicensePlate);
            Console.WriteLine(garageVehicle.ToString());
           
            /*
            Tire carTire = new Tire("Michlen", 32, 32);
            Tire motorcycleTire = new Tire("Michlen", 30, 30);
            Tire lorryTire = new Tire("Michlen", 27, 27);

            ElectricCar ec = new ElectricCar("Tesla", "12345678", 100f, carTire, Vehicle.eCarColour.Black, Vehicle.eNumOfDoors.Four);
            ElectricMotorcycle em = new ElectricMotorcycle("Dukati", "00000000", 100f, motorcycleTire, Vehicle.eMotorcycleLicenseType.A1, 250);
            FuelCar fc = new FuelCar("Subaru XV", "87654321", 100f, carTire, FuelVehicle.eFuelType.Octan96, Vehicle.eCarColour.Red, Vehicle.eNumOfDoors.Five);
            FuelMotorcycle fm = new FuelMotorcycle("KTM", "11122234", 100f, motorcycleTire, FuelVehicle.eFuelType.Octan95, Vehicle.eMotorcycleLicenseType.AB, 500);
            Lorry lorry = new Lorry("MAN", "66666666", 100f, lorryTire, FuelVehicle.eFuelType.Soler, true, 100f);


            garage.PutNewVehicleInGarage(ec, "Omri", "0544560297", GarageVehicle.eVehicleStatus.Repair);
            garage.PutNewVehicleInGarage(em, "Amir", "0544921380", GarageVehicle.eVehicleStatus.Repair);
            garage.PutNewVehicleInGarage(fc, "Aa", "05050", GarageVehicle.eVehicleStatus.Repair);
            garage.PutNewVehicleInGarage(fm, "Tonali", "050500002220", GarageVehicle.eVehicleStatus.Repair);
            garage.PutNewVehicleInGarage(lorry, "Steve", "050001124", GarageVehicle.eVehicleStatus.Repair);
            GarageVehicle v = garage.GetVehicleData("12345678");
            GarageVehicle vv = garage.GetVehicleData("00000000");
            GarageVehicle vvv = garage.GetVehicleData("87654321");
            GarageVehicle vvvv = garage.GetVehicleData("11122234");
            GarageVehicle vvvvv = garage.GetVehicleData("66666666");

            Console.WriteLine(v.ToString());
            Console.WriteLine(vv.ToString());
            Console.WriteLine(vvv.ToString());
            Console.WriteLine(vvvv.ToString());
            Console.WriteLine(vvvvv.ToString());
            */
        }
    }
}
