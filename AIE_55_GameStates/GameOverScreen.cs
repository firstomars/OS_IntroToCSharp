using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_55_GameStates
{
    class GameOverScreen : GameState
    {
        public GameOverScreen(Program p) : base(p)
        {

        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            Raylib.DrawText("You died.", program.windowWidth - 100, program.windowHeight - 50, 20, Color.RED);

            Raylib.DrawText(program.scores[0].name, 10, 10, 10, Color.BLACK);
            Raylib.DrawText(program.scores[0].score.ToString(), 150, 10, 10, Color.BLACK);



            //foreach(var s in program.scores)
            //{
            //    Raylib.DrawText(s.ToString(), program.windowWidth / 2, program.windowHeight, 20, Color.GREEN);
            //    //Raylib.DrawText(" ")
            //}
        }
    }
}
