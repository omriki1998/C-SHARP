using System;

namespace Ex03
{
    public class GarageVehicle
    {
        private Vehicle m_Vehicle;
        private readonly string r_OwnerName = null;
        private readonly string r_OwnerPhoneNumber = null;
        private eCarStatus m_CarStatus;

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, eCarStatus i_CarStatus)
        {
            m_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_CarStatus = eCarStatus.Repair;
        }

        public eCarStatus CarStatus
        {
            get { return m_CarStatus; }
            set { m_CarStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle;  }
        }

        public enum eCarStatus
        {
            Repair,
            Done,
            Paid
        }

        public override string ToString()
        {
            string toOut = string.Format("Vehicle properties: \n{0}" +
                "Owner name: {1}\n" +
                "Owner phone number: {2}\n" +
                "Car status: {3}\n", m_Vehicle.ToString(), r_OwnerName, r_OwnerPhoneNumber, m_CarStatus);

            return toOut;
        }
    }
}
