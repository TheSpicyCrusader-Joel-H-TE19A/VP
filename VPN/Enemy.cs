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
        Texture2D EnemyTexture = Raylib.LoadTexture("EnemyImage.png");

        public Rectangle EnemyRec;

        public Enemy()
        {
            Reset();
        }

        public void Reset()
        {
            EnemyRec = new Rectangle(-78, 100 - 80, 30, 90);
        }

        public void EnemyUpdate()
        {

        }

        public void EnemyDraw()
        {

        }
    }
}