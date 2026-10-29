using System.Runtime.ConstrainedExecution;
using Microsoft.VisualBasic;
using MultimediaCatalog.src.Models;
using MultimediaCatalog.src.Services;
using MultimediaCatalog.src.Utils;

namespace MultimediaCatalog.src.UI;

public static class AppMenu
{
    public static void DisplayMenu(List<MultimediaContent> list)
    {
        var option = -1;

        do
        {
            ShowMenu();
            option = ConsoleUtils.ReadInt("\nElija una opción: ");

            switch (option)
            {
                case 1:
                    list.Add(AddFilm());
                    Console.WriteLine("\nPelícula añadida con éxito.");
                    break;
                case 2:
                    list.Add(AddSerie());
                    Console.WriteLine("\nSerie añadida con éxito.");
                    break;
                case 3:
                    Console.WriteLine();
                    ShowCatalog(list);
                    break;
                case 4:
                    Console.WriteLine();
                    SearchByTitle(list);
                    break;
                case 5:
                    Console.WriteLine();
                    RateContent(list);
                    break;
                case 6:
                    Console.WriteLine();
                    SaveCatalog(list);
                    break;
                case 7:
                    Console.WriteLine();
                    var loadedList = LoadCatalog();
                    if (loadedList != null)
                    {
                        list.Clear();
                        list.AddRange(loadedList);
                        Console.WriteLine("Datos cargados correctamente");
                    }
                    break;
                case 0:
                    Console.WriteLine("\nSaliendo del programa...");
                    break;
                default:
                    Console.WriteLine("\nOpción inválida. Elija un número del 1 al 7");
                    break;
            }
        } while (option != 0);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n=== Catalogo Multimedia ===");
        Console.WriteLine("1. Añadir película");
        Console.WriteLine("2. Añadir serie");
        Console.WriteLine("3. Mostrar catalogo");
        Console.WriteLine("4. Buscar por título");
        Console.WriteLine("5. Valorar un contenido");
        Console.WriteLine("6. Guardar datos");
        Console.WriteLine("7. Cargar datos");
        Console.WriteLine("0. Salir");
    }

    private static Film AddFilm()
    {
        Console.WriteLine("\n--- Nueva Película ---");
        // var id = ConsoleUtils.ReadInt("Id de la película: ");
        var title = ConsoleUtils.ReadString("Título de la película: ");
        var releaseDate = ConsoleUtils.ReadDateTime("Fecha de estreno (ej. 2023-10-15): ");
        var director = ConsoleUtils.ReadString("Director: ");
        var duration = ConsoleUtils.ReadInt("Duración en minutos: ");

        return new Film(title, releaseDate, new List<double>() /* [] */ , director, duration);

        /*
        return new Film(
            id: id,
            title: title,
            releaseDate: releaseDate,
            scores: [],
            director: director,
            durationMinutes: duration
        );
        */
    }

    private static Serie AddSerie()
    {
        Console.WriteLine("\n--- Nueva Serie ---");
        // var id = ConsoleUtils.ReadInt("Id de la serie: ");
        var title = ConsoleUtils.ReadString("Título de la serie: ");
        var releaseDate = ConsoleUtils.ReadDateTime("Fecha de estreno (ej. 2023-10-15): ");
        var numSeasons = ConsoleUtils.ReadInt("Número de temporadas: ");
        var onAir = ConsoleUtils.ReadBool("¿Está en emisión? (true/false): ");

        return new Serie(title, releaseDate, new List<double>() /* [] */ , numSeasons, onAir);

        /*
        return new Serie(
            id: id,
            title: title,
            releaseDate: releaseDate,
            scores: [],
            numSeasons: numSeasons,
            onAir: onAir
        );
        */
    }

    private static void ShowCatalog(List<MultimediaContent> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Catalogo vacío.");
            return;
        }

        foreach (var content in list)
        {
            content.ShowDetails();
        }
    }

    private static void SearchByTitle(List<MultimediaContent> list)
    {
        var input = ConsoleUtils.ReadString("Introduzca un título: ");
        var found = false;

        foreach (var content in list)
        {
            if (content.Title?.Contains(input, StringComparison.OrdinalIgnoreCase) == true)
            {
                content.ShowDetails();
                found = true;
            }
        }

        if (!found) Console.WriteLine("No se ha encontrando contenido");

        /*
        === USANDO LINQ ===
        var result = list.Where(c => c.Title?.Contains(input, StringComparison.OrdinalIgnoreCase) == true).ToList();
        
        if (result.Count == 0)
        {
            Console.WriteLine("No se ha encontrado contenido.");
            return;
        }

        result result.ForEach(c => c.ShowDetails());
        */
    }

    private static void RateContent(List<MultimediaContent> list)
    {
        var input = ConsoleUtils.ReadString("Introduzca un título: ");
        var found = false;

        foreach (var content in list)
        {
            if (content.Title?.Equals(input, StringComparison.OrdinalIgnoreCase) == true)
            {
                var score = ConsoleUtils.ReadDouble("Introduzca una puntuación del 0 al 10: ");
                content.AssignScore(score);
                found = true;
                break;
            }
        }

        if (!found) Console.WriteLine("No se ha encontrando contenido con este título.");

        /*
        === USANDO LINQ ===
        var item = list.FirstOrDefault(c => c.Title?.Equals(input, StringComparison.OrdinalIgnoreCase) == true);

        if (item is null)
        {
            Console.WriteLine("No se ha encontrado contenido con ese título.");
            return;
        }

        var score2 = ConsoleUtils.ReadDouble("Introduzca una puntuación del 0 al 10: ");
        item.AssignScore(score2);
        Console.WriteLine("Puntuación añadida correctamente!");
        */
    }
    private static void SaveCatalog(List<MultimediaContent> list)
    {
        var path = ConsoleUtils.ReadString("Introduzca una ruta (ej: catalogo.json): ");
        Console.WriteLine($"Guardando fichero JSON en {path}...");
        DataManager.SaveCatalogJson(list, path);
    }

    private static List<MultimediaContent>? LoadCatalog()
    {
        var path = ConsoleUtils.ReadString("Introduzca la ruta del archivo a cargar (ej: catalogo.json): ");
        Console.WriteLine($"Cargando fichero JSON y sobrescribiendo la lista actual...");
        return DataManager.LoadCatalog(path);
    }
}