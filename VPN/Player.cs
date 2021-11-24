using System;
using System.Numerics;
using Raylib_cs;

namespace VPN
{
    public class Player
    {
        public int playerHP;
        public int playerDMG;

        public int playerSpeed = 2;

        public Vector2 movement = new Vector2();

        public Rectangle PlayerRec = new Rectangle(Raylib.GetScreenWidth() / 2 - 15, Raylib.GetScreenHeight() / 2 - 45, 30, 90);

        Texture2D PlayerRight = Raylib.LoadTexture("PlayerSquareRight.png");
        Texture2D PlayerLeft = Raylib.LoadTexture("PlayerSquareLeft.png");
        Texture2D PlayerDown = Raylib.LoadTexture("PlayerSquareDown.png");

        Texture2D PlayerUp = Raylib.LoadTexture("PlayerSquareUp.png");

        Texture2D currentState;

        public Player()
        {
            currentState = PlayerDown; //ändra till dile sen
        }
        public void Update()
        {
            movement.X = 0;
            movement.Y = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && PlayerRec.x < Raylib.GetScreenWidth() - 347)
            {
                movement.X = playerSpeed;
                currentState = PlayerRight;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && PlayerRec.x > 0)
            {
                movement.X = -playerSpeed;
                currentState = PlayerLeft;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && PlayerRec.y < Raylib.GetScreenHeight() - 347)
            {
                movement.Y = playerSpeed;
                currentState = PlayerDown;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && PlayerRec.y > 0)
            {
                movement.Y = -playerSpeed;
                currentState = PlayerUp;
            }


            PlayerRec.x += movement.X;
            PlayerRec.y += movement.Y;
        }

        public void Draw()
        {

            Raylib.DrawTexture(currentState, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);

            // if (movement.X == playerSpeed)
            // {
            //     Raylib.DrawTexture(PlayerRight, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            // }
            // else if (movement.X == -playerSpeed)
            // {
            //     Raylib.DrawTexture(PlayerLeft, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            // }
            // if (movement.Y == playerSpeed)
            // {
            //     Raylib.DrawTexture(PlayerDown, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            // }
            // else if (movement.Y == -playerSpeed)
            // {
            //     Raylib.DrawTexture(PlayerUp, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
            // }
        }
    }
}