using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager_NoEF
{
    public class UserInterface
    {
        //nella UI metto il menù e tutto quello che riguarda 
        //la scelta da console. Inoltre parla con il Data Processor,
        //quindi lo inietterò nel costruttore.

        const string MENU = "Inserisci:\n'b' per la lista libri\n'a' per la lista autori\n'i' per inserire un libro\n"+
            "'q' per inserire un autore\n'c' per cancellare un libro\n"+
            "'d' per cancellare un autore\n'e' per uscire";
        DataProcessor processor;

        public UserInterface(DataProcessor dP)
        {
            processor = dP;
        }

        public void MainMenu()
        {
            PrintMenu();
            string input = ReadLine();
            switch (input[0])
            {
                case 'b':
                    ShowAllBooks();
                    break;
                case 'a':
                    ShowAllAuthors();
                    break;
                case 'i':
                    CheckIfAuthorInDB();
                    break;
                case 'q':
                    InsertAuthor();
                    break;
                case 'c':
                    DeleteBookById();
                    break;
                case 'd':
                    DeleteAuthorById();
                    break;
                case 'd':
                    DeleteAuthorById();
                    break;
                case 'd':
                    DeleteAuthorById();
                    break;
                case 'e':
                    return;
                default:
                    Console.WriteLine("La lettera non è valida, riprova");
                    break;
            }
            MainMenu();
        }

        private void DeleteAuthorById()
        {
            ShowAllAuthors();
            var input = ReadLine("\nInserisci ID autore da eliminare: ");
            processor.DeleteAuthorById(input);
            Console.WriteLine("Autore eliminato\n");
            ShowAllAuthors();
        }

        private void DeleteBookById()
        {
            ShowAllBooks();
            var input = ReadLine("\nInserisci ID libro da eliminare: ");
            processor.DeleteBookById(input);
            Console.WriteLine("Libro eliminato\n");
            ShowAllBooks();
        }

        private void InsertAuthor()
        {
            var input = ReadLine("\nInserisci nome, cognome: ");
            var s = input.Split(',', ' ');
            processor.InsertAuthor(s);
            Console.WriteLine("Autore inserito:\n");
            ShowAllAuthors();
        }

        private void InsertBook()
        {
            var input = ReadLine("\nInserisci titolo, numero pagine, id autore: ");
            var s = input.Split(',', ' ');
            processor.InsertBook(s);
            Console.WriteLine("Libro inserito:\n");
            ShowAllBooks();
        }

        private void CheckIfAuthorInDB()
        {
            Console.WriteLine("\nLista Autori: ");
            ShowAllAuthors();
            var inputautore = ReadLine("L'autore del libro è già presente nel db?(s/n)");
            switch (inputautore[0])
            {
                case 's':
                    InsertBook();
                    break;
                case 'n':
                    InsertAuthor();
                    break;
                default:
                    Console.WriteLine("La lettera non è valida, riprova");
                    break;
            }
        }

        private void ShowAllAuthors()
        {
            IEnumerable<Author> authors = processor.ShowAllAuthors();
            foreach (var a in authors)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("\n");
        }

        private void ShowAllBooks()
        {
            IEnumerable<Book> books = processor.ShowAllBooks();
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("\n");
        }

        private string ReadLine(string prompt ="")
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }

        private void PrintMenu()
        {
            Console.WriteLine(MENU);
        }
    }
}
