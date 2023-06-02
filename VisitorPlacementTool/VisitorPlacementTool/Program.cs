using LogicLayer;

class Program
{
    static void Main()
    {
        Evenement evenement = new Evenement();

        // Add visitors to the event compartments
        evenement.AddBezoekerToVak("kind1", 12);
        evenement.AddBezoekerToVak("kind2", 10);
        evenement.AddBezoekerToVak("adult1", 25);
        evenement.AddBezoekerToVak("adult2", 20);
        evenement.AddBezoekerToVak("adult3", 20);
        evenement.AddBezoekerToVak("kind3", 10);
        evenement.AddBezoekerToVak("adult4", 25);
        evenement.AddBezoekerToVak("kind4", 8);
        evenement.AddBezoekerToVak("kind5", 12);
        evenement.AddBezoekerToVak("adult5", 30);
        evenement.AddBezoekerToVak("adult6", 25);
        evenement.AddBezoekerToVak("adult7", 90);
        evenement.AddBezoekerToVak("kind6", 12);
        evenement.AddBezoekerToVak("adult8", 32);
        evenement.AddBezoekerToVak("adult9", 25);
        evenement.AddBezoekerToVak("kind7", 8);
        evenement.AssignBezoekersToStoelen();
        // Print the event details
        PrintEventDetails(evenement);
    }

    static void PrintEventDetails(Evenement myEvent)
    {
        foreach (var vak in myEvent.Vakken)
        {
            string vakLetter = vak.VakLetter.ToString(); // Convert to string
            Console.WriteLine($"Vak: {vakLetter}");

            foreach (var rij in vak.Rijen)
            {
                Console.WriteLine($"Rij: {rij.RijId}");

                foreach (var stoel in rij.Stoelen)
                {
                    if (stoel.Bezoeker != null)
                    {
                        Console.WriteLine($"Stoel: {stoel.StoelId} | Bezoeker: {stoel.Bezoeker.Naam}");
                    }
                    else
                    {
                        Console.WriteLine($"Stoel: {stoel.StoelId} | Unoccupied");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
