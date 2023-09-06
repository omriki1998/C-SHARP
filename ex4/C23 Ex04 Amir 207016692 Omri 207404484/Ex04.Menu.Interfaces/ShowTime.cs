using System;

namespace Ex04
{
    public class ShowTime : Leaf
    {

        public ShowTime(string i_LeafName) : base(i_LeafName)
        {
        }
        public override void MethodToExecute()
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine(String.Format("The hour is: {0}\n", currentTime.ToString("HH:mm:ss")));
        }
    }
}
