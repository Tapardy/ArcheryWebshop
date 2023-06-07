namespace VisitorPlacementToolCallForHelp;

public class Groep
{
    public int GroepId { get; private set; }
    public int GroepSize { get; private set; }
    public DateTime GroepsAanmeldingsDatum { get; private set; }
    public List<Bezoeker> Bezoekers { get; private set; }

    public Groep(int groepId, DateTime groepsAanmeldingsDatum, int groepGrootte)
    {
        GroepId = groepId;
        GroepsAanmeldingsDatum = groepsAanmeldingsDatum;
        GroepSize = groepGrootte;
        Bezoekers = new List<Bezoeker>();
    }

    public void AddBezoeker(Bezoeker bezoeker)
    {
        Bezoekers.Add(bezoeker);
    }

    public bool GroepHasAdult()
    {
        return Bezoekers.Any(bezoeker => bezoeker.Leeftijd > 12);
    }
}