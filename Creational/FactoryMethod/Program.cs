// Фабричный метод — это порождающий паттерн проектирования,
// который определяет общий интерфейс для создания объектов в суперклассе,
// позволяя подклассам изменять тип создаваемых объектов

namespace FactoryMethod;

public static class Program
{
    public static void Main()
    {
        Creator[] creators = { new CreatorA(), new CreatorB() };

        foreach (Creator creator in creators)
        {
            Delivery product = creator.FactoryMethod();
            Console.WriteLine(product.TypeDelivery());
        }
    }
}


public abstract class Delivery
{
    public abstract string TypeDelivery();
}
public abstract class Creator
{
    public abstract Delivery FactoryMethod();
}

public class DeliveryRiver : Delivery
{
    public override string TypeDelivery() => "Доставка по реке";
}
public class DeliveryRoad : Delivery
{
    public override string TypeDelivery() => "Доставка по дороге";
}

public class CreatorA : Creator
{
    public override Delivery FactoryMethod() => new DeliveryRiver();
}
public class CreatorB : Creator
{
    public override Delivery FactoryMethod() => new DeliveryRoad();
}
