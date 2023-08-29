using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        internal Dictionary<string, GarageVehicle> m_VehiclesDict = new Dictionary<string, GarageVehicle>();


        internal bool PutNewCarInGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, GarageVehicle.eCarStatus i_CarStatus)
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

        internal List<string> GetListOfCarsInGarage(GarageVehicle.eCarStatus i_CarStatus)
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

        internal void ChangeVehicleStatus(string i_LicensePlate, GarageVehicle.eCarStatus i_CarStatus)
        {
            GarageVehicle currentVehicle = m_VehiclesDict[i_LicensePlate];
            currentVehicle.CarStatus = i_CarStatus; 
        }

        internal void InflateTiresToMax(string i_LicensePlate)
        {
            GarageVehicle currentVehicle = m_VehiclesDict[i_LicensePlate];
            for(int i = 0; i < currentVehicle.Vehicle.NumOfTires; i++)
            {
                Tire currentVehicleTire = currentVehicle.Vehicle.Tires[i];
                currentVehicleTire.InflateTire(currentVehicleTire.MaximumPressure - currentVehicleTire.TirePressure);
            }
        }   
    }
}
