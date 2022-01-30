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

            //Alla fiender

            List<Enemy> enemies = new List<Enemy>();
            //row 1
            enemies.Add(new Enemy(10, 10));
            enemies.Add(new Enemy(10, 100));
            enemies.Add(new Enemy(10, 190));
            enemies.Add(new Enemy(10, 280));
            enemies.Add(new Enemy(10, 370));
            enemies.Add(new Enemy(10, 460));
            enemies.Add(new Enemy(10, 550));
            //row 2
            enemies.Add(new Enemy(100, 100));
            enemies.Add(new Enemy(100, 190));
            enemies.Add(new Enemy(100, 280));
            enemies.Add(new Enemy(100, 370));
            enemies.Add(new Enemy(100, 550));
            enemies.Add(new Enemy(100, 640));
            enemies.Add(new Enemy(100, 730));
            //row 3
            enemies.Add(new Enemy(190, 100));
            enemies.Add(new Enemy(190, 550));
            //row 4 
            enemies.Add(new Enemy(280, 100));
            enemies.Add(new Enemy(280, 280));
            enemies.Add(new Enemy(280, 370));
            enemies.Add(new Enemy(280, 460));
            enemies.Add(new Enemy(280, 550));
            enemies.Add(new Enemy(280, 730));
            enemies.Add(new Enemy(280, 820));
            //row 5
            enemies.Add(new Enemy(370, 100));
            enemies.Add(new Enemy(370, 550));
            //row 6
            enemies.Add(new Enemy(460, 100));
            enemies.Add(new Enemy(460, 190));
            enemies.Add(new Enemy(460, 280));
            enemies.Add(new Enemy(460, 370));
            enemies.Add(new Enemy(460, 550));
            enemies.Add(new Enemy(460, 640));
            enemies.Add(new Enemy(460, 730));
            //row 7
            enemies.Add(new Enemy(550, 100));
            enemies.Add(new Enemy(550, 550));
            //row 8
            enemies.Add(new Enemy(640, 100));
            enemies.Add(new Enemy(640, 280));
            enemies.Add(new Enemy(640, 370));
            enemies.Add(new Enemy(640, 460));
            enemies.Add(new Enemy(640, 550));
            enemies.Add(new Enemy(640, 730));
            enemies.Add(new Enemy(640, 820));
            //row 9
            enemies.Add(new Enemy(730, 100));
            //row 10
            enemies.Add(new Enemy(820, 100));
            enemies.Add(new Enemy(820, 630));
            enemies.Add(new Enemy(820, 730));
            enemies.Add(new Enemy(820, 820));
            //row 11
            enemies.Add(new Enemy(910, 100));
            //row 12
            enemies.Add(new Enemy(1000, 100));
            enemies.Add(new Enemy(1000, 280));
            enemies.Add(new Enemy(1000, 370));
            enemies.Add(new Enemy(1000, 460));
            enemies.Add(new Enemy(1000, 550));
            enemies.Add(new Enemy(1000, 730));
            //row 13
            enemies.Add(new Enemy(1090, 100));
            enemies.Add(new Enemy(1090, 280));
            enemies.Add(new Enemy(1090, 550));
            enemies.Add(new Enemy(1090, 730));
            //row 14
            enemies.Add(new Enemy(1180, 100));
            enemies.Add(new Enemy(1180, 280));
            enemies.Add(new Enemy(1180, 550));
            enemies.Add(new Enemy(1180, 730));
            //row 15
            enemies.Add(new Enemy(1270, 100));
            enemies.Add(new Enemy(1270, 280));
            enemies.Add(new Enemy(1270, 550));
            enemies.Add(new Enemy(1270, 730));
            //row 16
            enemies.Add(new Enemy(1360, 100));
            enemies.Add(new Enemy(1360, 280));
            enemies.Add(new Enemy(1360, 550));
            enemies.Add(new Enemy(1360, 730));
            //row 17
            enemies.Add(new Enemy(1450, 100));
            enemies.Add(new Enemy(1450, 280));
            enemies.Add(new Enemy(1450, 550));
            enemies.Add(new Enemy(1450, 730));
            //row 18
            enemies.Add(new Enemy(1540, 100));
            enemies.Add(new Enemy(1540, 730));
            //row 19
            enemies.Add(new Enemy(1630, 100));
            enemies.Add(new Enemy(1630, 190));
            enemies.Add(new Enemy(1630, 280));
            enemies.Add(new Enemy(1630, 370));
            enemies.Add(new Enemy(1630, 460));
            enemies.Add(new Enemy(1630, 550));
            enemies.Add(new Enemy(1630, 640));
            enemies.Add(new Enemy(1630, 730));

            //Alla homebases

            List<Homebase> homebases = new List<Homebase>();
            //row 1
            homebases.Add(new Homebase(10, 640));
            //row 2
            homebases.Add(new Homebase(100, 10));
            homebases.Add(new Homebase(100, 370));
            //row 13
            homebases.Add(new Homebase(1090, 370));
            homebases.Add(new Homebase(1090, 460));

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
            Texture2D HomeBase = Raylib.LoadTexture("Homebase_Logo.png");
            //Interactives
            Rectangle buttonPlay = new Rectangle(650, 500, 500, 100);
            Rectangle buttonExit = new Rectangle(650, 700, 500, 100);
            Rectangle buttonRetry = new Rectangle(650, 375, 500, 100);
            Rectangle buttonMenu = new Rectangle(650, 550, 500, 100);

            Color bgColor = Color.BEIGE;

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
                    playerIsAlive = true;
                    bgColor = Color.BLUE;
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
                    {
                        playerIsAlive = false;
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
                    {
                        scene = "Victory";
                    }

                    if (playerIsAlive == false)
                    {
                        scene = "Deadscreen";
                    }

                    if (victory == true)
                    {
                        scene = "Victory";
                    }

                    foreach (Enemy e in enemies)
                    {
                        if (Raylib.CheckCollisionRecs(p.rect, e.rect))
                        {
                            scene = "Deadscreen";
                        }
                    }
                    foreach (Homebase h in homebases)
                    {
                        if (Raylib.CheckCollisionRecs(p.rect, h.rect))
                        {
                            scene = "Victory";
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
                else if (scene == "Victory")
                {
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
                    foreach (Homebase h in homebases)
                    {
                        h.Draw();
                    }
                }

                if (scene == "Victory")
                {
                    bgColor = Color.GREEN;
                    Raylib.DrawTexture(HomeBase, 300, 25, Color.WHITE);
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
