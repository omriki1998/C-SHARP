using System;

namespace Ex03
{
    internal class Car : Vehicle
    {
        protected const byte k_NumOfTires = 5;
        protected const byte k_TireMaxPressure = 32;
        protected const byte k_MaxNumOfDoors = 5;
        protected const byte k_MinNumOfDoors = 2;
        protected eNumOfDoors m_NumOfDoors;
        protected eCarColour m_CarColour;
        
        internal Car(string i_LicensePlate) : base(i_LicensePlate, k_NumOfTires, k_TireMaxPressure)
        {
            r_QuestionsToCreateNewVehicle.Add("How many doors does your car have? ", this.InvokeNumOfDoorsSetter);
            r_QuestionsToCreateNewVehicle.Add(
                string.Format("Please state your car colour:\n" +
                "1. Black\n" +
                "2. White\n" +
                "3. Red\n" +
                "4. Blue"), 
                this.InvokeCarColourSetter);
            SetTires(k_NumOfTires);
        }

        public override string ToString()
        {
            string fuelCarString = string.Format(
                "{0}\n" +
                "Number of doors: {1}\n" +
                "Car colour: {2}\n",
                base.ToString(),
                m_NumOfDoors,
                m_CarColour);

            return fuelCarString;
        }

        internal void InvokeNumOfDoorsSetter(string i_NumOfDoors)
        {
            bool isValidNumOfDoors = false;
            bool isValidNumber = int.TryParse(i_NumOfDoors, out int o_NumOfDoors);

            if (!isValidNumber)
            {
                throw new FormatException("Please validate input");
            }
            else if (o_NumOfDoors < k_MinNumOfDoors || o_NumOfDoors > k_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(k_MinNumOfDoors, k_MaxNumOfDoors);
            }
            else
            {
                isValidNumOfDoors = Enum.TryParse(i_NumOfDoors, out eNumOfDoors o_ENumOfDoors);
                if (isValidNumOfDoors)
                {
                    this.NumOfDoors = o_ENumOfDoors;
                }
                else
                {
                    throw new ArgumentException("Please enter a number in the range 2-5");
                }
            }
        }

        internal void InvokeCarColourSetter(string i_CarColour)
        {
            bool isValidCarColour = Enum.TryParse(i_CarColour, out eCarColour o_ECarColour);
            bool isValidNum = int.TryParse(i_CarColour, out int o_CarColourNum);

            if (!isValidCarColour || (isValidNum && !Enum.IsDefined(typeof(eCarColour), o_CarColourNum)))
            {
                throw new ArgumentException("Please choose a colour from: Black, White, Red or Blue");
            }
            else
            {
                this.CarColour = o_ECarColour;
            }
        }

        internal eCarColour CarColour
        {
            get { return this.m_CarColour; }
            set { this.m_CarColour = value; }
        }

        internal eNumOfDoors NumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set { this.m_NumOfDoors = value; }
        }
        
        internal enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        internal enum eCarColour
        {
            Black = 1,
            White,
            Red,
            Blue
        }
    }
}
