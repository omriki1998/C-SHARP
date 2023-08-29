using System;

namespace Ex03
{
    public class Lorry : FuelVehicle
    {
        protected readonly bool r_IsColdTransporter = false;
        protected readonly float r_VolumeOfCargo = 0f;
        protected const float k_MaximumFuelCapacityLitres = 130;

        public Lorry (string i_ModelName, string i_LicensePlate, float i_EnergyLevelPercentage, Tire i_CarTires, eFuelType i_FuelType, bool i_IsColdTransporter, float i_VolumeOfCargo) 
            : base(i_ModelName, i_LicensePlate, i_EnergyLevelPercentage, i_CarTires, 12, k_MaximumFuelCapacityLitres, i_FuelType)
        {
            r_IsColdTransporter = i_IsColdTransporter;
            r_VolumeOfCargo = i_VolumeOfCargo;
            base.SetTires(12);
        }

        public override string ToString()
        {
            string toOut = string.Format("Lorry is cold transport: {0}\n" +
                "Volume of cargo: {1}\n" +
                "Maxmum fuel capacity in liters: {2}\n", r_IsColdTransporter, r_VolumeOfCargo, k_MaximumFuelCapacityLitres);

            return toOut;
        }
    }
}
