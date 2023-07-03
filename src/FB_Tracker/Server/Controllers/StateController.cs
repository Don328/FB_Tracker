using FB_Tracker.Server.Data;
using FB_Tracker.Shared.Entities.Teams;
using Microsoft.AspNetCore.Mvc;

namespace FB_Tracker.Server.Controllers;

[ApiController]
[Route("state")]
public class StateController : Controller
{
    private readonly AppState state;
    private readonly FBTDataContext db;

    public StateController(
        AppState state,
        FBTDataContext db)
    {
        this.state = state;
        this.db = db;
    }

    [HttpGet("season")]
    public async Task<ActionResult<int>>
        GetSelectedSeason() =>
        await Task.FromResult(state.SelectedSeason ?? 0);

    [HttpPost("season")]
    public async Task<IActionResult>
        SelectSeason([FromBody] int season)
    {
        state.SelectedSeason = season;

        // Get Teams for selected season and load into state
        await LoadSeasonTeams();
        // Check that 32 teams are present
        // Check that 4ea teams for each div are present
        // Handle failure by requiring correction/addition of teams
        // list is empty: chk for teams from prev yr
        // prev yr is empty: Require team data imput


        return await Task.FromResult(
            CreatedAtAction(nameof(GetSelectedSeason),
            new { season = state.SelectedSeason }));
    }

    [HttpGet("teams")]
    public async Task<ActionResult<IEnumerable<Team>>>
        GetSeasonTeams()
    {
        return await Task.FromResult(
            state.Teams.ToList());
    }

    private async Task LoadSeasonTeams()
    {
        await db.RefreshTeamsList();
        state.Teams = db.Teams;
        if (db.Teams.Count() == 32) state.TeamsLoaded = true;
    }

    [HttpGet("import-teams")]
    public async Task<ActionResult> ImportPreviousSeasonTeams()
    {
        await db.ImportTeams();

        return await Task.FromResult(StatusCode(200));
    }
}
