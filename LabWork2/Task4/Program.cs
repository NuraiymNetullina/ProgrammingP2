using System;
using System.IO;
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
            string s = "Hello Woeld";
            StreamWriter file = new StreamWriter(@"C:\Users\Nurayim\Desktop\qwerty\zxcvb\Test.txt"); // ссылка папки, где создаем новый файл 
            string path2 = @"C:\Users\Nurayim\Desktop\qwerty\output.txt"; // ссылка файла, куда переносим содержимое строки  
            file.Write(s); // функция, которая присваивает значение
            file.Close(); // закрываем файл
            string path = @"C:\Users\Nurayim\Desktop\qwerty\zxcvb\Test.txt"; // ссылка файла, где хранится строка
            if (File.Exists(path2)) //Проверяем есть ли существующий файл
            {
                File.Delete(path2); //Если есть, то удаляем.
                File.Move(path, path2); //через функцию мув, перемещаем файл с path в path2
            }
        }
    }
}
