using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements;
public abstract class Play
{
    public Play(
        int gameId,
        int driveId,
        int offenseId, 
        int defenseId,
        int quarter,
        int prev_playId = 0)
    {
        GameId = gameId;
        DriveId = driveId;
        OffenseId = offenseId;
        DefenseId = defenseId;
        Quarter = quarter;
        PreviousPlayId = prev_playId;
    }

    public int Id { get; set; }
    public int GameId { get; set; }
    public int DriveId { get; set; }
    public int OffenseId { get; set; }
    public int DefenseId { get; set; }
    public int Quarter { get; set; }
    public int PreviousPlayId { get; set; } = 0;
    public int NextPlayId { get; set; } = 0;
    public int Down { get; set; }
    public int Distance { get; set; }
    public int LineOfScrimmage { get; set; }
    public int LineToGain { get; set; }
    public TimeSpan TimeInQuarter { get; set; }
    public bool NoHuddle { get; set; }
    public bool Penalty { get; set; } = false;
    public int PenaltyId { get; set; } = 0;
    public int[] TackledBy { get; set; } = new int[0];
    public bool Turnover { get; set; } = false;
    public int TurnoverId { get; set; } = 0;
    public bool ResultIsFirstDown { get; set; } = false;
    public bool ResultIsTouchdown { get; set; } = false;
    public bool ResultInEndOfHalf { get; set; } = false;
    public bool ResultInEndOfRegulation { get; set; } = false;
    public bool ResultInEndOfGame { get; set; } = false;

}

