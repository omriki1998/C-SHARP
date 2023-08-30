using System;
using System.Collections.Generic;

namespace Ex03
{
    public class ElectricCar : ElectricVehicle
    {
        protected eNumOfDoors m_NumOfDoors;
        protected eCarColour m_CarColour;
        protected const float k_MaximumHoursOfChargeOnBattery = 5.2f;
        protected const byte k_NumOfTires = 5;
        protected const byte k_TireMaxPressure = 32;
        protected const byte k_MaxNumOfDoors = 5;
        protected const byte k_MinNumOfDoors = 2;

        public ElectricCar()
            : base(k_NumOfTires, k_TireMaxPressure, k_MaximumHoursOfChargeOnBattery)
        {
            r_QuestionsToCreateNewVehicle.Add("How many doors does your car have? ", InvokeNumOfDoorsSetter);
            r_QuestionsToCreateNewVehicle.Add("What is your car colour? ", InvokeCarColourSetter);
            base.SetTires(k_NumOfTires);
        }
       
        public void InvokeNumOfDoorsSetter(string i_NumOfDoors)
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

        public void InvokeCarColourSetter(string i_CarColour)
        {
            bool isValidCarColour = Enum.TryParse(i_CarColour, out eCarColour o_ECarColour);
            if (isValidCarColour)
            {
                this.CarColour = o_ECarColour;
            }
            else
            {
                throw new ArgumentException("Please choose a colour from: Red, White, Black or Blue");
            }
        }

        public eCarColour CarColour
        {
            get { return m_CarColour; }
            set { m_CarColour = value; }

        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }


        public override string ToString()
        {
            string electricCarString = string.Format("{0}\n" +
                "Number of doors: {1}\n" +
                "Colour of car: {2}\n", base.ToString(), m_NumOfDoors, m_CarColour);

            return electricCarString;
        }
    }
}
