namespace VisitorPlacementToolCallForHelp
{
    public class Rij
    {
        public int RijId { get; private set; }
        public List<Stoel> Stoelen { get; private set; }

        public Rij(int rijId)
        {
            RijId = rijId;
            Stoelen = new List<Stoel>();
        }

        public void AddStoelToRij(Stoel stoel)
        {
            Stoelen.Add(stoel);
        }
    }
}