namespace MultimediaCatalog.src.Interfaces;

public interface IEvaluable
{
    double AverageScore { get; }
    void AssignScore(double score);
}