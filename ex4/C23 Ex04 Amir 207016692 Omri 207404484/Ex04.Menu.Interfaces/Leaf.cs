using System;

namespace Ex04
{
    public class Leaf : ILeaf
    {
        string m_LeafName;

        public Leaf(string i_LeafName)
        {
            m_LeafName = i_LeafName; 
        }
        public virtual void MethodToExecute()
        {
        }
        public override string ToString()
        {
            return m_LeafName;
        }
    }
}
