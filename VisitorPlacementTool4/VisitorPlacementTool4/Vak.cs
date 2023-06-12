namespace VisitorPlacementTool4;

public class Vak
{
    private Random _random = new Random();
    private List<Rij> _rijen;
    public int VakId { get; }

    public Vak(int vakId)
    {
        VakId = vakId;
        _rijen = new List<Rij>();
    }

    public void CreateRijen(int numRijen)
    {
        if (numRijen < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numRijen), "Number of rijen cannot be negative.");
        }
        int numStoelen = _random.Next(3, 11);
        for (int i = 0; i < numRijen; i++)
        {
            Rij rij = new Rij(i + 1);
            rij.CreateStoelen(numStoelen);
            _rijen.Add(rij);
        }
    }

    public void AssignBezoekersToStoelen(List<Groep> groepen, List<Bezoeker> bezoekers)
    {
        List<Bezoeker> assignedChildren = new List<Bezoeker>();

        groepen = ExcludeGroepenWithoutVolwassenen(groepen);

        AssignKinderenToFirstRij(groepen, bezoekers, assignedChildren);
        AssignRemainingBezoekers(groepen, assignedChildren);
    }

    private List<Groep> ExcludeGroepenWithoutVolwassenen(List<Groep> groepen)
    {
        return groepen.Where(g => g.GroepHasVolwassenen()).ToList();
    }

    private void AssignKinderenToFirstRij(List<Groep> groepen, List<Bezoeker> bezoekers, List<Bezoeker> assignedChildren)
    {
        foreach (var bezoeker in bezoekers)
        {
            if (bezoeker.IsKind() && groepen.Any(g => g.Bezoekers().Contains(bezoeker)))
            {
                var rij1 = _rijen[0];
                rij1.AssignBezoekersToStoelen(new List<Groep>
                {
                    groepen.First(g => g.Bezoekers().Contains(bezoeker))
                });
                assignedChildren.Add(bezoeker);
            }
        }
    }

    private void AssignRemainingBezoekers(List<Groep> groepen, List<Bezoeker> assignedChildren)
    {
        foreach (var rij in _rijen)
        {
            rij.AssignBezoekersToStoelen(groepen.Where(g => !g.Bezoekers().Any(b => assignedChildren.Contains(b))).ToList());

            if (IsVakVol())
            {
                break;
            }
        }
    }


    public bool IsVakVol()
    {
        return _rijen.All(rij => rij.IsRijVol());
    }
    
    public IEnumerable<Rij> GetRijen()
    {
        return _rijen;
    }
}