namespace VisitorPlacementTool4;

public class Evenement
{
    private List<Vak> _vakken;
    private List<Groep> _groepen;
    private List<Bezoeker> _bezoekers;
    private Random _random = new Random();

    public Evenement()
    {
        _vakken = new List<Vak>();
        _groepen = new List<Groep>();
        _bezoekers = new List<Bezoeker>();
    }

    public void CreateVakken(int numVakken)
    {
        if (numVakken < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numVakken), "Number of vakken cannot be negative.");
        }
        for (int i = 0; i < numVakken; i++)
        {
            int numRijen = _random.Next(1, 4);
            Vak vak = new Vak(i + 1);
            vak.CreateRijen(numRijen);
            _vakken.Add(vak);
        }
    }

    public void CreateGroepen(int numGroepen)
    {
        for (int i = 0; i < numGroepen; i++)
        {
            int groepId = _groepen.Count + 1; //generate groepId based on the current count of groepen

            Groep groep = new Groep(groepId);

            for (int k = 0; k < groep.GroepGrootte; k++)
            {
                Bezoeker bezoeker = new Bezoeker(groepId);
                groep.AddBezoeker(bezoeker);
                _bezoekers.Add(bezoeker);
            }

            _groepen.Add(groep);
        }
    }

    public void AssignBezoekersToStoelen()
    {
        var bezoekers = GetSortedBezoekers();
        var groepen = GetSortedGroepen();

        foreach (var vak in _vakken)
        {
            vak.AssignBezoekersToStoelen(groepen, bezoekers);

            if (IsEvenementVol())
            {
                break;
            }
        }

        Console.WriteLine($"Groepen: {_groepen.Count}");
        int totalVisitors = bezoekers.Count;
        Console.WriteLine("Total visitors: " + totalVisitors);
    }

    private List<Bezoeker> GetSortedBezoekers()
    {
        return _bezoekers
            .OrderBy(b => !_groepen.Any(g => g.Bezoekers().Contains(b)))
            .ThenBy(b => b.Leeftijd <= 12)
            .ThenBy(b => b.AanmeldingsDatum)
            .ToList();
    }

    private List<Groep> GetSortedGroepen()
    {
        return _groepen
            .OrderBy(g => g.AanmeldingsDatum)
            .ToList();
    }
    
    private bool IsEvenementVol()
    {
        return _vakken.All(vak => vak.IsVakVol());
    }

    public IEnumerable<Vak> GetVakken()
    {
        return _vakken;
    }

    public IEnumerable<Groep> GetGroepen()
    {
        return _groepen;
    }
}