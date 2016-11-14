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
        public static double Eps { get; }

        static Shape()
        {
            string eps = ConfigurationManager.AppSettings["Epsilon"];
            double result;
            if (double.TryParse(eps, out result))
            {
                if (Eps <= 0 || Eps >= 1)
                    throw new ConfigurationErrorsException($"Check the value of {nameof(eps)}, something gone wrong");
                Eps = result;
            }
            else
            {
                Eps = double.Epsilon;
            }
        }

        public abstract double Perimeter { get; }
        public abstract double Area { get;}
    }

    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value >= Eps)
                    Radius = value;
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

        public override double Perimeter => 2*Math.PI*Radius;

        public override double Area => Math.PI*Radius*Radius;
    }

    public class Triangle : Shape
    {
        
    }

    public class Rectangle : Shape
    {
        
    }

    public class Square : Rectangle
    {
        
    }

}
