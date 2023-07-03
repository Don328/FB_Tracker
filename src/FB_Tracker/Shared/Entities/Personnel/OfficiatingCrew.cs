using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.Personnel;
public class OfficiatingCrew
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int RefereeId { get; set; }
    public int RefereeExp { get; set; }
    public int UmpireId { get; set; }
    public int UmpireExp { get; set; }
    public int DownJudgeId { get; set; }
    public int DownJudgeExp { get; set; }
    public int LineJudgeId { get; set; }
    public int LineJudgeExp { get; set; }
    public int FieldJudgeId { get; set; }
    public int FieldJudgeExp { get; set; }
    public int SideJudgeId { get; set; }
    public int SideJudgeExp { get; set; }
    public int BackJudgeId { get; set; }
    public int BackJudgeExp { get; set; }
    public int ReplayOfficialId { get; set; }
    public int ReplayOfficialExp { get; set; }
}
