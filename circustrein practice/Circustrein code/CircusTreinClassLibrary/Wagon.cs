namespace CircusTreinClassLibrary;
public class Wagon
{
    public List<Animal> animals = new List<Animal>();
    public bool CanAddAnimal(Animal animal)
    {
        int totalSize = animals.Sum(a => (int)a.Size);
        if (totalSize + (int)animal.Size > 10)
        {
            return false;
        }

        if (animals.Any(a => a.Type == Type.Carnivore && (int)a.Size >= (int)animal.Size))
        {
            return false;
        }

        if (animal.Type == Type.Herbivore && animals.Any(a => a.Type == Type.Carnivore && (int)a.Size > (int)animal.Size))
        {
            return false;
        }
        return true;
    }
}


// public class Wagon
// {
//     public List<Animal> Animals { get; set; }
//     //private int TotalPoints { get { return Animals.Sum(a => (int)a.Size); } }
//
//     public Wagon()
//     {
//         Animals = new List<Animal>();
//     }
//
//     public bool CanAddAnimal(Animal animal)
//     {
//         int totalSize = Animals.Sum(a => (int)a.Size);
//         if (totalSize + (int)animal.Size > 10)
//         {
//             return false;
//         }
//
//         if (Animals.Any(a => a.Type == Type.Carnivore && (int)a.Size >= (int)animal.Size))
//         {
//             return false;
//         }
//         if (animal.Type == Type.Herbivore && Animals.Any(a => a.Type == Type.Carnivore && (int)a.Size > (int)animal.Size))
//         {
//             return false;
//         }
//         return true;
//     }
// }

// public bool CanAddAnimal(Animal animal)
    // {
    //     if (animal.Type == Type.Carnivore)
    //     {
    //         foreach (var a in Animals)
    //         {
    //             if (a.Type == Type.Carnivore || a.Size >= animal.Size)
    //             {
    //                 return false;
    //             }
    //         }
    //     }
    //     else// Herbivore
    //     {
    //         foreach (var a in Animals)
    //         {
    //             if (a.Type == Type.Carnivore && a.Size >= animal.Size)
    //             {
    //                 return false;
    //             }
    //         }
    //     }

        //return true;

        // foreach (var a in Animals)
            // {
            //     if (a.Type == Type.Carnivore && (int)a.Size >= (int)animal.Size)
            //     {
            //         return false;
            //     }
            //     if (a.Type == Type.Herbivore && (int)a.Size >= (int)animal.Size)
            //     {
            //         return false;
            //     }
            // }
    //     }
    //    return TotalPoints + (int)animal.Size <= 10;
    // }


