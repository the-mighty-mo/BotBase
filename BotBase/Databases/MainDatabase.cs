﻿using BotBase.Databases.MainDatabaseTables;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotBase.Databases
{
    public class MainDatabase
    {
        private readonly SqliteConnection connection = new("Filename=Database.db");
        private readonly Dictionary<System.Type, ITable> tables = new();

        public DatabaseTable Database => (tables[typeof(DatabaseTable)] as DatabaseTable)!;

        public MainDatabase() =>
            tables.Add(typeof(DatabaseTable), new DatabaseTable(connection));

        public async Task InitAsync()
        {
            IEnumerable<Task> GetTableInits()
            {
                foreach (var table in tables.Values)
                {
                    yield return table.InitAsync();
                }
            }
            await connection.OpenAsync();
            await Task.WhenAll(GetTableInits());
        }

        public Task CloseAsync() => connection.CloseAsync();
    }
}