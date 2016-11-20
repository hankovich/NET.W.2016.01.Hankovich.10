using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Logic.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [TestCase(1, 1, 1)]
        [Test]
        public void EpsAccuracy(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            Assert.LessOrEqual(Math.Abs(a - triangle.A), Shape.Eps);
        }

        [TestCase(-1, 1, 1, typeof (ArgumentOutOfRangeException))]
        [TestCase(10, 10, 300000, typeof (ArgumentException))]
        [TestCase(1, 100, 50, typeof (ArgumentException))]
        [Test]
        public void ExceptionExpected(double a, double b, double c, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Triangle(a, b, c));
        }

        [TestCase(Math.E, Math.E, Math.E, Math.E*3)]
        [Test]
        public void Perimeter(double a, double b, double c, double expectedPerimeter)
        {
            Triangle triangle = new Triangle(a, b, c);
            Assert.LessOrEqual(Math.Abs(expectedPerimeter - triangle.Perimeter), Shape.Eps);
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(Math.E, Math.E, Math.E, Math.E*Math.E*1.732050807/4.0)]
        [Test]
        public void Area(double a, double b, double c, double expectedArea)
        {
            Triangle triangle = new Triangle(a, b, c);
            Assert.LessOrEqual(Math.Abs(expectedArea - triangle.Area), Shape.Eps);
        }
    }


    [TestFixture]
    public class CircleTests
    {
        [TestCase(1)]
        [Test]
        public void EpsAccuracy(double radius)
        {
            var circle = new Circle(radius);
            Assert.LessOrEqual(Math.Abs(radius - circle.Radius), Shape.Eps);
        }

        [TestCase(-1, typeof (ArgumentOutOfRangeException))]
        [TestCase(0,  typeof (ArgumentOutOfRangeException))]
        [Test]
        public void ExceptionExpected(double radius, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Circle(radius));
        }

        [TestCase(Math.E, Math.E*Math.PI*2)]
        [Test]
        public void Perimeter(double radius, double expectedPerimeter)
        {
            Circle circle = new Circle(radius);
            Assert.LessOrEqual(Math.Abs(expectedPerimeter - circle.Perimeter), Shape.Eps);
        }

        [TestCase(1, Math.PI)]
        [TestCase(Math.E, Math.E*Math.E*Math.PI)]
        [Test]
        public void Area(double radius, double expectedArea)
        {
            Circle circle = new Circle(radius);
            Assert.LessOrEqual(Math.Abs(expectedArea - circle.Area), Shape.Eps);
        }
    }

    [TestFixture]
    public class RectangleTests
    {
        [TestCase(1, 2)]
        [Test]
        public void EpsAccuracy(double a, double b)
        {
            var rectangle = new Rectangle(a, b);
            Assert.LessOrEqual(Math.Abs(a - rectangle.A), Shape.Eps);
        }

        [TestCase(-1, 1, typeof (ArgumentOutOfRangeException))]
        [Test]
        public void ExceptionExpected(double a, double b, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Rectangle(a, b));
        }

        [TestCase(Math.E, Math.PI, (Math.PI + Math.E)*2)]
        [Test]
        public void Perimeter(double a, double b, double expectedPerimeter)
        {
            Rectangle rectangle = new Rectangle(a, b);
            Assert.LessOrEqual(Math.Abs(expectedPerimeter - rectangle.Perimeter), Shape.Eps);
        }

        [TestCase(1, 1, 1)]
        [TestCase(Math.E, Math.PI, Math.PI*Math.E)]
        [Test]
        public void Area(double a, double b, double expectedArea)
        {
            Rectangle rectangle = new Rectangle(a, b);
            Assert.LessOrEqual(Math.Abs(expectedArea - rectangle.Area), Shape.Eps);
        }
    }

    [TestFixture]
    public class SquareTests
    {
        [TestCase(Math.PI)]
        [Test]
        public void EpsAccuracy(double a)
        {
            var square = new Square(a);
            Assert.LessOrEqual(Math.Abs(a - square.A), Shape.Eps);
        }

        [TestCase(-11, typeof(ArgumentOutOfRangeException))]
        [Test]
        public void ExceptionExpected(double a, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new Square(a));
        }

        [TestCase(Math.E, Math.E * 4)]
        [Test]
        public void Perimeter(double a, double expectedPerimeter)
        {
            Square square = new Square(a);
            Assert.LessOrEqual(Math.Abs(expectedPerimeter - square.Perimeter), Shape.Eps);
        }

        [TestCase(1, 1)]
        [TestCase(Math.E, Math.E * Math.E)]
        [Test]
        public void Area(double a, double expectedArea)
        {
            Square square = new Square(a);
            Assert.LessOrEqual(Math.Abs(expectedArea - square.Area), Shape.Eps);
        }
    }
}
