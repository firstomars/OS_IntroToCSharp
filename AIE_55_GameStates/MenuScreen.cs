using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_55_GameStates
{
    class MenuScreen : GameState
    {
        public MenuScreen(Program p) : base(p)
        {

        }
        
        public override void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                program.ChangeGameState(new GameScreen(program));
            }
        }

        public override void Draw()
        {
            Raylib.DrawText("Menu Screen", 10, program.windowHeight / 2, 20, Color.BLACK);
        }

    }
}
