using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_55_GameStates
{
    class GameScreen : GameState
    {

        int spaceCount = 0;
        float countdownTimer = 3.0f;
        
        public GameScreen(Program p) : base(p)
        {

        }
        
        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                spaceCount += 1;
            }

            countdownTimer -= Raylib.GetFrameTime();

            if (countdownTimer < 0)
            {
                program.ChangeGameState(new GameOverScreen(program));
            }

        }

        public override void Draw()
        {
            Raylib.DrawText("Game Screen", 10, program.windowHeight - 50, 20, Color.BLACK);
            Raylib.DrawText(spaceCount.ToString(), program.windowWidth / 2, program.windowHeight / 2, 30, Color.BLUE);
        }
    }
}
