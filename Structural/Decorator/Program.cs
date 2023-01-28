// Декоратор — структурный шаблон проектирования, предназначенный
// для динамического подключения дополнительного поведения к объекту.
// Шаблон Декоратор предоставляет гибкую альтернативу практике создания
// подклассов с целью расширения функциональности.

namespace Decorator;

class Program
{
    static void Main()
    {

        ConcreteDecoratorA dA = new()
        {
            Component = new ConcreteComponent()
        };

        ConcreteDecoratorB dB = new()
        {
            Component = dA
        };

        dA.Operation();
        Console.WriteLine();

        dB.Operation();
        Console.WriteLine();
    }
}

abstract class Component
{
    public abstract void Operation();
}
abstract class Decorator : Component
{
    public Component? Component { set; get; }

    public override void Operation()
    {
        if (Component != null)
            Component.Operation();
    }
}

class ConcreteComponent : Component
{
    public override void Operation() => Console.Write("Привет");
}

class ConcreteDecoratorA : Decorator
{
    public override void Operation() => base.Operation();
}
class ConcreteDecoratorB : Decorator
{
    public override void Operation()
    {
        base.Operation();
        Console.Write(" Мир!");
    }
}
