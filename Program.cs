using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Validator validator = new Validator();
            int num1;
            Console.Write("Введите номер задания из списка \"1 2 3 4 5 6 7\": ");
            num1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
            switch (num1)
            {
                case 1:
                    {
                        int n1, n2;
                        Console.Write("Введите количество элементов в списке L1: ");
                        n1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        List<string> L1 = Collections.CreateList(n1);
                        Console.WriteLine();
                        Console.Write("Введите количество элементов в списке L2: ");
                        n2 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        List<string> L2 = Collections.CreateList(n2);

                        List<string> L = Collections.Intersect(L1, L2);

                        Console.WriteLine();
                        Console.Write("Итоговый результат: ");
                        Console.WriteLine(Collections.PrintList(L));
                        break;
                    }
                case 2:
                    {
                        int n1;
                        Console.Write("Введите количество элементов в списке L: ");
                        n1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        List<string> L = Collections.CreateList(n1);

                        List<string> result = Collections.LinkedList(L);

                        Console.WriteLine();
                        Console.Write("Итоговый результат: ");
                        Console.WriteLine(Collections.PrintList(result));
                        break;
                    }
                case 3:
                    {
                        int n1, n2, n3, n4;
                        int num;
                        Console.Write("Введите количество ТРЦ, которые посетил 1 студент: ");
                        n1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        HashSet<string> SetSt1 = Collections.CreateSetStudent(n1);
                        Console.WriteLine();
                        Console.Write("Введите количество ТРЦ, которые посетил 2 студент: ");
                        n2 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        HashSet<string> SetSt2 = Collections.CreateSetStudent(n2);
                        Console.WriteLine();
                        Console.Write("Введите количество ТРЦ, которые посетил 3 студент: ");
                        n3 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        HashSet<string> SetSt3 = Collections.CreateSetStudent(n3);
                        Console.WriteLine();
                        Console.Write("Введите количество ТРЦ, которые посетил 4 студент: ");
                        n4 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        HashSet<string> SetSt4 = Collections.CreateSetStudent(n4);
                        Console.WriteLine();
                   
                        Console.Write("Какой пункт из трех хотите решить: ");
                        num = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        switch (num)
                        {
                            // Решение 1 пункта
                            case 1:
                                {
                                    SetSt1.IntersectWith(SetSt2);
                                    SetSt1.IntersectWith(SetSt3);
                                    SetSt1.IntersectWith(SetSt4);
                                    Console.Write("Перечень ТРЦ, в которые ходили все студенты группы: ");
                                    Console.WriteLine(Collections.PrintHashSet(SetSt1));
                                    break;
                                }
                            // Решение 2 пункта
                            case 2:
                                {
                                    HashSet<string> allStudent = new HashSet<string>(SetSt1);
                                    allStudent.UnionWith(SetSt2);
                                    allStudent.UnionWith(SetSt3);
                                    allStudent.UnionWith(SetSt4);

                                    HashSet<string> intersectStudent = new HashSet<string>(SetSt1);
                                    intersectStudent.IntersectWith(SetSt2);
                                    intersectStudent.IntersectWith(SetSt3);
                                    intersectStudent.IntersectWith(SetSt4);

                                    HashSet<string> someStudent = new HashSet<string>(allStudent);
                                    someStudent.ExceptWith(intersectStudent);

                                    Console.Write("Перечень ТРЦ, в которые ходили некоторые студенты группы: ");
                                    Console.WriteLine(Collections.PrintHashSet(someStudent));
                                    break;
                                }
                            // Решение 3 пункта
                            case 3:
                                {
                                    // Общий перечень центров 
                                    HashSet<string> GeneralHashSet = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

                                    HashSet<string> allStudent = new HashSet<string>(SetSt1);
                                    allStudent.UnionWith(SetSt2);
                                    allStudent.UnionWith(SetSt3);
                                    allStudent.UnionWith(SetSt4);

                                    GeneralHashSet.ExceptWith(allStudent);

                                    Console.Write("Перечень ТРЦ, в которые не ходили никакие студенты группы: ");
                                    Console.WriteLine(Collections.PrintHashSet(GeneralHashSet));
                                    break;
                                }
                        }
                        break;
                    }
                case 4:
                    {
                        Console.Write("Количество разных букв, которые встречаются в тексте: ");
                        Console.WriteLine( Collections.CountDifferentLetter());
                        break;
                    }
                case 5:
                    {
                        Collections.CreateFileStream();
                        Console.WriteLine(Collections.DictionaryOfAthletes());
                        break;
                    }
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
