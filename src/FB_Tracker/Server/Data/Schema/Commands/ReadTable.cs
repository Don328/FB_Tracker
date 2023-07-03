namespace FB_Tracker.Server.Data.Schema.Commands;

internal static class ReadTable
{
    internal static string TeamById => teamById;
    internal static string TeamsBySeason => teamsBySeason;

    private const string teamById =
        @"SELECT
            Id, Season, Locale, Name, 
            Abrev, Conference, Region
        FROM Teams
        WHERE Id=@id";

    private const string teamsBySeason =
        @"SELECT
            Id, Season, Locale, Name,
            Abrev, Conference, Region
        FROM Teams
        Where Season=@season";

}
