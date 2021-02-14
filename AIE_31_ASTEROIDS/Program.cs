using System;
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
