using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes.TurnoverTypes;
public class Fumble : Turnover
{
    public Fumble(
        int gameId,
        int driveId,
        int playId)
    : base(
        gameId,
        driveId,
        playId)
    { }

    public int CausedBy_PlayerId { get; set; }
    public int RecoverdBy_PlayerId { get; set; }
    public int Fumbling_PlayerId { get; set; }
    public bool ChangeOfPossession { get; set; } = true;
    public int FumbledAt { get; set; }
    public int RecoverdAt { get; set; }
    public int DownAt { get; set; }
}
