using SQLite;
using System;
using System.IO;
namespace Workout.Servives
{
    public class SQLiteDb
    {

        private static SQLiteDb instance = null;
        public static SQLiteDb Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLiteDb();
                }
                return instance;
            }
        }

        public SQLiteAsyncConnection Connection;

        private SQLiteDb()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MyData.db");
            Connection = new SQLiteAsyncConnection(path);
        }

    }
}
