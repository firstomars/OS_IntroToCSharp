using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;

namespace AIE_29_GameSettings_RL
{
    class Sprite
    {
        public Vector2 pos = new Vector2();
        public Vector2 dir = new Vector2();
        public float speed = 5.0f;
        public float radius = 10.0f;

        GameSettings GS = new GameSettings();

        public Sprite()
        {
            
        }

        public void Draw()
        {
            Raylib.DrawRectangle(GS.windowWidth / 2, GS.windowHeight / 2, 100, 200, Color.RAYWHITE);
        }


        //public Sprite(Texture2D texture, Vector size)
        //{
        //    this.texture = texture;

            
        //    //Raylib.DrawRectangle((int)pos.X, (int)pos.Y, 5, 5, Color.DARKBLUE);
        //}

        public void Update()
        {
            //move
        }

        public void Move(int rotation, Vector2 direction, int speed)
        {
            //enter function
        }
    }
}
