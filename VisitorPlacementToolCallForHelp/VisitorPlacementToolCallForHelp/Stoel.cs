namespace VisitorPlacementToolCallForHelp
{
    public class Stoel
    {
        public int StoelId { get; private set; }
        public Bezoeker Bezoeker { get; private set; }

        public Stoel(int stoelId)
        {
            StoelId = stoelId;
        }
        
        public bool AssignStoelToBezoeker(Bezoeker bezoeker)
        {
            if (Bezoeker == null)
            {
                Bezoeker = bezoeker;
                return true;
            }

            return false;
        }

    }
}