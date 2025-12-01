using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapeOne = new List<Shape>();

        Square squ1 = new Square("Red", 3);
        shapeOne.Add(squ1);

        Rectangle rect1 = new Rectangle("Yellow", 7, 6);
        shapeOne.Add(rect1);

        Circle cir1 = new Circle("Orange", 7);
        shapeOne.Add(cir1);

        foreach(Shape shap in shapeOne)
        {
            string color = shap.GetColor();

            double area = shap.GetArea();

            Console.WriteLine($"The {color} shape has an area {area}");
        }
    }
}