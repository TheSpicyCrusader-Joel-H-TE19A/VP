using System;
using Raylib_cs;
using System.Numerics;

namespace VPN
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1800, 900, "Brandons adventure");

            //Texturer

            //Variabler
            string scene = "Menu";
            bool playerIsAlive = true;

            Rectangle buttonPlay = new Rectangle(650, 500, 500, 100);


            //Obstacles

            while (!Raylib.WindowShouldClose())
            {
                //Logic
                Color bgColor = Color.BLUE;
                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonPlay) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    scene = "Arena";
                }

                if (scene == "Arena")
                {
                    bgColor = Color.GREEN;
                }

                if (playerIsAlive == false)
                {
                    bgColor = Color.GRAY;
                }



                //Drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(bgColor);
                if (scene == "Menu")
                {
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonPlay))
                    {
                        Raylib.DrawRectangleRec(buttonPlay, Color.WHITE);
                        Raylib.DrawText("P", 715, 525, 50, Color.BLACK);
                        Raylib.DrawText("L", 830, 525, 50, Color.BLACK);
                        Raylib.DrawText("A", 945, 525, 50, Color.BLACK);
                        Raylib.DrawText("Y", 1060, 525, 50, Color.BLACK);
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(buttonPlay, Color.BLACK);
                        Raylib.DrawText("P", 715, 525, 50, Color.WHITE);
                        Raylib.DrawText("L", 830, 525, 50, Color.WHITE);
                        Raylib.DrawText("A", 945, 525, 50, Color.WHITE);
                        Raylib.DrawText("Y", 1060, 525, 50, Color.WHITE);
                    }


                }


                Raylib.EndDrawing();
            }
        }
    }
}
