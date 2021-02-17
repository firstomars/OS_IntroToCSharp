using System;
using System.Collections.Generic;
using System.IO;

namespace AIE_44_FileIOhighscores_crack2
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
            SerialiseScores("./scores/highscores.txt", scores);

            // clear the scores
            scores = new List<ScoreEntry>();

            // read the scores
            DeSerialiseScoreos("./scores/highscores.txt", scores);

            // print scores
            foreach (var entry in scores)
            {
                Console.WriteLine($"{entry.name}:{entry.score}");
            }

        }

        static void SerialiseScores(string filename, List<ScoreEntry> scores)
        {
            // TODO: write code to write the scores to file


            //create folder / directory
            var fileInfo = new FileInfo(filename);
            string dir = fileInfo.Directory.FullName;
            Directory.CreateDirectory(dir);

            // using stream / create folder
            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach(var s in scores)
                {
                    //using stream / write text
                    sw.WriteLine($"score: {s.name}, {s.score}");
                }
            }
        }

        static void DeSerialiseScoreos(string filename, List<ScoreEntry> scores)
        {
            //using streamreader / read each line
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    string[] words = line.Split(" ");

                    string rawName = words[1];
                    string name = rawName.Remove(rawName.Length-1, 1);
                    int score = int.Parse(words[2]);

                    ScoreEntry scoreEntry = new ScoreEntry(name, score);
                    scores.Add(scoreEntry);
                }
            }

        }
    }
}
