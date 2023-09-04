using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class ElectricEngine : Engine
    {
        protected float m_BatteryHoursRemaining;
        protected float m_MaximumHoursOfChargeOnBattery = 0f;

        internal ElectricEngine(float i_MaximumHoursOfChargeOnBattery)
            : base(i_MaximumHoursOfChargeOnBattery)
        {
            m_MaximumHoursOfChargeOnBattery = i_MaximumHoursOfChargeOnBattery;
            m_BatteryHoursRemaining = m_MaximumHoursOfChargeOnBattery * m_EnergyRemainingPrecentage;
        }

        internal void ChargeBattery(float i_NumberOfHoursToCharge)
        {
            if (i_NumberOfHoursToCharge + this.BatteryHoursRemaining > this.MaximumHoursOfChargeOnBattery)
            {
                throw new ValueOutOfRangeException(0, (this.MaximumHoursOfChargeOnBattery - this.BatteryHoursRemaining) * 60);
            }
            else
            {
                FillEnergy(i_NumberOfHoursToCharge);
            }
        }

        internal override void FillEnergy(float i_NumberOfHoursToCharge)
        {
            this.EnergyRemainingPrecentage += (i_NumberOfHoursToCharge / this.MaximumHoursOfChargeOnBattery) * 100;
            this.BatteryHoursRemaining = (this.EnergyRemainingPrecentage * this.MaximumHoursOfChargeOnBattery) / 100;
        }

        internal float BatteryHoursRemaining 
        {
            get { return (EnergyRemainingPrecentage * this.MaximumHoursOfChargeOnBattery) / 100; }
            set { m_BatteryHoursRemaining = value; }
        }

        internal float MaximumHoursOfChargeOnBattery
        {
            get { return m_MaximumHoursOfChargeOnBattery; }
            set { m_MaximumHoursOfChargeOnBattery = value; }
        }

        public override string ToString()
        {
            string electricCarString = string.Format(
                "{0}\n" +
                "Battery hours remaining: {1}\n" +
                "Maximum hours of battery: {2}",
                base.ToString(),
                this.BatteryHoursRemaining,
                this.MaximumHoursOfChargeOnBattery);

            return electricCarString;
        }
    }
}
