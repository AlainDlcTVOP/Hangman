
using System.Text;
using static System.Console;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input, answer;
            char guessedChar;
            int  numberOfGuesses = 10;


            List<string> guessedList = new List<string>();
            string[] secretWord = new string[] {  "Sat" };

            secretWord = Array.ConvertAll(secretWord, w => w.ToLower());



            var random = new Random();
            int rnd = random.Next(0, secretWord.Length);
            answer = secretWord[rnd]; 

            

            char[] answerAsCharArray = answer.ToCharArray();
            char[] answerDisplay = new char[answerAsCharArray.Length];

            for (int i = 0; i < answerAsCharArray.Length; i++)
            {
                answerDisplay[i] = '_';
            }

            

            StringBuilder guessedLetters = new StringBuilder(50);

            while (numberOfGuesses > 0)
            {

               
                string checkAnswer = new string(answerDisplay);
                if (checkAnswer == answer)
                {
                    WriteLine("You Win!");
                    numberOfGuesses = 0;
                    break;
                }
                else
                {
                    Clear();
                    WriteLine("Guess the word!");
                    //Display number of letters in word
                    WriteLine(answerDisplay);
                    //Display previously guessed letters
                    WriteLine(guessedLetters);
                    WriteLine($"Guesses left:{numberOfGuesses}\n1. Guess a letter.\n2. Solve word");
                    input = ReadLine();
                    switch (input)
                    {
                      
                        case "1":
                            numberOfGuesses--;
                            WriteLine("Guess a letter: ");
                            input = ReadLine();
                            guessedChar = ConvertToChar(input);
                            for (int j = 0; j < answerAsCharArray.Length; j++)
                            {
                                if (guessedChar == answerAsCharArray[j])
                                {
                                    answerDisplay[j] = guessedChar;
                                }
                               
                            }
                            if (guessedList.Contains(input) == true)
                            {
                                numberOfGuesses++;
                            }
                            else
                            {
                                guessedList.Add(input);
                            }
                            guessedLetters.Append(guessedChar);
                            break;

                        ///////////////////////////////

                        case "2":
                            input = ReadLine();
                            if (input == answer)
                            {
                                WriteLine("You Win!");
                                numberOfGuesses = 0;
                                break;
                            }
                            else
                            {
                                numberOfGuesses--;
                            }
                            break;
                        ///////////////////////////////
                        default:
                            WriteLine("Invalid choice, try again...");
                            ReadLine();
                            break;
                    }
                }
            }

            WriteLine("Thank you for playing.");
            ReadLine();
        }
        public static char ConvertToChar(string input)
        {
            char answer = char.Parse(input);
            return answer;
        }
    }
}