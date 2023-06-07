namespace VisitorPlacementToolCallForHelp
{
    public class Vak
    {
        public List<Rij> Rijen { get; private set; }
        public int VakId { get; private set; }

        public Vak(int vakId)
        {
            VakId = vakId;
            Rijen = new List<Rij>();
        }

        public void AddRijToVak(Rij rij)
        {
            Rijen.Add(rij);
        }
    }
}