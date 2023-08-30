﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                                displayListOfVehiclesInGarageMenu();
                                validUserChoice = true;
                                break;
                            case "3":
                                displayChangeVehicleStatusMenu();
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
            addNewVehicle(i_Garage, "123445");
            /*bool validInput = false;
            Console.Clear();
            while (!validInput)
            {
                Console.WriteLine("Please enter the license plate for the desired vehicle: ");
                string userInputLicensePlate = Console.ReadLine();
                bool validLicensePlate = isValidLicensePlate(userInputLicensePlate);
                if (!validLicensePlate)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid license plate. (Should consist of letters and digits only, and be between 5-10 characters long)\n");
                    continue;
                }
                else
                {
                    addNewVehicle(i_Garage, userInputLicensePlate);
                }
            }*/
        }

        private static void displayListOfVehiclesInGarageMenu()
        {

        }

        private static void displayChangeVehicleStatusMenu()
        {

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
            if (i_Garage.isVehicleInGarage(i_LicensePlate))
            {
                i_Garage.updateExistingVehicle(i_LicensePlate);
            }
            else
            {
                Vehicle currentVehicle = new FuelCar();
                foreach(KeyValuePair<string, Action<string>> kvp in currentVehicle.QuestionsToCreateNewVehicle)
                {
                    bool validArgument = false;
                    
                    Console.WriteLine(kvp.Key);
                    while (!validArgument)
                    {
                        try
                        {
                            kvp.Value(Console.ReadLine());
                            validArgument = true;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        /*private static Vehicle createNewVehicle()
        {
            string[] vehicleDetails = getVehicleDetailsFromUser();
            Tire vehicleTire = createNewTire();
            Vehicle newVehicle = new Vehicle(vehicleDetails[0], vehicleDetails[1], float.Parse(vehicleDetails[2]), vehicleTire, byte.Parse(vehicleDetails[3]));

            return newVehicle;
        }*/

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


            garage.PutNewVehicleInGarage(ec, "Omri", "0544560297", GarageVehicle.eCarStatus.Repair);
            garage.PutNewVehicleInGarage(em, "Amir", "0544921380", GarageVehicle.eCarStatus.Repair);
            garage.PutNewVehicleInGarage(fc, "Aa", "05050", GarageVehicle.eCarStatus.Repair);
            garage.PutNewVehicleInGarage(fm, "Tonali", "050500002220", GarageVehicle.eCarStatus.Repair);
            garage.PutNewVehicleInGarage(lorry, "Steve", "050001124", GarageVehicle.eCarStatus.Repair);
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
