// это поведенческий паттерн проектирования,
// который даёт возможность последовательно
// обходить элементы составных объектов,
// не раскрывая их внутреннего представления.

using System.Collections;

namespace Command;

class Program
{
    static void Main()
    {
        WordsCollection collection = new();
        collection.AddItem("1");
        collection.AddItem("2");
        collection.AddItem("3");

        foreach (var element in collection)
            Console.WriteLine(element);
    }
}


abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();
    public abstract int Key();
}

abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

class AlphabeticalOrderIterator : Iterator
{
    private WordsCollection _collection;


    private int _position = -1;
    private bool _reverse = false;

    public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
    {
        _collection = collection;
        _reverse = reverse;

        if (reverse)
            _position = collection.GetItems().Count;
    }

    public override object Current() => _collection.GetItems()[_position];
    public override bool MoveNext()
    {
        int updatedPosition = _position + (_reverse ? -1 : 1);

        if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
        {
            _position = updatedPosition;
            return true;
        }
        else
            return false;
    }
    public override void Reset() => _position = _reverse ? _collection.GetItems().Count - 1 : 0;
    public override int Key() => _position;
}

class WordsCollection : IteratorAggregate
{
    List<string> _collection = new();
    bool _direction = false;

    public List<string> GetItems() => _collection;
    public void AddItem(string item) => _collection.Add(item);

    public override IEnumerator GetEnumerator() => new AlphabeticalOrderIterator(this, _direction);

    public void ReverseDirection() => _direction = !_direction;
}
