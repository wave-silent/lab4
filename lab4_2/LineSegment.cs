using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class LineSegment
    {
        private double _x;
        private double _y;

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public LineSegment(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public bool IntersectionOfSegments(LineSegment line2)
        {
            if ((line2._x <= this._x && line2._y >= this._y) || (line2._x >= this._x && line2._y <= this._y) || (Math.Abs(line2._x) <= this._x || Math.Abs(line2._y) <= this._x)
                || (Math.Abs(line2._x) <= this._y || Math.Abs(line2._y) <= this._y) || (line2._x >= this._x && line2._x <= this._y) || (line2._y >= this._y && line2._y <= this._x))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double operator !(LineSegment line) 
        {

            if (line._x > line._y)
            {
                return Math.Abs(line._x - line._y);
            }
            else
            {
                return Math.Abs(line._y - line._x);
            }
        }

        public static LineSegment operator ++(LineSegment line)
        {
            if (line._x > line._y)
            {
                LineSegment resLine = new LineSegment(line._y--, line._x++);
                return resLine;
            }
            else
            {
                LineSegment resLine = new LineSegment(line._x--, line._y++);
                return resLine;
            }
        }

        public static implicit operator int(LineSegment line)
        {
            return (int)line.X;
        }

        public static explicit operator double(LineSegment line)
        {
            return (double)line.Y;
        }

        public static LineSegment operator -(LineSegment line, int n)
        {
            return new LineSegment(line._x - n, line._y);
        }

        public static LineSegment operator -(int n, LineSegment line)
        {
            return new LineSegment(line._x, line._y-n);
        }

        public static bool operator <(LineSegment line1, LineSegment line2)
        {
            return line1.IntersectionOfSegments(line2);          
        }

        // Добавил, чтобы не выходила ошибка, не был осуществлен оператор ">"
        public static bool operator >(LineSegment line1, LineSegment line2)
        {
            return line1.IntersectionOfSegments(line2);
        }

        public override string ToString()
        {
            if (_x > _y) 
            {
                return "[" + _y + ";" + _x + "]";
            }
            else
            {
                return "[" + _x + ";" + _y + "]";
            }     
        }
    }
}
