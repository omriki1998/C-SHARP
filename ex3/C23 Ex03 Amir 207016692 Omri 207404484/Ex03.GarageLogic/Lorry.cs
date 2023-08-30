using System;
using System.Collections.Generic;

namespace Ex03
{
    public class Lorry : FuelVehicle
    {
        protected bool m_IsColdTransporter = false;
        protected float m_VolumeOfCargo = 0f;
        protected const float k_MaximumFuelCapacityLitres = 130f;
        protected const byte k_NumOfTires = 12;
        protected const byte k_TireMaxPressure = 27;
        protected const float k_MaxVolumeOfCargo = 100000f;


        public Lorry () 
            : base(k_NumOfTires, k_TireMaxPressure, k_MaximumFuelCapacityLitres)
        {
            r_QuestionsToCreateNewVehicle.Add("The lorry has cold transportation? (true/false)", InvokeIsColdTransporterSetter);
            r_QuestionsToCreateNewVehicle.Add("What is the volume of cargo in litres?", InvokeVolumeOfCargo);
            base.SetTires(k_NumOfTires);
        }

        public void InvokeIsColdTransporterSetter(string i_BoolValue)
        {
            bool isValid = bool.TryParse(i_BoolValue, out bool o_BoolValue);

            if (!isValid)
            {
                throw new FormatException("Please enter true/false");
            }
            else
            {
                m_IsColdTransporter = o_BoolValue;
            }

        }

        public void InvokeVolumeOfCargo(string i_VolOfCargo)
        {
            bool isValidFloat = float.TryParse(i_VolOfCargo, out float o_VolumeOfCargo);

            if (!isValidFloat)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if (o_VolumeOfCargo < 0f || o_VolumeOfCargo > k_MaxVolumeOfCargo)
            {
                throw new ValueOutOfRangeException(0, k_MaxVolumeOfCargo);
            }
            else
            {
                m_VolumeOfCargo = o_VolumeOfCargo;
            }
        }

        public bool IsColdTransporter
        {
            get { return m_IsColdTransporter; }
            set { m_IsColdTransporter = value; }
        }

        public float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { m_VolumeOfCargo = value; }
        }

        public override string ToString()
        {
            string lorryString = string.Format("{0}\n" +
                "Lorry is cold transport: {1}\n" +
                "Volume of cargo: {2}\n", base.ToString(), m_IsColdTransporter, m_VolumeOfCargo);

            return lorryString;
        }
    }
}
