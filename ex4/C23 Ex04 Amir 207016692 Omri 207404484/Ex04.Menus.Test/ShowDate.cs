using System;

namespace Ex04
{
    internal class ShowDate : Leaf
    {

        internal ShowDate(string i_LeafName) : base(i_LeafName)
        {
        }

        public override void MethodToExecute()
        {
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("The date is: {0}\n", currentDate.ToString("yyyy-MM-dd"));
        }
    }
}   
