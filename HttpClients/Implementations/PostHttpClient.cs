using System.Net.Http.Json;
using Shared.DTOs;

namespace HttpClients.ClientInterfaces.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;
    
    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task CreateAsync(DTOs.PostCreationDTO dto)
    { 
        HttpResponseMessage response = await client.PostAsJsonAsync("/post",dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}