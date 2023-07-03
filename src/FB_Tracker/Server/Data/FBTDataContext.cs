using FB_Tracker.Server.Data.Repo;
using FB_Tracker.Server.Data.Schema.Genesis;
using FB_Tracker.Shared.Entities.Teams;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace FB_Tracker.Server.Data;

public class FBTDataContext : DbContext
{
    private readonly AppState state;
    private readonly MySqlConnection conn;
    private TeamsRepo teamsRepo = new();

    internal IEnumerable<Team> Teams { get => teamsRepo.Data; }
    
    public FBTDataContext(
        AppState state,
        IConfiguration config)
    {
        this.state = state;
        conn = new MySqlConnection(connectionString: config.GetConnectionString("statDb"));
        EnsureDbExists();
        RefreshTeamsList().GetAwaiter();
    }

    private void EnsureDbExists()
    {
        conn.Open();
        MariaDbDatabase.EnsureExists(conn);
        DbTables.EnsureExists(conn);
        DbTables.Seed2021Teams(conn).GetAwaiter().GetResult();
        conn.Close();
    }

    public async Task RefreshTeamsList()
    {
        await conn.OpenAsync();
        await teamsRepo.RefreshData(conn, state.SelectedSeason ?? 0);
        await conn.CloseAsync();
        await Task.CompletedTask;
    }

    public async Task ImportTeams()
    {
        var prev = state.SelectedSeason - 1;
        var teams = await teamsRepo.GetBySeason(conn, prev??0);
        foreach(var team in teams)
        {
            team.Id = 0;
            team.Season++;
        }

        await conn.OpenAsync();
        await teamsRepo.SaveTeamRecords(conn, teams.ToList());
    }
}
