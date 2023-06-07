namespace ConsoleApp;

using CircusTreinClassLibrary;

class Program
{
    private static void Main()
    {
        var train = new Train();
        int wagonCount = train.wagons.Count;
        while (true)
        {
            while (true)
            {
                Console.WriteLine(
                    "Enter the size of the animal (1 for small, 3 for medium, 5 for large) or -1 to stop:");
                var sizeInputString = Console.ReadLine();
                if (string.IsNullOrEmpty(sizeInputString))
                {
                    Console.WriteLine("Invalid size");
                    continue;
                }

                if (!int.TryParse(sizeInputString, out int sizeInput))
                {
                    Console.WriteLine("Invalid size");
                    continue;
                }

                if (sizeInput == -1)
                {
                    break;
                }
                else if (sizeInput != 1 && sizeInput != 3 && sizeInput != 5)
                {
                    Console.WriteLine("Invalid size");
                }
                else
                {
                    var size = (Size)sizeInput;

                    Console.WriteLine("Enter the type of the animal (carnivore or herbivore):");
                    var typeInput = Console.ReadLine()!.ToLower();

                    if (string.IsNullOrEmpty(typeInput) || (typeInput != "carnivore" && typeInput != "herbivore"))
                    {
                        Console.WriteLine("Invalid type");
                        continue;
                    }

                    Type type;
                    if (typeInput == "carnivore")
                    {
                        type = Type.Carnivore;
                    }
                    else
                    {
                        type = Type.Herbivore;
                    }

                    var animal = new Animal(size, type);

                    train.AddAnimal(animal);
                }
            }

            //Console.WriteLine($"Train has {wagonCount} wagon{(wagonCount > 1 ? "s" : "")}:");
            foreach (var wagon in train.wagons)
            {
                Console.WriteLine("Wagon with animals:");
                foreach (var animal in wagon.Animals)
                {
                    Console.WriteLine($"Size: {animal.Size}, Type: {animal.Type}");
                }
            }
            Console.ReadLine();
        }
    }
}