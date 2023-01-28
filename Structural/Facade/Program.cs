// Фасад — это структурный паттерн проектирования,
// который предоставляет простой интерфейс к сложной
// системе классов, библиотеке или фреймворку.

namespace Facade;
class Program
{
    public static void Main()
    {
        RockBand rockBand = new();
        rockBand.PlayStart();
        rockBand.PlayMiddle();
        rockBand.PlayEnd();
    }
}


class Human
{
    public readonly string name;
    public Human(string name) => this.name = name;
}
class Vocalist : Human
{
    public Vocalist(string name) : base(name) { }
    public string Sings() => name + ": Поет";
}
class Drummer : Human
{
    public Drummer(string name) : base(name) { }
    public string Play() => name + ": Играет на барабане";
}
class GuitarPlayer : Human
{
    public GuitarPlayer(string name) : base(name) { }
    public string Play() => name + ": Играет на гитаре";
}
class TrianglePlayer : Human
{
    public TrianglePlayer(string name) : base(name) { }
    public string Play() => name + ": Играет на треугольнике";
}

class RockBand
{
    Vocalist vocalist = new("Дима");
    Drummer drummer = new("Саша");
    GuitarPlayer guitarPlayer = new("Егор");
    TrianglePlayer trianglePlayer = new("Антон");

    public void PlayStart()
    {
        Console.WriteLine("Начало");
        Console.WriteLine(guitarPlayer.Play());
        Console.WriteLine();
    }
    public void PlayMiddle()
    {
        Console.WriteLine("Середина");
        Console.WriteLine(vocalist.Sings());
        Console.WriteLine(guitarPlayer.Play());
        Console.WriteLine(drummer.Play());
        Console.WriteLine();
    }
    public void PlayEnd()
    {
        Console.WriteLine("Конец");
        Console.WriteLine(trianglePlayer.Play());
        Console.WriteLine();
    }
}// Фасад.
