using FB_Tracker.Shared.Entities.Teams;
using FB_Tracker.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace FB_Tracker.Client.Areas.Components.TeamsDisplay;

public partial class TeamListView : ComponentBase
{
    [Parameter]
    public IEnumerable<Team> Teams { get; set; }

    [Parameter]
    public EventCallback OnUserValidated { get; set; }

    private List<Team> _afcTeams = new();
    private List<Team> _nfcTeams = new();
    private List<Team> _afcNorth = new();
    private List<Team> _afcSouth = new();
    private List<Team> _afcEast = new();
    private List<Team> _afcWest = new();
    private List<Team> _nfcNorth = new();
    private List<Team> _nfcSouth = new();
    private List<Team> _nfcEast = new();
    private List<Team> _nfcWest = new();
    private bool _teamsEqual32 = false;
    private bool _validConfs = false;
    private bool _validDivs = false;
    private bool _userValidation = false;
    private ViewMode _viewMode = 0;

    private enum ViewMode
    {
        All,
        ByConference,
        ByDivision
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _viewMode = ViewMode.All;
        RefreshLists();
    }

    private async Task UserValidateTeams()
    {
        _userValidation = true;
        await OnUserValidated.InvokeAsync();
    }

    private void RefreshLists()
    {
        CreateDivisionLists();
        ValidateLeagueTeams();
    }

    private void ShowAll()
    {
        RefreshLists();
        _viewMode = ViewMode.All;
    }

    private void ShowConferences()
    {
        RefreshLists();
        _viewMode = ViewMode.ByConference;
    }

    private void ShowDivisions()
    {
        RefreshLists();
        _viewMode = ViewMode.ByDivision;
    }

    private void ValidateLeagueTeams()
    {
        if (Teams.Count() == 32) _teamsEqual32 = true;
        var validConferences = true;
        if (_afcTeams.Count() != 16) validConferences |= false;
        if (_nfcTeams.Count() != 16) validConferences = false;
        _validConfs = validConferences;
        var validDivisions = true;
        if (_afcNorth.Count() != 4) validDivisions |= false;
        if (_afcSouth.Count() != 4) validDivisions |= false;
        if (_afcEast.Count() != 4) validDivisions |= false;
        if (_afcWest.Count() != 4) validDivisions |= false;
        if (_nfcNorth.Count() != 4) validDivisions |= false;
        if (_nfcSouth.Count() != 4) validDivisions |= false;
        if (_nfcEast.Count() != 4) validDivisions |= false;
        if (_nfcWest.Count() != 4) validDivisions |= false;
        _validDivs = validDivisions;
    }

    private void CreateDivisionLists()
    {
        _afcTeams = (from t in Teams
                    where t.Conference == Conference.AFC
                    select t).ToList();
        _nfcTeams = (from t in Teams
                    where t.Conference == Conference.NFC
                    select t).ToList();
        _afcNorth = (from t in Teams
                    where t.Conference == Conference.AFC
                    && t.Region == Region.North
                    select t).ToList();
        _afcSouth = (from t in Teams
                    where t.Conference == Conference.AFC
                    && t.Region == Region.South
                    select t).ToList();
        _afcEast = (from t in Teams
                   where t.Conference == Conference.AFC
                   && t.Region == Region.East
                   select t).ToList();
        _afcWest = (from t in Teams
                   where t.Conference == Conference.AFC
                   && t.Region == Region.West
                   select t).ToList();
        _nfcNorth = (from t in Teams
                    where t.Conference == Conference.NFC
                    && t.Region == Region.North
                    select t).ToList();
        _nfcSouth = (from t in Teams
                    where t.Conference == Conference.NFC
                    && t.Region == Region.South
                    select t).ToList();
        _nfcEast = (from t in Teams
                   where t.Conference == Conference.NFC
                   && t.Region == Region.East
                   select t).ToList();
        _nfcWest = (from t in Teams
                   where t.Conference == Conference.NFC
                   && t.Region == Region.West
                   select t).ToList();
    }
}
