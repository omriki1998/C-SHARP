using System;
using System.Linq;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public class UserInterface
    {
        public static byte getUserNumOfGuesses()
        {
            Console.WriteLine("Please enter the maximum number of guesses (4-10):");
            bool isValid = false;
            byte o_MaxNumOfGuesses = 0;

            while (!isValid)
            {
                bool isValidByte = byte.TryParse(Console.ReadLine(), out o_MaxNumOfGuesses);
                if (!isValidByte || (o_MaxNumOfGuesses < 4 || o_MaxNumOfGuesses > 10))
                {
                    Console.WriteLine("Enter a valid number from 4 to 10");
                }
                else
                {
                    isValid = true;
                }
            }

            return o_MaxNumOfGuesses;
        }

        public static void printGameBoard(GameBoard gameBoard)
        {
            Screen.Clear();
            Console.WriteLine("Current board status:");
            Console.WriteLine(gameBoard.GameBoardStr.ToString());
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
        }

        public static void printWinScreen(GameBoard i_gameBoard, int i_Iteration)
        {
            Screen.Clear();
            Console.WriteLine(i_gameBoard.GameBoardStr.ToString());
            Console.WriteLine(@"You guessed after {0} steps!", i_Iteration + 1);
            Console.WriteLine("Would you like to start a new game? <Y/N>");
        }

        public static void printLooseScreen(GameBoard i_gameBoard)
        {
            Screen.Clear();
            Console.WriteLine(i_gameBoard.GameBoardStr.ToString());
            Console.WriteLine("You ran out of guesses! Would you like to start a new game? <Y/N>");
        }


        public static string isValidGuessAndAssign(ref bool i_KeepPlaying)
        {
            string inputStr = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                inputStr = Console.ReadLine().ToUpper();
                if (inputStr.Equals("Q"))
                {
                    i_KeepPlaying = false;
                    break;
                }
                else if (inputStr.Length != 4)
                {
                    Console.WriteLine("Enter a valid input of size 4.");
                    continue;
                }
                else if (inputStr.Distinct().Count() != inputStr.Length)
                {
                    Console.WriteLine("Enter a valid input of size 4. Please do not repeat the same character more than once.");
                    continue;
                }
                {
                    isValid = true;
                    foreach (char letter in inputStr)
                    {
                        if (letter < 'A' || letter > 'H')
                        {
                            Console.WriteLine("Please enter a valid guess <'A' - 'H'> or 'Q' to quit");
                            isValid = false;
                            break;
                        }
                    }
                }
            }

            return inputStr;
        }

        public static bool isValidAnswerAndAssign()
        {
            bool isValid = false;
            while (!isValid)
            {
                string inputStr = Console.ReadLine().ToUpper();
                if (inputStr.Equals("Y"))
                {
                    isValid = true;
                }
                else if (inputStr.Equals("N"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input <Y/N>.");
                }
            }

            return isValid;
        }
    }
}
