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


            //Variabler
            string scene = "Menu";
            bool playerIsAlive = true;

            Player p = new Player();


            //Interactives
            Rectangle buttonPlay = new Rectangle(650, 500, 500, 100);
            Rectangle buttonExit = new Rectangle(650, 650, 500, 100);


            //Obstacles

            while (!Raylib.WindowShouldClose() && scene != "Quit")
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

                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonExit) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    scene = "Quit";
                }

                if (playerIsAlive == false)
                {
                    bgColor = Color.GRAY;
                }


                // I Player-klass: movement-Vector2
                // Om trycker höger: vektorns x +

                // else if vektons x+ rita ut gå-höger-bilden
                // else if vektorns x- rita ut gå-vänster
                // else if vektorns y- rita ut gå uppåt 

                //Drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(bgColor);
                if (scene == "Menu")
                {
                    //PlayButton
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

                    //ExitButton
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonExit))
                    {
                        Raylib.DrawRectangleRec(buttonExit, Color.WHITE);
                        Raylib.DrawText("E", 715, 675, 50, Color.BLACK);
                        Raylib.DrawText("X", 830, 675, 50, Color.BLACK);
                        Raylib.DrawText("I", 945, 675, 50, Color.BLACK);
                        Raylib.DrawText("T", 1060, 675, 50, Color.BLACK);
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(buttonExit, Color.BLACK);
                        Raylib.DrawText("E", 715, 675, 50, Color.WHITE);
                        Raylib.DrawText("X", 830, 675, 50, Color.WHITE);
                        Raylib.DrawText("I", 945, 675, 50, Color.WHITE);
                        Raylib.DrawText("T", 1060, 675, 50, Color.WHITE);
                    }
                }

                if (scene == "Arena")
                {
                    p.Update();

                    p.Draw();
                }

                Raylib.EndDrawing();
            }
        }
    }
}
