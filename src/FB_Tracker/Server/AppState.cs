using FB_Tracker.Shared.Entities.Teams;

namespace FB_Tracker.Server;

public class AppState
{
    public int? SelectedSeason { get; set; } = null;
    public IEnumerable<Team> Teams { get; set; }
    public bool TeamsLoaded { get; set; } = false;
}
