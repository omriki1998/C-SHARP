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
            string toOut = string.Format("Licesnse type: {0}\n" +
                "Engine volume: {1}\n" +
                "Maximum hours of charge on battery: {2}\n", r_LicenseType, r_EngineVol, k_MaximumHoursOfChargeOnBattery);

            return toOut;
        }
    }
}
