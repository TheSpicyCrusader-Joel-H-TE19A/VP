using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace VPN
{
    public class Player
    {
        public int playerHP = 100;
        public int playerDMG = 5;

        public int playerProjectileSpeed = 3;

        public int playerSpeed = 1;

        public Vector2 movement = new Vector2();

        public Rectangle PlayerRec;

        Texture2D PlayerRight = Raylib.LoadTexture("PlayerRight.png");
        Texture2D PlayerLeft = Raylib.LoadTexture("PlayerLeft.png");
        Texture2D PlayerDown = Raylib.LoadTexture("PlayerDown.png");
        Texture2D PlayerUp = Raylib.LoadTexture("PlayerUp.png");

        Texture2D currentState;

        public Player()
        {
            Reset();
        }
        public void Reset()
        {
            PlayerRec = new Rectangle(Raylib.GetScreenWidth() / 2 - 75, Raylib.GetScreenHeight() / 2 - 80, 30, 90); //positionen som resettar till startpositionen
            currentState = PlayerDown; //fungerar som idle/startpositions state
            playerHP = 100;
            playerSpeed = 1;
            playerDMG = 5;
            playerProjectileSpeed = 1;
        }

        public void PlayerUpdate()
        {
            movement.X = 0;
            movement.Y = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && PlayerRec.x < Raylib.GetScreenWidth() - 75)
            {
                movement.X = playerSpeed;
                currentState = PlayerRight;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && PlayerRec.x > 0)
            {
                movement.X = -playerSpeed;
                currentState = PlayerLeft;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && PlayerRec.y < Raylib.GetScreenHeight() - 80)
            {
                movement.Y = playerSpeed;
                currentState = PlayerDown;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && PlayerRec.y > 0)
            {
                movement.Y = -playerSpeed;
                currentState = PlayerUp;
            }

            // bullets.Add(new Vector2(PlayerRec.x, PlayerRec.y));

            PlayerRec.x += movement.X;
            PlayerRec.y += movement.Y;
        }

        public void PlayerDraw()
        {
            Raylib.DrawTexture(currentState, (int)PlayerRec.x, (int)PlayerRec.y, Color.WHITE);
        }
    }
}