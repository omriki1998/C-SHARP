using System;
using System.Collections.Generic;

namespace Ex02
{
    public class WordGenerator
    {
        private static readonly char[] sr_PossibleLetters = new char[8] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

        public static char[] generateWord()
        {
            Random rnd = new Random();
            char[] generatedWord = new char[4];
            List<int> indexesToChooseFrom = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                indexesToChooseFrom.Add(i);
            }

            for (int i = 7; i > 3; i--)
            {
                int randomInt = rnd.Next(0, i + 1);
                generatedWord[7 - i] = sr_PossibleLetters[indexesToChooseFrom[randomInt]];
                indexesToChooseFrom.RemoveAt(randomInt);
            }

            return generatedWord;
        }
    }
}
