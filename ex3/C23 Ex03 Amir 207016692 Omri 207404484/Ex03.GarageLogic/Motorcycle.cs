using System;

namespace Ex03
{
    internal class Motorcycle : Vehicle
    {
        protected const byte k_NumOfTires = 2;
        protected const byte k_TireMaxPressure = 30;
        protected eMotorcycleLicenseType m_LicenseType;
        protected int m_EngineVolume = 0;

        internal Motorcycle(string i_LicensePlate) : base(i_LicensePlate, k_NumOfTires, k_TireMaxPressure)
        {
            r_QuestionsToCreateNewVehicle.Add(
                string.Format("Please enter the motorcycle license type:\n" +
                "1. A\n" +
                "2. A1\n" +
                "3. A2\n" +
                "4. AB"), 
                InvokeLicenseTypeSetter);
            r_QuestionsToCreateNewVehicle.Add("Please enter the engine volume: ", InvokeEngineVolumeSetter);
            SetTires(k_NumOfTires);
        }

        internal void InvokeLicenseTypeSetter(string i_LicenseType)
        {
            bool isValidLicenseType = Enum.TryParse(i_LicenseType, out eMotorcycleLicenseType o_ELicenseType);
            bool isValidNum = int.TryParse(i_LicenseType, out int o_LicenseTypeNum);

            if (!isValidLicenseType || (isValidNum && !Enum.IsDefined(typeof(eMotorcycleLicenseType), o_ELicenseType)))
            {
                throw new FormatException("Please enter a valid license type");
            }
            else
            {
                this.LicenseType = o_ELicenseType;
            }
        }

        internal void InvokeEngineVolumeSetter(string i_EngineVolume)
        {
            bool isValidInt = int.TryParse(i_EngineVolume, out int o_EngineVolume);
            if (!isValidInt)
            {
                throw new FormatException("Engine volume should be a number");
            }
            else if (o_EngineVolume > 100000 || o_EngineVolume < 0)
            {
                throw new ArgumentException("Engine volume is in the range 0-100000");
            }
            else
            {
                this.EngineVolume = o_EngineVolume;
            }
        }

        public override string ToString()
        {
            string fuelMotorcycleString = string.Format(
                "{0}\n" +
                "License type: {1}\n" +
                "Engine volume: {2}\n", 
                base.ToString(), 
                m_LicenseType, 
                m_EngineVolume);

            return fuelMotorcycleString;
        }

        internal int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        internal eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        internal enum eMotorcycleLicenseType
        {
            A = 1,
            A1,
            A2,
            AB
        }
    }
}
