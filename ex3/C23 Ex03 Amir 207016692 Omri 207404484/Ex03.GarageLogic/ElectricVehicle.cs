using System;

namespace Ex03.GarageLogic
{
    internal class ElectricVehicle : Vehicle
    {
        protected float m_BatteryHoursRemaining = 0f;
        protected readonly float r_MaximumHoursOfChargeOnBattery = 0f;

        internal ElectricVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLevel, Tire i_CarTires, byte i_NumOfTires, float i_BatteryHoursReamining, float i_MaximumHoursOfChargeOnBattery)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevel, i_CarTires, i_NumOfTires)
        {
            m_BatteryHoursRemaining = i_BatteryHoursReamining;
            r_MaximumHoursOfChargeOnBattery = i_MaximumHoursOfChargeOnBattery;
        }

        internal void ChargeBattery(float i_NumberOfHoursToCharge)
        {
            try
            {
                base.m_EnergyRemaining += i_NumberOfHoursToCharge / r_MaximumHoursOfChargeOnBattery;
            }
            catch
            {
                //TBD - Exception (out of bounds hours to charge)
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
    }
}
