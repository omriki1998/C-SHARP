using System;
using System.Reflection;

namespace Ex04
{
    internal class CountCapitals : Leaf
    {
        internal CountCapitals(string i_LeafName) : base(i_LeafName)
        {
        }

        public override void MethodToExecute()
        {
            byte numOfCapitals = 0;

            Console.WriteLine("Please type the sentence for which you would like to count the number of capital letters:");
            string userInput = Console.ReadLine();

            foreach (char c in userInput)
            {
                if (Char.IsUpper(c))
                {
                    numOfCapitals++; 
                }
            }

            Console.WriteLine(String.Format("The number of capitals is: {0}\n", numOfCapitals));
        }
    }
}
