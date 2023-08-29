using System;

namespace Ex02
{
    public class Guess
    {
        private readonly string r_UserGuess = null;
        private readonly byte? r_NumOfBullsEye = null;
        private readonly byte? r_NumsOfHits = null;

        public Guess(char[] i_GeneratedWord, string i_UserInput)
        {
            r_UserGuess = i_UserInput;
            byte[] results = calculateResult(i_GeneratedWord, i_UserInput);
            r_NumOfBullsEye = results[0];
            r_NumsOfHits = results[1];
        }

        private static byte[] calculateResult(char[] i_GeneratedWord, string i_UserInput)
        {
            byte[] result = new byte[2];
            byte numOfBullsEyes = 0;
            byte numOfHits = 0;

            for(int i = 0; i < i_GeneratedWord.Length; i++)
            {
                int charToFind = i_UserInput.IndexOf(i_GeneratedWord[i]);

                if (charToFind != -1)
                {
                    if (char.Equals(i_UserInput[i], i_GeneratedWord[i]))
                    {
                        numOfBullsEyes++;
                    }
                    else
                    {
                        numOfHits++;
                    }                    
                }
            }

            result[0] = numOfBullsEyes;
            result[1] = numOfHits;
            return result; 
        }

        public byte? NumOfBullsEye
        {
            get { return r_NumOfBullsEye; }
        }

        public byte? NumOfHits
        {
            get { return r_NumsOfHits; }
        }

        public string UserGuess
        {
            get { return r_UserGuess; }
        }
    }
}
