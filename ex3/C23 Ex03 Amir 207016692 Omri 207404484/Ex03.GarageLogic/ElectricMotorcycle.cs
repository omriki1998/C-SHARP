using System;

namespace Ex03
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        protected readonly eMotorcycleLicenseType r_LicenseType;
        protected readonly int r_EngineVol = 0;
        protected const float k_MaximumHoursOfChargeOnBattery = 2.4f;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, eMotorcycleLicenseType i_LicenseType, int i_EngineVol)
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, 2, k_MaximumHoursOfChargeOnBattery)
        {
            r_LicenseType = i_LicenseType;
            r_EngineVol = i_EngineVol;
            base.SetTires(2); 
        }

        public override string ToString()
        {
            string electricMotorcycleString = string.Format("{0}\n" +
                "Licesnse type: {1}\n" +
                "Engine volume: {2}\n", base.ToString(), r_LicenseType, r_EngineVol);

            return electricMotorcycleString;
        }
    }
}
