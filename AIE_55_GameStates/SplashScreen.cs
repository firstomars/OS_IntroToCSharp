using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_55_GameStates
{
    class SplashScreen : GameState
    {
        //protected Program program;

        float cooldownTimer = 3.0f;
        //float resetTimer = 3.0f;

        public SplashScreen(Program p) : base(p)
        {
            
        }
        
        public override void Update()
        {
            //if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            //{
            //    program.ChangeGameState(this);
            //}

            cooldownTimer -= Raylib.GetFrameTime();
            if (cooldownTimer <= 0)
            {
                program.ChangeGameState(new MenuScreen(program));
                //cooldownTimer = resetTimer;
            }

        }

        public override void Draw()
        {
            Raylib.DrawText("SplashScreen", 10, 10, 20, Color.BLACK);
        }
    }
}
