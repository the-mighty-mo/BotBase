using System.Threading.Tasks;
using BotBase.Databases;

namespace BotBase
{
    public class DatabaseManager
    {
        public readonly Database database;

        public async Task InitAsync()
        {
            await Task.WhenAll(
                database.InitAsync()
            );
        }
    }
}
