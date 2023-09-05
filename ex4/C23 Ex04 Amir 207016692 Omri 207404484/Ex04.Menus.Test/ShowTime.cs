using System;

namespace Ex04
{
    internal class ShowTime : Leaf
    {

        internal ShowTime(string i_LeafName) : base(i_LeafName)
        {
        }
        public override void MethodToExecute()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine(String.Format("The hour is: {0}\n", currentTime.ToString("HH:mm:ss")));
        }
    }
}
