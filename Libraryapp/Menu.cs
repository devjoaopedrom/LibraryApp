using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Libraryapp
{
    public class Menu
    {
        private readonly ManagerBook _managerBook;
        public Menu(ManagerBook managerBook)
        {
            _managerBook = managerBook; 
        }
        public static void Show()
            
        {
            Console.WriteLine(" Enter the option of your choice (enter the number)");
            Console.WriteLine("1 - Register new a Book");
            Console.WriteLine("2 - List Registered Books");
            Console.WriteLine("3 - Consult a Book");
            Console.WriteLine("4 - Remove a Book");
            Console.WriteLine("5 - Loan Book");
            Console.WriteLine("0 - Exit");
            ManagerBook managerBook = new ManagerBook();
            short option;
            while (!short.TryParse(Console.ReadLine(), out option) || option < 0 || option > 5) // validacao do menu
            {
                Console.WriteLine("Invalid option. Enter a number between 0 and 4:");
                Menu.Show();
            }

            switch (option)
            { 
                
                case 1: managerBook.RegisterBook(); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show(); break;
                case 2: ManagerBook .ListBooks(); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show(); break;
                case 3: managerBook.SearchBooks(); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show(); break;
                case 4: managerBook.DeleteBook(); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show(); break;
                case 5:
                    managerBook.LoanBook(); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show(); break;
                case 0: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Invalid option"); Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show();
                    break;
            }
        }
    }
}
