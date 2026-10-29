namespace MultimediaCatalog.src.Utils;

public static class ConsoleUtils
{
    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
            Console.WriteLine("Error: El texto no puede estar vacío.");
        }
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out var result) && result >= 0) return result;
            Console.WriteLine("Error: Debe introducir un número entero válido (mayor o igual a 0).");
        }
    }

    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out var result)) return result;
            Console.WriteLine("Error: Debe introducir un número entero válido.");
        }
    }

    public static bool ReadBool(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim().ToLower();
            if (input == "true" || input == "si" || input == "s") return true;
            if (input == "false" || input == "no" || input == "n") return false;
            Console.WriteLine("Error: Debe introducir 'true' o 'false'.");
        }
    }

    public static DateTime ReadDateTime(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (DateTime.TryParse(input, out var result)) return result;
            Console.WriteLine("Error: Formato de fecha incorrecto.");
        }
    }
}