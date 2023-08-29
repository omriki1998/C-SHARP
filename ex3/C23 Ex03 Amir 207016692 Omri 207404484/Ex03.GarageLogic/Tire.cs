using System;

namespace Ex03.GarageLogic
{
    internal class Tire
    {
        protected readonly string r_ManufacturerName = null;
        protected float m_TirePressure = 0f;
        protected readonly float r_MaximumPressure = 0f; 

        internal Tire(string i_ManufacturerName, float i_TirePressure, float i_MaximumPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_TirePressure = i_TirePressure;
            r_MaximumPressure = i_MaximumPressure;
        }
        
        internal void InflateTire(float i_AmountOfAirToInflate)
        {
            try
            {
                m_TirePressure += i_AmountOfAirToInflate; 
            }
            catch
            {
                //TBD (Exception - Too much air)
            }
        }

        internal float TirePressure
        {
            get { return m_TirePressure;  }
        }

        internal float MaximumPressure
        {
            get { return r_MaximumPressure; }
        }
    }
}
