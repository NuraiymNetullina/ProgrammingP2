using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Line(int line)
        {
            for(int i=0; i < line; ++i) // пробегаемся через цикл фор по строке
            {
                Console.Write("   "); // при увеличении индекса добавляем пустой отрезок 
            }
        }
        static void File(DirectoryInfo dir, int line)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                Line(line); // отправляем в функцию лайн
                Console.WriteLine(f.Name); // выводим имя файла
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Line(line); // отправляем в функцию лайн
                Console.WriteLine(d.Name); // выводим имя папки
                File(d, line + 1); 
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Nurayim\Desktop\KBTU\Semester-2"); // ссылка на папку
            File(dir, 0); // отправляем в функцию файл
            Console.ReadKey();
           
        }
    }
}
