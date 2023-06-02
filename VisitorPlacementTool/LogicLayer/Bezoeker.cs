namespace LogicLayer;

public class Bezoeker
{
    public int Leeftijd { get; set; }
    public string Naam { get; set; }

    public Bezoeker(string naam, int leeftijd)
    {
        Naam = naam;
        Leeftijd = leeftijd;
    }

    public bool IsKind()
    {
        if (Leeftijd <= 12)
        {
            return true;
        }
        return false;
    }
}