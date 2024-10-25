using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Raylib_cs;

namespace game
{
    internal class Functions
    {


        public static void drawAgeTextBox()
        {
            Raylib.DrawRectangleRec(GlobalVars.ageTextBox, Color.LightGray);

            if (GlobalVars.mouseOnTextBox)
            {
                Raylib.DrawRectangleLines((int)GlobalVars.ageTextBox.X, (int)GlobalVars.ageTextBox.Y, (int)GlobalVars.ageTextBox.Width, (int)GlobalVars.ageTextBox.Height, Color.Red);
            }
            else
            {
                Raylib.DrawRectangleLines((int)GlobalVars.ageTextBox.X, (int)GlobalVars.ageTextBox.Y, (int)GlobalVars.ageTextBox.Width, (int)GlobalVars.ageTextBox.Height, Color.DarkGray);
            }

            Raylib.DrawText(GlobalVars.age.ToString(), (int)GlobalVars.ageTextBox.X + 5, (int)GlobalVars.ageTextBox.Y + 8, 20, Color.Maroon);
        }
        public static void ageInputBoxLogic()
        {

            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), GlobalVars.ageTextBox)) { GlobalVars.mouseOnTextBox = true; } else GlobalVars.mouseOnTextBox = false;

            if (GlobalVars.mouseOnTextBox)
            {
                Raylib.SetMouseCursor(MouseCursor.IBeam);
                int key = Raylib.GetKeyPressed(); // Returns the ASCII key code of the pressed key

                // Check if more characters have been pressed on the same frame
                while (key > 0)
                {
                    //Checks if pressed key is a number (0-9)
                    if (key >= 48 && key <= 57 && GlobalVars.digitCount < 2)
                    {
                        // Calc the age by shifting the current value and adding the new digit
                        GlobalVars.age = GlobalVars.age * 10 + (key - 48);
                        GlobalVars.digitCount++;
                    }

                    key = Raylib.GetKeyPressed(); // Check the next character
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Backspace))
                {
                    GlobalVars.age /= 10; // Remove the last digit
                    GlobalVars.digitCount--;
                    if (GlobalVars.digitCount < 0) { GlobalVars.digitCount = 0; }
                }
            }

            else
            {
                Raylib.SetMouseCursor(MouseCursor.Default);
            }

        }
    }

}
