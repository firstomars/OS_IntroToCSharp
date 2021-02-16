using System;
using System.Collections.Generic;
using System.Text;

namespace AIE_40_HighScoresTable
{
    class ScoreEntry
    {
        public string name;
        public int score;
        
        public ScoreEntry(string name, int score) // why do we need to define variable type here as well as above?
        {
            this.name = name;
            this.score = score;
        }
    }
}
