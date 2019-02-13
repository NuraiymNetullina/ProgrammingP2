using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader str = new StreamReader(@"C:\Users\Nurayim\Desktop\KBTU\Semester-2\PP2\LabWork2\Task1\pln\p.txt"); // ссылка в тхт файл
            string s = str.ReadToEnd();
            str.Close();
            string s1 = ""; // создаем пустую строку
            for (int i = s.Length - 1; i >= 0; --i) // пробегаемся от конца до нулевого элемента
            {
                s1 += s[i]; // добавляем каждый элемент в новую строку
            }
            if (s == s1) // если перевернутая строка равна заданной строке 
            {
                Console.WriteLine("Yes"); // то строка polindrom
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();
        }
    }
}
