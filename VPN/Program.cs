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

            List<Block> blocks = new List<Block>();
            List<Homebase> homebases = new List<Homebase>();
            //row 1


            string[] level = {"*                   ",
                              "xxxxxxxxxxxxxxxxxxx ",
                              "*x   x            x ",
                              " x x x x   xxxxxx x ",
                              " x x x x   x   x  x ",
                              "   x   x   x*x    x ",
                              "xxxxxxxx   xxxxxx x ",
                              "*x   x   x        x ",
                              " x x x x xxxxxxxxxx ",
                              "   x   x            "};

            for (int y = 0; y < level.Length; y++)
            {
                for (int x = 0; x < level[y].Length; x++)
                {
                    char item = level[y][x];

                    if (item == 'x')
                    {
                        blocks.Add(new Enemy(10 + 90 * x, 10 + 90 * y));
                    }

                    if (item == '*')
                    {
                        blocks.Add(new Homebase(10 + 90 * x, 10 + 90 * y));
                    }
                }
            }

            //Variabler
            string scene = "Menu";
            bool playerIsAlive = true;
            Player p = new Player();


            //logos
            Texture2D logo = Raylib.LoadTexture("BrandonsAdventure_logo.png");
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
                    scene = MenuUpdate(buttonPlay, buttonExit, p);
                }
                //Logic
                if (scene == "Intro")
                {
                    IntroDraw(ButtonLayout);
                    scene = IntroUpdate();
                }

                if (scene == "Arena")
                {
                    scene = ArenaUpdate(playerIsAlive, scene, p, blocks);

                }
                else if (scene == "Deadscreen")
                {
                    scene = DeadscreenUpdate(buttonMenu, buttonRetry, scene, p);
                }
                else if (scene == "Victory")
                {
                    scene = VictoryUpdate(buttonMenu, buttonRetry, scene, p);
                }

                Raylib.BeginDrawing();
                if (scene == "Menu")
                {
                    MenuDraw(buttonPlay, buttonExit, logo);
                }

                if (scene == "Arena")
                {
                    Raylib.ClearBackground(Color.BLUE);
                    if (playerIsAlive == true)
                    {
                        p.PlayerUpdate();

                        p.PlayerDraw();
                    }

                    foreach (Block e in blocks)
                    {
                        e.Draw();
                    }
                }

                if (scene == "Victory")
                {
                    VictoryDraw(HomeBase, buttonRetry, buttonMenu);
                }

                if (scene == "Deadscreen")
                {
                    DeadscreenDraw(DeadscreenLOGO, buttonRetry, buttonMenu);
                }
                Raylib.EndDrawing();
            }
        }
        static string MenuUpdate(Rectangle buttonPlay, Rectangle buttonExit, Player p)
        {
            //menu buttons
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonPlay) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                p.Reset();
                return "Intro";
            }
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonExit) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return "Quit";
            }

            return "Menu";
        }

        static void MenuDraw(Rectangle buttonPlay, Rectangle buttonExit, Texture2D logo)
        {
            Raylib.ClearBackground(Color.ORANGE);
            Raylib.DrawTexture(logo, 300, 125, Color.WHITE);
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
        static string IntroUpdate()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
            {
                return "Arena";
            }

            return "Intro";
        }

        static void IntroDraw(Texture2D ButtonLayout)
        {
            Raylib.ClearBackground(Color.GREEN);
            Raylib.DrawTexture(ButtonLayout, 300, 400, Color.WHITE);
            Raylib.DrawText("- Welcome to Brandons advetnure!", 50, 50, 40, Color.BLACK);
            Raylib.DrawText("- Your objective is to guide Brandom to his home safely.", 50, 100, 40, Color.BLACK);
            Raylib.DrawText("- To guide Brandom home you have to get to the purple squares.", 50, 150, 40, Color.BLACK);
            Raylib.DrawText("- But avoid the red squares as they will kill Brandon.", 50, 200, 40, Color.BLACK);
            Raylib.DrawText("- You can guide Brandon using the W, A, S and D buttons.", 50, 250, 40, Color.BLACK);
            Raylib.DrawText("- Press the ENTER button to continue.", 50, 300, 40, Color.BLACK);
            Raylib.DrawText("- Good luck :)", 50, 350, 40, Color.BLACK);
        }

        static string ArenaUpdate(bool playerIsAlive, string scene, Player p, List<Block> blocks)
        {
            playerIsAlive = true;
            Raylib.ClearBackground(Color.BLUE);
            //commands
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_Q))
            {
                return "Deadscreen";
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
            {
                return "Victory";
            }

            //collision 
            foreach (Block e in blocks)
            {
                if (Raylib.CheckCollisionRecs(p.rect, e.rect))
                {
                    if (e is Enemy)
                    {
                        return "Deadscreen";
                    }
                    if (e is Homebase)
                    {
                        return "Victory";
                    }
                }
            }
            return "Arena";
        }

        static string VictoryUpdate(Rectangle buttonMenu, Rectangle buttonRetry, String scene, Player p)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonMenu) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return "Menu";
            }

            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonRetry) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                p.Reset();
                return "Arena";
            }
            return "Victory";
        }

        static void VictoryDraw(Texture2D HomeBase, Rectangle buttonRetry, Rectangle buttonMenu)
        {
            Raylib.ClearBackground(Color.GREEN);
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

        static string DeadscreenUpdate(Rectangle buttonMenu, Rectangle buttonRetry, String scene, Player p)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonMenu) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                return "Menu";
            }

            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), buttonRetry) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                p.Reset();
                return "Arena";
            }
            return "Deadscreen";
        }

        static void DeadscreenDraw(Texture2D Deadscreen_logo, Rectangle buttonRetry, Rectangle buttonMenu)
        {
            Raylib.ClearBackground(Color.RED);
            Raylib.DrawTexture(Deadscreen_logo, 300, 25, Color.WHITE);
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

    }
}
