using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03
{
    public class Garage
    {
        public Dictionary<string, GarageVehicle> m_VehiclesDict = new Dictionary<string, GarageVehicle>();

        public bool isVehicleInGarage(string i_LicensePlate)
        {
            return m_VehiclesDict.ContainsKey(i_LicensePlate);
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

            if (!isValidCarStatus || (isValidNum && !Enum.IsDefined(typeof(GarageVehicle.eVehicleStatus), o_ECarStatus)))
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
            if (!isVehicleInGarage(i_LicensePlate))
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
        
        public void AddFuel(string i_LicensePlate, FuelVehicle.eFuelType i_FuelType, float i_LitresToFill)
        {

            FuelVehicle currentVehicle = GetVehicleByLicensePlate(i_LicensePlate) as FuelVehicle;
            if (currentVehicle == null)
            {
                throw new ArgumentException("This is not a fuel powered vehicle.");
            }
            else
            {
                try
                {
                    currentVehicle.FillFuel(i_FuelType, i_LitresToFill);
                }
                catch(ArgumentException ex)
                {
                    //Fuel type does not match
                }
                catch(ValueOutOfRangeException ex)
                {
                    //Too much fuel to fill 
                }
            }
        }

        public void ChargeBattery(string i_LicensePlate, float i_MinutesToCharge)
        {
            ElectricVehicle currentVehicle = GetVehicleByLicensePlate(i_LicensePlate) as ElectricVehicle;
            if (currentVehicle == null)
            {
                throw new ArgumentException("This is not an electricity powered vehicle.");
            }
            else
            {
                try
                {
                    currentVehicle.ChargeBattery(i_MinutesToCharge / 60);
                }
                catch 
                {
                    //Too much power to fill 
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
