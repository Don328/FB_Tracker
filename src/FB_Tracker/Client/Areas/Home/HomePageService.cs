using FB_Tracker.Shared.Entities.Teams;
using System.Net.Http;
using System.Net.Http.Json;

namespace FB_Tracker.Client.Components.Home;

public class HomePageService : IHomePageService
{
    private readonly HttpClient http;

    public HomePageService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<int> GetSelectedSeason()
    {
        var response = await http.GetFromJsonAsync<int>("state/season");

        return response;
    }

    public async Task SetSelectedSeason(int season)
    {
        var response = await http.PostAsJsonAsync("state/season", season);
        if (response.IsSuccessStatusCode)
        {

        }

        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Team>> GetTeams()
    {
        var teams = new List<Team>();
        var response = await http.GetFromJsonAsync<IEnumerable<Team>>("state/teams");
        if (response is null) return teams;
        teams = response.ToList();
        return await Task.FromResult(teams.AsEnumerable());
    }

    public async Task<IEnumerable<Team>> ImportPrevSeasonTeams()
    {
        var response = await http.GetAsync("state/import-teams");
        if (response.IsSuccessStatusCode)
        {
            return await GetTeams();
        }

        return new List<Team>();
    }

}
