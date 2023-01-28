// Адаптер — это структурный паттерн проектирования,
// который позволяет объектам с несовместимыми интерфейсами работать вместе.

namespace Adapter;

class Program
{
    static void Main()
    {
        Human human = new();
        Сar car = new();
        human.Travel(car);

        Camel camel = new();
        ITransport camelTransport = new CamelTransportAdapter(camel);
        human.Travel(camelTransport);
    }
}


interface ITransport
{
    void Drive();
}
interface IAnimal
{
    void Move();
}

class Human
{
    public void Travel(ITransport transport) => transport.Drive();
}
class Сar : ITransport
{
    public void Drive() => Console.WriteLine("Машина едет по дороге");
}
class Camel : IAnimal
{
    public void Move() => Console.WriteLine("Верблюд идет по пустыне");
}

class CamelTransportAdapter : ITransport
{
    Camel camel;
    public CamelTransportAdapter(Camel camel) => this.camel = camel;

    public void Drive() => camel.Move();
}// Адаптер.
