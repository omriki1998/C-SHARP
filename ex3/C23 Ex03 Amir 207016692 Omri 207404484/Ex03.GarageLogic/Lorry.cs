using System;
using System.Collections.Generic;

namespace Ex03
{
    internal class Lorry : Vehicle
    {
        protected const float k_MaximumFuelCapacityLitres = 130f;
        protected const byte k_NumOfTires = 12;
        protected const byte k_TireMaxPressure = 27;
        protected const float k_MaxVolumeOfCargo = 100000f;
        protected bool m_IsColdTransporter = false;
        protected float m_VolumeOfCargo = 0f;

        internal Lorry(string i_LicensePlate) : base(i_LicensePlate, k_NumOfTires, k_TireMaxPressure)
        {
            r_QuestionsToCreateNewVehicle.Add("The lorry has cold transportation? (true/false)", InvokeIsColdTransporterSetter);
            r_QuestionsToCreateNewVehicle.Add("What is the volume of cargo in litres?", InvokeVolumeOfCargo);
            Engine = new FuelEngine(k_MaximumFuelCapacityLitres);
            SetTires(k_NumOfTires);
            AddKeyValPairsToDict(m_Enigne.r_QuestionsToCreateNewEngine);
        }

        internal void InvokeIsColdTransporterSetter(string i_BoolValue)
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

        internal void InvokeVolumeOfCargo(string i_VolOfCargo)
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
                this.VolumeOfCargo = o_VolumeOfCargo;
            }
        }

        internal bool IsColdTransporter
        {
            get { return this.m_IsColdTransporter; }
            set { this.m_IsColdTransporter = value; }
        }

        internal float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { this.m_VolumeOfCargo = value; }
        }

        public override string ToString()
        {
            string lorryString = string.Format(
                "{0}\n" +
                "Lorry is cold transport: {1}\n" +
                "Volume of cargo: {2}\n", 
                base.ToString(), 
                this.IsColdTransporter, 
                this.VolumeOfCargo);

            return lorryString;
        }
    }
}
