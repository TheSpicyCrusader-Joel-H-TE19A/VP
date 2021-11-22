using System;
using System.Numerics;
using Raylib_cs;

namespace VPN
{
    public class Player
    {
        public int playerHP;
        public int playerDMG;

        public int playerSpeed;

        public Vector2 movement = new Vector2();

        public Rectangle PlayerRec = new Rectangle();

        Texture2D PlayerUp = Raylib.LoadTexture("PlayerSquareUp.png");
        Texture2D PlayerDown = Raylib.LoadTexture("PlayerSquareDown.png");
        Texture2D PlayerLeft = Raylib.LoadTexture("PlayerSquareLeft.png");
        Texture2D PlayerRight = Raylib.LoadTexture("PlayerSquareRight.png");

        public void Update()
        {
            PlayerRec.x += movement.X;
            PlayerRec.y += movement.Y;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {

            }
        }

        public void Draw()
        {
            if (movement.X > 0)
            {
                Raylib.DrawTexture(PlayerRight, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            }
            else if (movement.X < 0)
            {
                Raylib.DrawTexture(PlayerLeft, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            }
            if (movement.Y > 0)
            {
                Raylib.DrawTexture(PlayerDown, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            }
            else if (movement.X < 0)
            {
                Raylib.DrawTexture(PlayerUp, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            }
        }
    }
}