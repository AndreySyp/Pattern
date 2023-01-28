// Компоновщик — это структурный паттерн проектирования,
// который позволяет сгруппировать множество объектов в древовидную структуру,
// а затем работать с ней так, как будто это единичный объект.

namespace Composite;

class Program
{
    static void Main()
    {
        Brigade brigadeMain = new("Бригада основная");

        brigadeMain.Add(new Regiment("Полк рязанский"));
        brigadeMain.Add(new Regiment("Полк псковский"));

        Brigade brigadeSupport = new("Бригада поддержки");
        brigadeSupport.Add(new Regiment("Полк артиллерии"));
        brigadeSupport.Add(new Regiment("Полк минометов"));

        brigadeMain.Add(brigadeSupport);
        brigadeMain.Add(new Regiment("Полк ростовский"));

        Regiment leaf = new("Полк минский");
        brigadeMain.Add(leaf);
        brigadeMain.Remove(leaf);

        brigadeMain.Print(0);
    }
}


abstract class Army
{
    protected string name;

    public Army(string name) => this.name = name;

    public abstract void Print(int spaceAmount);
}
class Brigade : Army
{
    private List<Army> subordinates = new();

    public Brigade(string name) : base(name) { }

    public void Add(Army component) => subordinates.Add(component);
    public void Remove(Army component) => subordinates.Remove(component);

    public override void Print(int spaceAmount)
    {
        Console.WriteLine(new string(' ', spaceAmount) + name);

        foreach (Army sub in subordinates)
            sub.Print(spaceAmount + 4);
    }
}
class Regiment : Army
{
    public Regiment(string name) : base(name) { }

    public override void Print(int spaceAmount)
        => Console.WriteLine(new string(' ', spaceAmount) + name);
}
