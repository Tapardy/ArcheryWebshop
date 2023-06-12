using VisitorPlacementTool4;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Evenement evenement = new Evenement();
            evenement.CreateVakken(3);
            evenement.CreateGroepen(20);
            evenement.AssignBezoekersToStoelen();

            IEnumerable<Vak> vakken = evenement.GetVakken();
            IEnumerable<Groep> groepen = evenement.GetGroepen();

            Console.WriteLine("Vakken:");
            foreach (var vak in vakken)
            {
                Console.WriteLine($"Vak {vak.VakId}:");
                foreach (var rij in vak.GetRijen())
                {
                    Console.WriteLine($"  Rij {rij.RijId}:");
                    foreach (var stoel in rij.GetStoelen())
                    {
                        if (stoel.IsBezet())
                        {
                            Bezoeker bezoeker = stoel.GetBezoeker();
                            Console.WriteLine($"    Stoel {stoel.StoelId}: Bezoeker GroepId={bezoeker.GroepId}, Leeftijd={bezoeker.Leeftijd}");
                        }
                        else
                        {
                            Console.WriteLine($"    Stoel {stoel.StoelId}: Unassigned");
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Groepen:");
            foreach (var groep in groepen)
            {
                Console.WriteLine($"Groep {groep.GroepId}:");
                foreach (var bezoeker in groep.Bezoekers())
                {
                    Console.WriteLine($"- Bezoeker GroepId={bezoeker.GroepId}, Leeftijd={bezoeker.Leeftijd}, AanmeldingsDatum={bezoeker.AanmeldingsDatum}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
