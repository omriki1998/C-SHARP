using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class FuelEngine : Engine
    {
        protected readonly float r_FuelTankSize = 0f;
        protected eFuelType? m_FuelType = null;
        protected float m_CurrentFuelLevel;

        internal FuelEngine(float i_FuelTankSize)
            : base(i_FuelTankSize)
        {
            r_FuelTankSize = i_FuelTankSize;
            r_QuestionsToCreateNewEngine.Add(
                string.Format(
                "Please choose your fuel type:\n" +
                "1. Octan95\n" +
                "2. Octan96\n" +
                "3. Octan98\n" +
                "4. Soler"), 
                InvokeFuelTypeSetter);
        }

        internal void FillFuel(string i_FuelType, string i_LitresOfFuelToFill)
        {
            bool isValidFloat = float.TryParse(i_LitresOfFuelToFill, out float o_LitresOfFuelToFill);

            if (i_FuelType == "electricity")
            {
                throw new WrongEngineTypeException("electricity", "fuel");
            }
            else if (!isValidFloat)
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
            else if (o_LitresOfFuelToFill + m_CurrentFuelLevel > r_FuelTankSize)
            {
                throw new ValueOutOfRangeException(0, this.FuelTankSize - this.CurrentFuelLevel);
            }
            else
            {
                FillEnergy(o_LitresOfFuelToFill);
            }
        }

            internal override void FillEnergy(float i_LitresOfFuelToFill)
            {
                m_EnergyRemainingPrecentage += 100 * (i_LitresOfFuelToFill / r_FuelTankSize);
                this.CurrentFuelLevel = (EnergyRemainingPrecentage * this.FuelTankSize) / 100;
            }

        internal void InvokeFuelTypeSetter(string i_FuelType)
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

        internal eFuelType validateFuelType(string i_FuelType)
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
            get { return (EnergyRemainingPrecentage * this.FuelTankSize) / 100; }
            set { m_CurrentFuelLevel = value; }
        }

        internal float FuelTankSize
        {
            get { return r_FuelTankSize; }
        }

        internal enum eFuelType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }

        public override string ToString()
        {
            string fuelVehicleString = string.Format(
                "{0}\n" +
                "Fuel Tank Size: {1}\n" +
                "Fuel type: {2}\n" +
                "Current fuel level: {3}",
                base.ToString(),
                this.MaxEnergyCapacity,
                this.FuelType,
                this.CurrentFuelLevel);

            return fuelVehicleString; 
        }
    }
}
