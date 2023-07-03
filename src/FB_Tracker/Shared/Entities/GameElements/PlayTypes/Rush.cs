using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes;
public class Rush : Play
{
    public Rush(
        int gameId,
        int driveId,
        int offenseId,
        int defenseId,
        int quarter,
        int prev_playId = 0)
    : base(
        gameId,
        driveId,
        offenseId,
        defenseId,
        quarter,
        prev_playId)
    { }

    public int RunnerId { get; set; }
    public int YardsGained { get; set; }
    public bool Shotgun { get; set; }
}
