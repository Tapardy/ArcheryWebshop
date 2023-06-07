namespace CircusTreinClassLibrary;

public class Animal
{
    public Size Size { get; private set; }
    public Type Type { get; private set; }

    public Animal(Size size, Type type)
    {
        Size = size;
        Type = type;
    }
    
    public bool AnimalDiet(Animal otherAnimal)
    {

        //Carnivore eats animals equal, or smaller than them
        if (this.Type == Type.Carnivore && otherAnimal.Size > this.Size)
        {
            return false;
        }
        
        //Herbivores eat plants, not animals
        if (this.Type == Type.Herbivore && otherAnimal.Type == Type.Carnivore)
        {
            return false;
        }
        
        return true;
    }

}