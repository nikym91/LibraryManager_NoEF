using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager_NoEF
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumPage { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public Book()
        {

        }
        public Book(int id, string title, int numPage, int authorId)
        {
            Id = id;
            Title = title;
            NumPage = numPage;
            AuthorId = authorId;
        }
        public Book(string title, int numPage, int authorId)
        {
            Title = title;
            NumPage = numPage;
            AuthorId = authorId;
        }

        public Book(int id, string title, int numPage, Author author)
        {
            Id = id;
            Title = title;
            NumPage = numPage;
            Author = author;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Title: {Title}, NumPage: {NumPage}, Author: {Author.Firstname} {Author.Lastname}";
        }
    }
}
