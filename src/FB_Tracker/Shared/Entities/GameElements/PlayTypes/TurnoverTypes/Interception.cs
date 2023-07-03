using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes.TurnoverTypes;
internal class Interception : Turnover
{
    public Interception(
        int gameId,
        int driveId,
        int playId)
    : base(
        gameId,
        driveId,
        playId)
        { }

    public int InterceptedBy_PlayerId { get; set; }
    public int IntendedRecieverId { get; set; }
    public int PasserId { get; set; }
    public int InterceptedOn { get; set; }
    public int DownOn { get; set; }
    public bool PicSix { get; set; }
}
