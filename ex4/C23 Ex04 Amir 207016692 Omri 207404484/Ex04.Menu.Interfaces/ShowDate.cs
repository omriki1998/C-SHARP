using System;

namespace Ex04
{
    public class ShowDate : ILeaf
    {

        public ShowDate(string i_LeafName)
        {
        }

        public void MethodToExecute()
        {
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("The date is: {0}\n", currentDate.ToString("yyyy-MM-dd"));
        }
    }
}   
