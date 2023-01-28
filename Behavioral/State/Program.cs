// это поведенческий паттерн проектирования,
// который позволяет объектам менять поведение в зависимости от своего состояния.
// Извне создаётся впечатление, что изменился класс объекта.

namespace State;

class Program
{
    static void Main()
    {
        Context context = new(new ConcreteStateA());
        context.Request1();
        context.Request2();
    }
}


class Context
{
    private State _state = null;
    public Context(State state) => TransitionTo(state);
    public void TransitionTo(State state)
    {
        Console.WriteLine($"Context: Переход к {state.GetType().Name}.");
        _state = state;
        _state.SetContext(this);
    }

    public void Request1() => _state.Handle1();
    public void Request2() => _state.Handle2();
}

abstract class State
{
    protected Context _context;

    public void SetContext(Context context) => _context = context;

    public abstract void Handle1();
    public abstract void Handle2();
}

class ConcreteStateA : State
{
    public override void Handle1()
    {
        Console.WriteLine("ConcreteStateA обрабатывает запрос1.");
        Console.WriteLine("ConcreteStateA хочет изменить состояние контекста.");
        _context.TransitionTo(new ConcreteStateB());
    }
    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateA обрабатывает запрос2.");
    }
}
class ConcreteStateB : State
{
    public override void Handle1()
    {
        Console.Write("ConcreteStateB обрабатывает запрос1.");
    }
    public override void Handle2()
    {
        Console.WriteLine("ConcreteStateB обрабатывает запрос2.");
        Console.WriteLine("ConcreteStateB хочет изменить состояние контекста.");
        _context.TransitionTo(new ConcreteStateA());
    }
}
