using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libraryapp
{
  
    {

        public static List<Book> library = new List<Book>(); //Criando a lista
        public static void RegisterBook()
        {
            Console.WriteLine("Registering a new book:");

            Console.Write("Enter the book name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name)) //validacao
            {
                Console.Write("Invalid Author. Enter a valid name");
                name = Console.ReadLine();
            }

            Console.Write("Enter the author: ");
            string author = Console.ReadLine();
            while (string.IsNullOrEmpty(author)) //validacao
            {
                Console.Write("Invalid Author. Enter a valid name");
                author = Console.ReadLine();
            }

            Console.Write("Enter the ISBN: ");
            string isbn = Console.ReadLine();
            while (string.IsNullOrEmpty(isbn)) //validacao
            {
                Console.Write("Invalid ISBN. Enter a valid code: ");
                isbn = Console.ReadLine();
            }

            Console.Write("Enter the publication year: ");
            int publiYear;
            while (!int.TryParse(Console.ReadLine(), out publiYear) || publiYear < 0) //validacao
            {
                Console.Write("Invalid year. Enter a valid publication year: ");
            }
            int id = library.Count + 1; // Atribui o próximo ID disponível e incrementa o contador
            Book newBook = new(id, name, author, isbn, publiYear);
            library.Add(item: newBook);
            Console.WriteLine("Book registered successfully!");
            Console.WriteLine($"ID: {id}, Name: {newBook.Name}, Author: {newBook.Author}, ISBN: {newBook.Isbn}, Publish Year: {newBook.PubliYear}");
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
            Menu.Show();
        }
        public static void ListBooks()
        {
            Console.WriteLine("Registered books list");
            var result = from newBook in library select new { newBook.Id, newBook.Name, newBook.Author, newBook.PubliYear, newBook.Isbn }; //Usando LINQ expressao tradicional

            foreach (var item in result)
            {
                Console.WriteLine($" Id: {item.Id}, Name: {item.Name}, Author: {item.Author}, ISBN: {item.Isbn}, Year: {item.PubliYear}");
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
            Menu.Show();
        }
        public static void SearchBooks()
        {
            Console.WriteLine("Enter the book ID to search for it :");
            string inputId = Console.ReadLine();
            if (int.TryParse(inputId, out int searchId))
            {
                var result = library.FirstOrDefault(book => book.Id == searchId); // usando LINQ com uma expressao lambda

                if (result != null) //validacao
                {
                    Console.WriteLine($"Id: {result.Id} Name: {result.Name}, Author: {result.Author}, ISBN: {result.Isbn}, Year: {result.PubliYear}");
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show();
                }


                else
                {
                    Console.WriteLine("Book not found");
                }
            }
            else
            {
                Console.WriteLine("Sorry, Invalid or Undefined Id");
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
            Menu.Show();

        }
        public static void DeleteBooks()
        {
            Console.WriteLine("Enter the book ID to search for it :");
            string inputId = Console.ReadLine();
            if (int.TryParse(inputId, out int searchId))
            {
                var result = library.FirstOrDefault(book => book.Id == searchId); // usando LINQ com uma expressao lambda

                if (result != null) //validacao
                {
                    Console.WriteLine($"Id: {result.Id} Name: {result.Name}, Author: {result.Author}, ISBN: {result.Isbn}, Year: {result.PubliYear}");
                    library.Remove(result);
                    Console.WriteLine($" Book Name: {result.Name} is removed sucessfuly");
                    Console.WriteLine("Press any key to return to the menu");
                    Console.ReadLine();
                    Menu.Show();
                }else
                {
                    Console.WriteLine("Book not found");
                }

            }
            else
            {
                Console.WriteLine("Invalid or inexist ID");
            }
            Console.WriteLine("Press any key to return to the menu");
            Console.ReadLine();
            Menu.Show();

        }
    }
}

