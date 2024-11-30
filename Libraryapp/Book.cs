using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraryapp
{
    public class Book
    {
        
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Author { get; protected set; }
        public string Isbn { get; protected set; }
        public int PubliYear { get; protected set; }
        public Book(int id, string name, string author, string isbn, int publiYear)
        {
            this.Id = id; 
            Name = name;
            Author = author;
            Isbn = isbn;
            PubliYear = publiYear;
        }

    }
        
}
