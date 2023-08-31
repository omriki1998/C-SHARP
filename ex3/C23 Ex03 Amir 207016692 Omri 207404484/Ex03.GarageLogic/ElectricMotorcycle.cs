using System;
using System.Collections.Generic;

namespace Ex03
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        protected eMotorcycleLicenseType m_LicenseType;
        protected int m_EngineVolume = 0;
        protected const float k_MaximumHoursOfChargeOnBattery = 2.4f;
        protected const byte k_NumOfTires = 2;
        protected const byte k_TireMaxPressure = 30;

        public ElectricMotorcycle()
            : base(k_NumOfTires, k_TireMaxPressure, k_MaximumHoursOfChargeOnBattery)
        {
            r_QuestionsToCreateNewVehicle.Add("Please enter the motorcycle license type(A, A1, A2, AB) ", InvokeLicenseTypeSetter);
            r_QuestionsToCreateNewVehicle.Add("Please enter the engine volume: ", InvokeEngineVolumeSetter);
            base.SetTires(2); 
        }

        public void InvokeLicenseTypeSetter(string i_LicenseType)
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

        public void InvokeEngineVolumeSetter(string i_EngineVolume)
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

        public eMotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public override string ToString()
        {
            string electricMotorcycleString = string.Format("{0}\n" +
                "Licesnse type: {1}\n" +
                "Engine volume: {2}\n", base.ToString(), m_LicenseType, m_EngineVolume);

            return electricMotorcycleString;
        }
    }
}
