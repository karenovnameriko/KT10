//2.Напишите обобщенный интерфейс IClonable<T>, который содержит метод T Clone(), который
//возвращает копию объекта типа T. Напишите произвольное ограничение для этого интерфейса.
//Затем напишите классы Point и Rectangle, которые имеют конструктор с одним параметром
//типа Point и Rectangle соответственно и реализуют интерфейс IClonable<T> для своих типов.
//Затем напишите метод, который принимает на вход объект типа T, который реализует
//интерфейс IClonable<T>, и возвращает его клон с помощью метода Clone().
using System.Drawing;
using static KT10_2.Program;

namespace KT10_2;

class Program
{
    public interface IClonable<T> where T: class
    {
        T Clone();
    }
    public class Point: IClonable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Конструктор для создания нового Point с координатами
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
        }

        public Point Clone()
        {
            return new Point(this);
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    public class Rectangle: IClonable<Rectangle>
    {
        public Point TopLeft { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Point topLeft, int width, int height)
        {
            TopLeft = topLeft;
            Width = width;
            Height = height;
        }

        public Rectangle(Rectangle other)
        {
            TopLeft = other.TopLeft.Clone();
            Width = other.Width;
            Height = other.Height;
        }

        public Rectangle Clone()
        {
            return new Rectangle(this);
        }

        public override string ToString()
        {
            return $"Rectangle(TopLeft: {TopLeft}, Width: {Width}, Height: {Height})";
        }
    }

    public static T CreateClone<T>(T original) where T : class, IClonable<T>
    {
        return original.Clone();
    }
    static void Main(string[] args)
    {
        Point originalPoint = new Point(10, 20);
        Point clonedPoint = CreateClone(originalPoint);

        Console.WriteLine($"Оригинал: {originalPoint}");
        Console.WriteLine($"Клон: {clonedPoint}");

        originalPoint.X = 100;
        Console.WriteLine($"После изменения оригинала: {originalPoint}");
        Console.WriteLine($"Клон остался прежним: {clonedPoint}");

        Rectangle originalRect = new Rectangle(new Point(5, 5), 30, 40);
        Rectangle clonedRect = CreateClone(originalRect);

        Console.WriteLine($"Оригинал: {originalRect}");
        Console.WriteLine($"Клон: {clonedRect}");

        originalRect.TopLeft.X = 999;
        originalRect.Width = 100;
        Console.WriteLine($"После изменения оригинала: {originalRect}");
        Console.WriteLine($"Клон остался прежним: {clonedRect}");
        
        Point point1 = new Point(15, 25);
        Point point2 = new Point(point1);
        Console.WriteLine($"Point1: {point1}");
        Console.WriteLine($"Point2 (копия): {point2}");
    }
}
