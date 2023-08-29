using System;


namespace Ex03.GarageLogic
{
    internal class FuelCar : FuelVehicle
    {
        protected readonly eNumOfDoors r_NumOfDoors;
        protected readonly eCarColour r_CarColour;

        internal FuelCar(string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, float i_FuelTankSize, eFuelType i_FuelType, eCarColour i_CarColour, eNumOfDoors i_NumOfDoors)
           : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, 5, i_FuelTankSize, i_FuelType)
        {
            r_NumOfDoors = i_NumOfDoors;
            r_CarColour = i_CarColour;
            base.SetTires(5);
        }
    }
}
