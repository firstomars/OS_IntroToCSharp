using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace AIE_32_ASTEROIDS
{
    class Asset
    {
        public static Texture2D planeTexture;

        public static void LoadAssets()
        {
            planeTexture = Raylib.LoadTexture("./assets/plane3.png");
        }
    }
}
