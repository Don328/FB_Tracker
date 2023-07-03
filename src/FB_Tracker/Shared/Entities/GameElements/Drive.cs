using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.GameElements;
public class Drive
{
    public int DriveId { get; set; }
    public int GameId { get; set; }
    public int PreviousDriveId { get; set; } = 0;
    public int NextDriveId { get; set; } = 0;
    public int OffenseId { get; set; }
    public int DefenseId { get; set; }
}
