// поведенческий шаблон проектирования,
// определяющий основу алгоритма и
// позволяющий наследникам переопределять некоторые шаги алгоритма,
// не изменяя его структуру в целом.

namespace TemplateMethod;

class Program
{
    static void Main()
    {
        AbstractClass abstractClass = new ConcreteClass();
        abstractClass.TemplateMethod();
    }
}


abstract class AbstractClass
{
    public void TemplateMethod()
    {
        BaseOperation1();
        RequiredOperations1();
        BaseOperation2();
        RequiredOperation2();
        BaseOperation3();
    }

    protected void BaseOperation1() =>
        Console.WriteLine("AbstractClass: Базовая операция 1");
    protected void BaseOperation2() =>
        Console.WriteLine("AbstractClass: Базовая операция 2");
    protected void BaseOperation3() =>
        Console.WriteLine("AbstractClass: Базовая операция 3");

    protected abstract void RequiredOperations1();
    protected abstract void RequiredOperation2();
}

class ConcreteClass : AbstractClass
{
    protected override void RequiredOperations1() =>
        Console.WriteLine("ConcreteClass: Реализованная операция1");
    protected override void RequiredOperation2() =>
        Console.WriteLine("ConcreteClass: Реализованная операция2");
}
