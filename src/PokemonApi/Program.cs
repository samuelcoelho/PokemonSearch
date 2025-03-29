using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using PokemonApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("GetPokemon/{nameOrId}", async (string nameOrId) =>
{
    var pokemon = await PokiApiClient.GetPokemon(nameOrId);

    return pokemon;
})
.WithName("GetPokemon")
.WithSummary("Get one Pokemon by Name or ID")
.WithOpenApi();

app.MapGet("GetPokemonPaginated", async (int? limit, int? offset) =>
{
    var pokemonList = await PokiApiClient.GetPokemonPaginated(limit, offset);

    return pokemonList;
})
.WithName("GetPokemonPaginated")
.WithSummary("Get a paginated list of Pokemons, limit and offset are not required. Default limit value is 20")
.WithOpenApi();

app.Run();
