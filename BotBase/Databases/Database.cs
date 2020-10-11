﻿using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotBase.Databases
{
    public class Database
    {
        private readonly SqliteConnection cnDatabase = new SqliteConnection("Filename=Database.db");

        public async Task InitAsync()
        {
            await cnDatabase.OpenAsync();

            List<Task> cmds = new List<Task>();
            using (SqliteCommand cmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Database (guild_id TEXT PRIMARY KEY, data TEXT NOT NULL);", cnDatabase))
            {
                cmds.Add(cmd.ExecuteNonQueryAsync());
            }

            await Task.WhenAll(cmds);
        }
    }
}