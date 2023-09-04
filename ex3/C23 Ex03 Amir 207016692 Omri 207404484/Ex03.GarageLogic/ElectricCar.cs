using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class ElectricCar : Car
    {
        protected const float k_MaximumHoursOfChargeOnBattery = 5.2f;

        internal ElectricCar(string i_LicensePlate)
            : base(i_LicensePlate)
        {
            Engine = new ElectricEngine(k_MaximumHoursOfChargeOnBattery);
            AddKeyValPairsToDict(m_Enigne.r_QuestionsToCreateNewEngine);
        }
    }
}
