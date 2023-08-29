using System;

namespace Ex01_01
{
    class Program
    {
        private const byte k_ValidInputSize = 7;

        public static void Main()
        {
            binarySequence();
            Console.ReadLine();
        }

        private static void binarySequence()
        {
            Console.WriteLine("Please enter 3 numbers with 7 digits each in a binary format (press enter after each number):");
            string firstNumberStr = isInputNumberValidAndAssign();
            string secondNumberStr = isInputNumberValidAndAssign();
            string thirdNumberStr = isInputNumberValidAndAssign();
            int firstNumberDecimal = binaryStringToDecimalInt(firstNumberStr);
            int secondNumberDecimal = binaryStringToDecimalInt(secondNumberStr);
            int thirdNumberDecimal = binaryStringToDecimalInt(thirdNumberStr);

            float averageNumberOfZerosInInput = (totalNumberOfZerosInInput(firstNumberStr) + totalNumberOfZerosInInput(secondNumberStr)
                + totalNumberOfZerosInInput(thirdNumberStr)) / 3;
            float averageNumberOfOnesInInput = (21 - (totalNumberOfZerosInInput(firstNumberStr) + totalNumberOfZerosInInput(secondNumberStr)
                + totalNumberOfZerosInInput(thirdNumberStr))) / 3; // Number of indices in all 3 inputs together is 21.
            int numberOfInputsThatArePowerOfTwo = countNumberOfInputsThatArePowerOfTwo(firstNumberDecimal) +
                countNumberOfInputsThatArePowerOfTwo(secondNumberDecimal) + countNumberOfInputsThatArePowerOfTwo(thirdNumberDecimal);
            int numberOfAscendingInputs = countNumberOfAscendingInputs(firstNumberDecimal) + countNumberOfAscendingInputs(secondNumberDecimal) +
                countNumberOfAscendingInputs(thirdNumberDecimal);
            int largestValueInput = Math.Max(Math.Max(firstNumberDecimal, secondNumberDecimal), thirdNumberDecimal);
            int smallestValueInput = Math.Min(Math.Min(firstNumberDecimal, secondNumberDecimal), thirdNumberDecimal);

            string output = string.Format(@"The numbers are: {0}, {1}, {2}
There are {3} numbers that are a power of 2
In {4} of them there is an ascending order digits
The average number of ones is {5}, and average number of zeros is {6}
The largest number is {7} and the smallest is {8}", 
            firstNumberDecimal, 
            secondNumberDecimal,
            thirdNumberDecimal,
            numberOfInputsThatArePowerOfTwo,
            numberOfAscendingInputs,
            averageNumberOfOnesInInput,
            averageNumberOfZerosInInput,
            largestValueInput,
            smallestValueInput); 

            Console.WriteLine(output);
        }

        private static string isInputNumberValidAndAssign()
        {   
            while(true) 
            {
                string inputNumberBinary = Console.ReadLine();
                if (inputNumberBinary.Length != k_ValidInputSize)
                {
                    System.Console.WriteLine("Input number has to be of length 7! Please rewrite an input number (and then press enter):");
                    continue;
                }

                bool isValid = true;
                for (int i = 0; i < k_ValidInputSize; i++) 
                {
                    if (!(inputNumberBinary[i] == '0' || inputNumberBinary[i] == '1'))
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid binary number (only 0's and 1's (and then press enter)):");
                        break;
                    }
                }

                if (!isValid)
                {
                    continue;
                }

                return inputNumberBinary;
            }
        }

        private static int binaryStringToDecimalInt(string i_InputString)
        {
            int inputInt = 0;
            for (int i = 6; i >= 0; i--)
            {   
                if (i_InputString[i] == '1')
                {
                    inputInt += (int)Math.Pow(2, 6 - i); 
                }
            }

            return inputInt;
        }

        private static float totalNumberOfZerosInInput(string i_inputNumberStr)
        {
            float totalNumberOfZeros = 0;
            for (int index = 0; index < k_ValidInputSize; index++)
            {
                if (i_inputNumberStr[index] == '0')
                {
                    totalNumberOfZeros++;
                }
            }

            return totalNumberOfZeros;
        }

        private static int countNumberOfInputsThatArePowerOfTwo(int i_inputNumber)
        {
            int totalNumberOfInputsThatArePowerOfTwo = 0;
            if (isPowerOfTwo(i_inputNumber))
            {
                totalNumberOfInputsThatArePowerOfTwo++;
            }

            return totalNumberOfInputsThatArePowerOfTwo;
        }

        private static bool isPowerOfTwo(int i_inputNumberDecimal)
        {
            if (i_inputNumberDecimal == 0)
            {
                return false;
            }

            return (int)Math.Ceiling(Math.Log(i_inputNumberDecimal) / Math.Log(2)) == (int)Math.Floor(Math.Log(i_inputNumberDecimal) / Math.Log(2));
        }

        private static int countNumberOfAscendingInputs(int i_inputNumber)
        {
            int totalNumberOfAscendInputs = 0;
            if (isAscending(i_inputNumber))
            {
                totalNumberOfAscendInputs++;
            }       

            return totalNumberOfAscendInputs;
        }

        private static bool isAscending(int i_inputNumberDecimal)
        {
            bool isAscending = false;
            int leftMostDigit = 0, middleDigit = 0, rightMostDigit = 0;
            rightMostDigit = i_inputNumberDecimal % 10;
            middleDigit = (int)(i_inputNumberDecimal / 10) % 10;
            leftMostDigit = (int)(i_inputNumberDecimal / 100) % 10;

            if (rightMostDigit > middleDigit && middleDigit > leftMostDigit)
            {
                isAscending = true;
            }

            return isAscending;
        }
    }
}
