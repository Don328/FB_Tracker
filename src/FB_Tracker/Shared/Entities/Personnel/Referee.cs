using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB_Tracker.Shared.Entities.Personnel;
public class Referee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public char MiddleInitial { get; set; }
    public string LastName { get; set; } = string.Empty;
}
