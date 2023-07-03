using FB_Tracker.Server.Data.Schema.Commands;
using MySqlConnector;

namespace FB_Tracker.Server.Data.Schema.Genesis;

internal static class MariaDbDatabase
{
    internal static void EnsureExists(MySqlConnection conn)
    {
        new MySqlCommand(CreateDb.statDb, conn).ExecuteNonQuery();
    }
}
