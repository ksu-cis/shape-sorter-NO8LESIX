using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>() {

                new Circle(4.0),
                new Rectangle(6,7),
                new Square(5.0),
                new Circle(3.0),
                new Rectangle(2.0,4.0),
                new Circle(3.0),
                new Square(10)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name + ": " + shape.Area);
            }

            IEnumerable<IShape> filteredByShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with an area greater than 50");

            foreach (IShape shape in filteredByShapes)
            {
                Console.WriteLine(shape.GetType().Name + ": " + shape.Area);
            }

            Console.WriteLine("Circles: ");

            IEnumerable<Circle> circles;
            //
            //circles = shapes.Where(shape => shape is Circle);
            //
            //circles = shapes.Where(shape => shape.GetType() == typeof(Circle));
            //
            circles = shapes.OfType<Circle>();


            foreach (Circle shape in circles)
            {
                Console.WriteLine("Radius: " + shape.Radius + " - Area:" + shape.Area);
            }


            Console.WriteLine("Shapes with an area less than or equal to 30");

            foreach (Circle shape in circles.Where(circle => circle.Area <= 30))
            {
                Console.WriteLine("Radius: " + shape.Radius + " - Area:" + shape.Area);
            }


            Console.WriteLine("Grouping By Evens and Odds");

            var groupByEO = shapes.GroupBy(shape => shape.Area % 2 == 0);

            foreach (var i in groupByEO)
            {
                Console.WriteLine(i.Key? "Evens":"Odds");
                foreach (var shape in i)
                {
                    Console.WriteLine(shape.GetType().Name + ": " + shape.Area);

                }
            }

            Console.WriteLine("Grouping By Type");

            var groupByType = shapes.GroupBy(shape => shape.GetType());

            foreach (var i in groupByType)
            {
                Console.WriteLine(i.Key + "Group");
                foreach (var shape in i)
                {
                    Console.WriteLine(shape.GetType().Name + ": " + shape.Area);

                }
            }

        }

    }
}
