namespace CircusTreinClassLibrary;
public class Train
{
    private List<Wagon> wagons;
    public Train()
    {
        wagons = new List<Wagon>();
    }

    public void AddAnimal(Animal animal)
    {
        var addedToWagon = false;
        foreach (var wagon in wagons)
        {
            if (wagon.CanAddAnimal(animal))
            {
                wagon.animals.Add(animal);
                addedToWagon = true;
                break;
            }
        }

        if (!addedToWagon)
        {
            var newWagon = new Wagon();
            newWagon.animals.Add(animal);
            wagons.Add(newWagon);
        }
    }

    public void DisplayWagons()
    {
        int wagonCount = wagons.Count;
        Console.WriteLine($"Train has {wagonCount} wagon{(wagonCount > 1 ? "s" : "")}:");
        foreach (var wagon in wagons)
        {
            Console.WriteLine("Wagon with animals:");
            foreach (var animal in wagon.animals)
            {
                Console.WriteLine($"Size: {animal.Size}, Type: {animal.Type}");
            }
        }
    }
}
