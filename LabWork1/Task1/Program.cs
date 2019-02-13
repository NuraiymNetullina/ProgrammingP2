using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static bool Prime(int n)
        {
            if (n <= 1)
            {
                return false; // 1 не является простым числом
            }
            else
            {
                bool ok = true;
                for(int i=2; i<n; ++i)
                {
                    if (n % i == 0) // проверяем число на prime
                    {
                        ok = false;
                        break;
                    }
                }
                return ok;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // считываем количество элементов массива
            string s = Console.ReadLine(); 
            string[] a = s.Split(); // создаем массив стрингов, разбиваем на подстроки 
            int[] b = new int[n]; // новый массив , в котором будут храниться простые числа
            for(int i=0; i < n; ++i)
            {
                b[i] = int.Parse(a[i]); // добавляем числа массива а
            }
            int cnt = 0; // коунтер, который будет показывать количество простых чисел
            for (int i = 0; i < n; ++i)
            {
                if (Prime(b[i]) == false) // закидываем числа массива в функцию, чтобы проверить 
                {
                    b[i] = 0;
                }
                else
                {
                    cnt++;
                }
            }
                Console.WriteLine(cnt); 
                for(int i=0; i < n; ++i)
                {
                    if (b[i] != 0)
                    {
                        Console.Write(b[i] + " ");
                    }
                }
            Console.ReadKey();
        }
    }
}
