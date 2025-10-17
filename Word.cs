using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    //Om tid och motiverad - hantera tvådelade ord
    internal class Word
    {
        //AI suggested private set to stop SecretWord to be changed except for when a word object is created. 
        public string SecretWord { get; private set; } 

        //AI suggested HashSet to save letters of correct guesses. 
        public HashSet<char> CorrectGuesses { get; private set; } = new HashSet<char>();

        private Random RandomNr { get; set; } = new Random();

        public List<string> Words { get; set; } = new List<string>()
        {
            "polymorphism",
            "inheritance",
            "encapsulation",
            "abstraction",
            "struct",
            "field",
            "property",
            "method",
            "class",
            "interface",
            "stack",
            "heap",
            "generic",
            "attribute",
            "override",
            "virtual",
            "overload",
            "debugg",
            "instance",
            "object",
            "dynamic",
            //"type conversion",
            "repository",
            "pull request",
            "merge conflict",
            "branch",
            "constructor",
            "destructor",
            "configurate",
            "execute",
            "enum"

        };

        //Constructor
        //AI suggested using constructor to set SecretWords.
        public Word()
        {
            SecretWord = GenerateSecretWord();
            //DEBUGG
            Console.WriteLine("dEBUGG: New Word created");
        }

        public bool CheckGuess (char letter)
        {
            if (SecretWord.Contains(letter))
            {
                CorrectGuesses.Add(letter);
                return true;
            }

            return false;
        }

        //AI suggested this code after I asked questions about other suggestions...
        public string MakeMaskedWord()
        {
            var chars = SecretWord
                .Select(c => CorrectGuesses.Contains(c) ? c : '_')
                .ToArray();
            
            return string.Join(" ", chars);
        }

        public string GenerateSecretWord()
        {
            int randomIndex = RandomNr.Next(Words.Count);
            return Words[randomIndex];
            
        }

    }
}
