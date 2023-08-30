using System;

namespace Ex03
{
    internal class ValueOutOfRangeException : Exception
    {
        protected float m_MaxValue = 0f;
        protected float m_MinValue = 0f; 

        internal ValueOutOfRangeException(float i_MinCapacity, float i_MaxCapacity)
            : base(string.Format("Value out of range exception. Min value is: {0}, max value is: {1}", i_MinCapacity, i_MaxCapacity))
                  { }

        internal float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }

        internal float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }
    }
}
