using System;

namespace Ex03
{
    public class FuelVehicle : Vehicle
    {
        protected readonly float r_FuelTankSize = 0f;
        protected readonly eFuelType? r_FuelType = null;
        protected float m_CurrentFuelLevel = 0f;

        internal FuelVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, byte i_NumOfTires, float i_FuelTankSize,  eFuelType i_FuelType)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, i_NumOfTires)
        {
            r_FuelTankSize = i_FuelTankSize;
            r_FuelType = i_FuelType;
            m_CurrentFuelLevel = i_FuelTankSize * (i_EnergyLevelPercentage / 100);
        }

        internal void FillFuel(eFuelType i_FuelType, float i_LitresOfFuelToFill)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(string.Format("Fuel type does not match the vehicle's fuel. Try {0}", r_FuelType));
            }
            else if (i_LitresOfFuelToFill + m_CurrentFuelLevel > r_FuelTankSize)
            {
                throw new ValueOutOfRangeException("fuel", r_FuelTankSize, "litres");
            }
            else
            {
                base.m_EnergyRemainingPrecentage += i_LitresOfFuelToFill / r_FuelTankSize;
            }
        }

        internal eFuelType? FuelType
        {
            get { return r_FuelType; }
        }

        internal float fuelLevel
        { 
            get { return base.m_EnergyRemainingPrecentage; }
        }

        internal float FuelTankSize
        {
            get { return r_FuelTankSize; }
        }

        public enum eFuelType
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        public override string ToString()
        {
            string toOut = string.Format("Fuel Tank Size: {0}\n" +
                "Fuel type: {1}\n" +
                "Current fuel level: {2}\n", r_FuelTankSize, r_FuelType, m_CurrentFuelLevel);

            return toOut; 
        }
    }
}
