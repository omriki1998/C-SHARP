using System;


namespace Ex03.GarageLogic
{
    internal class FuelMotorcycle : FuelVehicle
    {
        protected readonly eMotorcycleLicenseType r_LicenseType;
        protected readonly int r_EngineVol = 0;

        internal FuelMotorcycle(string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, float i_FuelTankSize, eFuelType i_FuelType, eMotorcycleLicenseType i_LicenseType, int i_EngineVol)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, 2, i_FuelTankSize, i_FuelType)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVol = i_EngineVol;
            base.SetTires(2);
        }
    }
}
