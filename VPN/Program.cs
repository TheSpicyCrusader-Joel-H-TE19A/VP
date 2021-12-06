using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

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
            Enemy e = new Enemy();


            //Interactives
            Rectangle buttonPlay = new Rectangle(650, 500, 500, 100);
            Rectangle buttonExit = new Rectangle(650, 700, 500, 100);
            Rectangle buttonRetry = new Rectangle(650, 375, 500, 100);
            Rectangle buttonMenu = new Rectangle(650, 550, 500, 100);

            Color bgColor = Color.BEIGE;
            //Obstacles

            while (!Raylib.WindowShouldClose() && scene != "Quit")
            {
                if (scene == "Menu")
                {
                    bgColor = Color.ORANGE;
                    //menu buttons
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonPlay) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Arena";
                        p.Reset();
                    }
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonExit) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Quit";
                    }
                }
                //Logic

                if (scene == "Arena")
                {
                    Raylib.DrawText($"Player HP: {p.playerHP}", 750, 25, 40, Color.BLACK);
                    playerIsAlive = true;
                    bgColor = Color.BLUE;
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
                    {
                        playerIsAlive = false;
                    }

                    if (playerIsAlive == false)
                    {
                        scene = "Deadscreen";
                    }

                }
                else if (scene == "Deadscreen")
                {
                    //deadscreen buttons
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonMenu) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Menu";
                    }

                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonRetry) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Arena";
                        p.Reset();
                    }
                }

                //Drawing
                Raylib.BeginDrawing();
                Raylib.ClearBackground(bgColor);
                if (scene == "Menu")
                {
                    playerIsAlive = true;
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
                        Raylib.DrawText("E", 715, 725, 50, Color.BLACK);
                        Raylib.DrawText("X", 830, 725, 50, Color.BLACK);
                        Raylib.DrawText("I", 945, 725, 50, Color.BLACK);
                        Raylib.DrawText("T", 1060, 725, 50, Color.BLACK);
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(buttonExit, Color.BLACK);
                        Raylib.DrawText("E", 715, 725, 50, Color.WHITE);
                        Raylib.DrawText("X", 830, 725, 50, Color.WHITE);
                        Raylib.DrawText("I", 945, 725, 50, Color.WHITE);
                        Raylib.DrawText("T", 1060, 725, 50, Color.WHITE);
                    }
                }

                if (scene == "Arena")
                {
                    if (playerIsAlive == true)
                    {
                        p.PlayerUpdate();

                        p.PlayerDraw();
                    }

                }

                if (scene == "Deadscreen")
                {
                    bgColor = Color.GRAY;

                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonRetry))
                    {
                        Raylib.DrawRectangleRec(buttonRetry, Color.WHITE);
                        Raylib.DrawText("R", 675, 400, 50, Color.BLACK);
                        Raylib.DrawText("E", 781, 400, 50, Color.BLACK);
                        Raylib.DrawText("T", 888, 400, 50, Color.BLACK);
                        Raylib.DrawText("R", 995, 400, 50, Color.BLACK);
                        Raylib.DrawText("Y", 1100, 400, 50, Color.BLACK);
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(buttonRetry, Color.BLACK);
                        Raylib.DrawText("R", 675, 400, 50, Color.WHITE);
                        Raylib.DrawText("E", 781, 400, 50, Color.WHITE);
                        Raylib.DrawText("T", 888, 400, 50, Color.WHITE);
                        Raylib.DrawText("R", 995, 400, 50, Color.WHITE);
                        Raylib.DrawText("Y", 1100, 400, 50, Color.WHITE);
                    }

                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonMenu))
                    {
                        Raylib.DrawRectangleRec(buttonMenu, Color.WHITE);
                        Raylib.DrawText("M", 715, 575, 50, Color.BLACK);
                        Raylib.DrawText("E", 830, 575, 50, Color.BLACK);
                        Raylib.DrawText("N", 945, 575, 50, Color.BLACK);
                        Raylib.DrawText("U", 1060, 575, 50, Color.BLACK);
                    }
                    else
                    {
                        Raylib.DrawRectangleRec(buttonMenu, Color.BLACK);
                        Raylib.DrawText("M", 715, 575, 50, Color.WHITE);
                        Raylib.DrawText("E", 830, 575, 50, Color.WHITE);
                        Raylib.DrawText("N", 945, 575, 50, Color.WHITE);
                        Raylib.DrawText("U", 1060, 575, 50, Color.WHITE);
                    }

                }

                Raylib.EndDrawing();
            }
        }
    }
}
