using System;

namespace Ex03
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName = null;
        protected readonly string r_LicensePlate = null;
        protected float m_EnergyRemainingPrecentage = 0f;
        protected Tire[] m_Tires = null;
        protected Tire m_TireType = null;
        protected readonly byte r_NumOfTires;

        public Vehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTire, byte i_NumOfTires)
        {
            r_ModelName = i_ModelName;
            r_LicensePlate = i_LicensePlate;
            m_EnergyRemainingPrecentage = i_EnergyLevelPercentage;
            m_TireType = i_CarTire; 
            r_NumOfTires = i_NumOfTires;
        }

        internal void SetTires(byte i_NumOfTires)
        {
            m_Tires = new Tire[i_NumOfTires];
            for (int i = 0; i < i_NumOfTires; i++)
            {
                m_Tires[i] = m_TireType;
            }
        }

        internal string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        internal byte NumOfTires
        {
            get { return r_NumOfTires; }
        }

        internal Tire[] Tires
        {
            get { return m_Tires; }
        }

        public enum eMotorcycleLicenseType
        {
            A,
            A1,
            A2,
            AB
        }

        public enum eCarColour
        {
            Black,
            White,
            Red, 
            Blue
        }

        public enum eNumOfDoors
        {
            Two = 2, 
            Three = 3, 
            Four = 4, 
            Five = 5
        }

        public override string ToString()
        {
            string toOut = string.Format("Model name: {0}\n" +
                "License plate: {1}\n" +
                "Energy remaining percentage: {2}\n" +
                "Number of tires: {3}\n" +
                "Tire Type: {4}\n", r_ModelName, r_LicensePlate, m_EnergyRemainingPrecentage, r_NumOfTires, m_TireType.ToString());

            return toOut;
        }
    }
}
