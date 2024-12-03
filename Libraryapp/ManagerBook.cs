using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Libraryapp
{
  
    public class ManagerBook
    {
      

        public static List<Book> library = new List<Book>(); //Criando a lista de books
        public Book RegisterBook()
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
            return newBook;
        }
        public static void ListBooks()
        {
            Console.WriteLine("Registered books list");
            var result = from newBook in library select new { newBook.Id, newBook.Name, newBook.Author, newBook.PubliYear, newBook.Isbn }; //Usando LINQ expressao tradicional

            foreach (var item in result)
            {
                Console.WriteLine($" Id: {item.Id}, Name: {item.Name}, Author: {item.Author}, ISBN: {item.Isbn}, Year: {item.PubliYear}");
            }
        }
        public Book SearchBooks()
        {
            Console.WriteLine("Enter the book ID to search for it :");
            string inputId = Console.ReadLine();
            if (int.TryParse(inputId, out int searchId))
            {
                var result = library.FirstOrDefault(book => book.Id == searchId); // usando LINQ com uma expressao lambda

                if (result != null) //validacao
                {
                    Console.WriteLine($"Id: {result.Id} Name: {result.Name}, Author: {result.Author}, ISBN: {result.Isbn}, Year: {result.PubliYear}");
                    return result;
                }


                else
                {
                    Console.WriteLine("Book not found");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Sorry, Invalid or Undefined Id");
                return null;
            }
        }
        public Book DeleteBook()
        {
            Console.WriteLine("Enter the book ID to search for it:");
            string inputId = Console.ReadLine();

            // Verifica se o ID informado é um número válido
            if (int.TryParse(inputId, out int searchId))
            {
                // Busca o livro pela ID
                var book = library.FirstOrDefault(r => r.Id == searchId);

                if (book != null)
                {
                    // Remove o livro e retorna o objeto removido
                    library.Remove(book);
                    Console.WriteLine($"Removed the book: {book.Name} successfully.");
                    return book; // Retorna o livro que foi removido
                }
                else
                {
                    Console.WriteLine("Invalid or non-existent ID.");
                    return null; // Retorna null se o livro não for encontrado
                }
            }
            else
            {
                // Se o ID não for um número válido
                Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
                return null;
            }
        }
        public void LoanBook()
        {
                // Selecionar o usuário
                Console.WriteLine("Enter user ID to process loan:");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    // Buscar o usuário na lista centralizada em User
                    var user = User.FindUserById(userId);
                    if (user == null)
                    {
                        Console.WriteLine("User not found.");
                        return;
                    }

                    // Buscar o livro usando SearchBooks
                    Book bookToLoan = SearchBooks();
                    if (bookToLoan == null) return;

                    // Remover o livro da biblioteca
                    if (library.Remove(bookToLoan))
                    {
                        // Adicionar o livro ao usuário
                        user.AddBook(bookToLoan);
                        Console.WriteLine($"Book '{bookToLoan.Name}' loaned to {user.Name}.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Could not loan the book.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid user ID.");
                }
        }

    public void AddBook(Book book)
        {
            library.Add(book);
        }
    }
}





