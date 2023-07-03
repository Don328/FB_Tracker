using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes.TurnoverTypes;
public class OnDowns : Turnover
{
    public OnDowns(
        int gameId,
        int driveId,
        int playId)
    : base(
        gameId,
        driveId,
        playId)
        { }
}
