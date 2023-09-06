using System;

namespace Ex03
{
    public class WrongEngineTypeException : Exception
    {
        private string m_TriedToFill = string.Empty;
        private string m_ActualEnergyType = string.Empty;

        public WrongEngineTypeException(string i_TriedToFill, string i_ActualEnergyType)
            : base(string.Format("Wrong engine type. Tried to fill {0} in type {1} powered engine", i_TriedToFill, i_ActualEnergyType))
        {
            m_TriedToFill = i_TriedToFill;
            m_ActualEnergyType = i_ActualEnergyType;
        }

        public string TriedToFill
        {
            get { return m_TriedToFill; }
        }

        public string ActualEnergyType
        {
            get { return m_ActualEnergyType; }
        }
    }
}