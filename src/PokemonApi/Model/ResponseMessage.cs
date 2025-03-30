using System.Net;

namespace PokemonApi;

public class ResponseMessage
{
    public HttpStatusCode StatusCode { get; set; }
    public string? StatusMessage { get; set; }
}
