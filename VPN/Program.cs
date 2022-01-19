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
            Raylib.InitWindow(1800, 910, "Brandons adventure");


            List<Enemy> enemies = new List<Enemy>();
            enemies.Add(new Enemy(10, 10));
            enemies.Add(new Enemy(10, 100));
            enemies.Add(new Enemy(10, 190));
            enemies.Add(new Enemy(10, 280));
            enemies.Add(new Enemy(10, 370));
            enemies.Add(new Enemy(10, 460));
            enemies.Add(new Enemy(10, 550));
            enemies.Add(new Enemy(10, 640));
            enemies.Add(new Enemy(10, 730));
            enemies.Add(new Enemy(10, 820));
            enemies.Add(new Enemy(10, 910));

            //Variabler
            string scene = "Menu";
            bool playerIsAlive = true;
            bool victory = false;

            Player p = new Player();
            // Enemy e = new Enemy(0, 0);

            //logos
            Texture2D LOGO = Raylib.LoadTexture("BrandonsAdventure_logo.png");
            Texture2D DeadscreenLOGO = Raylib.LoadTexture("Deadscreen_logo.png");
            Texture2D ButtonLayout = Raylib.LoadTexture("ButtonLayout.png");
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
                    Raylib.DrawTexture(LOGO, 300, 125, Color.WHITE);
                    //menu buttons
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonPlay) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Intro";
                        p.Reset();
                    }
                    if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonExit) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        scene = "Quit";
                    }
                }
                //Logic
                if (scene == "Intro")
                {
                    bgColor = Color.GREEN;
                    Raylib.DrawTexture(ButtonLayout, 300, 400, Color.WHITE);
                    Raylib.DrawText("- Welcome to Brandons advetnure!", 50, 50, 40, Color.BLACK);
                    Raylib.DrawText("- Your objective is to guide Brandom to his home safely.", 50, 100, 40, Color.BLACK);
                    Raylib.DrawText("- To guide Brandom home you have to get to the purple squares.", 50, 150, 40, Color.BLACK);
                    Raylib.DrawText("- But avoid the red squares as they will kill Brandon.", 50, 200, 40, Color.BLACK);
                    Raylib.DrawText("- You can guide Brandon using the W, A, S and D buttons.", 50, 250, 40, Color.BLACK);
                    Raylib.DrawText("- Press the ENTER button to continue.", 50, 300, 40, Color.BLACK);
                    Raylib.DrawText("- Good luck :)", 50, 350, 40, Color.BLACK);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "Arena";
                    }
                }

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



                    foreach (Enemy e in enemies)
                    {
                        if (Raylib.CheckCollisionRecs(p.rect, e.rect))
                        {
                            scene = "Deadscreen";
                        }
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
                    //Logo

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

                    foreach (Enemy e in enemies)
                    {
                        e.Draw();
                    }
                }

                if (scene == "Deadscreen")
                {
                    bgColor = Color.GRAY;
                    Raylib.DrawTexture(DeadscreenLOGO, 300, 25, Color.WHITE);

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
