using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager_NoEF
{
    public class DataProcessor
    {
        //Lui comunicherà con il DataSource, iniettato nel costruttore.
        DataSource source;
        public DataProcessor(DataSource dS)
        {
            source = dS;
        }
        public IEnumerable<Book> ShowAllBooks()
        {
            return source.ShowAllBooks();
        }

        public IEnumerable<Author> ShowAllAuthors()
        {
            return source.ShowAllAuthors();
        }

        public void InsertBook(string[] input)
        {
            //var id = int.Parse(input[0]);
            var title = input[0];
            var numPage = int.Parse(input[1]);
            var authorId = int.Parse(input[2]);
            var book = new Book(
                //id,
                title,
                numPage,
                authorId
                );
            source.InsertBook(book);
        }

        public void InsertAuthor(string[] input)
        {
            var firstname = input[0];
            var lastname = input[1];
            var author = new Author(
                firstname,
                lastname
                );
            source.InsertAuthor(author);
        }

        public void DeleteBookById(string input)
        {
            var id = int.Parse(input);
            source.DeleteBookById(id);
        }

        internal void DeleteAuthorById(string input)
        {
            var id = int.Parse(input);
            source.DeleteAuthorById(id);
        }
    }
}
