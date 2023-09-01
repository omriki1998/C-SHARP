using System;
using System.Collections.Generic;

namespace Ex03
{
    public class ElectricVehicle : Vehicle
    {
        protected float m_BatteryHoursRemaining;
        protected float m_MaximumHoursOfChargeOnBattery = 0f;

        internal ElectricVehicle(byte i_NumOfTires, byte i_MaxTirePressure, float i_MaximumHoursOfChargeOnBattery)
            : base(i_NumOfTires, i_MaxTirePressure, i_MaximumHoursOfChargeOnBattery)
        {
            m_MaximumHoursOfChargeOnBattery = i_MaximumHoursOfChargeOnBattery;
            m_BatteryHoursRemaining =  m_MaximumHoursOfChargeOnBattery * m_EnergyRemainingPrecentage;
        }

        internal void ChargeBattery(float i_NumberOfHoursToCharge)
        {
            if(i_NumberOfHoursToCharge + this.BatteryHoursRemaining > this.MaximumHoursOfChargeOnBattery)
            {
                throw new ValueOutOfRangeException(0, (this.MaximumHoursOfChargeOnBattery - this.BatteryHoursRemaining) * 60);
            }
            else
            {
                this.EnergyRemainingPrecentage += (i_NumberOfHoursToCharge / this.MaximumHoursOfChargeOnBattery) * 100;
                this.BatteryHoursRemaining = (this.EnergyRemainingPrecentage * this.MaximumHoursOfChargeOnBattery) / 100;
            }
        }

        /*internal void InvokeBaterryHoursRemainingSetter(string i_BatteryHoursRemaining)
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
        }*/
        
        internal float BatteryHoursRemaining 
        {
            get { return (base.EnergyRemainingPrecentage * this.MaximumHoursOfChargeOnBattery) / 100; }
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
