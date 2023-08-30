using System;


namespace Ex03
{
    public class FuelCar : FuelVehicle
    {
        protected readonly eNumOfDoors r_NumOfDoors;
        protected readonly eCarColour r_CarColour;
        protected const float k_MaximumFuelCapacityLitres = 44;

        public FuelCar(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, eFuelType i_FuelType, eCarColour i_CarColour, eNumOfDoors i_NumOfDoors)
           : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, 5, k_MaximumFuelCapacityLitres, i_FuelType)
        {
            r_NumOfDoors = i_NumOfDoors;
            r_CarColour = i_CarColour;
            base.SetTires(5);
        }

        public override string ToString()
        {
            string fuelCarString = string.Format("{0}\n" +
                "Number of doors: {1}\n" +
                "Car colour: {2}\n", base.ToString(), r_NumOfDoors, r_CarColour);

            return fuelCarString;
        }
    }
}
