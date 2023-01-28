// это поведенческий паттерн проектирования,
// который позволяет уменьшить связанность множестваклассов между собой,
// благодаря перемещению этих связей в один класс-посредник.

namespace Command;

class Program
{
    static void Main()
    {
        Component1 component1 = new();
        Component2 component2 = new();
        new ConcreteMediator(component1, component2);

        Console.WriteLine("Клиент запускает операцию A.");
        component1.DoA();

        Console.WriteLine();

        Console.WriteLine("Клиент запускает операцию D.");
        component2.DoD();
    }
}


public interface IMediator
{
    abstract void Notify(object sender, string ev);
}

class ConcreteMediator : IMediator
{
    private Component1 _component1;
    private Component2 _component2;

    public ConcreteMediator(Component1 component1, Component2 component2)
    {
        _component1 = component1;
        _component1.SetMediator(this);

        _component2 = component2;
        _component2.SetMediator(this);
    }

    public void Notify(object sender, string ev)
    {
        if (ev == "A")
        {
            Console.WriteLine("Mediator реагирует на A и запускает следующие операции:");
            _component2.DoC();
        }
        if (ev == "D")
        {
            Console.WriteLine("Mediator реагирует на D и запускает следующие операции:");
            _component1.DoB();
            _component2.DoC();
        }
    }
}

class BaseComponent
{
    protected IMediator _mediator;

    public BaseComponent(IMediator mediator = null) => _mediator = mediator;
    public void SetMediator(IMediator mediator) => _mediator = mediator;
}
class Component1 : BaseComponent
{
    public void DoA()
    {
        Console.WriteLine("Компонент 1 делает А.");
        _mediator.Notify(this, "A");
    }
    public void DoB()
    {
        Console.WriteLine("Компонент 1 делает B.");
        _mediator.Notify(this, "B");
    }
}
class Component2 : BaseComponent
{
    public void DoC()
    {
        Console.WriteLine("Компонент 2 делает C.");
        _mediator.Notify(this, "C");
    }
    public void DoD()
    {
        Console.WriteLine("Компонент 2 делает D.");
        _mediator.Notify(this, "D");
    }
}
