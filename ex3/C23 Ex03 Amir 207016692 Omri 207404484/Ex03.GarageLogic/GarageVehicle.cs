using System;

namespace Ex03
{
    public class GarageVehicle
    {
        private readonly string r_OwnerPhoneNumber = null;
        private readonly string r_OwnerName = null;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public GarageVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = eVehicleStatus.Repair;
        }

        public static string isValidOwnerNameAndAssign(string i_OwnerName)
        {
            if (string.IsNullOrEmpty(i_OwnerName))
            {
                throw new FormatException("Please enter a name");
            }

            foreach (char c in i_OwnerName)
            {
                if (!char.IsLetter(c))
                {
                    throw new FormatException("Please enter a valid name");
                }
            }

            return i_OwnerName;
        }

        public static string isValidOwnerPhoneNumberAndAssign(string i_OwnerPhoneNumber)
        {
            if (string.IsNullOrEmpty(i_OwnerPhoneNumber))
            {
                throw new FormatException("Please enter a valid phone number");
            }

            foreach (char c in i_OwnerPhoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    throw new FormatException("Please enter a valid phone number");
                }
            }

            return i_OwnerPhoneNumber;
        }

        public eVehicleStatus CarStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle;  }
        }

        public enum eVehicleStatus
        {
            Repair = 1,
            Done,
            Paid
        }

        public override string ToString()
        {
            string toOut = string.Format(
                "Vehicle properties: \n{0}" +
                "Owner name: {1}\n" +
                "Owner phone number: {2}\n" +
                "Car status: {3}\n", 
                this.Vehicle.ToString(),
                r_OwnerName, 
                r_OwnerPhoneNumber, 
                m_VehicleStatus);

            return toOut;
        }
    }
}
