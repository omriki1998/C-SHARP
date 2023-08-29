using System;

namespace Ex03.GarageLogic
{
    internal class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private readonly string r_OwnerName = null;
        private readonly string r_OwnerPhoneNumber = null;
        private eCarStatus m_CarStatus;

        internal GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, eCarStatus i_CarStatus)
        {
            m_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_CarStatus = eCarStatus.Repair;
        }

        internal eCarStatus CarStatus
        {
            get { return m_CarStatus; }
            set { m_CarStatus = value; }
        }

        internal Vehicle Vehicle
        {
            get { return m_Vehicle;  }
        }

        internal enum eCarStatus
        {
            Repair,
            Done,
            Paid
        }
    }
}
