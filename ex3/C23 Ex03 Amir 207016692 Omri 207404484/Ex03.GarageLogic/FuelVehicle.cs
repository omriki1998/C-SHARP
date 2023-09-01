using System;
using System.Collections.Generic;

namespace Ex03
{
    public class FuelVehicle : Vehicle
    {
        protected float m_FuelTankSize = 0f;
        protected eFuelType? m_FuelType = null;
        protected float m_CurrentFuelLevel;

        internal FuelVehicle(byte i_NumOfTires, float i_MaxTirePressure, float i_FuelTankSize)
            : base(i_NumOfTires, i_MaxTirePressure, i_FuelTankSize)
        {
            m_FuelTankSize = i_FuelTankSize;
            r_QuestionsToCreateNewVehicle.Add(String.Format("Please choose your fuel type:\n" +
                "1. Octan95\n" +
                "2. Octan96\n" +
                "3. Octan98\n" +
                "4. Soler"), InvokeFuelTypeSetter);
        }

        internal void FillFuel(string i_FuelType, string i_LitresOfFuelToFill)
        {
            bool isValidFloat = float.TryParse(i_LitresOfFuelToFill, out float LitresOfFuelToFill);

            if (!isValidFloat)
            {
                throw new FormatException("Please enter a valid number");
            }
            eFuelType fuelType = new eFuelType();
            try
            {
                fuelType = validateFuelType(i_FuelType);
            }
            catch
            {
                throw;
            }

            if (fuelType != m_FuelType)
            {
                throw new ArgumentException(string.Format("Fuel type does not match the vehicle's fuel. Try {0}", m_FuelType));
            }
            else if (LitresOfFuelToFill + m_CurrentFuelLevel > m_FuelTankSize)
            {
                throw new ValueOutOfRangeException(0, (this.FuelTankSize - this.CurrentFuelLevel));
            }
            else
            {
                base.m_EnergyRemainingPrecentage += (100 * (LitresOfFuelToFill / m_FuelTankSize));
                this.CurrentFuelLevel = (base.EnergyRemainingPrecentage * this.FuelTankSize) / 100;
            }
        }

       /* public void InvokeCurrentFuelLevelSetter(string i_CurrentFuelLevel)
        {
            bool isValidFuelLevel = float.TryParse(i_CurrentFuelLevel, out float o_CurrentFuelLevel);

            if (!isValidFuelLevel)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if(o_CurrentFuelLevel < 0 || o_CurrentFuelLevel > m_FuelTankSize)
            {
                throw new ValueOutOfRangeException(0, m_FuelTankSize);
            }
            else
            {
                this.CurrentFuelLevel = o_CurrentFuelLevel;
            }
        }*/

        public void InvokeFuelTypeSetter(string i_FuelType)
        {
            try
            {
                eFuelType fuelType = validateFuelType(i_FuelType);
                this.FuelType = fuelType;
            }
            catch
            {
                throw;
            }
        }

        private eFuelType validateFuelType(string i_FuelType)
        {
            bool isValidFuelType = Enum.TryParse(i_FuelType, out eFuelType o_EFuelType);
            bool isValidNum = int.TryParse(i_FuelType, out int o_FuelTypeNum);

            if (!isValidFuelType || (isValidNum && !Enum.IsDefined(typeof(eFuelType), o_EFuelType)))
            {
                throw new ArgumentException("Please enter a valid fuel type");
            }

            return o_EFuelType;
        }

        internal eFuelType? FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        internal float CurrentFuelLevel
        {
            get { return (base.EnergyRemainingPrecentage * this.FuelTankSize) / 100; }
            set { m_CurrentFuelLevel = value; }
        }
        internal float FuelTankSize
        {
            get { return m_FuelTankSize; }
            set { m_FuelTankSize = value; }
        }

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }

        public override string ToString()
        {
            string fuelVehicleString = string.Format("{0}\n" +
                "Fuel Tank Size: {1}\n" +
                "Fuel type: {2}\n" +
                "Current fuel level: {3}", base.ToString(), base.r_MaxEnergyCapacity, m_FuelType, base.m_EnergyLevel);

            return fuelVehicleString; 
        }
    }
}
