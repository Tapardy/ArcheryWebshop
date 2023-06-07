namespace VisitorPlacementToolCallForHelp
{
    public class Bezoeker
    {
        public int Leeftijd { get; private set; }
        public DateTime AanmeldingsDatum { get; private set; }
        public int GroepId { get; private set; }

        public Bezoeker(int leeftijd, DateTime aanmeldingsDatum)
        {
            Leeftijd = leeftijd;
            AanmeldingsDatum = aanmeldingsDatum;
        }

        public Bezoeker(int leeftijd, DateTime aanmeldingsDatum, int groepId)
        {
            Leeftijd = leeftijd;
            AanmeldingsDatum = aanmeldingsDatum;
            GroepId = groepId;
        }

        public bool IsKind()
        {
            return Leeftijd <= 12;
        }
    }
}
