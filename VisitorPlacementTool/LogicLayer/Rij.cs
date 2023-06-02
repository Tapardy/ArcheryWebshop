namespace LogicLayer;

public class Rij
{
    public int RijId { get; set; }
    public IReadOnlyList<Stoel> Stoelen => _stoelen;

    private List<Stoel> _stoelen;

    public Rij()
    {
        _stoelen = new List<Stoel>();
    }

    public void AddStoel(int numStoel)
    {
        for (int i = 0; i < numStoel; i++)
        {
            Stoel stoel = new Stoel(i + 1);
            _stoelen.Add(stoel);
        }
    }

    public bool IsVol()
    {
        return Stoelen.All(s => s.IsBezet());
    }

    public Stoel GetAvailableKinderStoel()
    {
        return Stoelen.FirstOrDefault(s => !s.IsBezet());
    }

    public Stoel GetAvailableStoel()
    {
        return Stoelen.FirstOrDefault(s => !s.IsBezet());
    }

    // public bool AddBezoekerToRij(string bezoekersNaam, int leeftijd)
    // {
    //     var stoel = _stoelen.FirstOrDefault(s => !s.IsBezet());
    //     if (stoel == null)
    //         return false;
    //
    //     stoel.Bezoeker = new Bezoeker(bezoekersNaam, leeftijd); // Assuming the Bezoeker class constructor only takes name and age parameters
    //
    //     if (stoel.Bezoeker.IsChild())
    //     {
    //         var stoelForChild = GetAvailableChildStoel();
    //         if (stoelForChild != null)
    //         {
    //             stoelForChild.Bezoeker = stoel.Bezoeker;
    //             stoel.Bezoeker = null;
    //             return true;
    //         }
    //     }
    //     else
    //     {
    //         var stoelForAdult = GetAvailableStoel();
    //         if (stoelForAdult != null)
    //         {
    //             stoelForAdult.Bezoeker = stoel.Bezoeker;
    //             stoel.Bezoeker = null;
    //             return true;
    //         }
    //     }
    //
    //     return true;
    // }
}