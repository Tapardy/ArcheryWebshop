namespace VisitorPlacementTool4;

public class Groep
{
    private Random _random = new Random();
    private List<Bezoeker> _bezoekers;
    public int GroepId { get; }
    public int GroepGrootte { get; private set; }
    public DateTime AanmeldingsDatum { get; set; }

    public Groep(int groepId)
    {
        GroepId = groepId;
        GroepGrootte = _random.Next(1, 8);
        _bezoekers = new List<Bezoeker>(); //initiate bezoekers list
        AanmeldingsDatum = RandomAanmeldingsDatum();
    }

    public void AddBezoeker(Bezoeker bezoeker)
    {
        bezoeker.AanmeldingsDatum = AanmeldingsDatum;
        _bezoekers.Add(bezoeker);
    }

    public bool GroepHasVolwassenen()
    {
        return _bezoekers.Any(b => b.Leeftijd > 12);
    }
    
    public DateTime RandomAanmeldingsDatum()
    {
        int daysToSubtract = _random.Next(1, 30); //random number of days between 1 and 29
        int hoursToSubtract = _random.Next(0, 24); //random number of hours between 0 and 23
        int minutesToSubtract = _random.Next(0, 60); //random number of minutes between 0 and 59
        int secondsToSubtract = _random.Next(0, 60); //random number of seconds between 0 and 59
        AanmeldingsDatum = DateTime.Now -
                           new TimeSpan(daysToSubtract, hoursToSubtract, minutesToSubtract, secondsToSubtract);
        return AanmeldingsDatum;
    }

    public IEnumerable<Bezoeker> Bezoekers()
    {
        return _bezoekers;
    }
}