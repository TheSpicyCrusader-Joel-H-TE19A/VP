using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace VPN
{
    public class Enemy
    {
        public int enemyHP;
        public int enemyDMG;

        public float enemySpeed = 1;

        public Random EnemyPos = new Random();
        Texture2D texture = Raylib.LoadTexture("Enemy.png");

        public Rectangle rect;

        public Enemy(float x, float y)
        {
            rect = new Rectangle(x, y, 78, 80);

            // Reset();
        }

        public void Reset()
        {
            rect = new Rectangle(-78, 100 - 80, 30, 90);
        }

        public void EnemyUpdate()
        {

        }

        public void Draw()
        {
            Raylib.DrawTexture(texture, (int)rect.x, (int)rect.y, Color.WHITE);
        }
    }
}