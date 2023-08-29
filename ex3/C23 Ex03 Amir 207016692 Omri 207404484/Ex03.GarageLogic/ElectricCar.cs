using System;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : ElectricVehicle
    {
        protected readonly eNumOfDoors r_NumOfDoors;
        protected readonly eCarColour r_CarColour;

        internal ElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, float i_BatteryHoursReamining, float i_MaximumHoursOfChargeOnBattery, eCarColour i_CarColour, eNumOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, 5, i_BatteryHoursReamining, i_MaximumHoursOfChargeOnBattery)
        {
            r_NumOfDoors = i_NumOfDoors;
            r_CarColour = i_CarColour;
            base.SetTires(5);
        }
    }
}
