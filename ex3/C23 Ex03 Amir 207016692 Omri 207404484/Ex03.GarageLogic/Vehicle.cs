using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03
{
    public abstract class Vehicle
    {
        public Dictionary<string, Action<string>> r_QuestionsToCreateNewVehicle = new Dictionary<string, Action<string>>();
        protected readonly string r_LicensePlate = null;
        protected readonly byte r_NumOfTires;
        protected string m_ModelName = null;
        protected Engine m_Enigne = null;
        protected Tire[] m_Tires = null;
        protected Tire m_TireType = new Tire();

        public Vehicle(string i_LicensePlate, byte i_NumOfTires, float i_MaxPressure)
        {
            r_LicensePlate = i_LicensePlate;
            r_NumOfTires = i_NumOfTires;
            m_TireType.MaximumPressure = i_MaxPressure;
            r_QuestionsToCreateNewVehicle.Add("What is your vehicle model name? ", InvokeModelNameSetter);
            AddKeyValPairsToDict(m_TireType.r_QuestionsToCreateNewTire);
        }

        internal void SetTires(byte i_NumOfTires)
        {
            m_Tires = new Tire[i_NumOfTires];
            for (int i = 0; i < i_NumOfTires; i++)
            {
                m_Tires[i] = m_TireType;
            }
        }

        internal void InvokeModelNameSetter(string i_ModelName)
        {
            if(i_ModelName.Length == 0)
            {
                throw new FormatException("Please enter a valid name");
            }

            this.ModelName = i_ModelName;
        }

        public Dictionary<string, Action<string>> QuestionsToCreateNewVehicle
        {
            get { return r_QuestionsToCreateNewVehicle; }
        }

        internal Engine Engine
        {
            get { return m_Enigne; }
            set { m_Enigne = value; }
        }

        internal string LicensePlate
        {
            get { return r_LicensePlate; }
        }

        internal byte NumOfTires
        {
            get { return r_NumOfTires; }
        }

        internal string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        internal Tire TireType 
        {
            get { return m_TireType; }
        }

        internal Tire[] Tires
        {
            get { return m_Tires; }
        }

        public static bool isValidLicensePlate(string i_LicensePlate)
        {
            bool isValidLicensePlate = true;
            if (i_LicensePlate.Length < 5 || i_LicensePlate.Length > 10)
            {
                isValidLicensePlate = false;
                throw new ValueOutOfRangeException(5f, 10f);
            }
            else
            {
                foreach (char c in i_LicensePlate)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        isValidLicensePlate = false;
                        throw new FormatException("Invalid license plate. Please make sure the license plate consists of numbers and letters only.");
                    }
                }
            }

            return isValidLicensePlate;
        }

        public override string ToString()
        {
            string toOut = string.Format(
                "Number of tires: {0}\n" +
                "Tire properties:\n" +
                "{1}\n" +
                "Model name: {2}\n" +
                "License plate: {3}\n" +
                "Engine properties:\n" +
                "{4}",
                r_NumOfTires,
                tireArrayToString(),
                m_ModelName,
                this.LicensePlate,
                this.Engine.ToString());

            return toOut;
        }

        private string tireArrayToString()
        {
            StringBuilder tiresString = new StringBuilder();
            tiresString.Append("Manufacturer name: " + m_TireType.ManufacturerName);
            tiresString.AppendLine();
            tiresString.Append("Tires pressure: ");
            for (int i = 0;  i < m_Tires.Length; i++)
            {   
                if (i == m_Tires.Length - 1)
                {
                    tiresString.Append(m_Tires[i].TirePressure);
                }
                else
                {
                  tiresString.Append(m_Tires[i].TirePressure + ", ");
                }
            }

            tiresString.AppendLine();
            tiresString.Append("Maximum pressure of tires: " + m_TireType.MaximumPressure);

            return tiresString.ToString();
        }

        protected void AddKeyValPairsToDict(Dictionary<string, Action<string>> dict)
        {
            foreach (KeyValuePair<string, Action<string>> kvp in dict)
            {
                r_QuestionsToCreateNewVehicle.Add(kvp.Key, kvp.Value);
            }
        }
    }
}
