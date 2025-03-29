namespace PokemonApi;

using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class PokiApiClient
{
    private static readonly string uriBasePokiApi = "https://pokeapi.co/api/v2/pokemon";
    private static readonly HttpClient httpClient = new()
    {
        BaseAddress = new Uri(uriBasePokiApi)
    };

    public static async Task<Pokemon?> GetPokemon(string searchParam)
    {
        Pokemon? pokemon = new();

        try
        {
            string requestUri = $"{uriBasePokiApi}/{searchParam}";
            using HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var pokemonResponse = response.Content.ReadFromJsonAsync<Pokemon>().Result;
            pokemon = pokemonResponse;
        }
        catch (System.Exception)
        {
            throw;
        }

        return pokemon;
    }

    public static async Task<PokemonPaginated?> GetPokemonPaginated(int? limit, int? offset)
    {
        PokemonPaginated? pokemonPaginated = new();

        try
        {
            string requestUri = uriBasePokiApi + "?";
            string concatParam = "";
            if (limit != null)
            {
                requestUri = $"{requestUri}limit={limit}";
                concatParam = "&";
            }
            
            if (offset != null)
            {
                requestUri = $"{requestUri}{concatParam}offset={offset}";
            }

            using HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var pokemonResponse = response.Content.ReadFromJsonAsync<PokemonPaginated>().Result;
            pokemonPaginated = pokemonResponse;
        }
        catch (System.Exception)
        {
            throw;
        }

        return pokemonPaginated;
    }
}
