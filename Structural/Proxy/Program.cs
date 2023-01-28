// Заместитель - объект, который является посредником между
// двумя другими объектами, и который реализует/ограничивает
// доступ к объекту, к которому обращаются через него.

namespace Proxy;

class Program
{
    static void Main()
    {
        IMath x = new MathSimple();

        Console.WriteLine("4 + 2 = " + x.Add(4, 2));
        Console.WriteLine("4 - 2 = " + x.Sub(4, 2));
        Console.WriteLine("4 * 2 = " + x.Mul(4, 2));
        Console.WriteLine("4 / 2 = " + x.Div(4, 2));
    }
}


public interface IMath
{
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
}

class MathAdvance : IMath
{
    public MathAdvance()
    {
        Console.WriteLine("Создание модуля");
        Thread.Sleep(1000);
    }

    public double Add(double x, double y) => x + y;
    public double Sub(double x, double y) => x - y;
    public double Mul(double x, double y) => x * y;
    public double Div(double x, double y) => x / y;
}
class MathSimple : IMath
{
    MathAdvance? math;

    public MathSimple() => math = null;

    public double Add(double x, double y) => x + y;
    public double Sub(double x, double y) => x - y;


    public double Mul(double x, double y)
    {
        math ??= new MathAdvance();
        return math.Mul(x, y);
    }
    public double Div(double x, double y)
    {
        math ??= new MathAdvance();
        return math.Div(x, y);
    }
}
