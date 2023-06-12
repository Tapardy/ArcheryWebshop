namespace VisitorPlacementTool4;

public class Stoel
{
    private Bezoeker _bezoeker;
    public int StoelId { get; private set; }

    public Stoel(int stoelId)
    {
        StoelId = stoelId;
    }
    
    public bool CanAssignStoelToBezoeker(Bezoeker bezoeker)
    {
        if (!IsBezet())
        {
            AssignBezoekerToStoel(bezoeker);
            return true;
        }

        return false;
    }

    private void AssignBezoekerToStoel(Bezoeker bezoeker)
    {
        _bezoeker = bezoeker;
    }
    
    public bool IsBezet()
    {
        return _bezoeker != null;
    }
    
    public Bezoeker GetBezoeker()
    {
        return _bezoeker;
    }
}