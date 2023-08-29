using System;

namespace Ex03.GarageLogic
{
    internal class Lorry : FuelVehicle
    {
        protected readonly bool r_IsColdTransporter = false;
        protected readonly float r_VolumeOfCargo = 0f; 

        internal Lorry (string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, float i_FuelTankSize, eFuelType i_FuelType, bool i_IsColdTransporter, float i_VolumeOfCargo) 
            : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, 12, i_FuelTankSize, i_FuelType)
        {
            r_IsColdTransporter = i_IsColdTransporter;
            r_VolumeOfCargo = i_VolumeOfCargo;
            base.SetTires(12);
        }
    }
}
