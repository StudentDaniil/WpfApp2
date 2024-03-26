using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public abstract class Shape
    {
        protected double centerX;
        protected double centerY;

        public Shape(double centerX, double centerY)
        {
            this.centerX = centerX;
            this.centerY = centerY;
        }

        public abstract double[] GetEnclosingRectangle(); // Абстрактный метод для получения координат прямоугольника обрамляющего фигуру
        public abstract double GetArea(); // Абстрактный метод для вычисления площади фигуры
    }

    // Производный класс: Точка
    public class Point : Shape
    {
        public Point(double x, double y) : base(x, y)
        {
        }

        public override double[] GetEnclosingRectangle()
        {
            // Для точки не определяется прямоугольник обрамления
            return null;
        }

        public override double GetArea()
        {
            return 0; // Площадь точки равна 0
        }
    }

    // Производный класс: Линия
    public class Line : Shape
    {
        public Line(double x1, double y1, double x2, double y2) : base((x1 + x2) / 2, (y1 + y2) / 2)
        {
        }

        public override double[] GetEnclosingRectangle()
        {
            // Прямоугольник для линии задается двумя точками
            return null;
        }

        public override double GetArea()
        {
            return 0; // Площадь линии равна 0
        }
    }

    // Производный класс: Многоугольник
    public class Polygon : Shape
    {
        private int numOfSides;
        private double sideLength;

        public Polygon(double centerX, double centerY, int numOfSides, double sideLength) : base(centerX, centerY)
        {
            this.numOfSides = numOfSides;
            this.sideLength = sideLength;
        }

        public override double[] GetEnclosingRectangle()
        {
            // Прямоугольник для многоугольника
            double width = numOfSides * sideLength;
            double height = sideLength;
            double[] rectangle = { centerX - width / 2, centerY - height / 2, width, height };
            return rectangle;
        }

        public override double GetArea()
        {
            return 0.25 * numOfSides * sideLength * sideLength / Math.Tan(Math.PI / numOfSides);
        }
    }

    // Производный класс: Эллипс
    public class Ellipse : Shape
    {
        private double majorAxis;
        private double minorAxis;

        public Ellipse(double centerX, double centerY, double majorAxis, double minorAxis) : base(centerX, centerY)
        {
            this.majorAxis = majorAxis;
            this.minorAxis = minorAxis;
        }

        public override double[] GetEnclosingRectangle()
        {
            // Прямоугольник для эллипса
            double[] rectangle = { centerX - majorAxis / 2, centerY - minorAxis / 2, majorAxis, minorAxis };
            return rectangle;
        }

        public override double GetArea()
        {
            return Math.PI * majorAxis * minorAxis;
        }
    }
}
