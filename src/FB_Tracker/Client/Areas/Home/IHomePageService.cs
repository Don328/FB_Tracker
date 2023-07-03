using FB_Tracker.Shared.Entities.Teams;

namespace FB_Tracker.Client.Components.Home;

public interface IHomePageService
{
    Task<int> GetSelectedSeason();
    Task SetSelectedSeason(int season);
    Task<IEnumerable<Team>> GetTeams();
    Task<IEnumerable<Team>> ImportPrevSeasonTeams();
}
