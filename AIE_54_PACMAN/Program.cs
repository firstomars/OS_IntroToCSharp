using System;
using Raylib_cs;

namespace AIE_54_PACMAN

//Up to vid 3 - 20.56

/*
PART 1
create project
setup basic game states
setup GameLevelState"
Define 2D array for TileMap
Draw TileMap (walls and pacdots)
Debug Draw TileMap

PART 2
Create player class
Draw player
Move player on key press
Debug draw player - highlight which tile the player is on
Snap / lock to grid
Speed up
Prevent movement from going through walls
Eat pacdots
Reset level when all pacdots are eaten

PART 3
Create Ghost class - copy of player class
Spawn ghosts when level is created
Move in random direction at intersections
Detect collissions with Player
- pacman reset
- ghost resets
- lives decrease
*/

{
    class Program
    {
        public int windowWidth = 800;
        public int windowHeight = 450;
        public string windowTitle = "PacMan";

        IGameState gameState;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.RunGame();
        }

        void RunGame()
        {
            Raylib.InitWindow(windowWidth, windowHeight, windowTitle);
            Raylib.SetTargetFPS(60);

            LoadGame();

            while (!Raylib.WindowShouldClose())
            {
                Draw();
                Update();
                
            }

            Raylib.CloseWindow();
        }

        void LoadGame()
        {
            gameState = new GameLevelScreen(this);
        }

        void Update()
        {
            if (gameState != null)
            {
                gameState.Update();
            }
        }

        void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            if (gameState != null)
            {
                gameState.Draw();
            }

            Raylib.EndDrawing();
            Raylib.DrawFPS(10, windowHeight - 30);
        }
    }
}
