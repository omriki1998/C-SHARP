using System;

namespace Ex01_05
{
    class Program
    {
        private const byte k_ValidInputSize = 6;
        public static void Main()
        {
            statisticalNumbers();
            Console.ReadLine();
        }

        private static void statisticalNumbers()
        {
            Console.WriteLine("Please enter a 6 digit number (and then press enter):");
            string inputStr = Console.ReadLine();
            while(!isValidInput(inputStr))
            {
                Console.WriteLine(@"Input is not valid! 
Please enter a 6 digit number (and then press enter):");
                inputStr = Console.ReadLine();
            }

            string outputStr = string.Format(
                @"The number of digits that are greater than the units digit is {0}.
The smallest digit is {1}.
The number of digits that are dividable by 3 is {2}.
The average of the digits in the input is {3}.", 
                numOfDigitsGreaterThanUnitsDigit(inputStr), 
                smallestDigit(inputStr),
                numOfDigitsDividableByThree(inputStr), 
                averageOfDigits(inputStr));
            Console.WriteLine(outputStr);
        }

        private static bool isValidInput(string i_inputStr)
        {
            bool isValid = true;
            if (i_inputStr.Length != k_ValidInputSize)
            {
                isValid = false;
            }
            else 
            {
                for (int i = 0; i < k_ValidInputSize; i++)
                {
                    if (!char.IsDigit(i_inputStr[i]))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        private static int numOfDigitsGreaterThanUnitsDigit(string i_inputStr)
        {
            int numOfDigitsGreaterThanUnitsDigit = 0;
            char unitsDigit = i_inputStr[5];
            for (int i = 0; i < 5; i++)
            {
                if (i_inputStr[i] > unitsDigit)
                {
                    numOfDigitsGreaterThanUnitsDigit++;
                }
            }

            return numOfDigitsGreaterThanUnitsDigit;
        }

        private static char smallestDigit(string i_inputStr)
        {
            char smallestDigit = i_inputStr[0];
            for(int i = 1; i < k_ValidInputSize; i++)
            {
                if (i_inputStr[i] < smallestDigit)
                {
                    smallestDigit = i_inputStr[i];
                }
            }

            return smallestDigit;
        }

        private static int numOfDigitsDividableByThree(string i_inputStr)
        {
            int numDigitsDividableByThree = 0;
            for (int i = 0; i < k_ValidInputSize; i++)
            {
                if (i_inputStr[i] % 3 == 0)
                {
                    numDigitsDividableByThree++;
                }
            }

            return numDigitsDividableByThree;
        }

        private static float averageOfDigits(string i_inputStr)
        {
            float sumOfDigits = 0;
            bool isValid = int.TryParse(i_inputStr, out int o_InputInt);
            if (isValid)
            {
                while(o_InputInt > 0)
                {
                    sumOfDigits += o_InputInt % 10;
                    o_InputInt /= 10;
                }
            }

            float averageOfDigits = sumOfDigits / 6;

            return averageOfDigits;
        }
    }
}
