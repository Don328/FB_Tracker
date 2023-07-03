namespace FB_Tracker.Server.Data.Models;

public record _Team(
    int Id, 
    int Season,
    string Locale,
    string Name,
    string Abrev,
    int ConferenceIndex,
    int RegionIndex);
