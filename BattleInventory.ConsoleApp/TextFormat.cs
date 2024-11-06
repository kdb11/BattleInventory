public static class TextFormat
{

    public static void WriteRed(string str)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(str);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteYellow(string str)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(str);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteGreen(string str)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(str);
        Console.ForegroundColor = ConsoleColor.White;
    }
}