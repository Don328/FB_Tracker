using FB_Tracker.Server.Data.Mappers;
using FB_Tracker.Server.Data.Models;
using FB_Tracker.Server.Data.Schema;
using FB_Tracker.Server.Data.Schema.Commands;
using FB_Tracker.Server.Data.Schema.Tables;
using FB_Tracker.Shared.Entities.Teams;
using MySqlConnector;

namespace FB_Tracker.Server.Data.Repo;

internal class TeamsRepo
{
    internal IEnumerable<Team> Data { get; set; }
    
    internal async Task RefreshData(
        MySqlConnection conn,
        int season)
    {
        var teams = await GetBySeason(conn, season);
        Data = teams;
    }
    
    internal async Task<IEnumerable<Team>> GetBySeason(
        MySqlConnection conn,
        int season)
    {
        var teams = new List<Team>();
        var records = await TeamsTable.ReadSeason(conn, season);
        foreach (var record in records)
        {
            teams.Add(TeamsMapper.ToEntity(record));
        }

        return await Task.FromResult(teams);
    }

    internal async Task SaveTeamRecords(
        MySqlConnection conn,
        List<Team> entities)
    {
        foreach (var entity in entities)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = CreateRow.team;
            ParamBuilder.Build(cmd, "@season", entity.Season);
            ParamBuilder.Build(cmd, "@locale", entity.Locale);
            ParamBuilder.Build(cmd, "@name", entity.Name);
            ParamBuilder.Build(cmd, "@abrev", entity.Abrev);
            ParamBuilder.Build(cmd, "@conference", entity.Conference);
            ParamBuilder.Build(cmd, "@region", entity.Region);

            cmd.ExecuteNonQuery();
        }
        await Task.CompletedTask;
    }
}
