using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // считываем количество элементов массива
            string s = Console.ReadLine();
            string[] a = s.Split(); // создаем массив стрингов, разбиваем на подстроки 
            int[] b = new int[n]; // новый массив 
            for (int i=0; i<n; ++i)
            {
                b[i] = int.Parse(a[i]); // добавляем числа массива а
            }
            for(int i=0; i<n; ++i)
            {
                Console.Write(b[i] + " " + b[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
