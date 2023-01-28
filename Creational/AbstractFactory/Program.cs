// это порождающий паттерн проектирования,
// который позволяет создавать семейства связанных объектов,
// не привязываясь к конкретным классам создаваемых объектов.

namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Бтр");
        Transport elf = new(new BtrFactory());
        elf.Fire();
        elf.Movement();

        Console.WriteLine("\nТанк");
        Transport voin = new(new TankFactory());
        voin.Fire();
        voin.Movement();

    }
}


class Transport
{
    private Weapon weapon;
    private Movement move;
    public Transport(TransportFactory factory)
    {
        weapon = factory.CreateWeapon();
        move = factory.CreateMovement();
    }

    public void Movement() => move.Move();
    public void Fire() => weapon.Hit();
}

abstract class Weapon
{
    public abstract void Hit();
}
abstract class Movement
{
    public abstract void Move();
}

class Gun15mm : Weapon
{
    public override void Hit() => Console.WriteLine("Пиу пиу");
}
class Gun120mm : Weapon
{
    public override void Hit() => Console.WriteLine("Бабах");
}

class Wheels : Movement
{
    public override void Move() => Console.WriteLine("Едем с помощью колес");
}
class Tracks : Movement
{
    public override void Move() => Console.WriteLine("Едем с помощью гусениц");
}


abstract class TransportFactory
{
    public abstract Movement CreateMovement();
    public abstract Weapon CreateWeapon();
}
class BtrFactory : TransportFactory
{
    public override Movement CreateMovement() => new Wheels();

    public override Weapon CreateWeapon() => new Gun15mm();
}
class TankFactory : TransportFactory
{
    public override Movement CreateMovement() => new Tracks();

    public override Weapon CreateWeapon() => new Gun120mm();
}
