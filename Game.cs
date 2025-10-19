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

        public int MaxWrongGuesses { get; private set; } = 10;

        public List<char> GuessedLetters { get; private set; } = new List<char>();

        public Word Word { get; set; } = new Word();              

        public bool IsGameOver()
        {
            if (NrWrongGuesses<MaxWrongGuesses)
            {
                return false;
            }

            return true;
        }

        // Checked in documentation to find the method "IsSuperSet", asked AI to confirm that I had understood it.
        public bool IsWordGuessed()
        {
            var lettersInSecretWord = new HashSet<char>(Word.SecretWord);

            return Word.CorrectGuesses.IsSupersetOf(lettersInSecretWord);
            
        }

        public string MakeGuess(char letter)
        {
            GuessedLetters.Add(letter);

            bool isLetterCorrect = Word.CheckGuess(letter);

            if (!isLetterCorrect)
            {
                NrWrongGuesses++;
                return "\nNot correct!";               
            }

            else
            {
                return "\nYes, good guess!";
            }            
        }
               
        public string GetMaskedWord()
        {
            return Word.MakeMaskedWord();
        }              
    }
}
