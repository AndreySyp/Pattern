// Одиночка — это порождающий паттерн проектирования,
// который гарантирует, что у класса есть только один экземпляр,
// и предоставляет к нему глобальную точку доступа.

namespace Singleton;

class Program
{
    static void Main()
    {
        Computer comp = new();
        comp.Launch("Windows 8.1");
        Console.WriteLine(comp.OS.Name);

        comp.OS = OS.getInstance("Windows 10");
        Console.WriteLine(comp.OS.Name);
    }
}


class Computer
{
    public OS OS { get; set; }

    public void Launch(string osName) => OS = OS.getInstance(osName);
}
class OS
{
    private static OS instance;
    public string Name { get; set; }

    protected OS(string name) => Name = name;

    public static OS getInstance(string name) => instance ??= new OS(name);
}
