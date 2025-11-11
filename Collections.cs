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
        private static List<string> _list;

        private static HashSet<string> _set;

        public static List<string> List
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
                Console.Write("Введите фамилию для {0} спортсмена: ", i+1);
                streamWriter.Write(Console.ReadLine() + " ");
                Console.Write("Введите Имя для {0} спортсмена: ", i + 1);
                streamWriter.Write(Console.ReadLine() + " ");
                Console.WriteLine("Теперь введем Баллы для {0} спортсмена: ", i + 1);
                for (int j = 0; j < m; ++j)
                {
                    Console.Write("Введите баллы для {0} вида многоборья: ", j+1);
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

            Dictionary<string, int> Athletes = new Dictionary<string, int>();

            while ((s = streamReader.ReadLine()) != null)
            {
                arrAthletes = s.Split(' ');
                
                string keyNameSurname = arrAthletes[0] + " " + arrAthletes[1];

                int sumArrMarks = 0;

                for (int i = 0; i < m; ++i)
                {
                    sumArrMarks += Convert.ToInt32(arrAthletes[i+2]);
                }

                Athletes.Add(keyNameSurname, sumArrMarks);
            }

            streamReader.Close();

            string res="";

            // Сортировка по убыванию суммы баллов
            var sortedAthletes = Athletes.OrderByDescending(x => x.Value).ToList();

            if (sortedAthletes.Count > 1)
            {
                int place = 1;
                int otherPlace = 1;
                int n1 = sortedAthletes[0].Value;
                res += sortedAthletes[0].Key + " " + sortedAthletes[0].Value + " "  + place + "\n";
                for (int i = 1; i < sortedAthletes.Count; i++)
                {
                    if (sortedAthletes[i].Value == n1)
                    {
                        place = otherPlace;
                        res += sortedAthletes[i].Key + " " + sortedAthletes[i].Value + " " + place + "\n";
                        n1 = sortedAthletes[i].Value;
                    }
                    else if (sortedAthletes[i].Value < n1)
                    {
                        place++;
                        otherPlace++;
                        res += sortedAthletes[i].Key + " " + sortedAthletes[i].Value + " " + place + "\n";
                        n1 = sortedAthletes[i].Value;
                    }   
                }
                return res;
            }
            else
            {
                int place = 1;
                res += sortedAthletes[0].Key + " " + sortedAthletes[0].Value + " " + place + "\n";

                return res;
            }
        }

        public static List<string> CreateList(int n)
        {
            List<string> list = new List<string>(n);
            
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Напишите элемент, который вы хотите добавить в список: ");
                list.Add(Console.ReadLine());
            }
            List = list;

            return List;
        }

        public static string PrintList(List<string> list)
        {
            string result = "";
            foreach (string item in list)
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
        public static List<string> LinkedList(List<string> list)
        {
            List<string> res = new List<string>();
            foreach (string item in list)
            {
                res.Add(item);
            }

            for (int i = list.Count - 1; i >= 0; --i)
            {
                res.Add(list[i]);
            }

            List = res;

            return res;
        }

   
        // Решение 1 задачи
        public static List<string> Intersect(List<string> list1, List<string> list2)
        {
            List<string> res = new List<string>();

            foreach (string item in list1)
            {
                if (list2.Contains(item) && !res.Contains(item))
                {
                    res.Add(item);
                }
            }
            List = res;

            return res;
        }
    }
}
