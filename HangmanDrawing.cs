using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class HangmanDrawing
    {
        // Frames for gallow and hangman
        // Each string[] is a frame, each string is one console row
        public List<string[]> Frames { get; set; } = new List<string[]>()
        {
            // Frame 0 – ground
            new string[]
            {
                "        ",
                "        ",
                "        ",
                "        ",
                "        ",
                "        ",
                "        ",
                "==============="
            },

            // Frame 1 – pole
            new string[]
            {
                "        ",
                "   |   ",
                "   |   ",
                "   |   ",
                "   |   ",
                "   |   ",
                "   |   ",
                "==============="
            },

            // Frame 2 – pole + beam
            new string[]
            {
                "    _____",
                "   |/    ",
                "   |     ",
                "   |     ",
                "   |     ",
                "   |     ",
                "   |     ",
                "=============="
            },

            // Frame 3 – pole + beam + rope
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |     ",
                "   |     ",
                "   |     ",
                "   |     ",
                "   |     ",
                "=============="
            },

            // Frame 4 – head
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo)",
                "   |     ",
                "   |     ",
                "   |     ",
                "   |     ",
                "=============="
            },

            // Frame 5 – body
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo)",
                "   |     |",
                "   |     ",
                "   |     ",
                "   |     ",
                "=============="
            },

            // Frame 6 – arms
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo)",
                "   |    \\|/",
                "   |     ",
                "   |     ",
                "   |     ",
                "=============="
            },

            // Frame 7 – full body + arms 
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo)",
                "   |    \\|/",
                "   |     |",
                "   |      ",
                "   |      ",
                "=============="
            },

             // Frame 8 – full body + arms + one leg
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo)",
                "   |    \\|/",
                "   |     |",
                "   |    / ",
                "   |      ",
                "=============="
            },

            // Frame 9 – complete man
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (oo) \"Help, please!\"",
                "   |    \\|/",
                "   |     | ",
                "   |    / \\",
                "   |        ",
                "=============="
            },

            // Frame 10 – dead man
            new string[]
            {
                "    _____,",
                "   |/    |",
                "   |    (xx) \"Ugh!\"",
                "   |    /|\\",
                "   |     |",
                "   |    | |",
                "   |     ",
                "=============="
            },

            // Frame 11 - Happy free man
            new string[]
            {
                "    _____ ",
                "   |/     ",
                "   |      ",
                "   |     (¤¤) \"Yay!\"",
                "   |     \\|/ ",
                "   |      |",
                "   |     / \\   ",
                "=============="
            }
        };
    }
}
