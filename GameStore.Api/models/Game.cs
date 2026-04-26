using System;

namespace GameStore.Api.models;

public class Game
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public Genre? Genre { get; set; }

    public int GenreId { get; set; }

    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

}
