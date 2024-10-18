using System.Numerics;
using game;
using Raylib_cs;

namespace game;

class Program
{
    public static void Main()
    {
        
        // Resizeable, make sure to adjust every texture
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(GlobalVars.screenWidth, GlobalVars.screenHeight, "EliteLegends");

        // 240 hz monitor shrug
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.ClearBackground(Color.Red);

            string text = "Hello world!";
            int center = (GlobalVars.screenWidth / 2);
            Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, 20, 0);

            Raylib.DrawText(text, (int) ((GlobalVars.screenWidth / 2) - (textSize.Length() / 2)), 12, 20, Color.Black);

            // Wanted to draw a line under, but couldn't figure out the cords.
            // It's something along the lines of text start cord to text end cord, and a y cord of some type.

            Raylib.EndDrawing();

            if (Raylib.IsWindowResized())
            {
                GlobalVars.screenWidth = Raylib.GetScreenWidth();
                GlobalVars.screenHeight = Raylib.GetScreenHeight();

            }

        }

        Raylib.CloseWindow();
    }
}