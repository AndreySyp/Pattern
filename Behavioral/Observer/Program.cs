// это поведенческий паттерн проектирования,
// который создаёт механизм подписки,
// позволяющий одним объектам следить и реагировать на события,
// происходящие в других объектах.


namespace Observer;

class Program
{
    static void Main()
    {
        Subject subject = new();
        ConcreteObserverA observerA = new();
        ConcreteObserverB observerB = new();

        subject.Attach(observerA);
        subject.Attach(observerB);

        subject.SomeBusinessLogic();

        subject.Detach(observerB);

        subject.SomeBusinessLogic();
    }
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}
public interface IObserver
{
    void Update(ISubject subject);
}

class ConcreteObserverA : IObserver
{
    public void Update(ISubject subject)
    {
        if (((Subject)subject).State < 3)
            Console.WriteLine("ConcreteObserverA: Отреагировал на событие.");
    }
}
class ConcreteObserverB : IObserver
{
    public void Update(ISubject subject)
    {
        if (((Subject)subject).State == 0 || ((Subject)subject).State >= 2)
            Console.WriteLine("ConcreteObserverB: Отреагировал на событие.");
    }
}

public class Subject : ISubject
{
    public int State { get; set; } = -0;
    private List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        Console.WriteLine("Subject: Добавил наблюдателя.");
        _observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine("Subject: Убрал наблюдатель.");
    }

    public void Notify()
    {
        Console.WriteLine("Subject: Уведомление наблюдателей");

        foreach (var observer in _observers)
            observer.Update(this);
    }

    public void SomeBusinessLogic()
    {
        State = new Random().Next(0, 10);
        Console.WriteLine("\nSubject: Начинаюю оповещение. Значение равно " + State);

        Notify();
    }
}
