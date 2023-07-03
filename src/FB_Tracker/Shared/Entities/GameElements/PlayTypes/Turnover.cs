using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements.PlayTypes;
public abstract class Turnover
{
    public Turnover(
        int gameId,
        int driveId,
        int playId)
    {
        GameId = gameId;
        DriveId = driveId;
        PlayId = playId;
    }

    public int Id { get; set; }
    public int GameId { get; set; }
    public int DriveId { get; set; }
    public int PlayId { get; set; }
}
