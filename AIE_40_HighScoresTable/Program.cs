using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_40_HighScoresTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ScoreEntry> scores = new List<ScoreEntry>()
            {
                new ScoreEntry("bob", 12),
                new ScoreEntry("fred", 20),
                new ScoreEntry("ted", 6),
                new ScoreEntry("tom", 42),
                new ScoreEntry("harry", 9),
            };

            // save the scores
            SerialiseScores("highscores.txt", scores);

            // clear the scores
            scores = new List<ScoreEntry>();

            // read the scores
            DeSerialiseScoreos("highscores.txt", scores);

            // print scores
            foreach (var entry in scores)
            {
                Console.WriteLine($"{entry.name}:{entry.score}");
            }

        }

        static void SerialiseScores(string filename, List<ScoreEntry> scores)
        {
            // TODO: write code to write the scores to file

            //Create file
            var fileInfo = new FileInfo(filename);
            string dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);


            //Use streamwrite to create text on file
            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach(var se in scores)
                {
                    sw.WriteLine($"{se.name} {se.score}");
                }
            }
        }

        static void DeSerialiseScoreos(string filename, List<ScoreEntry> scores)
        {
            // TODO: write code to read the scores from file

            //streamreader to read text
            //write it to console

            string s;

            using (StreamReader sr = File.OpenText(filename))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    string[] words = s.Split(" ");
                    var name = words[0];
                    var score = int.Parse(words[1]);

                    ScoreEntry entry = new ScoreEntry(name, score);
                    scores.Add(entry);

                }
            }
        }
    }
}
