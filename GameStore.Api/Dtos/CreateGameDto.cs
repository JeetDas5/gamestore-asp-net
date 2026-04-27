using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
    [Required][StringLength(50)] string Name,
    // [Required][StringLength(50)] string Genre,
    [Required][Range(1, 50)] int GenreId,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
);
