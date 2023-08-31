using System;
using System.Collections.Generic;

namespace Ex03
{
    public class FuelVehicle : Vehicle
    {
        protected float m_FuelTankSize = 0f;
        protected eFuelType? m_FuelType = null;
        protected float m_CurrentFuelLevel = 0f;

        internal FuelVehicle(byte i_NumOfTires, float i_MaxTirePressure, float i_FuelTankSize)
            : base(i_NumOfTires, i_MaxTirePressure)
        {
            m_FuelTankSize = i_FuelTankSize;
            r_QuestionsToCreateNewVehicle.Add(String.Format("Please choose your fuel type:\n" +
                "1. Octan95\n" +
                "2. Octan96\n" +
                "3. Octan98\n" +
                "4. Soler"), InvokeFuelTypeSetter);
            m_CurrentFuelLevel = m_FuelTankSize * m_EnergyRemainingPrecentage;
        }

        internal void FillFuel(eFuelType i_FuelType, float i_LitresOfFuelToFill)
        {
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException(string.Format("Fuel type does not match the vehicle's fuel. Try {0}", m_FuelType));
            }
            else if (i_LitresOfFuelToFill + m_CurrentFuelLevel > m_FuelTankSize)
            {
                throw new ValueOutOfRangeException(0, m_FuelTankSize);
            }
            else
            {
                base.m_EnergyRemainingPrecentage += i_LitresOfFuelToFill / m_FuelTankSize;
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
            bool isValidFuelType = Enum.TryParse(i_FuelType, out eFuelType o_EFuelType);
            bool isValidNum = int.TryParse(i_FuelType, out int o_FuelTypeNum);


            if (!isValidFuelType || (isValidNum && !Enum.IsDefined(typeof(eFuelType), o_EFuelType)))
            {
                throw new ArgumentException("Please enter a valid fuel type");
            }
            else
            {
                this.FuelType = o_EFuelType;
            }
        }

        internal eFuelType? FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        internal float CurrentFuelLevel
        {
            get { return m_CurrentFuelLevel; }
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
                "Current fuel level: {3}", base.ToString(), m_FuelTankSize, m_FuelType, m_CurrentFuelLevel);

            return fuelVehicleString; 
        }
    }
}
