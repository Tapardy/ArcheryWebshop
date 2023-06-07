namespace CircusTreinClassLibrary;

public class Train
{
    public List<Wagon> wagons = new List<Wagon>();

    public void AddAnimal(Animal animal)
    {
        bool addedToWagon = false;
        foreach (var wagon in wagons)
        {
            if (wagon.AddAnimal(animal))
            {
                addedToWagon = true;
                break;
            }
        }

        if (!addedToWagon)
        {
            var newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            wagons.Add(newWagon);
        }
    }
}

//ireadonly list
//int.tryparse voor de bool

