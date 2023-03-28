namespace CircusTreinClassLibrary;

public class Animal
{
    public Size Size { get; set; }
    public Type Type { get; set; }

    public Animal(Size size, Type type)
    {
        Size = size;
        Type = type;
    }
}