using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Game
    {
        public int NrWrongGuesses { get; set; } = 0;

        public int MaxWrongGuesses { get; private set; } = 15;

        public List<char> GuessedLetters { get; private set; } = new List<char>();

        public Word Word { get; set; } = new Word();

        public HangmanUI Ui { get; set; } = new HangmanUI();

        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Ui.ShowWelcomeMessage();

                Ui.DrawHangman();

                Ui.ShowMaskedWord();

                Ui.ShowGuessedLetters();

                Ui.ShowBorderLine();

                char letter = Ui.AskForGuess();

                MakeGuess(letter);


                if (IsWordGuessed())
                {
                    Ui.ShowWinMessage();
                    isRunning = false;
                }

                else if (IsGameOver())
                {
                    Ui.ShowLooseMessage();
                    isRunning = false;
                }
            }
        }

        public bool IsGameOver()
        {
            if (NrWrongGuesses<MaxWrongGuesses)
            {
                return false;
            }

            return true;
        }

        public bool IsWordGuessed()
        {
            var lettersInSecretWord = new HashSet<char>(Word.SecretWord);

            return Word.CorrectGuesses.IsSubsetOf(lettersInSecretWord);
            
        }

        public void MakeGuess(char letter)
        {
            GuessedLetters.Add(letter);

            bool isLetterCorrect = Word.CheckGuess(letter);

            if (!isLetterCorrect)
            {
                NrWrongGuesses++;
                Console.WriteLine("Not correct!");               
            }

            else
            {
                Console.WriteLine("Yes, good guess!");
            }

            Thread.Sleep(10000);
        }
               
        public string GetMaskedWord()
        {
            return Word.MakeMaskedWord();
        }              
    }
}
