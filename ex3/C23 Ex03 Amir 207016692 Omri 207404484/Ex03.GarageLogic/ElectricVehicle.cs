using System;
using System.Collections.Generic;

namespace Ex03
{
    public class ElectricVehicle : Vehicle
    {
        protected float m_BatteryHoursRemaining = 0f;
        protected float m_MaximumHoursOfChargeOnBattery = 0f;

        internal ElectricVehicle(byte i_NumOfTires, byte i_MaxTirePressure, float i_MaximumHoursOfChargeOnBattery)
            : base(i_NumOfTires, i_MaxTirePressure)
        {
            m_MaximumHoursOfChargeOnBattery = i_MaximumHoursOfChargeOnBattery;
            r_QuestionsToCreateNewVehicle.Add("How many hours on battery remaining? ", InvokeBaterryHoursRemainingSetter);
        }

        internal void ChargeBattery(float i_NumberOfHoursToCharge)
        {
            if(i_NumberOfHoursToCharge + m_BatteryHoursRemaining > m_MaximumHoursOfChargeOnBattery)
            {
                throw new ValueOutOfRangeException(0, MaximumHoursOfChargeOnBattery);
            }
            else
            {
                m_EnergyRemainingPrecentage += i_NumberOfHoursToCharge / m_MaximumHoursOfChargeOnBattery;
            }
        }

        internal void InvokeBaterryHoursRemainingSetter(string i_BatteryHoursRemaining)
        {
            bool isValidBaterryHours = float.TryParse(i_BatteryHoursRemaining, out float o_BaterryHoursRemaining);

            if (!isValidBaterryHours)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if(o_BaterryHoursRemaining < 0f || o_BaterryHoursRemaining > m_MaximumHoursOfChargeOnBattery)
            {
                throw new ValueOutOfRangeException(0, m_MaximumHoursOfChargeOnBattery);
            }
            else
            {
                this.BatteryHoursRemaining = o_BaterryHoursRemaining;
            }
        }

        internal float BatteryHoursRemaining 
        {
            get { return m_BatteryHoursRemaining; }
            set { m_BatteryHoursRemaining = value; }
            
        }

        internal float MaximumHoursOfChargeOnBattery
        {
            get { return m_MaximumHoursOfChargeOnBattery; }
            set { m_MaximumHoursOfChargeOnBattery = value; }
        }

        public override string ToString()
        {
            string electricCarString = string.Format("{0}\n" +
                "Battery hours remaining: {1}\n" +
                "Maximum hours of battery: {2}", base.ToString(), m_BatteryHoursRemaining, m_MaximumHoursOfChargeOnBattery);

            return electricCarString;
        }
    }
}
