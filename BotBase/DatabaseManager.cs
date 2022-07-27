using BotBase.Databases;
using System.Threading.Tasks;

namespace BotBase
{
    public static class DatabaseManager
    {
        public static readonly MainDatabase database = new();

        public static Task InitAsync() =>
            Task.WhenAll(
                database.InitAsync()
            );

        public static Task CloseAsync() =>
            Task.WhenAll(
                database.CloseAsync()
            );
    }
}