namespace PokemonApi;

using System.Net.Http;

public class PokiApiClient
{
    private static readonly string uriBasePokiApi = "https://pokeapi.co/api/v2/pokemon";
    private static HttpClient httpClient = new HttpClient();

    public static async Task GetPokemon(string searchParam)
    {
        httpClient.BaseAddress = new Uri(uriBasePokiApi);
        string requestUri = uriBasePokiApi + "/" + searchParam;
        using HttpResponseMessage response = await httpClient.GetAsync(requestUri);

        var teste = response.StatusCode == System.Net.HttpStatusCode.OK;
        response.EnsureSuccessStatusCode();
        Console.WriteLine(response.Content);

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);
    }
}
