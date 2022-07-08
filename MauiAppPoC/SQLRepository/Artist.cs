using SQLite;

namespace MauiAppPoC.SQLRepository;

[SQLite.Table("artists")]
public class Artist
{
    [PrimaryKey, AutoIncrement]
    public int ArtistId { get; set; }

    public string Name { get; set; } = string.Empty;

}