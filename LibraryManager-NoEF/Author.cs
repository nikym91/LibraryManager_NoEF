using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager_NoEF
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Book> Books { get; set; }

        public Author(){ }
        public Author(int id, string firstname, string lastname)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
        }
        public Author(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public Author(int id, string firstname, string lastname, List<Book> books)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Books = books;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Firstname: {Firstname}, Lastname: {Lastname}";
        }
    }
}
