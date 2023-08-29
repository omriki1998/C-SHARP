using System;

namespace Ex03.GarageLogic
{
    internal class FuelVehicle : Vehicle
    {
        protected readonly float r_FuelTankSize = 0f;
        protected readonly eFuelType? r_FuelType = null;

        internal FuelVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, byte i_NumOfTires, float i_FuelTankSize,  eFuelType i_FuelType)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, i_NumOfTires)
        {
            r_FuelTankSize = i_FuelTankSize;
            r_FuelType = i_FuelType;
        }

        internal void FillFuel(float i_LitresOfFuelToFill, eFuelType i_FuelType)
        {
            try
            {
                base.m_EnergyRemaining += i_LitresOfFuelToFill / r_FuelTankSize;
            }
            catch
            {
                //TBD Exception (Out of bounds fuel to fill or incorrect fuel type 
            }
        }

        internal eFuelType? FuelType
        {
            get { return r_FuelType; }
        }

        internal float fuelLevel
        { 
            get { return base.m_EnergyRemaining; }
        }

        internal float FuelTankSize
        {
            get { return r_FuelTankSize; }
        }

        internal enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }
    }
}
