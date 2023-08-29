using System;

namespace Ex03
{
    public class ElectricVehicle : Vehicle
    {
        protected float m_BatteryHoursRemaining = 0f;
        protected readonly float r_MaximumHoursOfChargeOnBattery = 0f;

        internal ElectricVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, byte i_NumOfTires, float i_MaximumHoursOfChargeOnBattery)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, i_NumOfTires)
        {
            m_BatteryHoursRemaining = MaximumHoursOfChargeOnBattery * (m_EnergyRemainingPrecentage / 100);
            r_MaximumHoursOfChargeOnBattery = i_MaximumHoursOfChargeOnBattery;
        }

        internal void ChargeBattery(float i_NumberOfHoursToCharge)
        {
            if(i_NumberOfHoursToCharge + m_BatteryHoursRemaining > r_MaximumHoursOfChargeOnBattery)
            {
                throw new ValueOutOfRangeException("electricity", MaximumHoursOfChargeOnBattery, "hours");
            }
            else
            {
                m_EnergyRemainingPrecentage += i_NumberOfHoursToCharge / r_MaximumHoursOfChargeOnBattery;
            }
        }

        internal float BatteryHoursRemaining 
        {
            get { return m_BatteryHoursRemaining; }
        }

        internal float MaximumHoursOfChargeOnBattery
        {
            get { return r_MaximumHoursOfChargeOnBattery; }
        }

        public override string ToString()
        {
            string toOut = string.Format("Battery hours remaining: {0}\n" +
                "Maximum hours of battery: {1}\n", m_BatteryHoursRemaining, r_MaximumHoursOfChargeOnBattery);

            return toOut;
        }
    }
}
