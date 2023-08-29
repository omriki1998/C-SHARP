using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            drawSandClock();
            Console.ReadLine();
        }
        
        public static void drawSandClock(int i_numberOfStarsInLine = 5, int i_numberOfSpaces = 0)
        {
            StringBuilder lineOfStars = new StringBuilder(string.Empty);

            lineOfStars.Append(' ', i_numberOfSpaces);
            lineOfStars.Append('*', i_numberOfStarsInLine);
            lineOfStars.Append(' ', i_numberOfSpaces);
            Console.WriteLine(lineOfStars.ToString());
            if (i_numberOfStarsInLine != 1)
            {
                drawSandClock(i_numberOfStarsInLine - 2, i_numberOfSpaces + 1);
                Console.WriteLine(lineOfStars.ToString());
            }
        }
    }
}
