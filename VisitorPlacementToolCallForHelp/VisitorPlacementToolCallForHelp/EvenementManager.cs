namespace VisitorPlacementToolCallForHelp
{
    public class EvenementManager
    {
        private EvenementData _evenementData;

        public EvenementManager(EvenementData evenementData)
        {
            _evenementData = evenementData;
        }

        public void GenerateEvent(int numBezoekers, int numGroepen, int numVakken)
        {
            GenerateBezoekers(numBezoekers);
            GenerateGroepen(numGroepen);
            AddVakToEvenement(numVakken);
            SortBezoekersAndGroepen();
            AssignBezoekersToStoelen();
        }

        public void GenerateBezoekers(int numBezoekers)
        {
            _evenementData.GenerateBezoekers(numBezoekers);
        }

        public void GenerateGroepen(int numGroepen)
        {
            _evenementData.GenerateGroepen(numGroepen);
        }

        public void AddVakToEvenement(int numVakken)
        {
            _evenementData.GenerateVakInhoud(numVakken);

            if (_evenementData.GetVakken().Count() == numVakken)
            {
                Console.WriteLine($"Successfully generated {numVakken} vakken.");
            }
            else
            {
                Console.WriteLine(
                    $"Failed to generate {numVakken} vakken. Generated {_evenementData.GetVakken().Count()} vakken instead.");
            }
        }

        public void AssignBezoekersToStoelen()
        {
            var remainingBezoekers = _evenementData.GetBezoekers().ToList();
            var groepen = _evenementData.GetGroepen().ToList();
            var vakken = _evenementData.GetVakken().ToList();

            foreach (var vak in vakken)
            {
                var sortBezoekers = remainingBezoekers.ToList();
                RemoveInvalidGroepBezoekers(groepen, remainingBezoekers);

                foreach (var bezoeker in sortBezoekers)
                {
                    if (IsVakVol(vak))
                    {
                        break;
                    }

                    AssignBezoekerToNextAvailableStoel(bezoeker, vak);
                    remainingBezoekers.Remove(bezoeker);
                }
            }

            Console.WriteLine($"Groepen: {groepen.Count}");
            int unassignedCount = remainingBezoekers.Count;
            Console.WriteLine("Unassigned visitors: " + unassignedCount);
        }

        private void RemoveInvalidGroepBezoekers(List<Groep> groepen, List<Bezoeker> remainingBezoekers)
        {
            var invalidGroupIds = new List<int>();
            foreach (var groep in groepen)
            {
                if (!groep.GroepHasAdult())
                {
                    invalidGroupIds.Add(groep.GroepId);
                    remainingBezoekers.RemoveAll(b => b.GroepId == groep.GroepId);
                }
            }
        }

        private void AssignBezoekerToNextAvailableStoel(Bezoeker bezoeker, Vak vak)
        {
            var rij2 = vak.Rijen.Count() >= 2 ? vak.Rijen.ElementAt(1) : null;
            var rij3 = vak.Rijen.Count() >= 3 ? vak.Rijen.ElementAt(2) : null;

            if (bezoeker.IsKind() && bezoeker.GroepId != 0)
            {
                var rij1 = vak.Rijen.First();
                CanAssignBezoekerToNextAvailableStoel(bezoeker, rij1);
            }
            else if (bezoeker.IsKind() && bezoeker.GroepId == 0)
            {
                //skip assigning
            }
            else
            {
                if (rij2 != null)
                {
                    if (CanAssignBezoekerToNextAvailableStoel(bezoeker, rij2))
                        return;
                }

                if (rij3 != null)
                {
                    if (CanAssignBezoekerToNextAvailableStoel(bezoeker, rij3))
                        return;
                }

                if (!IsRijVol(vak.Rijen.First()))
                {
                    CanAssignBezoekerToNextAvailableStoel(bezoeker, vak.Rijen.First());
                }
            }
        }

        private bool CanAssignBezoekerToNextAvailableStoel(Bezoeker bezoeker, Rij rij)
        {
            if (rij != null)
            {
                var stoel = rij.Stoelen.FirstOrDefault(stoel => stoel.AssignStoelToBezoeker(bezoeker));
                return stoel != null;
            }

            return false;
        }

        public void SortBezoekersAndGroepen()
        {
            List<Groep> sortedGroepen = _evenementData.GetGroepen().ToList();
            sortedGroepen =
                sortedGroepen.OrderBy(g => g.GroepsAanmeldingsDatum).ToList(); // Sort groepen by GroepsAanmeldingsDatum

            List<Bezoeker> sortedBezoekers = _evenementData.GetBezoekers().ToList();
            sortedBezoekers =
                sortedBezoekers.OrderBy(b => b.AanmeldingsDatum).ThenBy(b => b.GroepId)
                    .ToList(); //sort bezoekers by aanmeldingsDatum, then by groepId

            //update the original lists with the sorted lists
            _evenementData.SetGroepen(sortedGroepen);
            _evenementData.SetBezoekers(sortedBezoekers);
        }

        public bool IsVakVol(Vak vak)
        {
            return vak.Rijen.All(rij => IsRijVol(rij));
        }

        private bool IsRijVol(Rij rij)
        {
            return rij.Stoelen.All(stoel => stoel.Bezoeker != null);
        }
    }
}