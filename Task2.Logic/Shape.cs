using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task2.Logic
{
    public abstract class Shape
    {
        /// <summary>
        /// Accuracy
        /// </summary>
        public static double Eps { get; }

        static Shape()
        {
            string eps = ConfigurationManager.AppSettings["Epsilon"];
            double result;
            if (double.TryParse(eps, out result))
            {
                if (result <= 0 || result >= 1)
                    throw new ConfigurationErrorsException($"Check the value of {nameof(eps)}, something gone wrong");
                Eps = result;
            }
            else
            {
                Eps = 1e-6;
            }
        }

        public abstract double Perimeter { get; }
        public abstract double Area { get; }
    }

    public class Circle : Shape
    {
        private double radius;

        /// <summary>
        /// Radius of a circle
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throws when value is less than Eps</exception>
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= Eps)
                    radius = value;
                else
                {
                    throw new ArgumentOutOfRangeException($"Check {nameof(value)}. It must be greater than {Eps}");
                }
            }
        }

        public Circle(double r)
        {
            Radius = r;
        }

        /// <summary>
        /// Count circle perimeter
        /// </summary>
        public override double Perimeter => 2*Math.PI*Radius;

        /// <summary>
        /// Count circle area
        /// </summary>
        public override double Area => Math.PI*Radius*Radius;
    }

    public class Triangle : Shape
    {
        /// <summary>
        /// Length of first triangle side
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Length of second triangle side
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Length of third triangle side
        /// </summary>
        public double C { get; }

        /// <summary>
        /// Ctor with parameters
        /// </summary>
        /// <param name="x">First side</param>
        /// <param name="y">Second side</param>
        /// <param name="z">Third side</param>
        /// <exception cref="ArgumentException">When the triangle inequality is not satisfied.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When at least one of the triangle's sides is less than Eps</exception>
        public Triangle(double x, double y, double z)
        {
            if (x < Eps)
                throw new ArgumentOutOfRangeException($"Check {nameof(x)}. It must be greater than {Eps}.");
            if (y < Eps)
                throw new ArgumentOutOfRangeException($"Check {nameof(y)}. It must be greater than {Eps}.");
            if (z < Eps)
                throw new ArgumentOutOfRangeException($"Check {nameof(z)}. It must be greater than {Eps}.");

            if (!IsValid(x, y, z))
                throw new ArgumentException(
                    $"Check {nameof(x)}, {nameof(y)} and {nameof(z)}. Don't forget the triangle inequality.");
            
            A = x;
            B = y;
            C = z;
        }

        /// <summary>
        /// Perimeter of a triangle
        /// </summary>
        public override double Perimeter => A + B + C;

        /// <summary>
        /// Area of a triangle
        /// </summary>
        public override double Area => Math.Sqrt(Perimeter*(Perimeter - 2*A)*(Perimeter - 2*B)*(Perimeter - 2*C))/4.0;

        private static bool IsValid(double a, double b, double c)
        {
            return (a + b - c > Eps) && (a + c - b > Eps) && (b + c - a > Eps);
        }
    }

    public class Rectangle : Shape
    {
        protected double a;
        protected double b;


        /// <summary>
        /// Length of first rectangle side
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Value is less than Eps</exception>
        public virtual double A
        {
            get { return a; }
            set
            {
                if (value >= Eps)
                    a = value;
                else
                {
                    throw new ArgumentOutOfRangeException($"Check {nameof(value)}. It must be greater than {Eps}.");
                }
            }
        }

        /// <summary>
        /// Length of second rectangle side
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Value is less than Eps</exception>
        public virtual double B
        {
            get { return b; }
            set
            {
                if (value >= Eps)
                    b = value;
                else
                {
                    throw new ArgumentOutOfRangeException($"Check {nameof(value)}. It must be greater than {Eps}.");
                }
            }
        }

        public Rectangle(double x, double y)
        {
            A = x;
            B = y;
        }

        /// <summary>
        /// Perimeter of a rectangle
        /// </summary>
        public override double Perimeter => 2*(A + B);

        /// <summary>
        /// Area of a rectangle
        /// </summary>
        public override double Area => A*B;
    }

    public class Square : Shape
    {
        private double a;

        /// <summary>
        /// Length of square side 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Value is less than Eps</exception>
        public double A
        {
            get { return a; }
            set
            {
                if (value >= Eps)
                {
                    a = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Check {nameof(value)}. It must be greater than {Eps}.");
                }
            }
        }

        public Square(double x)
        {
            A = x;
        }

        /// <summary>
        /// Perimeter of a square
        /// </summary>
        public override double Perimeter => 4 * A;

        /// <summary>
        /// Area of a square
        /// </summary>
        public override double Area => A * A;
    }
}
