using Microsoft.AspNetCore.Components;

namespace FB_Tracker.Client.Areas.Components.SeasonSelect;

public partial class SeasonSelect : ComponentBase
{
    [Parameter]
    public SeasonSelectModel Model { get; set; } = new();

    [Parameter]
    public EventCallback<int?> OnSeasonSelected { get; set; }

    [Parameter]
    public EventCallback OnCancel { get; set; }

    private async Task SelectSeason()
    {
        await OnSeasonSelected.InvokeAsync(Model.Season);
    }

    private async Task Cancel()
    {
        await OnCancel.InvokeAsync();
    }
}
