using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {

        public static Vehicle CreateVehicle(string i_VehicleType)
        {
            bool isValidCarType = Enum.TryParse(i_VehicleType, out eVehicleType o_EVehicleType);
            switch (o_EVehicleType)
            {
                case eVehicleType.FuelCar:
                    return new FuelCar();
                case eVehicleType.FuelMotorcycle:
                    return new FuelMotorcycle();
                case eVehicleType.ElectricCar:
                    return new ElectricCar();
                case eVehicleType.ElectricMotorcycle:
                    return new ElectricMotorcycle();
                case eVehicleType.Lorry:
                    return new Lorry();
                default:
                    throw new ArgumentException("Invalid car type. Please choose one of the options above");
            }
        }


        public enum eVehicleType
        {
            FuelCar = 1,
            FuelMotorcycle = 2,
            ElectricCar = 3,
            ElectricMotorcycle = 4,
            Lorry = 5
        }
    }
}