using FB_Tracker.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements;
public class Game
{
    public int Id { get; set; }
    public int Season { get; set; }
    public int Week { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int StadiumId { get; set; }
    public Weather Weather { get; set; }
    public int Temp_F { get; set; }
    public int Humidity { get; set; }
    public int WindSpeed { get; set; }
    public WindDirection WindDirection { get; set; }
    public int OfficialCrewId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeTeamId { get; set; }

    public List<Drive> Drives { get; set; } = new();
}
