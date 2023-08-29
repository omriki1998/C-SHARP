using System;
using Ex02.ConsoleUtils;

namespace Ex02
{
    public class Program
    {
        public static void Main()
        {
            runGame();
        }

        private static void runGame()
        {
            bool keepPlaying = true;

            while (keepPlaying)
            {
                byte maxNumOfGuesses = UserInterface.getUserNumOfGuesses();
                bool won = false;

                GameBoard gameBoard = new GameBoard(maxNumOfGuesses);
                char[] generatedWord = WordGenerator.generateWord();
                for (int i = 0; i < maxNumOfGuesses && keepPlaying; i++)
                {
                    UserInterface.printGameBoard(gameBoard);
                    string inputGuess = UserInterface.isValidGuessAndAssign(ref keepPlaying);
                    if (keepPlaying)
                    {
                        Guess currentGuess = new Guess(generatedWord, inputGuess);
                        gameBoard.ListOfRows[i].Guess = currentGuess;
                        gameBoard.RefreshGameBoardStr(i);
                        if (currentGuess.NumOfBullsEye == 4)
                        {
                            UserInterface.printWinScreen(gameBoard, i);
                            keepPlaying = UserInterface.isValidAnswerAndAssign();
                            won = true;
                            break;
                        }
                    }
                }

                if (keepPlaying && !won)
                {
                    UserInterface.printLooseScreen(gameBoard);
                    keepPlaying = UserInterface.isValidAnswerAndAssign();
                }

                Screen.Clear();
            }

            Console.WriteLine("Bye!");
            Console.ReadLine();
        }
    }
}
