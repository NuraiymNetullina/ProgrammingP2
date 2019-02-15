using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task1
{
    enum FarMode // нумерованный список 
    {
        dir,
        file
    }
    class Layer // класс, где хранятся действия 
    {
        int index; // переменная индекс
        public int Index
        {
            get
            {
                return index; // возвращем индекс
            }
            set
            {
                if (value < 0) // если значение меньше нуля, то возвращаем курсор на последнюю строку
                {
                    index = FSI.Length - 1;
                }
                else if (value >= FSI.Length) // если значение больше чем длина строк, то возвращаем курсор на нулевую строку
                {
                    index = 0;
                }
                else
                {
                    index = value; // приравниваем курсор на значаение 
                }
            }
        }
        public FileSystemInfo[] FSI // массив, где хранятся информация о файле
        {
            get;
            set;
        }
        public void Draw() // функция, которая показывает на экране список файлов и папок
        {
            Console.BackgroundColor = ConsoleColor.Black; // делаем экран черным и очищаем его
            Console.Clear();
            for (int i = 0; i < FSI.Length; ++i) // через цикл фор пробегаемся по списку
            {
                if (index == i) // если индекс равен курсору, то красим в синий цвет
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(i + 1 + ". " + FSI[i].Name);
                }

                else if (FSI[i].GetType() == typeof(DirectoryInfo)) // через функцию геттайп определяем тип. если тип=папке, то красим название папки в желтый цвет 
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(i + 1 + ". " + FSI[i].Name);
                }
                else if (FSI[i].GetType() == typeof(FileInfo)) // если это файл, то красим название в белый цвет
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(i + 1 + ". " + FSI[i].Name); // выводим на экран редактированный список
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo link = new DirectoryInfo(@"C:\Users\Nurayim\Desktop\KBTU"); // ссылка на папку
            Stack<Layer> history = new Stack<Layer>(); // создаем стэк, где будем хранить список
            FarMode mode = FarMode.dir; // приравниваем тип папке 
            history.Push(new Layer
            {
                FSI = link.GetFileSystemInfos(), // через функцию гетфайлсистеминфос достаем содержание папки
                Index = 0 // приравниваем индекс нулю, то есть курсор начинается с нулевого элемента
            });
            while (true) // создаем бесконечный цикл
            {
                if (mode == FarMode.dir) // если тип равен папке
                {
                    history.Peek().Draw(); // то вызываем метод 
                }
                ConsoleKeyInfo consoleKey = Console.ReadKey(); // функция, где хранится информация о клавишах
                switch (consoleKey.Key)
                {
                    case ConsoleKey.UpArrow: // если мы нажимаем на этот клавиш, то индекс уменьшается 
                        history.Peek().Index--;
                        break;
                    case ConsoleKey.DownArrow: // индекс прибавляется
                        history.Peek().Index++;
                        break;
                    case ConsoleKey.Enter:
                        int x1 = history.Peek().Index; // создаем переменную, которая будет служить в роле индекса
                        FileSystemInfo fileSystemInfo1 = history.Peek().FSI[x1];
                        if (fileSystemInfo1.GetType() == typeof(DirectoryInfo)) // определяем тип
                        {
                            DirectoryInfo d = fileSystemInfo1 as DirectoryInfo;
                            history.Push(new Layer { FSI = d.GetFileSystemInfos(), Index = 0 }); // если это папка, то открываем папку, достаем новый чписокб и приравниваем индекс нулю
                        }
                        else
                        {
                            mode = FarMode.file;
                            using (FileStream fs = new FileStream(fileSystemInfo1.FullName, FileMode.Open, FileAccess.Read)) // если это файл, то открываем файл и показываем содержание файла
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (mode == FarMode.dir) // если это папка, то удаляем через поп последнее окно
                        {
                            history.Pop();
                        }
                        else if (mode == FarMode.file)
                        {
                            mode = FarMode.dir;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().Index; 
                        FileSystemInfo fileSystemInfo2 = history.Peek().FSI[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo)) // если это папка, то удаляем через булевую функцию тру, то есть соглашаемся удалению содержания папки
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().FSI = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo; // если это файл, то просто удаляем файл и возвращаем обновленный список 
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().FSI = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().Index--; // при удвлении индекс уменьшается
                        break;
                    case ConsoleKey.F2:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string name = Console.ReadLine(); // создаем строкуб где будем писать новое имя
                        int x3 = history.Peek().Index;
                        FileSystemInfo fileSystemInfo3 = history.Peek().FSI[x3];
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo)) // определяем тип
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;
                            Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent + "/" + name); // если это папка, то меняем имя через функцию парент
                            history.Peek().FSI = directoryInfo.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo;
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name); // если файл, то через дайректори фулл нэйм
                            history.Peek().FSI = fileInfo.Directory.GetFileSystemInfos();
                        }
                        break;
                }
            }
        }
    }
}
