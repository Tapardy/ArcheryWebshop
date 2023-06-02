namespace LogicLayer;

public class Evenement
{
    public IReadOnlyList<Vak> Vakken => _vakken;
    private List<Vak> _vakken;
    private List<Bezoeker> _pendingBezoekers = new List<Bezoeker>();
    private char nextVakLetter = 'A';

    public Evenement()
    {
        _vakken = new List<Vak>();
    }

    public void AddBezoekerToVak(string bezoekersNaam, int leeftijd)
    {
        _pendingBezoekers.Add(new Bezoeker(bezoekersNaam, leeftijd));
    }


    public Vak CreateNewVak(char vakLetter)
    {
        var vak = new Vak(vakLetter);

        vak.AddRij(); // Call AddRij method to create new rows for the vak
        _vakken.Add(vak);
        nextVakLetter++;
        return vak;
    }
//filter aanmeldingsdatum, boven max bezoekers afknippen

    public void AssignBezoekersToStoelen()
    {
        int currentVakIndex = 0;
    
    
        while (_pendingBezoekers.Count > 0)
        {
            var vak = GetNextAvailableVak(currentVakIndex);
            if (vak == null)
            {
                vak = CreateNewVak(nextVakLetter); // Create a new vak if there is no available vak
            }
    
            if (vak.AssignBezoekersToStoelen(_pendingBezoekers)) // Assign bezoekers to seats in the current vak
            {
                _pendingBezoekers.RemoveAll(v => vak.Rijen.Any(r => r.Stoelen.Any(s => s.Bezoeker == v)));
            }
            else
            {
                // If bezoekers cannot be assigned to the current vak, move to the next vak
                currentVakIndex++;
            }
        }
    }
    
    
    
//     public void AssignBezoekersToStoelen()
//     {
//         int currentVakIndex = 0;
//     
//         while (_pendingBezoekers.Count > 0)
//         {
//             List<Bezoeker> pendingKinderen = _pendingBezoekers.Where(b => b.IsKind()).ToList();
//             List<Bezoeker> pendingVolwassenen = _pendingBezoekers.Where(b => !b.IsKind()).ToList();
// //order aanmeldingsdatum
// //limiteer lijst op bezoekers
//             var vak = GetNextAvailableVak(currentVakIndex);
//             if (vak == null)
//             {
//                 vak = CreateNewVak(nextVakLetter); // Create a new vak if there is no available vak
//             }
//             if (vak.AssignBezoekersToStoelen(pendingKinderen, pendingVolwassenen))
//             {
//                 _pendingBezoekers.RemoveAll(v => vak.Rijen.Any(r => r.Stoelen.Any(s => s.Bezoeker == v)));
//             }
// //lijst, order by -> foreach
//             else
//             {
//                 Console.WriteLine("Failed to assign visitors to seats.");
//
//                 currentVakIndex++; // Move to the next vak
//             }
//         }
//     }


    private Vak GetNextAvailableVak(int startIndex)
    {
        for (int i = startIndex; i < _vakken.Count; i++)
        {
            if (!_vakken[i].IsVol())
            {
                return _vakken[i];
            }
        }

        return null;
    }
    
    public int PendingBezoekersCount()
    {
        return _pendingBezoekers.Count;
    }

    public int TotalAssignedBezoekersCount()
    {
        int assignedCount = 0;

        foreach (var vak in _vakken)
        {
            foreach (var rij in vak.Rijen)
            {
                assignedCount += rij.Stoelen.Count(s => s.Bezoeker != null);
            }
        }

        return assignedCount;
    }
}