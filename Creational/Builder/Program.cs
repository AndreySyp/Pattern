// это порождающий паттерн проектирования, который позволяет
// создавать сложные объекты пошагово. Строитель даёт возможность
// использовать один и тот же код строительства для получения
// разных представлений объектов.

namespace Builder;

class Program
{
    static void Main()
    {
        Builder builder = new();

        House h1 = builder.Build(new ProletarianBuilder());
        h1.Print();

        Console.WriteLine();
        House h2 = builder.Build(new EliteBuilder());
        h2.Print();
    }
}


class Walls
{
    public string Type { get; set; }
}
class Roof
{
    public string Type { get; set; }
}

class House
{
    public Walls Walls { get; set; }
    public Roof Roof { get; set; }

    public void Print()
    {
        if (Walls != null)
            Console.WriteLine("Стены из " + Walls.Type);
        if (Roof != null)
            Console.WriteLine("Крышка из " + Roof.Type);
    }
}

class Builder
{
    public House Build(HouseBuilder houseBuilder)
    {
        houseBuilder.BuildHouse();
        houseBuilder.BuildWalls();
        houseBuilder.BuildRoof();

        return houseBuilder.House;
    }
}

abstract class HouseBuilder
{
    public House House { get; set; }
    public void BuildHouse() => House = new House();
    public abstract void BuildRoof();
    public abstract void BuildWalls();
}
class ProletarianBuilder : HouseBuilder
{
    public override void BuildRoof()
        => House.Walls = new Walls { Type = "панелей" };
    public override void BuildWalls()
        => House.Roof = new Roof { Type = "дерева" };
}
class EliteBuilder : HouseBuilder
{
    public override void BuildRoof()
        => House.Walls = new Walls { Type = "кирпич" };
    public override void BuildWalls()
        => House.Roof = new Roof { Type = "черепица" };
}
