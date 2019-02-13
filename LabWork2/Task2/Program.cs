using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static void pr()
        {
            StreamReader str = new StreamReader(@"C:\Users\Nurayim\Desktop\KBTU\Semester-2\PP2\LabWork2\Task2\s\1.txt"); // файл где хранятся числа
            string s = str.ReadToEnd(); // создаем строку, где будут элементы массива
            string[] a = s.Split(); // создаем массив
            List<int> l = new List<int>(); // создаем вектор
            Console.WriteLine(s);

            for (int i = 0; i < a.Length; ++i)
            {
                if ((int.Parse(a[i])) == 1)
                {
                    continue;
                }
                int prime = 0;
                for (int k = 2; k < (int.Parse(a[i])); ++k) // проверяем на prime
                {
                    if ((int.Parse(a[i])) % k == 0)
                    {
                        prime++;
                    }
                }
                if (prime < 1)
                {
                    l.Add(int.Parse(a[i])); // добавляем простые числа в вектор
                }
            }
            str.Close();
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Nurayim\Desktop\KBTU\Semester-2\PP2\LabWork2\Task2\s\2.txt"); // ссылка в другой txt файл
            for (int i = 0; i < l.Count; ++i)
            {
                streamWriter.Write(l[i] + " ");
            }
            streamWriter.Close();
        }
        static void Main(string[] args)
        {
            pr();
            Console.ReadKey();
        }
    }
}
