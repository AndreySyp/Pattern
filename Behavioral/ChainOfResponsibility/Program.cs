// это поведенческий паттерн,
// позволяющий передавать запрос по
// цепочке потенциальных обработчиков,
// пока один из них не обработает запрос.

namespace ChainOfResponsibility;

class Program
{
    static void Main()
    {
        var monkey = new MonkeyHandler();
        var squirrel = new SquirrelHandler();
        var dog = new DogHandler();

        monkey.SetNext(squirrel).SetNext(dog);

        Console.WriteLine("Обезьяна > Белка > Собака\n");
        foreach (var food in new List<string> { "Орех", "Банан", "Кофе" })
        {
            Console.WriteLine($"Клиент: Кто хочет {food}?");
            var result = monkey.Handle(food);

            if (result != null)
                Console.Write($"{result}");
            else
                Console.WriteLine($"{food} остался нетронутым.");
        }
        Console.WriteLine();


        Console.WriteLine("Белка > Собакаn");
        foreach (var food in new List<string> { "Орех", "Банан", "Кофе" })
        {
            Console.WriteLine($"Клиент: Кто хочет {food}?");
            var result = squirrel.Handle(food);

            if (result != null)
                Console.Write($"{result}");
            else
                Console.WriteLine($"{food} остался нетронутым.");
        }
    }
}


public interface IHandler
{
    IHandler SetNext(IHandler handler);
    object? Handle(string request);
}

abstract class AbstractHandler : IHandler
{
    private IHandler? _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual object? Handle(string request)
    {
        return _nextHandler?.Handle(request);
    }
}

class MonkeyHandler : AbstractHandler
{
    public override object? Handle(string request)
    {
        return request == "Банан" ? $"Обезьяна: я съем {request}.\n" : base.Handle(request);
    }
}
class SquirrelHandler : AbstractHandler
{
    public override object? Handle(string request)
    {
        return request == "Орех" ? $"Белка: Я съем {request}.\n" : base.Handle(request);
    }
}
class DogHandler : AbstractHandler
{
    public override object? Handle(string request)
    {
        return request == "Мясо" ? $"Собака: я съем{request}.\n" : base.Handle(request);
    }
}
