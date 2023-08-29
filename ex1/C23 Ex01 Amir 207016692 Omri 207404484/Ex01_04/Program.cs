using System;

namespace Ex01_04
{
    class Program
    {
        private const byte k_ValidInputSize = 8;

        public static void Main()
        {
            inputAnalysis();
            Console.ReadLine();
        }

        private static void inputAnalysis()
        {
            Console.WriteLine("Please write an input of length 8 consisting of only numbers, or only letters (and then press enter):");
            string inputStr = isValidInputAndAssign();
            string output = string.Empty;

            bool inputIsDivisableByFour = true;

            bool isIntegerInput = int.TryParse(inputStr, out int o_InputInt);
            if(isIntegerInput)
            {
                if (o_InputInt % 4 != 0)
                {
                    inputIsDivisableByFour = false;
                }

                output = string.Format(
                    @"Input is a palindrome: {0}.
Number is divisable by 4: {1}", 
                    isPalindrome(inputStr), 
                    inputIsDivisableByFour);
            }

            if (!isIntegerInput)
            {
                output = string.Format(
                    @"Input is a palindrome: {0}.
There are {1} upper case letters in the input", 
                    isPalindrome(inputStr), 
                    numOfUpperCaseLettersInInput(inputStr));
            }

            Console.WriteLine(output);
        }

        private static bool isPalindrome(string i_inputStr, int i_indexOfInput = 0)
        {
            bool inputIsPalindrome = true;
            if (i_indexOfInput != k_ValidInputSize / 2)
            {
                inputIsPalindrome = char.Equals(i_inputStr[i_indexOfInput], i_inputStr[k_ValidInputSize - (1 + i_indexOfInput)]) && 
                isPalindrome(i_inputStr, i_indexOfInput + 1);
            }

            return inputIsPalindrome;
        }

        private static string isValidInputAndAssign()
        {
            while (true)
            {
                string userInput = Console.ReadLine();
                bool isValid = true;
                while (userInput.Length != k_ValidInputSize)
                {
                    Console.WriteLine("Input should be of length 8! Please enter a valid input (and press enter):");
                    isValid = false;
                    break;
                }

                if(!isValid)
                {
                    continue;
                }

                int numberOfLettersInInput = 0, numberOfDigitsInInput = 0;
                for (int i = 0; i < k_ValidInputSize; i++)
                {
                    if (char.IsLetter(userInput[i]))
                    {
                        numberOfLettersInInput++;
                    }
                    else if (char.IsDigit(userInput[i]))
                    {
                        numberOfDigitsInInput++;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                if (numberOfDigitsInInput != 0 && numberOfLettersInInput != 0)
                {
                    isValid = false;
                }

                if (!isValid)
                {
                    Console.WriteLine("Input is not valid! Please enter a valid input (and press enter):");
                    continue;
                }

                return userInput;
            }
        }

        private static int numOfUpperCaseLettersInInput(string i_inputStr)
        {
            int numberOfUpperCaseLettersInInput = 0;
            for (int i = 0; i < k_ValidInputSize; i++)
            {
                if (char.IsUpper(i_inputStr[i]))
                {
                    numberOfUpperCaseLettersInInput++;
                }
            }

            return numberOfUpperCaseLettersInInput;
        }
    }
}
