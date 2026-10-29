using System.Text.Json;
using MultimediaCatalog.src.Models;

namespace MultimediaCatalog.src.Services;

public static class DataManager
{
    /*
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true
    };
    */

    public static void SaveCatalogJson(List<MultimediaContent> catalog, string path)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        var json = JsonSerializer.Serialize(catalog, options);

        File.WriteAllText(path, json);
    }

    public static List<MultimediaContent> LoadCatalog(string path)
    {
        if (!File.Exists(path)) return new List<MultimediaContent>();
        
        var json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<List<MultimediaContent>>(json) ?? new List<MultimediaContent>();
    }

}