/*
 * Copyright (c) 2022 by Fred George
 * May be used freely except for training; license required for training.
 * @author Fred George  fredgeorge@acm.org
 */

using System;

namespace Exercises.rectangle
{

    // Understands a four-sided polygon with sides at right angles
    public class Rectangle : IOurComparable<Rectangle> {

        public static Rectangle Create(double length, double width)
        {
            return (length == width) 
                ? Square(length) 
                : new Rectangle(length, width);
        }

        public static Rectangle Square(double side)
            => new(side, side);

        /*public static Rectangle? LargestArea(IEnumerable<Rectangle> rectangles)
        {
            //return rectangles.MaxBy(r => r.Area());
            return Best(rectangles, (challenger, champion)
                => challenger.Area() > champion.Area());
        }*/


        private readonly double _length;
        private readonly double _width;


        protected Rectangle(double length, double width) {
            if (length <= 0.0 || width <= 0.0) throw new ArgumentException("Invalid dimensions");
            _length = length;
            _width = width;
        }

        public double Area() => _length * _width;

        public bool IsSquare() => _length == _width;

        public double Perimeter() => 2 * (_length + _width);

        public override string ToString()
        {
            return _length + "x" + _width;
        }

        public bool BetterThan(Rectangle champion)
        {
            return Area() > champion.Area();
        }
    }

    public static class RectangleExtensions
    {
        public static Rectangle? LargestArea(this IEnumerable<Rectangle> rectangles)
            => rectangles.Best((challenger, champion) => challenger.Area() > champion.Area());
    }
}