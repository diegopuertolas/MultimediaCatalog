using MultimediaCatalog.src.Utils;

namespace MultimediaCatalog.src.Models;

public class Serie : MultimediaContent
{
    public int NumSeasons { get; set; }
    public bool OnAir { get; set; }

    public Serie(
        string title, DateTime releaseDate, List<double> scores, int numSeasons, bool onAir
    ) : base(title, releaseDate, scores)
    {
        NumSeasons = numSeasons;
        OnAir = onAir;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"{Id} | {Title} | {NumSeasons} | {(OnAir ? "En emisión" : "En plataformas")} | {AverageScore} | {DateUtils.FormatPublicationDate(ReleaseDate)}");
    }
}