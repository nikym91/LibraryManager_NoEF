using System;

namespace LibraryManager_NoEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Fa partire il programma, devo creare un nuovo UI, DBDataSource e DataProcessor.
            //Poi lancio il metodo MainMenu della UI.
            DBDataSource dbSource = new DBDataSource();
            DataProcessor processor = new DataProcessor(dbSource);
            UserInterface UI = new UserInterface(processor);
            UI.MainMenu();
        }
    }
}
