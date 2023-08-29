﻿using System;

namespace Ex03
{
    public class ElectricCar : ElectricVehicle
    {
        protected readonly eNumOfDoors r_NumOfDoors;
        protected readonly eCarColour r_CarColour;
        protected const float k_MaximumHoursOfChargeOnBattery = 5.2f; 

        public ElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, eCarColour i_CarColour, eNumOfDoors i_NumOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, 5, k_MaximumHoursOfChargeOnBattery)
        {
            r_NumOfDoors = i_NumOfDoors;
            r_CarColour = i_CarColour;
            base.SetTires(5);
        }

        public override string ToString()
        {
            string toOut = string.Format("Number of doors: {0}\n" +
                "Colour of car: {1}\n" +
                "Maximum hours of charge on battery: {2}\n", r_NumOfDoors, r_CarColour, k_MaximumHoursOfChargeOnBattery);

            return toOut;
        }
    }
}
