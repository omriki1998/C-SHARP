using System;

namespace Ex03
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tire carTire = new Tire("Michlen", 32, 32);
            Tire motorcycleTire = new Tire("Michlen", 30, 30);
            Tire lorryTire = new Tire("Michlen", 27, 27);

            ElectricCar ec = new ElectricCar("Tesla", "12345678", 100f, carTire, Vehicle.eCarColour.Black, Vehicle.eNumOfDoors.Four);
            ElectricMotorcycle em = new ElectricMotorcycle("Dukati", "00000000", 100f, motorcycleTire, Vehicle.eMotorcycleLicenseType.A1, 250);
            FuelCar fc = new FuelCar("Subaru XV", "87654321", 100f, carTire, FuelVehicle.eFuelType.Octan96, Vehicle.eCarColour.Red, Vehicle.eNumOfDoors.Five);
            FuelMotorcycle fm = new FuelMotorcycle("KTM", "11122234", 100f, motorcycleTire, FuelVehicle.eFuelType.Octan95, Vehicle.eMotorcycleLicenseType.AB, 500);
            Lorry lorry = new Lorry("MAN", "66666666", 100f, lorryTire, FuelVehicle.eFuelType.Soler, true, 100f);
            RunGarage();

        }

        public static void RunGarage()
        {
            Console.WriteLine("Welcome to the best garage in town!");
            Garage garage = new Garage(); 
            while (true)
            {
                displayMenu();
                Console.ReadLine();
                DisplayListOfVehiclesInGarage(garage, "Some readline license plate");
                Console.ReadLine();
            }
        }

        private static void displayMenu()
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
                string userChoiceStr = Console.ReadLine();
                int o_UserChoice;
                bool isValid = int.TryParse(userChoiceStr, out o_UserChoice); 
                if(isValid)
                {
                    if(o_UserChoice > 0 && o_UserChoice < 8)
                    {
                        validUserChoice = true;
                        switch (o_UserChoice)
                        {
                            case 1: 
                                displayAddNewVehicleToGarageMenu();
                                break;
                            case 2:
                                displayListOfVehiclesInGarageMenu();
                                break;
                            case 3:

                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Option selected is invalid! \n");
                        continue; 
                    }
                }
            }
        }

        private static void displayAddNewVehicleToGarageMenu()
        {

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

        private void addNewVehicle(Vehicle vehicle)
        {
            //TODO
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
