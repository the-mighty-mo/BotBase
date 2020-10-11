using System.Threading.Tasks;
using BotBase.Databases;

namespace BotBase
{
    public static class DatabaseManager
    {
        public static readonly Database database;

        public static async Task InitAsync()
        {
            await Task.WhenAll(
                database.InitAsync()
            );
        }

        public static async Task CloseAsync()
        {
            await Task.WhenAll(
                database.CloseAsync()
            );
        }
    }
}
