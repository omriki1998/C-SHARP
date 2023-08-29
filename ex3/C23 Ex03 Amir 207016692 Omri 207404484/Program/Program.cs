using System;

namespace Ex03
{
    class Program
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
            while (true)
            {
                displayMenu();
                Console.ReadLine();
                DisplayListOfVehiclesInGarage();
                Console.ReadLine();
            }
        }

        private static void displayMenu()
        {
            Console.WriteLine(string.Format("Please select one of the following options:\n" +
                    "1. Add new vehicle to the garage\n" +
                    "2. Display the list of vehicles in the garage\n" +
                    "3. Change a vehicle status\n" +
                    "4. Inflate tire in a specific vehicle\n" +
                    "5. Fuel a vehicle\n" +
                    "6. Charge an electric vehicle\n" +
                    "7. Display full details of a specific vehicle\n"));
        }

        private void addNewVehicle(Vehicle vehicle)
        {

        }

        private static void DisplayListOfVehiclesInGarage()
        {

            Tire carTire = new Tire("Michlen", 32, 32);
            Tire motorcycleTire = new Tire("Michlen", 30, 30);
            Tire lorryTire = new Tire("Michlen", 27, 27);

            ElectricCar ec = new ElectricCar("Tesla", "12345678", 100f, carTire, Vehicle.eCarColour.Black, Vehicle.eNumOfDoors.Four);
            ElectricMotorcycle em = new ElectricMotorcycle("Dukati", "00000000", 100f, motorcycleTire, Vehicle.eMotorcycleLicenseType.A1, 250);


            Garage garage = new Garage();
            garage.PutNewVehicleInGarage(ec, "Omri", "0544560297", GarageVehicle.eCarStatus.Repair);
            GarageVehicle v = garage.GetVehicleData("12345678");
            Console.WriteLine(v.ToString());
        }
    }
}
