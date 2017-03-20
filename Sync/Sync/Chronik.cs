using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using static System.Diagnostics.Debug;

namespace Sync
{
    class Chronik
    {
        string dataSource = "SQLiteSync.db";
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command;

        private void Datenbank() {
            command = new SQLiteCommand(connection);
            connection.ConnectionString = "Data Source=" + dataSource;
            connection.Open();
            

            // Erstellen der Tabelle, sofern diese noch nicht existiert.
            command.CommandText = "CREATE TABLE IF NOT EXISTS beispiel ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);";
            command.ExecuteNonQuery();

            // Einfügen eines Test-Datensatzes.
            command.CommandText = "INSERT INTO beispiel (id, name) VALUES(NULL, 'Test-Datensatz!')";
            command.ExecuteNonQuery();

            // Freigabe der Ressourcen.
            command.Dispose();
            
        }
        public void Auslesen()
        {
            command = new SQLiteCommand(connection);

            // Auslesen des zuletzt eingefügten Datensatzes.
            command.CommandText = "SELECT id, name FROM beispiel ORDER BY id DESC LIMIT 0, 1";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                WriteLine("Dies ist der {0}. eingefügte Datensatz mit dem Wert: \"{1}\"", reader[0].ToString(), reader[1].ToString());
            }

            // Beenden des Readers und Freigabe aller Ressourcen.
            reader.Close();
            reader.Dispose();

            command.Dispose();
        }
        
        
    }
}


