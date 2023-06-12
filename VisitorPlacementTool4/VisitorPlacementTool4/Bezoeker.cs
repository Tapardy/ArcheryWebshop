namespace VisitorPlacementTool4;

public class Bezoeker
{
    private Random _random = new Random();
    public int Leeftijd { get; set; }
    public DateTime AanmeldingsDatum { get; set; }
    public int GroepId { get; }
    public bool Assigned { get; set; }

    public Bezoeker(int groepId)
    {
        Leeftijd = _random.Next(1, 100);
        GroepId = groepId;
    }

    public bool IsKind()
    {
        return Leeftijd <= 12;
    }
}