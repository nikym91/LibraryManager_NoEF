using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace LibraryManager_NoEF
{
    public class DBDataSource : DataSource
    {
        const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookManager;Integrated Security=True";
        const string QUERY_ALL_BOOKS = "SELECT id, title, numpage, authorid FROM Book";
        const string QUERY_ALL_AUTHORS = "SELECT id, firstname, lastname FROM Author";
        const string QUERY_AUTHOR_BY_ID = "SELECT id, firstname, lastname FROM Author WHERE id = @authorId";
        const string QUERY_BOOKS_BY_AUTHORID = "SELECT id, title, numpage FROM Book WHERE authorid = @authorId";
        const string QUERY_INSERT_BOOK = "INSERT INTO Book (title, numpage, authorid) VALUES (@title, @numpage, @authorid)";
        const string QUERY_INSERT_AUTHOR = "INSERT INTO Author (firstname, lastname) VALUES (@firstname, @lastname)";
        const string QUERY_DELETE_BOOK = "DELETE FROM Book WHERE id=@id";
        const string QUERY_DELETE_AUTHOR = "DELETE FROM Author WHERE id=@id";
        public void InsertAuthor(Author a)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_INSERT_AUTHOR, conn))
                {
                    command.Parameters.AddWithValue("@firstname", a.Firstname);
                    command.Parameters.AddWithValue("@lastname", a.Lastname);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertBook(Book b)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_INSERT_BOOK, conn))
                {
                    //command.Parameters.AddWithValue("@id", b.Id);
                    command.Parameters.AddWithValue("@title", b.Title);
                    command.Parameters.AddWithValue("@numpage", b.NumPage);
                    command.Parameters.AddWithValue("@authorid", b.AuthorId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Author> ShowAllAuthors()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_ALL_AUTHORS, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    var posId = reader.GetOrdinal("id");
                    var posFirstname = reader.GetOrdinal("firstname");
                    var posLastname = reader.GetOrdinal("lastname");
                    var authors = new List<Author>();

                    while (reader.Read())
                    {
                        var a = new Author(
                            reader.GetInt32(posId),
                            reader.GetString(posFirstname),
                            reader.GetString(posLastname)
                            );
                        authors.Add(a);
                    }
                    return authors;
                }
            }
        }

        public IEnumerable<Book> ShowAllBooks()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_ALL_BOOKS, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    var posId = reader.GetOrdinal("id");
                    var posTitle = reader.GetOrdinal("title");
                    var posNumPage = reader.GetOrdinal("numpage");
                    var posAuthorId = reader.GetOrdinal("authorid");
                    var books = new List<Book>();

                    while (reader.Read())
                    {
                        var author = GetAuthorById(reader.GetInt32(posAuthorId));
                        var b = new Book(
                            reader.GetInt32(posId),
                            reader.GetString(posTitle),
                            reader.GetInt32(posNumPage),
                            author
                            );
                        books.Add(b);
                    }
                    return books;
                }
            }
        }
        public Author GetAuthorById(int authorId)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_AUTHOR_BY_ID, conn))
                {
                    command.Parameters.AddWithValue("@authorId", authorId);

                    SqlDataReader reader = command.ExecuteReader();

                    var posId = reader.GetOrdinal("id");
                    var posFirstname = reader.GetOrdinal("firstname");
                    var posLastname = reader.GetOrdinal("lastname");
                    Author a = new Author();
                    while (reader.Read())
                    {
                        var author = new Author(
                        reader.GetInt32(posId),
                        reader.GetString(posFirstname),
                        reader.GetString(posLastname)
                        );
                        a = author;
                    }
                    return a;
                }
            }
        }

        public void DeleteBookById(int id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_DELETE_BOOK, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAuthorById(int id)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(QUERY_DELETE_AUTHOR, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
