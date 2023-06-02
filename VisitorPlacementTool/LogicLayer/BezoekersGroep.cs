namespace LogicLayer;

public class BezoekersGroep
{
    public List<Bezoeker> Bezoekers { get; }

    public BezoekersGroep()
    {
        Bezoekers = new List<Bezoeker>();
    }

    public void AddBezoeker(Bezoeker bezoeker)
    {
        Bezoekers.Add(bezoeker);
    }
}