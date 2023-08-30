﻿using System;


namespace Ex03
{
    public class FuelMotorcycle : FuelVehicle
    {
        protected readonly eMotorcycleLicenseType r_LicenseType;
        protected readonly int r_EngineVol = 0;
        protected const float k_MaximumFuelCapacityLitres = 6.2f;

        public FuelMotorcycle(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, eFuelType i_FuelType, eMotorcycleLicenseType i_LicenseType, int i_EngineVol)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, 2, k_MaximumFuelCapacityLitres
                  , i_FuelType)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVol = i_EngineVol;
            base.SetTires(2);
        }

        public override string ToString()
        {
            string fuelMotorcycleString = string.Format("{0}\n" +
                "License type: {1}\n" +
                "Engine volume: {2}\n", base.ToString(), r_LicenseType, r_EngineVol);

            return fuelMotorcycleString;
        }
    }
}
