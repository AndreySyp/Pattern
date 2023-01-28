// это поведенческий паттерн проектирования,
// который превращает запросы в объекты,
// позволяя передавать их как аргументы при вызове методов.

namespace Command;

class Program
{
    static void Main()
    {
        Invoker invoker = new();
        invoker.SetOnStart(new SimpleCommand("Привет"));

        Receiver receiver = new();
        invoker.SetOnFinish(new ComplexCommand(receiver, "Сохранить отчет", "Отправить отчет"));
        invoker.DoSomethingImportant();
    }
}


public interface ICommand
{
    abstract void Execute();
}

class SimpleCommand : ICommand
{
    private readonly string _payload = string.Empty;

    public SimpleCommand(string payload) => _payload = payload;
    public void Execute() =>
        Console.WriteLine($"SimpleCommand: я могу делать простые вещи, например, печатать. ({_payload})");
}
class ComplexCommand : ICommand
{
    private readonly Receiver _receiver;
    private readonly string _a;
    private readonly string _b;

    public ComplexCommand(Receiver receiver, string a, string b)
    {
        _receiver = receiver;
        _a = a;
        _b = b;
    }

    public void Execute()
    {
        Console.WriteLine("ComplexCommand: сложные вещи должны выполняться объектом-получателем.");
        _receiver.DoSomething(_a);
        _receiver.DoSomethingElse(_b);
    }
}

class Receiver
{
    public void DoSomething(string a) => Console.WriteLine($"Receiver: Работа над ({a}.)");
    public void DoSomethingElse(string b) => Console.WriteLine($"Receiver: Также работаем над ({b}.)");
}
class Invoker
{
    private ICommand? _onStart;
    private ICommand? _onFinish;

    public void SetOnStart(ICommand command) => _onStart = command;
    public void SetOnFinish(ICommand command) => _onFinish = command;

    public void DoSomethingImportant()
    {
        Console.WriteLine("Invoker: Кто сделает что то до меня?");
        if (_onStart is not null)
            _onStart.Execute();

        Console.WriteLine("Invoker: что то делаю");
        Console.WriteLine("Invoker: Кто сделает что то после меня?");

        if (_onFinish is not null)
            _onFinish.Execute();
    }
}
