using System;
using System.Net.Mail;

namespace _12_GeometricFigures
{
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Incorrect triangle sides");
            }

            A = a;
            B = b;
            C = c;
        }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
    }

    class Square : GeometricFigure
    {
        public double A { get; set; }

        public Square(double a)
        {
            if (a <= 0)
                throw new ArgumentException("Incorrect square side");

            A = a;
        }

        public override double GetArea()
        {
            return A * A;
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
    }

    class Rhombus : GeometricFigure
    {
        public double A { get; set; }
        public double Height { get; set; }

        public Rhombus(double a, double height)
        {
            if (a <= 0 || height <= 0 || height > a)
                throw new ArgumentException("Incorrect rhombus dimensions");

            A = a;
            Height = height;
        }

        public override double GetArea()
        {
            return A * Height;
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
    }

    class Rectangle : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }

        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Incorrect rectangle sides");

            A = a;
            B = b;
        }

        public override double GetArea()
        {
            return A * B;
        }

        public override double GetPerimeter()
        {
            return 2 * (A + B);
        }
    }

    class Parallelogram : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Height { get; set; }

        public Parallelogram(double a, double b, double height)
        {
            if (a <= 0 || b <= 0 || height <= 0 || height > b)
                throw new ArgumentException("Incorrect parallelogram dimensions");

            A = a;
            B = b;
            Height = height;
        }

        public override double GetArea()
        {
            return A * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (A + B);
        }
    }

    class Trapezoid : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }
        public double Height { get; set; }



        public Trapezoid(double a, double b, double c,
                         double d, double height)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                d <= 0 || height <= 0 ||
                height > c || height > d)
            {
                throw new ArgumentException("Incorrect trapezoid dimensions");
            }

            double horizontal1 = Math.Sqrt(c * c - height * height);
            double horizontal2 = Math.Sqrt(d * d - height * height);

            double difference = Math.Abs(a - b);

            if (Math.Abs(horizontal1 + horizontal2 - difference) > 0.000001 &&
                Math.Abs(Math.Abs(horizontal1 - horizontal2) - difference) > 0.000001)
            {
                throw new ArgumentException("These dimensions cannot form a trapezoid");
            }

            A = a;
            B = b;
            C = c;
            D = d;
            Height = height;
        }



        public override double GetArea()
        {
            return (A + B) * Height / 2;
        }

        public override double GetPerimeter()
        {
            return A + B + C + D;
        }
    }

    class Circle : GeometricFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Incorrect circle radius");

            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Ellipse : GeometricFigure
    {
        public double A { get; set; }
        public double B { get; set; }

        public Ellipse(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Incorrect ellipse dimensions!");

            A = a;
            B = b;
        }

        public override double GetArea()
        {
            return Math.PI * A * B;
        }

        public override double GetPerimeter()
        {
            return Math.PI * (3 * (A + B) -
                Math.Sqrt((3 * A + B) * (A + 3 * B)));
        }
    }

    class CompositeFigure : GeometricFigure
    {
        private GeometricFigure[] figures;

        public CompositeFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }

        public override double GetArea()
        {
            double sum = 0;

            foreach (GeometricFigure figure in figures)
            {
                sum += figure.GetArea();
            }

            return sum;
        }

        public override double GetPerimeter()
        {
            double sum = 0;

            foreach (GeometricFigure figure in figures)
            {
                sum += figure.GetPerimeter();
            }

            return sum;
        }
    }

    internal class Program
    {
        static double ReadNumber(string message)
        {
            double number;

            Console.Write(message);

            while (!double.TryParse(Console.ReadLine(), out number)
                   || number <= 0)
            {
                Console.Write("Enter a positive number: ");
            }

            return number;
        }

        static void PrintFigure(string name, GeometricFigure figure)
        {
            Console.WriteLine("\n" + name);
            Console.WriteLine("Area: " + figure.GetArea().ToString("F2"));
            Console.WriteLine("Perimeter: " + figure.GetPerimeter().ToString("F2"));
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("TRIANGLE");

                double a = ReadNumber("Enter side A: ");
                double b = ReadNumber("Enter side B: ");
                double c = ReadNumber("Enter side C: ");

                Triangle triangle = new Triangle(a, b, c);

                Console.WriteLine("\nSQUARE");

                double squareSide = ReadNumber("Enter side A: ");

                Square square = new Square(squareSide);

                Console.WriteLine("\nRHOMBUS");

                double rhombusSide = ReadNumber("Enter side A: ");
                double rhombusHeight = ReadNumber("Enter height: ");

                Rhombus rhombus = new Rhombus(
                    rhombusSide, rhombusHeight);

                Console.WriteLine("\nRECTANGLE");

                double rectangleA = ReadNumber("Enter side A: ");
                double rectangleB = ReadNumber("Enter side B: ");

                Rectangle rectangle = new Rectangle(
                    rectangleA, rectangleB);

                Console.WriteLine("\nPARALLELOGRAM");

                double parallelogramA = ReadNumber("Enter side A: ");
                double parallelogramB = ReadNumber("Enter side B: ");
                double parallelogramHeight = ReadNumber("Enter height: ");

                Parallelogram parallelogram = new Parallelogram(
                    parallelogramA,
                    parallelogramB,
                    parallelogramHeight);


                Console.WriteLine("\nTRAPEZOID");

                double trapezoidA = ReadNumber("Enter first base A: ");
                double trapezoidB = ReadNumber("Enter second base B: ");
                double trapezoidC = ReadNumber("Enter side C: ");
                double trapezoidD = ReadNumber("Enter side D: ");
                double trapezoidHeight = ReadNumber("Enter height: ");

                Trapezoid trapezoid = new Trapezoid(
                    trapezoidA,
                    trapezoidB,
                    trapezoidC,
                    trapezoidD,
                    trapezoidHeight);

                Console.WriteLine("\nCIRCLE");

                double radius = ReadNumber("Enter radius: ");

                Circle circle = new Circle(radius);

                Console.WriteLine("\nELLIPSE");

                double ellipseA = ReadNumber("Enter semi-axis A: ");
                double ellipseB = ReadNumber("Enter semi-axis B: ");

                Ellipse ellipse = new Ellipse(ellipseA, ellipseB);

                GeometricFigure[] figures =
                {
                    triangle,
                    square,
                    rhombus,
                    rectangle,
                    parallelogram,
                    trapezoid,
                    circle,
                    ellipse
                };

                Console.WriteLine("\n========== RESULTS ==========");

                foreach (GeometricFigure figure in figures)
                {
                    PrintFigure(figure.GetType().Name, figure);
                }

                CompositeFigure composite = new CompositeFigure(
                    triangle,
                    square,
                    rectangle,
                    circle,
                    ellipse
                );

                PrintFigure("COMPOSITE FIGURE", composite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
