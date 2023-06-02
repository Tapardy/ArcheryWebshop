namespace LogicLayer;

public class Vak
{
    public List<Rij> Rijen { get; set; }
    public char VakLetter { get; set; }
    public Vak(char vakLetter)
    {
        Rijen = new List<Rij>();
        VakLetter = vakLetter;
    }
    
    // public bool AssignBezoekersToStoelen(List<Bezoeker> pendingKinderen, List<Bezoeker> pendingVolwassenen)
    // {
    //     bool assignedKinderen = AssignKinderenToStoelen(pendingKinderen);
    //     bool assignedVolwassenen = AssignVolwassenenToStoelen(pendingVolwassenen);
    //
    //     return assignedKinderen && assignedVolwassenen;
    // }
    //
    //
    // private bool AssignKinderenToStoelen(List<Bezoeker> pendingBezoekers)
    // {
    //     bool assigned = false;
    //
    //     foreach (var bezoeker in pendingBezoekers)
    //     {
    //         foreach (var rij in Rijen)
    //         {
    //             if (bezoeker.IsKind() && !rij.IsVol())
    //             {
    //                 var stoel = rij.GetAvailableKinderStoel();
    //                 if (stoel != null)
    //                 {
    //                     stoel.Bezoeker = bezoeker;
    //                     assigned = true;
    //                     break;
    //                 }
    //             }
    //         }
    //     }
    //
    //     return assigned;
    // }
    //
    //
    // private bool AssignVolwassenenToStoelen(List<Bezoeker> pendingBezoekers)
    // {
    //     bool assigned = false;
    //
    //     foreach (var bezoeker in pendingBezoekers)
    //     {
    //         foreach (var rij in Rijen)
    //         {
    //             if (!rij.IsVol())
    //             {
    //                 var stoel = rij.GetAvailableStoel();
    //                 if (stoel != null)
    //                 {
    //                     stoel.Bezoeker = bezoeker;
    //                     assigned = true;
    //                     break;
    //                 }
    //             }
    //             
    //             
    //         }
    //     }
    //
    //     return assigned;
    // }

    //voegrijtoe(rij rij)
    public void AddRij()
    {
        Random rnd = new Random();
        int numRij = rnd.Next(1, 4);
        int numStoel = rnd.Next(3, 11);

        for (int i = 0; i < numRij; i++)
        {
            Rij rij = new Rij
            {
                RijId = Rijen.Count + 1
            };
            rij.AddStoel(numStoel); // Generate the seats for the row
            Rijen.Add(rij);
        }
    }

    public bool IsVol()
    {
        return Rijen.All(r => r.IsVol());
    }
    public bool AssignBezoekersToStoelen(List<Bezoeker> pendingBezoekers)
    {
        bool assigned = false;
        bool kinderenAssigned = false;
    
        foreach (var bezoeker in pendingBezoekers)
        {
            var frontRij = Rijen.FirstOrDefault(r => r.RijId == 1); // Get the front row
    
            if (bezoeker.IsKind() && frontRij != null && !frontRij.IsVol())
            {
                var stoel = frontRij.GetAvailableKinderStoel();
                if (stoel != null)
                {
                    stoel.Bezoeker = bezoeker;
                    assigned = true;
                    kinderenAssigned = true;
                }
            }
        }
    
        if (!kinderenAssigned)
        {
            foreach (var bezoeker in pendingBezoekers)
            {
                foreach (var rij in Rijen)
                {
                    if (rij.RijId == 1 && bezoeker.IsKind() == false)
                        continue; // Skip the front row for bezoekers above 12 years old
    
                    if (!rij.IsVol())
                    {
                        var stoel = rij.GetAvailableStoel();
                        if (stoel != null)
                        {
                            stoel.Bezoeker = bezoeker;
                            assigned = true;
                            break;
                        }
                    }
                }
    
                if (assigned)
                {
                    break;
                }
            }
        }
    
        return assigned;
    }
}