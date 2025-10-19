using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    // NOTE TO SELF: If time, add feature to quit game by enter "quit/exit".
    internal class HangmanUI
    {
        public Game Game { get; set; } = new Game();

        public HangmanDrawing hangman { get; set; } = new HangmanDrawing();

        public void Start()
        {
            bool isRunning = true;            

            while (isRunning)
            {
                Console.Clear();
                ShowWelcomeMessage();

                ShowGuessedLetters();

                ShowSkyLine();

                DrawHangman();

                ShowMaskedWord();

                if (Game.IsWordGuessed())
                {
                    ShowWinMessage();
                    isRunning = false;
                }

                else if (Game.IsGameOver())
                {
                    ShowLooseMessage();
                    isRunning = false;
                }

                else if (Game.NrWrongGuesses < Game.MaxWrongGuesses || (!Game.IsWordGuessed()))
                {
                    AskForGuess();                                       
                    
                    Thread.Sleep(1500);
                }        
            }
            Console.ReadLine();
        }

        public void ShowWelcomeMessage()
        {
            Console.Write("\nSave the Hangman!");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" (*_*)\n");
            Console.ResetColor();            
        } 

        //AI helped me how to think about and use the frames
        public void DrawHangman()
        {
            Console.WriteLine();
            string[] currentFrame;

            if (Game.IsWordGuessed())
            {
                currentFrame = hangman.Frames[11];
            }
            else
            {
                currentFrame = hangman.Frames[Game.NrWrongGuesses];
            } 

            foreach (var line in currentFrame)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        public void ShowMaskedWord()
        {
            Console.WriteLine();
            Console.WriteLine(Game.GetMaskedWord());
            Console.WriteLine();
        }

        public void ShowGuessedLetters()
        {
            string guesses = string.Join(", ", Game.GuessedLetters);

            if (Game.GuessedLetters.Count.Equals(0))
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\nPrevious guesses: {guesses}");
                Console.ResetColor();
            }
                
        }

        public void ShowSkyLine()
        {            
            Console.WriteLine("~~~~~~~~~~~~~~~");
        }

        public void AskForGuess()
        {
            char letter = ReadInput("\nGuess a letter: ");

            //Marker from ReadInput of not valid input
            if (letter=='*')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nPlease guess one letter. Try again.");
                Console.ResetColor();
                return;
            }

            //Guess should be a new letter
            else if (IsNewLetter(letter))
            {
                string feedback = Game.MakeGuess(letter);
                Console.Write(feedback);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\nYou have already guessed \"{letter}\". Try again!");
                Console.ResetColor();
            }
        }

        public char ReadInput(string prompt)
        {     
            Console.Write(prompt);

            string userInput = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (userInput is { Length: 1} && char.IsLetter(userInput[0]))
            {
                return userInput[0];                  
            }

            //Mark for not valid input
            return '*';            
        }

        public bool IsNewLetter(char letter)
        {
            if (Game.GuessedLetters.Contains(letter))
            {
                return false;
            }

            return true;
        }

        public void ShowLooseMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\nOh no, you loose!");
            Console.ResetColor();
        }

        public void ShowWinMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nYou win! Phew, you saved the man.");
            Console.ResetColor();
        }
    }
}
