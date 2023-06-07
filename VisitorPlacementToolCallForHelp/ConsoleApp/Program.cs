using VisitorPlacementToolCallForHelp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EvenementData evenementData = new EvenementData();
            EvenementManager evenementManager = new EvenementManager(evenementData);
            
            int numBezoekers = 50;
            int numGroepen = 10;
            int numVakken = 4;
           
            evenementManager.GenerateEvent(numBezoekers, numGroepen, numVakken);
            
            DisplayEvenementInformation(evenementData.GetVakken()); //get list with all the vak information
            Console.ReadLine();
        }
        
        static void DisplayEvenementInformation(IEnumerable<Vak> vakken)
        {
            foreach (var vak in vakken)
            {
                Console.WriteLine("Vak number: " + vak.VakId);

                foreach (var rij in vak.Rijen)
                {
                    Console.WriteLine("Row ID: " + rij.RijId);

                    foreach (var stoel in rij.Stoelen)
                    {
                        if (stoel.Bezoeker != null)
                        {
                            Console.WriteLine("Stoel ID: " + stoel.StoelId + " - Bezoeker: Leeftijd - " + stoel.Bezoeker.Leeftijd + ", Aanmeldingsdatum - " + stoel.Bezoeker.AanmeldingsDatum + ", Groep ID - " + stoel.Bezoeker.GroepId);
                        }
                        else
                        {
                            Console.WriteLine("Stoel ID: " + stoel.StoelId + " - Empty chair");
                        }
                    }
                }

                int totalChairs = vak.Rijen[0].Stoelen.Count * vak.Rijen.Count;
                Console.WriteLine("Number of chairs per row: " + vak.Rijen[0].Stoelen.Count);
                Console.WriteLine("Total number of chairs: " + totalChairs);
                Console.WriteLine();
            }
        }
    }
}