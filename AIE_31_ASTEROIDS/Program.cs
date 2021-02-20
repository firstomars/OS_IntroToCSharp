using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Raylib_cs;

namespace AIE_32_ASTEROIDS
{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "Asteroids";

        Player player;

        Bullet[] bullets = new Bullet[100];

        Asteroid[] asteroids = new Asteroid[100];

        int bigAsteroidDestroyScoreAmount = 50;
        int smallAsteroidDestroyScoreAmount = 30;
        int tinyAsteroidDestroyScoreAmount = 5;

        float asteroidSpawnCooldown = 4.0f;
        float asteroidSpawnCooldownReset = 4.0f;

        static void Main(string[] args)
        {
            Program p = new Program();

            p.RunGame(); //static main can access the non-static RunGame fn?
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60); // do on all projects

            LoadGame();
            
            while (!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            Asset.LoadAssets();
            player = new Player(
                this,
                new Vector2(windowWidth / 2, windowHeight / 2), 
                new Vector2(windowWidth / 18, windowWidth / 18));

            //Initialise all other assets here

            //initialise bullets null
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = null;
            }

        }

        void Update()
        {
            asteroidSpawnCooldown -= Raylib.GetFrameTime(); // function that can be used to influence time
            if(asteroidSpawnCooldown < 0.0f)
            {
                SpawnNewAsteroid();
                asteroidSpawnCooldown = asteroidSpawnCooldownReset;
            }
            
            player.Update();
            
            //check bullet / asteroid collission
            foreach (var bullet in bullets)
            {
                foreach(var asteroid in asteroids)
                {
                    DoBulletAsteroidCollision(bullet, asteroid);
                }
            }

            player.playerAsteroidCollision = false;
            
            foreach (var asteroid in asteroids)
            {
                if(asteroid != null)
                {
                    asteroid.asteroidCollisionPlayer = false;
                }

                DoPlayerAsteroidCollision(player, asteroid);
            }
            
            //update all bullets
            for (int i = 0; i < bullets.Length; i++)
            {
                if(bullets[i] != null)
                {
                    bullets[i].Update(); //explain this line
                }
            }

            for (int i = 0; i <asteroids.Length; i++)
            {
                if(asteroids[i] != null)
                {
                    asteroids[i].Update();
                }
                
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) // && Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_CONTROL)
            {
                SerialisePlayerDetails(player, "./savefile/playersave.txt");
                SerialiseAsteroidDetails(asteroids, "./savefile/asteroidsave.txt");
            }

            if(Raylib.IsKeyPressed(KeyboardKey.KEY_L)) // add control
            {
                Console.WriteLine($"Current player position: {player.pos}");
                DeserialiseLoadPlayerDetails(player, "./savefile/playersave.txt");
                //DeserialiseLoadAsteroidDetails("./savefile/asteroidsave.txt");
            }
        }
        
        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BEIGE);

            //draw all bullets
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i] != null)
                {
                    bullets[i].Draw(); //explain this line
                }
            }

            player.Draw();

            //draw all asteroids
            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Draw();
                }
            }

            Raylib.EndDrawing();
        }

        public void SpawnBullet(Vector2 pos, Vector2 dir)
        {
            Bullet bullet = new Bullet(this, pos, dir);

            for (int i = 0; i < bullets.Length; i++)
            {
                
                if (bullets[i] == null)
                {
                    bullets[i] = bullet; //why do we start with bullets being null? why assign it?
                    break;
                }
            }
        }

        public void SpawnAsteroid(Vector2 pos, Vector2 dir, float radius)
        {
            Asteroid asteroid = new Asteroid(this, pos, dir, radius);
            asteroid.radius = radius;

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] == null)
                {
                    asteroids[i] = asteroid;
                    break;
                }
            }

        }
        void SpawnNewAsteroid()
        {
            Random rand = new Random();
            int side = rand.Next(0, 4); //4 means it goes up to three, does not include 4.

            float rot = (float)rand.NextDouble() * MathF.PI * 2.0f;
            Vector2 dir = new Vector2(MathF.Cos(rot), MathF.Sin(rot));

            float radius = 40.0f;

            //left spawn
            if(side == 0)
            {
                SpawnAsteroid(new Vector2(0, rand.Next(0,windowHeight)), dir, radius);
            }

            //top wall
            if (side == 1)
            {
                SpawnAsteroid(new Vector2(rand.Next(0, windowWidth), 0), dir, radius);
            }

            // right wall
            if (side == 2)
            {
                SpawnAsteroid(new Vector2(windowWidth, rand.Next(0, windowHeight)), dir, radius);
            }

            // bottom wall
            if (side == 3)
            {
                SpawnAsteroid(new Vector2(rand.Next(0, windowWidth), windowHeight), dir, radius);
            }
        }

        void SerialisePlayerDetails(Player player, String filename)
        {
            //create folder
            FileInfo fileInfo = new FileInfo(filename);
            string directory = fileInfo.Directory.FullName;
            Directory.CreateDirectory(directory);
            Console.WriteLine("Save folder created.");

            //use streamwriter to write player.pos, player.dir, score
            using (StreamWriter sw = File.CreateText(filename))
            {
                Console.WriteLine("Save file created.");
                sw.WriteLine($"Player position is {player.pos}");
                sw.WriteLine($"Player direction is {player.dir}");
                sw.WriteLine($"Player score is {player.currentScore}");
            }
        }

        void SerialiseAsteroidDetails(Asteroid[] asteroids, string filename)
        {
            //create folder
            FileInfo fileInfo = new FileInfo(filename);
            string directory = fileInfo.Directory.FullName;
            Directory.CreateDirectory(directory);

            //creating text files
            using(StreamWriter sw = File.CreateText(filename))
            {
                foreach(var a in asteroids)
                {
                    if (a != null)
                    {
                        sw.Write($"{a.ID} ");
                        sw.Write($"{a.pos.X} ");
                        sw.Write($"{a.pos.Y} ");
                        sw.Write($"{a.dir.X} ");
                        sw.Write($"{a.dir.Y} ");
                        sw.Write($"{a.radius} ");
                        sw.WriteLine("");
                    }
                }
            }
        }

        void DeserialiseLoadPlayerDetails(Player player, string filename)
        {
            //using stream read from file
            using (StreamReader sr = File.OpenText(filename))
            {
                //Get player position
                string playerPosLine;

                //translating read player.pos into X and Y coords
                if ((playerPosLine = sr.ReadLine()) != null)
                {
                    string[] playerPosWords = playerPosLine.Split(" ");
                    string rawValX = playerPosWords[3].Trim('<', ',');
                    string rawValY = playerPosWords[4].Remove(playerPosWords[4].Length - 1, 1);

                    player.pos.X = float.Parse(rawValX);
                    player.pos.Y = float.Parse(rawValY);

                    Console.WriteLine($"New player position: {player.pos}");
                }
            }
        }

        //void DeserialiseLoadAsteroidDetails(string filename)
        //{

        //    //use streamreader to read text)
        //    using (StreamReader sr = File.OpenText(filename))
        //    {
        //        //List<string[]> savedAsteroidDetails = new List<string[]>();

        //        //create string to save text

        //        string line;

        //        //read text 
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string[] aDetails = line.Split(" ");

        //            // identify X pos, Y pos
        //            float posValX = float.Parse(aDetails[1]);
        //            float posValY = float.Parse(aDetails[2]);
                    
        //            // identify direction
        //            float dirValX = float.Parse(aDetails[3]);
        //            float dirValY = float.Parse(aDetails[4]);

        //            // identify radius
        //            float valRadius = float.Parse(aDetails[5]);
        //        }
        //    }
        //}



        void DoPlayerAsteroidCollision(Player player, Asteroid asteroid)
        {
            if (asteroid == null)
            {
                return;
            }

            if (asteroid.radius > 5)
            {
                float distance = (player.pos - asteroid.pos).Length();

                if (distance < asteroid.radius + (player.size.X * 0.5f))
                {
                    player.playerAsteroidCollision = true;
                    asteroid.asteroidCollisionPlayer = true;
                    
                    //Console.WriteLine("Player has collided with asteroid.");
                }
            }
        }

        void DoBulletAsteroidCollision(Bullet bullet, Asteroid asteroid)
        {
            if (bullet == null || asteroid == null)
            {
                return;
            }

            float distance = (bullet.pos - asteroid.pos).Length();

            if (distance < asteroid.radius)
            {
                //find bullet in array, and find asteroid in array

                SpawnAsteroid(asteroid.pos, asteroid.dir, asteroid.radius/2);
                SpawnAsteroid(asteroid.pos, - asteroid.dir, asteroid.radius/2);


                for (int i = 0; i < bullets.Length; i++)
                {
                    if (bullets[i] == bullet)
                    {
                        bullets[i] = null;
                        break;
                    }
                }

                for (int i = 0; i < asteroids.Length; i++)
                {
                    if (asteroids[i] == asteroid)
                    {
                        asteroids[i] = null;

                        if (asteroid.radius >= 15)
                        {
                            player.CalculateScore(bigAsteroidDestroyScoreAmount);
                        }
                        else if (asteroid.radius < 15 && asteroid.radius > 5)
                        {
                            player.CalculateScore(smallAsteroidDestroyScoreAmount);
                        }

                        else
                        {
                            player.CalculateScore(tinyAsteroidDestroyScoreAmount);
                        }
                        
                        break;
                    }
                }
            }
        }
    }


}
