using System;

namespace Ex03
{
    internal class ValueOutOfRangeException : Exception
    {
        protected float m_MaxValue = 0f;
        protected float m_MinValue = 0f; 

        internal ValueOutOfRangeException(string i_Word, float i_MaxCapacity, string i_Units)
            : base(string.Format("An error occured while trying to fill {0}. Amount to fill exceeds maximum capacity. Maximum capacity is: {1} {2}", i_Word, i_MaxCapacity, i_Units))
                  { }
    }
}
