namespace VisitorPlacementTool4;

public class Rij
{
    private List<Stoel> _stoelen;
    public int RijId { get; private set; }
    public Rij(int rijId)
    {
        _stoelen = new List<Stoel>();
        RijId = rijId;
    }

    public void CreateStoelen(int numStoelen)
    {
        for (int i = 0; i < numStoelen; i++)
        {
            Stoel stoel = new Stoel(i + 1);
            _stoelen.Add(stoel);
        }
    }

    public bool IsRijVol()
    {
        return _stoelen.All(stoel => stoel.IsBezet());
    }

    public void AssignBezoekersToStoelen(List<Groep> groepen)
    {
        foreach (var stoel in _stoelen)
        {
            if (stoel.IsBezet())
            {
                continue;
            }

            foreach (var groep in groepen)
            {
                var bezoeker = groep.Bezoekers().FirstOrDefault(b => !b.Assigned);
                if (bezoeker != null && stoel.CanAssignStoelToBezoeker(bezoeker))
                {
                    bezoeker.Assigned = true; //set bezoeker to assigned
                    break; //break the loop after assigning a bezoeker to a stoel
                }
            }
        }
    }
    
    public IEnumerable<Stoel> GetStoelen()
    {
        return _stoelen;
    }
}