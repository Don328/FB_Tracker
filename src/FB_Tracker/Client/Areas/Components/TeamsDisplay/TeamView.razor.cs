using FB_Tracker.Shared.Entities.Teams;
using FB_Tracker.Shared.Enums;
using Microsoft.AspNetCore.Components;

namespace FB_Tracker.Client.Areas.Components.TeamsDisplay;

public partial class TeamView : ComponentBase
{
    [Parameter]
    public Team Team { get; set; }
}
