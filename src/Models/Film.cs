using MultimediaCatalog.src.Utils;

namespace MultimediaCatalog.src.Models;

public class Film : MultimediaContent
{
    public string? Director { get; set; }
    public int DurationMinutes { get; set; }

    public Film(
        string title, DateTime releaseDate, List<double>? scores, string director, int durationMinutes
    ) : base(title, releaseDate, scores)
    {
        Director = director;
        DurationMinutes = durationMinutes;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"{Id} | {Title} | {Director} | {DurationMinutes} min | Nota: {AverageScore:F1} | {DateUtils.FormatPublicationDate(ReleaseDate)}");
    }
}