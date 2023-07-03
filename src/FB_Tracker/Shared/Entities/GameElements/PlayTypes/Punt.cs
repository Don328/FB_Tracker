using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes;
public class Punt : Play
{
    public Punt(
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

    public int PunterId { get; set; }
    public int ReturnerId { get; set; }
    public int PuntCaughtAt { get; set; }
    public int ReturnYards { get; set; }
    public int DownAt { get; set; }
    public bool FairCatch { get; set; }
    public bool Touchback { get; set; }
    public int[] Tacklers { get; set; } = new int[0];
}
