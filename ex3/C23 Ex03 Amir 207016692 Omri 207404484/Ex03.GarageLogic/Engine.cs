using System;
using System.Collections.Generic;

namespace Ex03
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyCapacity = 0f;
        internal readonly Dictionary<string, Action<string>> r_QuestionsToCreateNewEngine = new Dictionary<string, Action<string>>();
        protected float m_EnergyRemainingPrecentage = 0f;
        protected float m_EnergyLevel = 0;

        internal Engine(float i_MaxEnergyCapacity)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            r_QuestionsToCreateNewEngine.Add("What is the energy precentage of the vehicle? ", InvokeEnergyRemainingPrecentageSetter);
        }

        internal void InvokeEnergyRemainingPrecentageSetter(string i_EnergyRemainingPrecentage)
        {
            bool isValidNumber = float.TryParse(i_EnergyRemainingPrecentage, out float o_EnergyRemainingPrecentage);

            if (!isValidNumber)
            {
                throw new FormatException("Please enter a valid number");
            }
            else if (o_EnergyRemainingPrecentage < 0 || o_EnergyRemainingPrecentage > 100)
            {
                throw new ValueOutOfRangeException(0, 100);
            }
            else
            {
                this.EnergyRemainingPrecentage = o_EnergyRemainingPrecentage;
                this.m_EnergyLevel = (this.EnergyRemainingPrecentage * this.r_MaxEnergyCapacity) / 100;
            }
        }

        internal float EnergyRemainingPrecentage
        {
            get { return m_EnergyRemainingPrecentage; }
            set { m_EnergyRemainingPrecentage = value; }
        }

        internal float MaxEnergyCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }

        internal float EnergyLevel
        {
            get { return m_EnergyLevel; }
            set { m_EnergyLevel = value; }
        }

        public override string ToString()
        {
            string toOut = string.Format("Energy remaining percentage: {0}", m_EnergyRemainingPrecentage);
            return toOut;
        }

       internal abstract void FillEnergy(float i_AmountOfEnergyToFill);
    }
}
