﻿using System.Net.NetworkInformation;
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

        // https://www.raylib.com/examples/core/loader.html?name=core_window_letterbox
        RenderTexture2D target = Raylib.LoadRenderTexture(GlobalVars.screenWidth, GlobalVars.screenHeight);
        Raylib.SetTextureFilter(target.Texture, TextureFilter.Bilinear);  // Texture scale filter to us
        
        while (!Raylib.WindowShouldClose())
        {

            // Toggle debug overlay
            if (Raylib.IsKeyPressed(KeyboardKey.F3))
            {
                GlobalVars.showDebug = !GlobalVars.showDebug;
            }


            // current screen width / original screen width
            float scale = Math.Min((float) Raylib.GetScreenWidth() / GlobalVars.screenWidth, (float) Raylib.GetScreenHeight() / GlobalVars.screenHeight);

            // First we write everything to a texture, and then we write that texture to the screen every frame.
            // This allows to rescale that one specific texture relative to the original screen width/height.
            Raylib.BeginTextureMode(target);

            string text = "Elite Legends!";
            int textWidth = Raylib.MeasureText(text, 20); // Measure text width first
            Raylib.DrawText(text, 100, 20, 20, Color.Black);

            // Draw a line under the game title using measured text width
            Raylib.DrawLine(100, 40, 100 + textWidth, 40, Color.Black); // Changed from fixed values to dynamic calc

            Raylib.DrawText("Whats your age: ", 100, 80, 20, Color.Black);

            
            Functions.ageInputBoxLogic();
            Functions.drawAgeTextBox();
            Raylib.EndTextureMode();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Red);

            // Draw render texture to screen, properly scaled
            Rectangle source = new(0.0f, 0.0f, (float) target.Texture.Width, (float) -target.Texture.Height);
            Rectangle destination = new((Raylib.GetScreenWidth() - (GlobalVars.screenWidth * scale)) * 0.5f,
                (Raylib.GetScreenHeight() - (GlobalVars.screenHeight * scale)) * 0.5f,
                GlobalVars.screenWidth * scale,
                GlobalVars.screenHeight * scale);
            Vector2 origin = new(0, 0);
            float rotation = 0.0f;


            // Draw debug overlay if toggled
            if (GlobalVars.showDebug)
            {
                Functions.DrawDebugInfo();
            }

            Raylib.DrawTexturePro(target.Texture, source, destination, origin, rotation, Color.White);

            Raylib.EndDrawing();

        }

        Raylib.UnloadRenderTexture(target);

        Raylib.CloseWindow();
    }
}