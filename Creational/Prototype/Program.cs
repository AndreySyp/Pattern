// Прототип — это порождающий паттерн проектирования, который
// позволяет копировать объекты, не вдаваясь в подробности их реализации.

namespace Prototype;

class Program
{
    static void Main()
    {
        IFigure figure = new Rectangle(30, 40);
        IFigure clonedFigure = figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();
    }
}


interface IFigure
{
    IFigure Clone();
    void GetInfo();
}

class Rectangle : IFigure
{
    private int width;
    private int height;

    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }

    public IFigure Clone() => new Rectangle(width, height);
    public void GetInfo() => Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
}
