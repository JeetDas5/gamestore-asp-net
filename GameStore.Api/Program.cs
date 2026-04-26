using GameStore.Api.Dtos;
const string GetGameEndpointName = "GetGameById";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = new List<GameDto>
{
    new GameDto(1, "The Legend of Zelda: Breath of the Wild", "Action-Adventure", 59.99m, new DateOnly(2017, 3, 3)),
    new GameDto(2, "God of War", "Action-Adventure", 49.99m, new DateOnly(2018, 4, 20)),
    new GameDto(3, "Red Dead Redemption 2", "Action-Adventure", 59.99m, new DateOnly(2018, 10, 26)),
    new GameDto(4, "The Witcher 3: Wild Hunt", "RPG", 39.99m, new DateOnly(2015, 5, 19)),
    new GameDto(5, "Cyberpunk 2077", "RPG", 59.99m, new DateOnly(2020, 12, 10))
};

app.MapGet("/", () => "Hello World!");

app.MapGet("/games", () => games);


app.MapGet("/games/{id}", (int id) =>
{
    var game = games.Find(g => g.Id == id);

    return game is not null ? Results.Ok(game) : Results.NotFound();
}).WithName(GetGameEndpointName);

app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
       games.Count + 1,
       newGame.Name,
       newGame.Genre,
       newGame.Price,
       newGame.ReleaseDate

    );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapPut("/games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    GameDto game = new(
       id,
       updatedGame.Name,
       updatedGame.Genre,
       updatedGame.Price,
       updatedGame.ReleaseDate

    );

    games[index] = game;

    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) =>
{
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    games.RemoveAt(index);

    return Results.NoContent();
});

app.Run();
