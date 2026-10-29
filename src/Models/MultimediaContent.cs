using System.Text.Json.Serialization;
using MultimediaCatalog.src.Interfaces;

namespace MultimediaCatalog.src.Models;

[JsonPolymorphic(
    TypeDiscriminatorPropertyName = "$tipo"
)]
[JsonDerivedType(typeof(Film), "Film")]
[JsonDerivedType(typeof(Serie), "Serie")]
public abstract class MultimediaContent : IEvaluable
{
    public Guid Id = Guid.NewGuid();
    public string? Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<double> Scores { get; set; }
    public double AverageScore => Scores.Count > 0 ? Scores.Average() : 0;

    public MultimediaContent(
        string title, DateTime releaseDate, List<double>? scores = null
    )
    {
        Title = title;
        ReleaseDate = releaseDate;
        Scores = scores ?? new List<double>();
    }

    public abstract void ShowDetails();

    public void AssignScore(double score)
    {
        if (score < 0 || score > 10)
        {
            Console.WriteLine("Valor de nota incorrecto.");
            return;
        }

        Scores.Add(score); 
    }
}