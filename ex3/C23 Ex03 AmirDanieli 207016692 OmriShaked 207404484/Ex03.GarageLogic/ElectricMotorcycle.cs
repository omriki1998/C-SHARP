using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class ElectricMotorcycle : Motorcycle
    {
        protected const float k_MaximumHoursOfChargeOnBattery = 2.4f;

        internal ElectricMotorcycle(string i_LicensePlate) : base(i_LicensePlate)
        {
            Engine = new ElectricEngine(k_MaximumHoursOfChargeOnBattery);
            AddKeyValPairsToDict(m_Enigne.r_QuestionsToCreateNewEngine);
        }
    }
}
