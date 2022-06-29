
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
            int guessesLeft = 10;


            // api random animal 
            client = new WebClient();
            downloadedString = client.DownloadString("https://random-word-form.herokuapp.com/random/animal");
            string randomWord = downloadedString;

            char[] charsToTrim = { '[', '"', '"', ']' };

            string text = randomWord;

            string formatedString = text.Trim(charsToTrim);

          


            List<string> savedList = new List<string>();
            string[] secretWord = new string[] { formatedString };

            secretWord = Array.ConvertAll(secretWord, w => w.ToLower());



            var random = new Random();
            int rnd = random.Next(0, secretWord.Length);
            answer = secretWord[rnd];



            char[] answerAsCharArray = answer.ToCharArray();
            char[] view = new char[answerAsCharArray.Length];

            for (int i = 0; i < answerAsCharArray.Length; i++)
            {
                view[i] = '_';

            }

          

            StringBuilder charList = new StringBuilder(15);

            while (guessesLeft > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                string checkAnswer = new string(view);
                if (checkAnswer == answer)
                {
                    WriteLine("You Win!");
                    guessesLeft = 0;
                   
                    break;
                }
                else
                {
                  
                    WriteLine("Guess the animal!");
                    WriteLine(view);
                    WriteLine(charList);
                    WriteLine($"Guesses left:{guessesLeft}\n1. Guess a letter.\n2. Solve word");
                    
                   
                    input = ReadLine();
                  
                    switch (input)
                    {

                        case "1":
                            guessesLeft--;
                            WriteLine("Guess a letter: ");
                            input = ReadLine();
                            guessedChar = char.Parse(input);
                            for (int j = 0; j < answerAsCharArray.Length; j++)
                            {
                                if (guessedChar == answerAsCharArray[j])
                                {
                                    view[j] = guessedChar;
                                }

                            }
                            if (savedList.Contains(input) == true)
                            {
                               
                                guessesLeft++;
                            }
                            else
                            {
                                savedList.Add(input);
                               
                               
                            }
                            charList.Append(guessedChar);

                            WriteLine($" letter that have been {charList}");
                            break;

                        case "2":
                            input = ReadLine();
                            if (input == answer)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                WriteLine("You Win!");
                                guessesLeft = 0;
                                break;
                            }
                            else
                            {
                                guessesLeft--;
                               
                            }

                          
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine("Invalid choice, try again...");
                            Console.ResetColor();
                            ReadLine();
                            Clear();
                            break;
                    }
                }

               
            }
          
          ReadLine();
          WriteLine($" The Correct answer is {formatedString}!");
        }
       
    }
}