using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program {

        public static string filePath = @"D:\PCOI\lab5\file.txt";

        static void Main(string[] args)
        {
            
            Menu();
        }


        public static void Show()
        {

            StreamReader fs = new StreamReader(filePath);
            string s = "";
            while (s != null)
            {
                s = fs.ReadLine();
                Console.WriteLine(s);
            }

            fs.Close();
            
        }

        public static void Add()
        {

            Console.WriteLine("Введите текст");
            string text = Console.ReadLine();

            StreamWriter streamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
            

            streamWriter.WriteLine(text);
            Console.WriteLine(" - - - - - Добавлено! - - - - - ");

            streamWriter.Close();

        }

        public static void Edit()
        {
            Show();
            Console.WriteLine("Введите номер строки, котрую хотите изменить");
            int lineNumber = Convert.ToInt32(Console.ReadLine());

            string[] line = File.ReadAllLines(filePath, System.Text.Encoding.Default);

            if (lineNumber <= 0 || lineNumber > line.Length) {
                Console.WriteLine("Нет такой строки");
                Menu();
            }

            Console.WriteLine("Введите текст на замену");
            string text = Console.ReadLine();

            var fileContents = File.ReadAllText(filePath);

            fileContents = fileContents.Replace(line[lineNumber - 1], text);

            System.IO.File.WriteAllText(filePath, fileContents);
            Console.WriteLine(" - - - - - Изменено! - - - - - ");

        }

        public static void Delete()
        {
            Show();
            Console.WriteLine("Введите номер строки, котрую хотите удалить");
            int deleteLine = Convert.ToInt32(Console.ReadLine());


            var file = new List<string>(System.IO.File.ReadAllLines(filePath));
            file.RemoveAt(deleteLine-1);
            File.WriteAllLines(filePath, file.ToArray());

        }

        public static void Search()
        {
            Show();
            Console.WriteLine("Введите, что хотите найти");
            string text = Console.ReadLine();

            string[] line = File.ReadAllLines(filePath, System.Text.Encoding.Default);
            bool flag = false;

            for (int i = 0; i < line.Length; i++)
            {

                if (line[i].Contains(text))
                {

                    Console.WriteLine(" - - - - - Найдно! - - - - - ");
                    Console.WriteLine(line[i]);
                    flag = true;
                    break;

                }
            }

            if (!flag) {
                Console.WriteLine(" - - - - - Ничего не найдено! - - - - - ");
            }

        }

        public static void Sort()
        {
            var file = new List<string>(System.IO.File.ReadAllLines(filePath));
            file.Sort();
            File.WriteAllLines(filePath, file.ToArray());

            Console.WriteLine(" - - - - - Отсортировано - - - - - ");

        }



        public static void Menu() {

            Console.WriteLine(" ");
            Console.WriteLine("1 - Просмотр");
            Console.WriteLine("2 - Добавить");
            Console.WriteLine("3 - Изменить");
            Console.WriteLine("4 - Удалить");
            Console.WriteLine("5 - Поиск");
            Console.WriteLine("6 - Сортировка");
            Console.WriteLine("7 - Выход");

            string line =  Console.ReadLine();

            switch (line)
            {
         
                case "1":
                    Show();
                    Menu();
                    break;
                case "2":
                    Add();
                    Menu();
                    break;
                case "3":
                    Edit();
                    Menu();
                    break;
                case "4":
                    Delete();
                    Menu();
                    break;
                case "5":
                    Search();
                    Menu();
                    break;
                case "6":
                    Sort();
                    Menu();
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Неверный ввод!");
                    Menu();
                    break;
            }
        }
    }
}
