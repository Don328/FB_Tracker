using FB_Tracker.Server.Data.Models;
using FB_Tracker.Server.Data.Schema.Commands;
using FB_Tracker.Server.Data.Schema.Genesis;
using FB_Tracker.Shared.Entities.Teams;
using MySqlConnector;

namespace FB_Tracker.Server.Data.Schema.Tables;

internal static class TeamsTable
{
    internal static async Task<int> Create(
        MySqlConnection conn, Team team)
    {
        int createdId = 0;
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = CreateRow.team;
            ParamBuilder.Build(cmd, "@season", team.Season);
            ParamBuilder.Build(cmd, "@locale", team.Locale);
            ParamBuilder.Build(cmd, "@name", team.Name);
            ParamBuilder.Build(cmd, "@abrev", team.Abrev);
            ParamBuilder.Build(cmd, "@conference", team.Conference);
            ParamBuilder.Build(cmd, "@region", team.Region);
            var response = await cmd.ExecuteScalarAsync();
            if (response != null) createdId = (int)response;
        }

        return await Task.FromResult(createdId);
    }

    internal static async Task<IEnumerable<_Team>> ReadSeason(
        MySqlConnection conn, int season)
    {
        var teams = new List<_Team>();
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = ReadTable.TeamsBySeason;
            ParamBuilder.Build(cmd, "@season", season);

            using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                teams.Add(new _Team(
                    Id: reader.GetInt32(0),
                    Season: reader.GetInt32(1),
                    Locale: reader.GetString(2),
                    Name: reader.GetString(3),
                    Abrev: reader.GetString(4),
                    ConferenceIndex: reader.GetInt32(5),
                    RegionIndex: reader.GetInt32(6)));
            }
        }

        return await Task.FromResult(teams);
    }
}
