
using System.Net;
using System.Text;
using static System.Console;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
          
            string downloadedString;
            WebClient client;


            string input, answer;
            char guessedChar;
            int numberOfGuesses = 10;


            client = new WebClient();
            downloadedString = client.DownloadString("https://random-word-api.herokuapp.com/word");
            string randomWord = downloadedString;

            char[] charsToTrim = { '[', '"', '"', ']' };

            string text = randomWord;

            string formatedString = text.Trim(charsToTrim);

            Console.WriteLine("After trim: " + formatedString);


            List<string> guessedList = new List<string>();
            string[] secretWord = new string[] { formatedString };

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



            StringBuilder guessedLetters = new StringBuilder(15);

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
                    Console.ResetColor();


                    WriteLine("Guess the word!");

                    WriteLine(answerDisplay);
                    WriteLine(formatedString);
                    WriteLine(guessedLetters);
                    WriteLine($"Guesses left:{numberOfGuesses}\n1. Guess a letter.\n2. Solve word");
                    input = ReadLine();
                    switch (input)
                    {

                        case "1":
                            numberOfGuesses--;
                            WriteLine("Guess a letter: ");
                            input = ReadLine();
                            guessedChar = char.Parse(input);
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



                        case "2":
                            input = ReadLine();
                            if (input == answer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                WriteLine("You Win!");
                                numberOfGuesses = 0;
                                break;
                            }
                            else
                            {
                                numberOfGuesses--;
                            }
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Invalid choice, try again...");
                            ReadLine();
                              Clear();
                            break;
                    }
                }
            }
        
           
            ReadLine();
        }
       
    }
}