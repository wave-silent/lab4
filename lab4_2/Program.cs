using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Validator validator = new Validator();
            int num1;
            Console.Write("Введите номер задания из списка \"6 7\": ");
            num1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
            switch (num1)
            {
                case 6:
                    {
                        Console.WriteLine("Введите x и y для 1 отрезка: ");
                        LineSegment line1 = new LineSegment(Convert.ToDouble(validator.check_double(Console.ReadLine())), Convert.ToDouble(validator.check_double(Console.ReadLine())));
                        Console.WriteLine();
                        Console.WriteLine("Введите x и y для 2 отрезка: ");
                        LineSegment line2 = new LineSegment(Convert.ToDouble(validator.check_double(Console.ReadLine())), Convert.ToDouble(validator.check_double(Console.ReadLine())));

                        Console.WriteLine(line1);
                        Console.Write("Итоговый результат: ");
                        Console.WriteLine(line1.IntersectionOfSegments(line2));
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Введите x и y для 1 отрезка: ");
                        LineSegment line1 = new LineSegment(Convert.ToDouble(validator.check_double(Console.ReadLine())), Convert.ToDouble(validator.check_double(Console.ReadLine())));
                        Console.WriteLine();
                        Console.WriteLine("Введите x и y для 2 отрезка: ");
                        LineSegment line2 = new LineSegment(Convert.ToDouble(validator.check_double(Console.ReadLine())), Convert.ToDouble(validator.check_double(Console.ReadLine())));

                        double range = !line1;
                        Console.WriteLine("Длина диапазона: " + range);
                        Console.WriteLine();

                        //line1 = line1++;
                        //Console.WriteLine("Расширенный на 1 отрезок: " + line1);
                        //Console.WriteLine();

                        int x = (int)line1;
                        Console.WriteLine("Целая часть координаты x: " + x);
                        Console.WriteLine();

                        double y = (double)line1;
                        Console.WriteLine("Координата y: " + y);
                        Console.WriteLine();

                        //line1 = line1 - 10;
                        //Console.WriteLine("Уменьшение координаты x: " + line1);
                        //Console.WriteLine();

                        //line1 = 10 - line1;
                        //Console.WriteLine("Уменьшение координаты y: " + line1);
                        //Console.WriteLine();

                        //Для пересечения отрезков надо было закомменитровать другие некоторые методы 2, 5, 6
                        bool IntersectLine = line1 < line2;
                        Console.WriteLine("Пересекаются ли отрезки: " + IntersectLine);
                        Console.WriteLine();
                        break;
                    }
            }

        }
    }
}
