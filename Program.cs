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

            string text = "Elite Legends!";
            int center = (GlobalVars.screenWidth / 2);
            Vector2 textSize = Raylib.MeasureTextEx(Raylib.GetFontDefault(), text, 20, 0);

            Raylib.DrawText(text, (int) ((GlobalVars.screenWidth / 2) - (textSize.Length() / 2)), 12, 20, Color.Black);

            //Draw a line under the game title
            Raylib.DrawLine(340, 40, 478, 40, Color.Black);

            Raylib.DrawText("Whats your age: ", 100, 80, 20, Color.Black);

            Functions.ageInputBoxLogic();

            Functions.drawAgeTextBox();

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