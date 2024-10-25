namespace game;
using Raylib_cs;

public static class GlobalVars
{
    public static int screenWidth = 640;
    public static int screenHeight = 450;
    public static Rectangle ageTextBox = new Rectangle(280, 76, 100, 30);
    public static int age = 0;
    public static int digitCount = 0; // didnt want to make this a global var but if i put it inside the logic function int wont work lol
    public static bool mouseOnTextBox = false;
}
