using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Sync
{
    class Chronik
    {

        string dataSource = "SQLiteSync.db";

        SQLiteConnection connection = new SQLiteConnection();
        public void datenbank()
        {

            connection.ConnectionString = "Data Source=" + dataSource;
            connection.Open();

        }
        
    }
}
