using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Raylib_cs;

namespace AIE_32_ASTEROIDS
{
    class Player : GameObject
    {
        //Program program;
        //public Vector2 pos = new Vector2();

        public Vector2 size = new Vector2(64, 64);
        
        public float rotation = 0.0f;
        public float rotationSpeed = 5.0f;

        public float accelerationSpeed = 0.05f;
        public Vector2 velocity = new Vector2(0,0);

        public bool playerAsteroidCollision = false;
        Color hitColor = new Color(255, 100, 100, 255);
        Color currentColor = Color.WHITE;

        int currentScore = 0;
        string scoreString = "0";

        float bulletSpawnCooldown = 0.2f;
        float bulletSpawnCooldownReset = 0.2f;


        //float timerCountDownHit = 0.5f;
        //float timerCountDownHitReset = 0.5f;

        public Player(Program program, Vector2 pos, Vector2 size) : base(program, pos)
        {
            //this.program = program;
            //this.pos = pos;
            this.size = size;
        }

        public override void Update()
        {
            //ChangePlayerColourOnHit();

            Controls();

            //add velocity to position
            pos += velocity;

            //wrap player around the screen
            if (pos.X < 0) pos.X = program.windowWidth;
            if (pos.X > program.windowWidth) pos.X = 0;
            if (pos.Y < 0) pos.Y = program.windowHeight;
            if (pos.Y > program.windowHeight) pos.Y = 0;
        }

        private void Controls()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                rotation -= rotationSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                rotation += rotationSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                var dir = GetFacingDirection();
                velocity += dir * accelerationSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                var dir = GetFacingDirection();
                velocity -= dir * accelerationSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                bulletSpawnCooldown -= Raylib.GetFrameTime();

                if (bulletSpawnCooldown <= 0)
                {
                    program.SpawnBullet(pos, GetFacingDirection());
                    bulletSpawnCooldown = bulletSpawnCooldownReset;
                }
            }
        }

        public Vector2 GetFacingDirection()
        {
            return new Vector2(
              MathF.Cos((MathF.PI / 180) * rotation), 
              MathF.Sin((MathF.PI / 180) * rotation));
        }

        public override void Draw()
        {
            var texture = Asset.planeTexture;

            // (condition ? true_expression : false_expression);
            Color color = playerAsteroidCollision ? hitColor : currentColor;

            Raylib.DrawTexturePro(
                texture,
                new Rectangle(0, 0, texture.width, texture.height),
                new Rectangle(pos.X, pos.Y, size.X, size.Y),
                new Vector2(0.5f * size.X, 0.5f * size.Y),
                rotation,
                color);

            Raylib.DrawText(scoreString, (program.windowWidth / 25), (program.windowHeight/20), 20, Color.RAYWHITE);
        }

        public void CalculateScore(int addPoints)
        {
            currentScore += addPoints;
            Console.WriteLine(currentScore);

            scoreString = currentScore.ToString();


            //string sNumber = Console.ReadLine();
            //int number = int.Parse(sNumber);

        }

        //public void ResetColour()
        //{
        //    currentColor = normalColor;
        //}

        //public void OnCollision(Bullet asteroid)
        //{

        //}

        //public void OnCollision(Asteroid asteroid)
        //{
        //    playerAsteroidCollision = true;
        //    Console.WriteLine("collision = true");

        //    //timerCountDownHit -= Raylib.GetFrameTime();

        //    //if (timerCountDownHit < 0)
        //    //{
        //    //    playerAsteroidCollision = false;
        //    //    Console.WriteLine("collision = false");
        //    //    timerCountDownHit = timerCountDownHitReset;
        //    //}
        //}

        //private void ChangePlayerColourOnHit()
        //{
        //    if (playerAsteroidCollision == true)
        //    {
        //        currentColor = Test;

        //        timerCountDownHit -= Raylib.GetFrameTime();

        //        if (timerCountDownHit < 0)
        //        {
        //            playerAsteroidCollision = false;
        //            Console.WriteLine("collision = false");
        //            timerCountDownHit = timerCountDownHitReset;
        //        }
        //    }

        //    else
        //    {
        //        currentColor = normalColor;
        //    }
        //}
    }

}
