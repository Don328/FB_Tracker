using FB_Tracker.Server.Data.Schema.Commands;
using FB_Tracker.Server.Data.Schema.Tables;
using MySqlConnector;
using System.Runtime.InteropServices;

namespace FB_Tracker.Server.Data.Schema.Genesis;

internal static class DbTables
{
    internal static void EnsureExists(MySqlConnection conn)
    {
        new MySqlCommand(CreateTable.Teams, conn).ExecuteNonQuery() ;
    }

    internal static async Task Seed2021Teams(MySqlConnection conn)
    {
        var teams = await TeamsTable.ReadSeason(conn, 2021);
        if (teams.Count() == 32) return;

        await new MySqlCommand(SeedData.Team_1, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_2, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_3, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_4, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_5, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_6, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_7, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_8, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_9, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_10, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_11, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_12, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_13, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_14, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_15, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_16, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_17, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_18, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_19, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_20, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_21, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_22, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_23, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_24, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_25, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_26, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_27, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_28, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_29, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_30, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_31, conn).ExecuteNonQueryAsync();
        await new MySqlCommand(SeedData.Team_32, conn).ExecuteNonQueryAsync();
    }
}
