using FB_Tracker.Client.Areas.Components.SeasonSelect;
using FB_Tracker.Client.Components.Home;
using FB_Tracker.Shared.Entities.Teams;
using Microsoft.AspNetCore.Components;

namespace FB_Tracker.Client.Areas.Home;

public partial class HomePage : ComponentBase
{
    [Inject]
    public IHomePageService Service { get; set; }

    private int? _selectedSeason = null;
    private SeasonSelectModel _seasonSelectModel = new();
    private bool _showSelectSeason = false;
    private ViewMode _viewMode = ViewMode.NoSeason;
    private ViewMode _viewMode_buffer = ViewMode.Empty;
    private List<Team> _teams = new();

    private enum ViewMode
    {
        NoSeason,
        TeamsView,
        SeasonView,
        Empty,
    }

    protected override async Task OnInitializedAsync()
    {
        await GetSelectedSeason();
    }

    private async Task GetSelectedSeason()
    {
        var season = await Service.GetSelectedSeason();
        if (season > 0)
        {
            _selectedSeason = season;
            return;
        }
        
        _selectedSeason = null;
    }

    private void ShowSelectSeason()
    {
        _viewMode_buffer = _viewMode;
        _viewMode = ViewMode.Empty;
        _seasonSelectModel =
            new() { Season = _selectedSeason }; ;
        _showSelectSeason = true;
    }

    private void HideSelectSeason()
    {
        _showSelectSeason = false;
        _viewMode = _viewMode_buffer;
        _viewMode_buffer = ViewMode.Empty;
    }

    private async Task SetSelectedSeason(int? season)
    {
        await Service.SetSelectedSeason(season ?? 0);
        await GetSelectedSeason();
        HideSelectSeason();
        await GetTeams();
        ViewTeamsList();
    }

    private async Task GetTeams()
    {
        var result = await Service.GetTeams();
        if (result is not null)
        {
            _teams = result.ToList();
        }
    }

    private void ViewTeamsList()
    {
        _viewMode = ViewMode.TeamsView;
    }

    private void OnTeamsAccepted()
    {
        _viewMode = ViewMode.SeasonView;
    }

    private async Task LoadPrevSeasonTeams()
    {
        _teams.Clear();
        var result = await Service.ImportPrevSeasonTeams();
        if (result is not null ) _teams = result.ToList();
        ViewTeamsList();
    }
}