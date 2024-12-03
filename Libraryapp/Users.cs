using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Libraryapp
{
    internal class User
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public User(int userId, string userName, string email)
        {
            Id = userId;
            Name = userName;
            Email = email;
        
        }
        public List<Book> BorrowedBooks = new List<Book>();
        public void AddBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void RemoveBook(Book book)
        {
            BorrowedBooks.Remove(book);
        }

        public static List<User> users = new List<User>(); ////Criando a lista de users
        public static User RegisterBegin()
        {
            Console.Write("Enter the your Username ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name)) //validacao
            {
                Console.Write("Invalid name. Enter a valid name");
                name = Console.ReadLine();
            }

            Console.Write("Enter the email ");
            string email = Console.ReadLine();
            while (string.IsNullOrEmpty(email)) //validacao
            {
                Console.Write("Invalid email. Enter a valid name");
                email = Console.ReadLine();
            }
            int userId = users.Count();
            User newUser = new User(userId, name, email);
            users.Add(item: newUser);
            Console.Write("User defined: ");
            Console.WriteLine($"ID: {userId}, Name: {newUser.Name}, Email: {newUser.Email}");
            return newUser;
        }
        public static User FindUserById(int userId)
        {
            return users.FirstOrDefault(user => user.Id == userId);
        }
    }
}
