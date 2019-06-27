using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager_NoEF
{
    public interface DataSource
    {
        IEnumerable<Book> ShowAllBooks();
        IEnumerable<Author> ShowAllAuthors();
        Author GetAuthorById(int authorId);
        void InsertBook(Book b);
        void InsertAuthor(Author a);
        void DeleteBookById(int id);
        void DeleteAuthorById(int id);
    }
}
