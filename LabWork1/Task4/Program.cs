using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // считываем количество элементов массива
            int[,] a = new int[n, n]; // создаем двумерный массив
            for(int i=1; i<=n; ++i) // пробегаемся по массиву 
            {
                for(int j=1; j<=i; ++j)
                {
                    Console.Write("[*]"); // вводим символ
                }
                Console.WriteLine(); // новая строка
            }
            Console.ReadKey();
        }
    }
}
