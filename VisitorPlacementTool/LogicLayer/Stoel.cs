namespace LogicLayer;

public class Stoel
{
    public int StoelId { get; set; }
    public Bezoeker Bezoeker { get; set; }

    public Stoel(int stoelId)
    {
        StoelId = stoelId;
    }

    public bool IsBezet()
    {
        return Bezoeker != null;
    }
}