using FB_Tracker.Shared.Entities.GameElements;
using FB_Tracker.Shared.Entities.Personnel;
using FB_Tracker.Shared.Enums;

namespace FB_Tracker.Shared.Entities.Teams;
public class Team
{
    public int Id { get; set; }
    public int Season { get; set; }
    public string Locale { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Abrev { get; set; } = string.Empty;
    public Conference Conference { get; set; }
    public Region Region { get; set; }
    public string Division { get => $"{Conference}-{Region}"; }
    //public List<Game> Games { get; set; } = new();
    //public List<Player> Players { get; set; } = new();
}
