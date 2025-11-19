using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace lab4
{
    internal class Collections
    {
        private static List<object> _list;

        private static HashSet<string> _set;

        public static List<object> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public static HashSet<string> Set
        {
            get { return _set; }
            set { _set = value; }
        }

        // Решение 4 задачи
        public static int CountDifferentLetter()
        {
            char[] russianLetter = {
                'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
                'ы', 'ь', 'э', 'ю', 'я',  'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
                'И', 'Й', 'К', 'Л', 'М','Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х',
                'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
            };
            StreamReader streamReader;
            string s;
            HashSet<char> set = new HashSet<char>();

            try
            {
                streamReader = new StreamReader("file1.txt");
            }
            catch
            {
                Console.WriteLine("Ошибка открытия файла!");
                return 0;
            }
            while ((s = streamReader.ReadLine()) != null)
            {
                foreach (char c in s)
                {
                    if (russianLetter.Contains(c) == true)
                    {
                        set.Add(c);
                    }
                }
            }
            streamReader.Close();
            return set.Count();
        }

        // Решение 5 задачи 
        public static void CreateFileStream()
        {
            int n, m;
            Validator validator = new Validator();
            StreamWriter streamWriter;

            try
            {
                streamWriter = new StreamWriter("file2.txt", false);
            }
            catch
            {
                Console.WriteLine("Ошибка открытия файла!");
                return;
            }

            Console.Write("Введите количество спорстменов: ");
            n = Convert.ToInt32(validator.check_int(Console.ReadLine()));
            streamWriter.WriteLine(n);

            Console.Write("Введите число видов спорта: ");
            m = Convert.ToInt32(validator.check_int(Console.ReadLine()));
            streamWriter.WriteLine(m);
            Console.WriteLine();
            Console.WriteLine("Теперь введем данные для каждого спортсмена");
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Введите фамилию для {0} спортсмена: ", i + 1);
                streamWriter.Write(Console.ReadLine() + " ");
                Console.Write("Введите Имя для {0} спортсмена: ", i + 1);
                streamWriter.Write(Console.ReadLine() + " ");
                Console.WriteLine("Теперь введем Баллы для {0} спортсмена: ", i + 1);
                for (int j = 0; j < m; ++j)
                {
                    Console.Write("Введите баллы для {0} вида многоборья: ", j + 1);
                    streamWriter.Write(Convert.ToInt32(validator.check_int(Console.ReadLine())) + " ");
                }
                streamWriter.WriteLine();
                Console.WriteLine();
            }

            streamWriter.Close();
        }

        public static string DictionaryOfAthletes()
        {
            StreamReader streamReader;
            string s;
            int n, m;
            try
            {
                streamReader = new StreamReader("file2.txt");
            }
            catch
            {
                Console.WriteLine("Ошибка открытия файла!");
                return null;
            }

            n = Convert.ToInt32(streamReader.ReadLine());

            m = Convert.ToInt32(streamReader.ReadLine());

            string[] arrAthletes = new string[2 + m];

            Dictionary<int, string> Athletes = new Dictionary<int, string>();

            while ((s = streamReader.ReadLine()) != null)
            {
                arrAthletes = s.Split(' ');

                string keyNameSurname = arrAthletes[0] + " " + arrAthletes[1];

                int sumArrMarks = 0;

                for (int i = 0; i < m; ++i)
                {
                    sumArrMarks += Convert.ToInt32(arrAthletes[i + 2]);
                }

               
                Athletes.Add(sumArrMarks, keyNameSurname);
            }

            streamReader.Close();

            string res = "";

            
            var sortedScores = Athletes.Keys.OrderByDescending(score => score).ToList();

            
            int place = 1;

            foreach (var score in sortedScores)
            {
                int currentPlace = place;
                foreach (var athleteName in Athletes[score])
                {
                    res += $"{athleteName} {score} {currentPlace}\n";
                }
                //place += Athletes[score].Count;  // Теперь это работает, т.к. Athletes[score] - List<string>
            }

            return res;
        }
        public static List<T> CreateList<T>(int n)
        {
            List<T> list = new List<T>(n);

            for (int i = 0; i < n; ++i)
            {
                Console.Write("Напишите элемент, который вы хотите добавить в список: ");
                string input = Console.ReadLine();
                T value = (T)Convert.ChangeType(input, typeof(T));
                list.Add(value);
            }

            List = list.Cast<object>().ToList();
           

            return list;
        }

        public static string PrintList<T>(List<T> list)
        {
            string result = "";
            foreach (T item in list)
                result += item + " ";

            result = result.TrimEnd();

            return result;
        }


        public static HashSet<string> CreateSetStudent(int n)
        {

            HashSet<string> student = new HashSet<string>();

            for (int i = 0; i < n; ++i)
            {
                Console.Write("Введите число, в каком ТРЦ побывал студент: ");
                student.Add(Console.ReadLine());
            }

            Set = student;

            return student;
        }

        // Вывод множества
        public static string PrintHashSet(HashSet<string> set)
        {
            string res = "";
            foreach (string item in set)
            {
                res += item + " ";
            }
            res = res.TrimEnd();

            return res;
        }

        // Решение 2 задачи
        public static LinkedList<T> AddReversedElements<T>(LinkedList<T> list)
        {

            // Создаем копию оригинального списка для результата
            LinkedList<T> result = new LinkedList<T>(list);

            // Добавляем элементы в обратном порядке
            LinkedListNode<T> current = list.Last;
            while (current != null)
            {
                result.AddLast(current.Value);
                current = current.Previous;
            }

            return result;
        }


        // Решение 1 задачи
        public static List<T> Intersect<T>(List<T> list1, List<T> list2)
        {
            List<T> res = new List<T>();

            foreach (T item in list1)
            {
                if (list2.Contains(item) && !res.Contains(item))
                {
                    res.Add(item);
                }
            }
            List = res.Cast<object>().ToList(); ;

            return res;
        }

        public static HashSet<string> task5_1(Dictionary<string, HashSet<string>> st, HashSet<string> global)
        {

            foreach (HashSet<string> item in st.Values)
            {
                global.IntersectWith(item);
            }
            Set = global;
            return Set;
        }

        public static HashSet<string> task5_2(Dictionary<string, HashSet<string>> st, HashSet<string> global)
        {
            HashSet<string> allVisited = new HashSet<string>();
            foreach (HashSet<string> studentSet in st.Values)
            {
                allVisited.UnionWith(studentSet);
            }
            allVisited.ExceptWith(task5_1(st, global));

            Set = allVisited;
            return allVisited;
        }

        public static HashSet<string> task5_3(Dictionary<string, HashSet<string>> st, HashSet<string> global)
        {
            HashSet<string> allVisited = new HashSet<string>();
            foreach (HashSet<string> studentSet in st.Values)
            {
                allVisited.UnionWith(studentSet);
            }
            global.ExceptWith(allVisited);

            Set = global;
            return global;
        }
    }
}
