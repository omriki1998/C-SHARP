using System;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            createStarClock();
            Console.ReadLine();
        }

        private static void createStarClock()
        {
            Console.WriteLine("Please enter the number of lines for the star clock (and then press enter):");
            while (true)
            {
                string inputNumberOfLinesStr = Console.ReadLine();
                bool goodInput = int.TryParse(inputNumberOfLinesStr, out int o_NumberOfLines); 
                while (!goodInput)
                {
                    Console.WriteLine("Please pass a valid input (and press enter):");
                    break;
                }

                if (!goodInput)
                {
                    continue;
                }

                if (o_NumberOfLines % 2 == 0)
                {
                    o_NumberOfLines += 1;
                }

                Ex01_02.Program.drawSandClock(o_NumberOfLines);
                break;
            }      
        }
    }
}
