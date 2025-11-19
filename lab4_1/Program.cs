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
            Console.Write("Введите номер задания из списка \"1 2 3 4 5\": ");
            num1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
            switch (num1)
            {
                case 1:
                    {
                        int n1, n2;
                        Console.Write("Введите количество элементов в списке L1: ");
                        n1 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        List<string> L1 = Collections.CreateList<string>(n1);
                        Console.WriteLine();
                        Console.Write("Введите количество элементов в списке L2: ");
                        n2 = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        List<string> L2 = Collections.CreateList<string>(n2);

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
                        List<string> L = Collections.CreateList<string>(n1);

                        //List<object> result = Collections.LinkedList(L);

                        //Console.WriteLine();
                        //Console.Write("Итоговый результат: ");
                        //Console.WriteLine(Collections.PrintList(result));
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
                        Dictionary<string, HashSet<string>> st = new Dictionary<string, HashSet<string>>();

                        st.Add("Студент 1", SetSt1);
                        st.Add("Студент 2", SetSt2);
                        st.Add("Студент 3", SetSt3);
                        st.Add("Студент 4", SetSt4);

                        HashSet<string> GeneralHashSet = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

                        Console.Write("Какой пункт из трех хотите решить: ");
                        num = Convert.ToInt32(validator.check_int(Console.ReadLine()));
                        switch (num)
                        {
                            // Решение 1 пункта
                            case 1:
                                {
                                    HashSet<string> res = Collections.task5_1(st, GeneralHashSet);
                                    Console.Write("Перечень ТРЦ, в которые ходили все студенты группы: ");
                                    Console.WriteLine(Collections.PrintHashSet(res));
                                    break;
                                }
                            // Решение 2 пункта
                            case 2:
                                {
                                    HashSet<string> res = Collections.task5_2(st, GeneralHashSet);
                                    Console.Write("Перечень ТРЦ, в которые ходили некоторые студенты группы: ");
                                    Console.WriteLine(Collections.PrintHashSet(res));
                                    break;
                                }
                            // Решение 3 пункта
                            case 3:
                                {
                                    HashSet<string> res = Collections.task5_3(st, GeneralHashSet);
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
                        Console.WriteLine(Collections.CountDifferentLetter());
                        break;
                    }
                case 5:
                    {
                        Collections.CreateFileStream();
                        Console.WriteLine(Collections.DictionaryOfAthletes());
                        break;
                    }
            }
            
        }
    }
}
