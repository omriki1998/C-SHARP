using System;
using System.Collections.Generic;

namespace Ex03
{
    public class Tire
    {
        protected string m_ManufacturerName = null;
        protected float m_TirePressure = 0f;
        protected float m_MaximumPressure = 0f;
        public readonly Dictionary<string, Action<string>> r_QuestionsToCreateNewTire = new Dictionary<string, Action<string>>();


        public Tire()
        {
            r_QuestionsToCreateNewTire.Add("What is your tire manufacturer? ", InvokeTireManufacturerSetter);
            r_QuestionsToCreateNewTire.Add("What is your current tire pressure? ", InvokeTirePressureSetter);
        }
        
        public void InvokeTirePressureSetter(string i_TirePressure)
        {
            bool isValidNumber = float.TryParse(i_TirePressure, out float o_TirePressure);

            if (!isValidNumber)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if(o_TirePressure < 0 || o_TirePressure > this.MaximumPressure)
            {
                throw new ValueOutOfRangeException(0, this.MaximumPressure);
            }
            else
            {
                this.TirePressure = o_TirePressure;
            }
        }

        public void InvokeTireManufacturerSetter(string i_TireManufacturer)
        {
            if(i_TireManufacturer.Length == 0)
            {
                throw new FormatException("Please enter a valid manufacturer");
            }
            else
            {
                this.ManufacturerName = i_TireManufacturer;
            }
        }

        internal void InflateTire(float i_AmountOfAirToInflate)
        {
            if(i_AmountOfAirToInflate + m_TirePressure > this.MaximumPressure)
            {
                throw new ValueOutOfRangeException(0, this.MaximumPressure);
            }
            else
            {
                m_TirePressure += i_AmountOfAirToInflate; 
            }
        }

        internal float TirePressure
        {
            get { return m_TirePressure;  }
            set { m_TirePressure = value; }
            }

        internal float MaximumPressure
        {
            get { return m_MaximumPressure; }
            set { m_MaximumPressure = value; }
        }

        internal string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public override string ToString()
        {
            string toOut = String.Format("Manufacturer name: {0}\n" +
                "Tire pressure: {1}\n" +
                "Maximum pressure: {2}\n", m_ManufacturerName, m_TirePressure, m_MaximumPressure);

            return toOut;
        }
    }
}
