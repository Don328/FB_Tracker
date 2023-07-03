using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes;
public class Pass : Play
{
    public Pass(
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

    public int PasserId { get; set; }
    public bool Shotgun { get; set; }
    public int RecieverId { get; set; }
    public bool Completed { get; set; }
    public int DefenderId { get; set; }
}
