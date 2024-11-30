using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Libraryapp
{
    public static class Menu
    {
        public static void Show()
        {
            Console.WriteLine(" Enter the option of your choice (enter the number)");
            Console.WriteLine("1 - Register new a Book");
            Console.WriteLine("2 - List Registered Books");
            Console.WriteLine("3 - Consult a Book");
            Console.WriteLine("4 - Remove a Book");
            Console.WriteLine("0 - Exit");
            short option;
            while (!short.TryParse(Console.ReadLine(), out option) || option < 0 || option > 4) // validacao do menu
            {
                Console.WriteLine("Invalid option. Enter a number between 0 and 4:");
                Menu.Show();
            }

            switch (option)
            {
                case 1: ManagerBook.RegisterBook(); break;
                case 2: ManagerBook.ListBooks(); break;
                case 3: ManagerBook.SearchBooks(); break;
                case 4: ManagerBook.DeleteBooks(); break;
                case 0: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
