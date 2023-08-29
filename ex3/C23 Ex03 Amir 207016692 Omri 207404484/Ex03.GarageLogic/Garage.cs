using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03
{
    public class Garage
    {
        public Dictionary<string, GarageVehicle> m_VehiclesDict = new Dictionary<string, GarageVehicle>();


        public bool PutNewVehicleInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, GarageVehicle.eCarStatus i_CarStatus)
        {
            bool isCarInGarage = false;
            if (m_VehiclesDict.ContainsKey(i_Vehicle.LicensePlate))
            {
                isCarInGarage = true;
                GarageVehicle currentCarInGarage = m_VehiclesDict[i_Vehicle.LicensePlate];
                currentCarInGarage.CarStatus = GarageVehicle.eCarStatus.Repair;
            }
            else
            {
            GarageVehicle garageVehicle = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhoneNumber, i_CarStatus);
            m_VehiclesDict.Add(key: i_Vehicle.LicensePlate, value: garageVehicle); 
            }

            return isCarInGarage;
        }

        public List<string> GetListOfCarsInGarage(GarageVehicle.eCarStatus i_CarStatus)
        {
            List<string> CarsInGarageList = new List<string>();
            
            foreach(KeyValuePair<string, GarageVehicle> kvp in m_VehiclesDict)
            {
                if (kvp.Value.CarStatus == i_CarStatus)
                {
                    CarsInGarageList.Add(kvp.Key);
                }
            }

            return CarsInGarageList;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, GarageVehicle.eCarStatus i_CarStatus)
        {
            GarageVehicle currentVehicle = m_VehiclesDict[i_LicensePlate];
            currentVehicle.CarStatus = i_CarStatus; 
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
