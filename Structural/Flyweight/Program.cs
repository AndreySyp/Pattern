// Легковес — это структурный паттерн проектирования,
// который позволяет вместить бóльшее количество объектов
// в отведённую оперативную память. Легковес экономит память,
// разделяя общее состояние объектов между собой, вместо
// хранения одинаковых данных в каждом объекте.

using System.Collections;

namespace Flyweight;

class Program
{
    static void Main()
    {
        string document = "AAZZBBZB";
        char[] chars = document.ToCharArray();

        CharacterFactory сf = new();

        int pointSize = 10;

        foreach (char c in chars)
        {
            pointSize++;
            Font character = сf.GetCharacter(c);
            character.Print(pointSize);
        }
    }
}


class CharacterFactory
{
    private Hashtable characters = new();

    public Font GetCharacter(char key)
    {
        Font? character = characters[key] as Font;
        if (character == null)
        {
            switch (key)
            {
                case 'A': character = new FontA(); break;
                case 'B': character = new FontB(); break;
                case 'Z': character = new FontZ(); break;
            }
            characters.Add(key, character);
        }
        return character;
    }
}

class Font
{
    protected char symbol;
    protected int width;
    protected int height;
    protected int ascent;
    protected int descent;
    protected int pointSize;

    public void Print(int pointSize)
    {
        this.pointSize = pointSize;
        Console.WriteLine(symbol + " (pointsize " + this.pointSize + ")");
    }
}

class FontA : Font
{
    public FontA()
    {
        symbol = 'A';
        height = 100;
        width = 120;
        ascent = 70;
        descent = 0;
    }
}
class FontB : Font
{
    public FontB()
    {
        symbol = 'B';
        height = 100;
        width = 140;
        ascent = 72;
        descent = 0;
    }
}
class FontZ : Font
{
    public FontZ()
    {
        symbol = 'Z';
        height = 100;
        width = 100;
        ascent = 68;
        descent = 0;
    }
}
