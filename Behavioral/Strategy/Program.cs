// это поведенческий паттерн проектирования,
// который определяет семейство схожих алгоритмов
// и помещает каждый из них в собственный класс,
// после чего алгоритмы можно взаимозаменять прямо
// во время исполнения программы.

namespace Strategy;

public static class Program
{
    public static void Main()
    {
        Context context = new(new ConcreteStrategy1());
        context.ExecuteOperation();

        context.SetStrategy(new ConcreteStrategy2());
        context.ExecuteOperation();
    }
}


public interface IStrategy
{
    void Algorithm();
}

public class ConcreteStrategy1 : IStrategy
{
    public void Algorithm() => Console.WriteLine("Выполняется алгоритм стратегии 1.");
}
public class ConcreteStrategy2 : IStrategy
{
    public void Algorithm() => Console.WriteLine("Выполняется алгоритм стратегии 2.");
}

public class Context
{
    private IStrategy _strategy;
    public Context(IStrategy strategy) => _strategy = strategy;
    public void SetStrategy(IStrategy strategy) => _strategy = strategy;

    public void ExecuteOperation() => _strategy.Algorithm();
}
