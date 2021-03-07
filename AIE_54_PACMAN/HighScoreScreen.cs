using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_54_PACMAN
{
    class HighScoreScreen : IGameState
    {
        public HighScoreScreen(Program p) : base(p)
        {

        }

        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                program.ChangeGameState(new GameLevelScreen(program));
            }
        }

        public override void Draw()
        {
            Raylib.DrawText("GAME OVER", (program.windowWidth / 2) - 200, 10, 50, Color.WHITE);
            Raylib.DrawText("High Scores", (program.windowWidth / 2) - 100, 100, 30, Color.WHITE);
            //print scores from text file below

            Raylib.DrawText("Press 'ENTER' to play again", (program.windowWidth / 2) - 100, program.windowHeight - 100, 30, Color.WHITE);
        }
    }
}
