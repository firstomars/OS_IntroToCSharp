using System;
using Raylib_cs;
using System.Numerics;

namespace AIE_23_PONG
{

    class Ball
    {
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 5.0f;
        public float radius = 7.0f;

        public Color ballColor = new Color(255, 0, 255, 255);
    }

    class Paddle
    {
        public Vector2 paddlePos = new Vector2();
        public Vector2 paddleSize = new Vector2(10, 100);
        public float paddleSpeed = 10.0f;

        public KeyboardKey upKey;
        public KeyboardKey downKey;

        public int score = 0;
    }


    class Program
    {
        int windowWidth = 800;
        int windowHeight = 450;
        Ball ball1;
        Ball ball2;

        Paddle paddleLeft;

        Paddle paddleRight;

        static void Main(string[] args)
        {
            Program p = new Program(); // what does this do?
            p.RunProgram();
        }

        void RunProgram()
        {
            Raylib.InitWindow(windowWidth, windowHeight, "Pong");

            Raylib.SetTargetFPS(60); // set frames

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
            ball1 = new Ball();
            ResetBall(ball1);
            ball1.dir.X = 0.707f;
            ball1.dir.Y = 0.707f;

            ball2 = new Ball();
            ResetBall(ball2);
            ball2.dir.X = -0.707f;
            ball2.dir.Y = 0.707f;


            paddleLeft = new Paddle();
            //paddleLeft.paddlePos = new Vector2(0, windowHeight / 2);

            paddleLeft.paddlePos.X = 5;
            paddleLeft.paddlePos.Y = windowHeight / 2;
            paddleLeft.upKey = KeyboardKey.KEY_W;
            paddleLeft.downKey = KeyboardKey.KEY_S;

            paddleRight = new Paddle();

            paddleRight.paddlePos.X = windowWidth - 5;
            paddleRight.paddlePos.Y = windowHeight / 2;
            paddleRight.upKey = KeyboardKey.KEY_UP;
            paddleRight.downKey = KeyboardKey.KEY_DOWN;


        }

        void Update()
        {
            UpdateBall(ball1);
            UpdateBall(ball2);

            UpdatePaddle(paddleLeft);
            UpdatePaddle(paddleRight);

            DoesBallHitPaddle(ball1, paddleLeft);
            DoesBallHitPaddle(ball1, paddleRight);

            DoesBallHitPaddle(ball2, paddleLeft);
            DoesBallHitPaddle(ball2, paddleRight);

        }

        void UpdateBall(Ball b)
        {
            b.pos += b.dir * b.speed;

            //the below two lines do the same as above
            //ball.pos.X += ball.dir.X * ball.speed; 
            //ball.pos.Y += ball.dir.Y * ball.speed;

            if (b.pos.X < 0)
            {
                ResetBall(b);
                paddleRight.score += 1;
            }

            if (b.pos.X > windowWidth)
            {
                ResetBall(b);
                paddleLeft.score += 1;
            }


            if (b.pos.Y > windowHeight)     b.dir.Y = -b.dir.Y;

            if (b.pos.Y < 0)                b.dir.Y = -b.dir.Y;
        }

        void UpdatePaddle(Paddle p)
        {
            if (Raylib.IsKeyDown(p.upKey))
            {
                p.paddlePos -= new Vector2(0, p.paddleSpeed);
            }

            if (Raylib.IsKeyDown(p.downKey))
            {
                p.paddlePos += new Vector2(0, p.paddleSpeed);
            }
        }


        void Draw() 
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DARKGREEN);

            DrawBall(ball1);
            DrawBall(ball2);

            DrawPaddle(paddleLeft);
            DrawPaddle(paddleRight);

            //Raylib.DrawText(paddleLeft.score.ToString(), (int)paddleLeft.paddlePos.X + 10, 10, 20, Color.RAYWHITE);
            //Raylib.DrawText(paddleRight.score.ToString(), (int)paddleRight.paddlePos.X - 20, 10, 20, Color.RAYWHITE);

            Raylib.DrawText(paddleLeft.score.ToString(), windowWidth / 2 - 20, 10, 20, Color.RAYWHITE);
            Raylib.DrawText(paddleRight.score.ToString(), windowWidth / 2 + 20, 10, 20, Color.RAYWHITE);


            //Raylib.DrawFPS(10, 10);
            Raylib.EndDrawing();
        }
        void DrawBall(Ball b)
        {
            Raylib.DrawCircle((int)b.pos.X, (int)b.pos.Y, b.radius, b.ballColor);
        }

        void DrawPaddle(Paddle p)
        {
            //Raylib.DrawRectangle((int)p.paddlePos.X, (int)p.paddlePos.Y, (int)p.paddleSize.X, (int)p.paddleSize.Y, Color.RAYWHITE);
            Raylib.DrawRectanglePro
                (new Rectangle
                (p.paddlePos.X, p.paddlePos.Y, 
                p.paddleSize.X, p.paddleSize.Y), 
                p.paddleSize / 2, // this puts the origin source of the rect. in the centre, rather than top right
                0.0f, // rotation
                Color.RAYWHITE);

            //Raylib.DrawText(p.score.ToString(), ((int)p.paddlePos.X - 10), 10, 20, Color.RAYWHITE);

        }

        void DoesBallHitPaddle(Ball b, Paddle p)
        {
            //float distance = (b.pos - p.paddlePos).Length(); - used in asteroids, not applicable here?

            float paddleTop = p.paddlePos.Y - (p.paddleSize.Y / 2);
            float paddleBottom = p.paddlePos.Y + (p.paddleSize.Y/2);
            float paddleRightSide = p.paddlePos.X + (p.paddleSize.X / 2);
            float paddleLeftSide = p.paddlePos.X - (p.paddleSize.X / 2);

            if (b.pos.Y > paddleTop && b.pos.Y < paddleBottom && b.pos.X < paddleRightSide && b.pos.X > paddleLeftSide)
            {
                Console.WriteLine("ball has hit paddle");
                b.dir.X = -b.dir.X;
             
            }


            //if (distance < p.paddleSize.X)
            //{
                
            //    b.dir.X = -b.dir.X;
            //}
        }

        void ResetBall(Ball b)
        {
            b.pos = new Vector2(windowWidth / 2, windowHeight / 2);


            // two states


            //Vector2 resetBallPos = new Vector2(windowWidth / 2, windowHeight / 2);
            //float ballCountdown = 1.0f;
            //float resetCountdown = 1.0f;

            
            //if (b.pos.X > windowWidth)
            //{
            //    b.pos = resetBallPos;
            //    ball.dir.X = -0.707f;
            //    ball.dir.Y = -0.707f;

            //    //ball.dir.X = 0.0f;
            //    //ball.dir.Y = 0.0f;

            //    //ballCountdown -= Raylib.GetFrameTime(); 
            //this won't work because ResetBall() is not connected with the Update() method. So it doesn't have the ability to countdown frames.

            //    //Console.WriteLine(ballCountdown);

            //    //if (ballCountdown < 0.0f)
            //    //{
            //    //    ball.dir.X = -0.707f;
            //    //    ball.dir.Y = -0.707f;
            //    //}
            //}

            //if (b.pos.X < 0) 
            //{
            //    b.pos = resetBallPos; 
            //    ball.dir.X = 0.707f;
            //    ball.dir.Y = 0.707f;
            //}

            //ballCountdown = resetCountdown;

        }

        //void DoPlayerAsteroidCollision(Player player, Asteroid asteroid)
        //{
        //    if (asteroid == null)
        //    {
        //        return;
        //    }

        //    if (asteroid.radius > 5)
        //    {
        //        float distance = (player.pos - asteroid.pos).Length();

        //        if (distance < asteroid.radius + (player.size.X * 0.5f))
        //        {
        //            player.playerAsteroidCollision = true;
        //            asteroid.asteroidCollisionPlayer = true;

        //            //Console.WriteLine("Player has collided with asteroid.");
        //        }


        //    }


        //}

    }

}


// logic for countdown startingBallState

/*
class Ball
{
	enum BallState
	{
		Starting,
		Moving
	}
	
	
	public BallState state = Starting;
	public float startTimer = 1.0f;
	
}


class Program
{
	Ball ball;
	
	
	void Update()
	{
		UpdateBall(ball);
	}
	
	void Draw()
	{
	
	}
	
	void ResetBall(Ball b)
	{
		b.state = Ball.BallState.Starting;
		b.pos = new Vector2(windowWidth/2, windowHeight/2);
	}
	
	void UpdateBall(Ball b)
	{
		if(b.state == Ball.BallState.Starting)
			UpdateBallStartingState(b);
		else if(b.state == Ball.BallState.Moving)
			UpdateBallMovingState(b);
	}
	
	void UpdateBallStartingState(Ball b)
	{
		b.startTimer -= Raylib.GetFrameTime();
		if(b.startTimer < 0 )
		{
			b.StartTimer = 1.0f;
			b.state = Ball.BallState.Moving;
		}
	}
	
	void UpdateBallMovingState(Ball b)
	{
		b.pos += b.dir * b.speed;
		if(b.pos < 0) ResetBall(b);
		if(b.pos > windowWidth) ResetBall(b);
	}
}
 */
