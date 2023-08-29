using System;

namespace Ex03
{
    public class Tire
    {
        protected readonly string r_ManufacturerName = null;
        protected float m_TirePressure = 0f;
        protected readonly float r_MaximumPressure = 0f; 

        public Tire(string i_ManufacturerName, float i_TirePressure, float i_MaximumPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_TirePressure = i_TirePressure;
            r_MaximumPressure = i_MaximumPressure;
        }
        
        internal void InflateTire(float i_AmountOfAirToInflate)
        {
            if(i_AmountOfAirToInflate + m_TirePressure > r_MaximumPressure)
            {
                throw new ValueOutOfRangeException("tire", MaximumPressure, "PSI");
            }
            else
            {
                m_TirePressure += i_AmountOfAirToInflate; 
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

        public override string ToString()
        {
            string toOut = String.Format("Manufacturer name: {0}\n" +
                "Tire pressure: {1}\n" +
                "Maximum pressure: {2}\n", r_ManufacturerName, m_TirePressure, r_MaximumPressure);

            return toOut;
        }
    }
}
