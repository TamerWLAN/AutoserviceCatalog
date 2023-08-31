using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using db_TO.DAL;

namespace db_TO.model
{   
    class Program
    {
        static void Menu(db_TO.DAL.AutoParkDBStorage db)
        {
            string input = "";

            while (input != "0")
            {
                Console.WriteLine(" Выберите пункт меню :\n 1 - Добавить авто в список" +
                    "\n 2 - Добавить запись о ТО\n 3 - Добавить запись о работах в рамках ТО" +
                    "\n 4 - Вывести информацию обо всех автомобилях" +
                    "\n 5 - Вывести информацию о всех ТО" +
                    "\n 6 - Вывести информацию о работах в рамках ТО" +
                    "\n 7 - Удалить модель\n 0 - Выход");
                Console.Write("\n> ");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        FucnForInterface.AddCar(db);
                        break;
                    case "2":
                        FucnForInterface.AddMaintenace(db);
                        break;
                    case "3":
                        FucnForInterface.AddWork(db);
                        break;
                    case "4":
                        FucnForInterface.PrintAllCarsInfo(db);
                        break;
                    case "5":
                        FucnForInterface.PrintAllMaintenancesInfo(db);
                        break;
                    case "6":
                        FucnForInterface.PrintAllWorksInfo(db);
                        break;
                    case "7":
                        FucnForInterface.DeleteModel(db);
                        break;
                    case "0":
                        Console.WriteLine("\n Работа программы завершена");
                        break;
                    default:
                        Console.WriteLine("\n Введите доступную команду");
                        break;
                }
                Console.WriteLine("\n Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            
            //ЕСЛИ ДОБАВЛЯТЬ ОДНУ И ТУ ЖЕ ЗАПЧАСТЬ, В ТАБЛИЦЕ ВОРКС - СП ПАРТС ТОЛЬКО ОДНА ЗАПИСЬ

            var _context = new TOContext();
            AutoParkDBStorage db = new AutoParkDBStorage(_context);
            Menu(db);

            Console.ReadKey();
        }
    }
}
