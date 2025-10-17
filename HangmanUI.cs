using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanUI
    {
        public Game Game { get; set; } = new Game();
       
        public void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to Hangman! (x_x) ");
        } 

        public void DrawHangman()
        {
            Console.WriteLine();
            Console.WriteLine($"Number of wrong guesses: {Game.NrWrongGuesses}");
            Console.WriteLine();
        }

        public void ShowMaskedWord()
        {
            Console.WriteLine(Game.GetMaskedWord());
        }

        public void ShowGuessedLetters()
        {
            string guesses = string.Join(", ", Game.GuessedLetters);

            Console.WriteLine($"\nYour guesses: {guesses}");
        }

        public void ShowBorderLine()
        {
            Console.WriteLine("------------------------------");
        }

        public char AskForGuess()
        {
            char letter = ReadInput("Guess a letter: ");

            return letter;
        }

        public char ReadInput(string prompt)
        {     
            while (true)
            {

                Console.Write(prompt);

                string userInput = Console.ReadLine()?.Trim().ToLowerInvariant();

                //DEBUGG
                Console.WriteLine($"DEBUG: input is {userInput ?? "null"}");


                if (userInput is { Length: 1} && char.IsLetter(userInput[0]))
                {
                    return userInput[0];                  
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter only one letter. Try again.\n");
                Console.ResetColor();
            }
        }

        public void ShowLooseMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Oh no, you loose!");
            Console.ResetColor();
        }

        public void ShowWinMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You win! Phew, you saved the man.");
            Console.ResetColor();
        }
    }
}
