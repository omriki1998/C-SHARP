using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03
{
    public abstract class Vehicle
    {
        protected string m_ModelName = null;
        protected string m_LicensePlate = null;
        protected float m_EnergyRemainingPrecentage = 0f;
        protected Tire[] m_Tires = null;
        protected Tire m_TireType = new Tire();
        protected readonly byte r_NumOfTires;
        public readonly Dictionary<string, Action<string>> r_QuestionsToCreateNewVehicle = new Dictionary<string, Action<string>>();


        public Vehicle(byte i_NumOfTires, float i_MaxPressure)
        {
            r_QuestionsToCreateNewVehicle.Add("What is your vehicle model name? ", InvokeModelNameSetter);
            r_QuestionsToCreateNewVehicle.Add("What is your license plate? ", InvokeLicensePlateSetter);
            r_QuestionsToCreateNewVehicle.Add("What is the energy precentage of the vehicle? ", InvokeEnergyRemainingPrecentageSetter);
            m_TireType.MaximumPressure = i_MaxPressure;
            r_QuestionsToCreateNewVehicle = r_QuestionsToCreateNewVehicle.Union(m_TireType.r_QuestionsToCreateNewTire).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
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

        public void InvokeLicensePlateSetter(string i_LicensePlate)
        {
            try
            {
                bool isValid = isValidLicensePlate(i_LicensePlate);
                this.LicensePlate = i_LicensePlate;
            }
            catch
            {
                throw;
            }
        }

        public void InvokeModelNameSetter(string i_ModelName)
        {
            if(i_ModelName.Length == 0)
            {
                throw new FormatException("Please enter a valid name");
            }
            this.ModelName = i_ModelName;
        }

        public void InvokeEnergyRemainingPrecentageSetter(string i_EnergyRemainingPrecentage)
        {
            bool isValidNumber = float.TryParse(i_EnergyRemainingPrecentage, out float o_EnergyRemainingPrecentage);

            if (!isValidNumber)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if(o_EnergyRemainingPrecentage < 0 || o_EnergyRemainingPrecentage > 100)
            {
                throw new ValueOutOfRangeException(0, 100);
            }
            else
            {
                this.EnergyRemainingPrecentage = o_EnergyRemainingPrecentage;
            }
        }

        public Dictionary<string, Action<string>> QuestionsToCreateNewVehicle
        {
            get { return r_QuestionsToCreateNewVehicle; }
        }

        internal string LicensePlate
        {
            get { return m_LicensePlate; }
            set { m_LicensePlate = value; }
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

        internal float EnergyRemainingPrecentage
        {
            get { return m_EnergyRemainingPrecentage; }
            set { m_EnergyRemainingPrecentage = value; }
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
                    if (!Char.IsLetterOrDigit(c))
                    {
                        isValidLicensePlate = false;
                        throw new FormatException("Invalid license plate. Please make sure the license plate consists of numbers and letters only.");
                    }
                }
            }

            return isValidLicensePlate;
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
            Black = 1,
            White,
            Red, 
            Blue
        }

        public enum eNumOfDoors
        {
            Two = 2, 
            Three, 
            Four, 
            Five
        }

        public override string ToString()
        {
            string toOut = string.Format("Model name: {0}\n" +
                "License plate: {1}\n" +
                "Energy remaining percentage: {2}\n" +
                "Number of tires: {3}\n" +
                "Tire Type: \n{4}", m_ModelName, m_LicensePlate, m_EnergyRemainingPrecentage, r_NumOfTires, tireArrayToString());

            return toOut;
        }

        private string tireArrayToString()
        {
            StringBuilder tiresString = new StringBuilder();
            tiresString.Append("Manufacturer name: " + m_TireType.ManufacturerName);
            tiresString.AppendLine();
            tiresString.Append("Tires pressure: ");
            for (int i = 0; i < m_Tires.Length; i++)
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
    }
}
