using System.Threading.Tasks;
using BotBase.Databases;

namespace BotBase
{
    public static class DatabaseManager
    {
        public static readonly MainDatabase database;

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
