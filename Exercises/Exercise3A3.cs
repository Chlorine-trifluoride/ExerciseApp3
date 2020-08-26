using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExerciseApp3.Exercises
{
    abstract class Shape : IComparable
    {
        public double Area { get; protected set; }

        public int CompareTo(object obj)
        {
            Shape other = obj as Shape;

            if (this.Area > other.Area)
                return 1;
            else if (this.Area == other.Area)
                return 0;
            else
                return -1;
        }
    }

    class Square : Shape
    {
        public Square(double sideLength)
        {
            this.Area = sideLength * sideLength;
        }
    }

    class Triangle : Shape
    {
        // Is this how you calculate triangle area?
        public Triangle(double baseLength, double height)
        {
            this.Area = (height * baseLength) / 2.0d;
        }
    }

    class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Area = radius * 2 * Math.PI;
        }
    }

    [Description("Shapes and Areas Exercise")]
    class Exercise3A3 : IExercise
    {
        List<Shape> allShapes = new List<Shape>();

        public void Run()
        {
            allShapes.Add(new Circle(3.0d));
            allShapes.Add(new Circle(1.0d));
            allShapes.Add(new Square(2.5d));
            allShapes.Add(new Triangle(2.5d, 2.5d));
            allShapes.Add(new Circle(2.0d));
            allShapes.Add(new Square(3.5d));

            PrintSortedShapes();
        }

        private void PrintSortedShapes()
        {
            allShapes.Sort();

            foreach (var shape in allShapes)
            {
                Console.WriteLine($"{shape.GetType()} has area of {shape.Area}");
            }
        }
    }
}
