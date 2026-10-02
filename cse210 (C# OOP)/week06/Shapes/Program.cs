using System;
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Circle circle = new Circle("Blue", 5);
        Rectangle rectangle = new Rectangle("yellow", 7, 5);
        Square square = new Square("Red", 4);

        shapes.Add(square);
        shapes.Add(circle);
        shapes.Add(rectangle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}