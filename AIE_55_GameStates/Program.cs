using System;
using System.Collections.Generic;
using Raylib_cs;

namespace AIE_55_GameStates
{
    class Program
    {
        public int windowWidth = 450;
        public int windowHeight = 800;
        public string windowTitle = "Game States";

        GameState currentGameState;

        public List<ScoreEntry> scores = new List<ScoreEntry>()
        {
            new ScoreEntry("Rob", 15),
            new ScoreEntry("Steve", 28),
            new ScoreEntry("Adam", 19),
            new ScoreEntry("Laila", 56),
            new ScoreEntry("Josie", 89),
        };

        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            LoadGame();

            while(!Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }
            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            //currentGameState = new SplashScreen(this);
            currentGameState = new GameOverScreen(this);
        }

        void Update()
        {
            if (currentGameState != null)
            {
                currentGameState.Update();
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            if (currentGameState != null)
            {
                currentGameState.Draw();
            }

            Raylib.DrawFPS(windowWidth - 70, 10);

            Raylib.EndDrawing();
        }

        public void ChangeGameState(GameState newGameState)
        {
            currentGameState = newGameState;
        }

    }
}
