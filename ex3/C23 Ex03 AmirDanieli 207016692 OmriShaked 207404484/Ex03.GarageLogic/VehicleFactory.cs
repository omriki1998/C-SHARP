using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(string i_VehicleType, string i_LicensePlate)
        {
            bool isValidCarType = Enum.TryParse(i_VehicleType, out eVehicleType o_EVehicleType);
            switch (o_EVehicleType)
            {
                case eVehicleType.FuelCar:
                    return new FuelCar(i_LicensePlate);
                case eVehicleType.FuelMotorcycle:
                    return new FuelMotorcycle(i_LicensePlate);
                case eVehicleType.ElectricCar:
                    return new ElectricCar(i_LicensePlate);
                case eVehicleType.ElectricMotorcycle:
                    return new ElectricMotorcycle(i_LicensePlate);
                case eVehicleType.Lorry:
                    return new Lorry(i_LicensePlate);
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