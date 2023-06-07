namespace VisitorPlacementToolCallForHelp
{
    public class EvenementData
    {
        private List<Vak> _vakken;
        private List<Bezoeker> _bezoekers;
        private List<Groep> _groepen;
        private Random _random;
        private DateTime _aanmeldingsDatum;

        public EvenementData()
        {
            _vakken = new List<Vak>();
            _bezoekers = new List<Bezoeker>();
            _groepen = new List<Groep>();
            _random = new Random();
        }

        public void GenerateVakInhoud(int numVakken)
        {
            for (int i = 0; i < numVakken; i++)
            {
                Vak vak = new Vak(i + 1);
                int numRijen = _random.Next(1, 4); //random number of rows between 1 and 3
                int numSeatsPerRow = _random.Next(3, 11); //random number of seats per row between 3 and 10

                for (int j = 0; j < numRijen; j++)
                {
                    Rij rij = new Rij(j + 1);

                    for (int k = 0; k < numSeatsPerRow; k++)
                    {
                        int stoelId = j * numSeatsPerRow + k + 1;
                        Stoel stoel = new Stoel(stoelId);
                        rij.AddStoelToRij(stoel);
                    }

                    vak.AddRijToVak(rij);
                }

                _vakken.Add(vak);
            }
        }

        public void GenerateGroepen(int numGroepen)
        {
            int groepId = 1;
            for (int i = 0; i < numGroepen; i++)
            {
                int groepGrootte = _random.Next(3, 6); //random group size between 3 and 5
                int daysToSubtract = _random.Next(1, 30); //random number of days between 1 and 29
                int hoursToSubtract = _random.Next(0, 24); //random number of hours between 0 and 23
                int minutesToSubtract = _random.Next(0, 60); //random number of minutes between 0 and 59
                int secondsToSubtract = _random.Next(0, 60); //random number of seconds between 0 and 59
                _aanmeldingsDatum = DateTime.Now -
                                    new TimeSpan(daysToSubtract, hoursToSubtract, minutesToSubtract, secondsToSubtract);

                Groep groep = new Groep(groepId, _aanmeldingsDatum, groepGrootte); //create a new Groep object with the current groepId

                for (int k = 0; k < groepGrootte; k++)
                {
                    int leeftijd = _random.Next(1, 20); //random age between 1 and 99
                    Bezoeker bezoeker = new Bezoeker(leeftijd, _aanmeldingsDatum, groepId);
                    groep.AddBezoeker(bezoeker); //add the bezoeker to the groep
                    _bezoekers.Add(bezoeker);
                }

                _groepen.Add(groep); //add the groep to the list of groepen
                groepId++;
            }
        }
        
        public void GenerateBezoekers(int numBezoekers)
        {
            for (int i = 0; i < numBezoekers; i++)
            {
                int leeftijd = _random.Next(1, 100); //random age between 1 and 99
                int daysToSubtract = _random.Next(1, 30); //random number of days between 1 and 29
                int hoursToSubtract = _random.Next(0, 24); //random number of hours between 0 and 23
                int minutesToSubtract = _random.Next(0, 60); //random number of minutes between 0 and 59
                int secondsToSubtract = _random.Next(0, 60); //random number of seconds between 0 and 59

                _aanmeldingsDatum = DateTime.Now -
                                    new TimeSpan(daysToSubtract, hoursToSubtract, minutesToSubtract, secondsToSubtract);
                
                Bezoeker bezoeker = new Bezoeker(leeftijd, _aanmeldingsDatum);
                _bezoekers.Add(bezoeker);
            }
        }

        public void SetGroepen(List<Groep> groepen)
        {
            _groepen = groepen;
        }

        public void SetBezoekers(List<Bezoeker> bezoekers)
        {
            _bezoekers = bezoekers;
        }

        public IEnumerable<Bezoeker> GetBezoekers()
        {
            return _bezoekers;
        }

        public IEnumerable<Groep> GetGroepen()
        {
            return _groepen;
        }

        public IEnumerable<Vak> GetVakken()
        {
            return _vakken;
        }
    }
}
