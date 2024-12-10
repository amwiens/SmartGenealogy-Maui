namespace SmartGenealogy.Data.Models;

public class Place
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Latitude { get; set; }

    public int Longitude { get; set; }

    public string Temp { get; set; }
}