using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotBase.Databases
{
    public class MainDatabase
    {
        private readonly SqliteConnection connection = new SqliteConnection("Filename=Database.db");

        public DatabaseTable Database;

        public MainDatabase()
        {
            Database = new DatabaseTable(connection);
        }

        public async Task InitAsync()
        {
            await connection.OpenAsync();

            List<Task> cmds = new List<Task>();
            using (SqliteCommand cmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Database (guild_id TEXT PRIMARY KEY, data TEXT NOT NULL);", connection))
            {
                cmds.Add(cmd.ExecuteNonQueryAsync());
            }

            await Task.WhenAll(cmds);
        }

        public async Task CloseAsync() => await connection.CloseAsync();

        public class DatabaseTable
        {
            private readonly SqliteConnection connection;

            public DatabaseTable(SqliteConnection connection) => this.connection = connection;
        }
    }
}
