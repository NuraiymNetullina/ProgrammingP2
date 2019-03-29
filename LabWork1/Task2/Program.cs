using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public string year;
        public List(string name, string id, string year)
        {
            this.name = name;
            this.id = id;
            this.year = year; // присваиваем значения 
        }
        public void Show()
        {
            Console.WriteLine(name + " " + id + " " + year); // показываем на экране имя, айди, год обучения
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student students = new Student(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()); // считываем имя, айди, год обучения
            students.Show(); 
            Console.ReadKey();
        }
    }
}
