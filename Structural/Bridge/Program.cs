// Мост — это структурный паттерн проектирования,
// который разделяет один или несколько классов на две отдельные иерархии,
// абстракцию и реализацию, позволяя изменять их независимо друг от друга.

namespace Bridge;

class Program
{
    static void Main()
    {
        Circle circle = new();
        circle.color = new Red();
        circle.Print();

        Square square = new();
        square.color = new Blue();
        square.Print();

        Circle circle2 = new();
        circle2.Print();
    }
}


class Figure
{
    public Color? color { get; set; }
}
class Circle : Figure
{
    public void Print()
    {
        if (color != null)
            Console.WriteLine("Я круг цвета " + color.ColorPrint());
        else
            Console.WriteLine("Я круг");
    }
}
class Square : Figure
{
    public void Print()
    {
        if (color != null)
            Console.WriteLine("Я квадрат цвета " + color.ColorPrint());
        else
            Console.WriteLine("Я квадрат");
    }
}

abstract class Color
{
    public abstract string ColorPrint();
}
class Red : Color
{
    public override string ColorPrint() => "Красный";
}
class Blue : Color
{
    public override string ColorPrint() => "Синий";
}
