using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03
{
    public class Garage
    {
        public Dictionary<string, GarageVehicle> m_VehiclesDict = new Dictionary<string, GarageVehicle>();

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return m_VehiclesDict.ContainsKey(i_LicensePlate);
        }

        public void ValidatesGarageIsNotEmpty()
        {
            if(this.m_VehiclesDict.Count == 0)
            {
                throw new ArgumentException("Garage is currently empty");
            }
        }

        public void ValidateVehicleInGarage(string i_LicensePlate)
        {
            if (!m_VehiclesDict.ContainsKey(i_LicensePlate))
            {
                throw new ArgumentException("License plate given does not exist in our garage");
            }
        }

        public void PutNewVehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            GarageVehicle garageVehicle = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhoneNumber);
            m_VehiclesDict.Add(key: i_Vehicle.LicensePlate, value: garageVehicle); 
        }

        public void updateExistingVehicle(string i_LicensePlate)
        {
            GarageVehicle currentCarInGarage = m_VehiclesDict[i_LicensePlate];
            currentCarInGarage.CarStatus = GarageVehicle.eVehicleStatus.Repair;
        }

        public List<string> GetListOfCarsInGarage(string i_CarStatus)
        {
            List<string> CarsInGarageList = new List<string>();
            bool isValidNum = int.TryParse(i_CarStatus, out int o_CarStatusInt);
            bool isValidCarStatus = Enum.TryParse(i_CarStatus, out GarageVehicle.eVehicleStatus o_ECarStatus);

            if (i_CarStatus.Equals("All") || (isValidNum && o_CarStatusInt == 4))
            {
                foreach (KeyValuePair<string, GarageVehicle> kvp in m_VehiclesDict)
                {
                    CarsInGarageList.Add(kvp.Key);
                }
            }
            else if (!isValidCarStatus || (isValidNum && !Enum.IsDefined(typeof(GarageVehicle.eVehicleStatus), o_ECarStatus)))
            {
                throw new ArgumentException("Please enter a valid car status");
            }
            else
            {
                foreach (KeyValuePair<string, GarageVehicle> kvp in m_VehiclesDict)
                {
                    if (kvp.Value.CarStatus == o_ECarStatus)
                    {
                        CarsInGarageList.Add(kvp.Key);
                    }
                }
            }

            return CarsInGarageList;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, string i_VehicleStatus)
        {
            if (!IsVehicleInGarage(i_LicensePlate))
            {
                throw new ArgumentException("This vehicle is not in garage");
            }

            bool isValidVehicleStatus = Enum.TryParse(i_VehicleStatus, out GarageVehicle.eVehicleStatus o_EVehicleStatus);
            bool isValidNum = int.TryParse(i_VehicleStatus, out int o_VehicleStatusNum);

            if (!isValidVehicleStatus || (isValidNum && !Enum.IsDefined(typeof(GarageVehicle.eVehicleStatus), o_EVehicleStatus)))
            {
                throw new FormatException("Please enter a valid vehicle status");
            }
            else
            {
            GarageVehicle currentVehicle = m_VehiclesDict[i_LicensePlate];
            currentVehicle.CarStatus = o_EVehicleStatus; 
            }
        }

        public void InflateTiresToMax(string i_LicensePlate)
        {
            Vehicle currentVehicle = GetVehicleByLicensePlate(i_LicensePlate);
            for(int i = 0; i < currentVehicle.NumOfTires; i++)
            {
                Tire currentVehicleTire = currentVehicle.Tires[i];
                currentVehicleTire.InflateTire(currentVehicleTire.MaximumPressure - currentVehicleTire.TirePressure);
            }
        } 

        public void AddFuel(string i_LicensePlate, string i_FuelType, string i_LitresToFill)
        {
            bool isValidFloat = float.TryParse(i_LitresToFill, out float o_AmountOfEnergyToFill);
            FuelEngine currentVehicle = GetVehicleByLicensePlate(i_LicensePlate).Engine as FuelEngine;

            if (currentVehicle == null)
            {
                throw new WrongEngineTypeException("fuel", "electricity");
            }
            else if (!isValidFloat)
            {
                throw new FormatException("Please enter a valid amount of litres to fill");
            }
            else
            {
                try
                {
                    currentVehicle.FillFuel(i_FuelType, i_LitresToFill);
                }
                catch
                {
                    throw;
                }
            }
        }

        public void ChargeBattery(string i_LicensePlate, string i_MinutesToCharge)
        {
            bool isValidFloat = float.TryParse(i_MinutesToCharge, out float o_MinutesToCharge);
            ElectricEngine currentVehicle = GetVehicleByLicensePlate(i_LicensePlate).Engine as ElectricEngine;
            if (currentVehicle == null)
            {
                throw new WrongEngineTypeException("electricity", "fuel");
            }
            else if (!isValidFloat)
            {
                throw new FormatException("Please enter a valid amount of minutes");
            }
            else
            {
                try
                {
                    currentVehicle.ChargeBattery(o_MinutesToCharge / 60);
                }
                catch 
                {
                    throw;
                }
            }
        }

        public GarageVehicle GetVehicleData(string i_LicensePlate)
        {
            return m_VehiclesDict[i_LicensePlate]; 
        }

        public Vehicle GetVehicleByLicensePlate(string i_LicensePlate)
        {
            return m_VehiclesDict[i_LicensePlate].Vehicle;
        }

        public override string ToString()
        {
            StringBuilder toOut = new StringBuilder();
            foreach (KeyValuePair<string, GarageVehicle> entry in m_VehiclesDict)
            {
                toOut.Append(entry.Value.ToString());
                toOut.AppendLine();
            }

            return toOut.ToString();
        }
    }
}
