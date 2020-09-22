using System;
using System.Data.SQLite;

namespace UtilData
{
    public class SqLiteBase
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\Data.sqlite"; }
        }

        public static SQLiteConnection SimpleDbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }
    }
}