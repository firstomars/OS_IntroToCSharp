using System;
using System.Numerics;
using Raylib_cs;

namespace AIE_33_BLOCKBREAKER
{
    class Program
    {
        //classes
        Ball ball;
        Paddle paddle;

        //refs
        public int windowHeight = 450;
        public int windowWidth = 800;
        

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Block Breaker");
            Raylib.SetTargetFPS(60);

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
            ball = new Ball();
            ball.ballPos.X = windowWidth / 2;
            ball.ballPos.Y = windowHeight / 2;
            ball.ballDir.X = -0.707f;
            ball.ballDir.Y = -0.207f;

            paddle = new Paddle();
            paddle.paddlePos.X = windowWidth / 2;
            paddle.paddlePos.Y = windowHeight -5;

            paddle.leftKey = KeyboardKey.KEY_LEFT;
            paddle.rightKey = KeyboardKey.KEY_RIGHT;
        }

        void Update()
        {
            UpdateBall(ball);
            UpdatePaddle(paddle);
            CreateScreenWalls();
            BallCollidePaddle(ball, paddle);
        }

        private void CreateScreenWalls()
        {
            if (ball.ballPos.X < 0)
            {
                ball.ballDir.X = -ball.ballDir.X;
            }

            if (ball.ballPos.X > windowWidth)
            {
                ball.ballDir.X = -ball.ballDir.X;
            }

            if (ball.ballPos.Y < 0)
            {
                ball.ballDir.Y = -ball.ballDir.Y;
            }

            if (ball.ballPos.Y > windowHeight)
            {
                ball.ballDir.Y = -ball.ballDir.Y;
            }
        }

        void UpdateBall(Ball b)
        {
            b.ballPos += b.ballDir * b.ballSpeed;
        }

        void UpdatePaddle(Paddle p)
        {
            if(Raylib.IsKeyDown(p.leftKey))
            {
                paddle.paddlePos -= new Vector2(p.paddleSpeed, 0);
            }

            if (Raylib.IsKeyDown(p.rightKey))
            {
                paddle.paddlePos += new Vector2(p.paddleSpeed, 0);
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);
            DrawBall(ball);
            DrawPaddle(paddle);

            //Enter other draw functions here

            Raylib.EndDrawing();
        }

        void DrawBall(Ball b)
        {
            Raylib.DrawCircle((int)b.ballPos.X, (int)b.ballPos.Y, b.ballRadius, Color.BLACK); 
        }

        void DrawPaddle(Paddle p)
        {
            Raylib.DrawRectanglePro(new Rectangle(p.paddlePos.X, p.paddlePos.Y, p.paddleSize.X, p.paddleSize.Y), p.paddleSize / 2, 0.0f, Color.BLACK);
        }

        void BallCollidePaddle(Ball b, Paddle p)
        {
            // paddleTop
            //paddleLeft
            //paddleRight

            float paddleTop = p.paddlePos.Y - (p.paddleSize.Y / 2);
            float paddleLeft = p.paddlePos.X - (p.paddleSize.X / 2);
            float paddleRight = p.paddlePos.X + (p.paddleSize.X / 2);

            if (b.ballPos.Y > paddleTop && b.ballPos.X < paddleRight && b.ballPos.X > paddleLeft)
            {
                b.ballDir.Y = -b.ballDir.Y;
                Console.WriteLine("ball collided with paddle");
            }

            // If b.ballPos.X < paddleRight && b.ballPos.X > paddleLeft && b.ballPos.Y > paddleTop
        }

    }
}
